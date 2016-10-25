using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using OneCoin.Service.Helper.Log;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Dal.Core
{   
    /// <summary>
    /// 事务上下文
    /// </summary>
    public class TransactionContext
    {
        public MySqlConnection Connection { get; internal set; }

        public MySqlTransaction Transaction { get; internal set; } 
    }
     
    /// <summary>
    /// 事务管理器
    /// </summary>
    public static class TransactionManager
    {


        //最大缓存数
        const int MulitContextMapMax = 100;

        //事务缓存
        private static readonly  Dictionary<int,ConcurrentDictionary<int, TransactionContext>> MulitContextMap = new Dictionary<int, ConcurrentDictionary<int, TransactionContext>>();

        private static string _connectionString;

        //初始化
        static TransactionManager()
        {
            Init(DalBase.DcString);

            for (int i = 0; i < MulitContextMapMax; i++)
            {
                MulitContextMap[i] = new ConcurrentDictionary<int, TransactionContext>();
            }
        }


        private static  ConcurrentDictionary<int, TransactionContext>  ContextMap
        {
            get
            {
                var hash = Math.Abs(Thread.CurrentThread.ManagedThreadId) % MulitContextMapMax;
                return MulitContextMap[hash];
            }
        }

        /// <summary>
        /// 初始化事务管理器
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        internal static void Init(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// 获取当前上下文，如果没有当前上下文，则创建新的上下文
        /// </summary>
        /// <returns>当前上下文</returns>
        private static TransactionContext GetCurrentContext()
        {
            TransactionContext context;
            var cm = ContextMap;


            if (!cm.TryGetValue(Thread.CurrentThread.ManagedThreadId, out  context))
            {
                context = new TransactionContext { Connection = new MySqlConnection(_connectionString) };
                context.Connection.Open();
                context.Transaction = context.Connection.BeginTransaction();

                cm.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, context, (key, oldValue) => { return context; });
            }

            
            return context;
        }

        /// <summary>
        /// 获取当前连接，如果没有当前上下文，则打开新的连接并开启事务
        /// </summary>
        /// <returns>当前上下文中的数据库连接</returns>
        public static MySqlConnection GetCurrentConnection()
        {
            return GetCurrentContext().Connection;
        }


        #region Commit &  Rollback
        /// <summary>
        /// 提交当前事务
        /// </summary>
        public static void Commit()
        {
            var cm = ContextMap;

            if (!cm.ContainsKey(Thread.CurrentThread.ManagedThreadId)) return;

            try
            {
                var context = cm[Thread.CurrentThread.ManagedThreadId];
                try
                {
                    context.Transaction.Commit();
                    context.Connection.Close(); 
                }
                catch (Exception ex)
                {
                    LogHelper.Add("数据库事务提交异常", ex);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Add("数据库事务提交异常之后内存回滚异常", ex);
            }
            finally
            {
                TransactionContext old;
                cm.TryRemove(Thread.CurrentThread.ManagedThreadId, out old);
            }
        }

        /// <summary>
        /// 回滚当前事务
        /// </summary>
        public static void Rollback()
        {
            var cm = ContextMap;

            if (!cm.ContainsKey(Thread.CurrentThread.ManagedThreadId)) return;

            TransactionContext context = cm[Thread.CurrentThread.ManagedThreadId];

            // HACK 这里的实现相当不好，暂时用着，因为底层的数据库框架会在出错的时候直接关闭链接
            if (context.Connection.State != ConnectionState.Closed && context.Connection.State != ConnectionState.Broken)
            {
                try
                {
                    context.Transaction.Rollback();
                    context.Connection.Close();
                }
                catch (Exception ex)
                {
                    LogHelper.Add("数据库事务回滚异常", ex);
                }
                finally
                {
                    TransactionContext old;
                    cm.TryRemove(Thread.CurrentThread.ManagedThreadId, out old);
                }
            } 
        }
        #endregion 
    }
}

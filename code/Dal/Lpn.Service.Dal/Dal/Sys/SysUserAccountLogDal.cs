using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述:[sys_user_account_log]E泊帐户日志 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    /// [sys_user_account_log]E泊帐户日志 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysUserAccountLogDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from sysuseraccountlog;";
        //新增插入语句
        protected const string SqlInsert = "insert into sysuseraccountlog(`LogID`,`UserID`,`Money`,`BalanceMoney`,`OperationType`,`Sign`,`Memo`,`OperateTime`,`OperatorID`,`OrderNo`) values(?LogID,?UserID,?Money,?BalanceMoney,?OperationType,?Sign,?Memo,?OperateTime,?OperatorID,?OrderNo);";
        #endregion

        #region 参数
        protected const string ParamLogID = "?LogID";
        protected const string ParamUserID = "?UserID";
        protected const string ParamMoney = "?Money";
        protected const string ParamBalanceMoney = "?BalanceMoney";
        protected const string ParamOperationType = "?OperationType";
        protected const string ParamSign = "?Sign";
        protected const string ParamMemo = "?Memo";
        protected const string ParamOperateTime = "?OperateTime";
        protected const string ParamOperatorID = "?OperatorID";
        protected const string ParamOrderNo = "?OrderNo";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysUserAccountLogDb</returns>
        public static List<SysUserAccountLogDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sysuseraccountlog">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysUserAccountLogDb sysuseraccountlog)
        {
            var param= GetInsertParams(sysuseraccountlog);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysUserAccountLogDb sysuseraccountlog)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamLogID,sysuseraccountlog.LogID),
                    new MySqlParameter(ParamUserID,sysuseraccountlog.UserID),
                    new MySqlParameter(ParamMoney,sysuseraccountlog.Money),
                    new MySqlParameter(ParamBalanceMoney,sysuseraccountlog.BalanceMoney),
                    new MySqlParameter(ParamOperationType,sysuseraccountlog.OperationType),
                    new MySqlParameter(ParamSign,sysuseraccountlog.Sign),
                    new MySqlParameter(ParamMemo,sysuseraccountlog.Memo),
                    new MySqlParameter(ParamOperateTime,sysuseraccountlog.OperateTime),
                    new MySqlParameter(ParamOperatorID,sysuseraccountlog.OperatorID),
                    new MySqlParameter(ParamOrderNo,sysuseraccountlog.OrderNo)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysUserAccountLogDb</returns>
        public static SysUserAccountLogDb  ConvertToObject(DataRow dr)
        {
            var data = new SysUserAccountLogDb
                {
                    LogID = DbChange.ToLong(dr["LogID"],0),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    Money = DbChange.ToDecimal(dr["Money"],0),
                    BalanceMoney = DbChange.ToDecimal(dr["BalanceMoney"],0),
                    OperationType = DbChange.ToInt(dr["OperationType"],0),
                    Sign = DbChange.ToString(dr["Sign"]),
                    Memo = DbChange.ToString(dr["Memo"]),
                    OperateTime = DbChange.ToDateTime(dr["OperateTime"],DateTime.MinValue),
                    OperatorID = DbChange.ToInt(dr["OperatorID"],0),
                    OrderNo = DbChange.ToString(dr["OrderNo"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysUserAccountLogDb</returns>
        public static List<SysUserAccountLogDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysUserAccountLogDb>(); 
            if (null != dt && dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    datas.Add(ConvertToObject(dt.Rows[i]));
                }
            }

            return datas;
        }
        #endregion

     }
}

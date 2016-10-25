﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.User;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.User
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class UserDiamondLogDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from user_diamond_log;";
        //新增插入语句
        protected const string SqlInsert = "insert into user_diamond_log(`UId`,`Amount`,`AfterAmount`,`ClientIp`,`RowTime`,`RefOrderNo`) values(?UId,?Amount,?AfterAmount,?ClientIp,?RowTime,?RefOrderNo);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from user_diamond_log where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update user_diamond_log set `UId`=?UId,`Amount`=?Amount,`AfterAmount`=?AfterAmount,`ClientIp`=?ClientIp,`RowTime`=?RowTime,`RefOrderNo`=?RefOrderNo where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from user_diamond_log  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamUId = "?UId";
        protected const string ParamAmount = "?Amount";
        protected const string ParamAfterAmount = "?AfterAmount";
        protected const string ParamClientIp = "?ClientIp";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamRefOrderNo = "?RefOrderNo";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of UserDiamondLogDb</returns>
        public static List<UserDiamondLogDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="userdiamondlog">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(UserDiamondLogDb userdiamondlog)
        {
            var param= GetInsertParams(userdiamondlog);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>UserDiamondLogDb</returns>
        public static UserDiamondLogDb  GetByPriKey(long id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByPriKey,param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion

        #region 根据主键更新查询数据
        /// <summary>
        /// 根据主键更新查询数据
        /// </summary>
        /// <param name="userdiamondlog">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(UserDiamondLogDb userdiamondlog)
        {
            var param= GetUpdateParams(userdiamondlog);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(long id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(UserDiamondLogDb userdiamondlog)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,userdiamondlog.Id),
                    new MySqlParameter(ParamUId,userdiamondlog.UId),
                    new MySqlParameter(ParamAmount,userdiamondlog.Amount),
                    new MySqlParameter(ParamAfterAmount,userdiamondlog.AfterAmount),
                    new MySqlParameter(ParamClientIp,userdiamondlog.ClientIp),
                    new MySqlParameter(ParamRowTime,userdiamondlog.RowTime),
                    new MySqlParameter(ParamRefOrderNo,userdiamondlog.RefOrderNo)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(UserDiamondLogDb userdiamondlog)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUId,userdiamondlog.UId),
                    new MySqlParameter(ParamAmount,userdiamondlog.Amount),
                    new MySqlParameter(ParamAfterAmount,userdiamondlog.AfterAmount),
                    new MySqlParameter(ParamClientIp,userdiamondlog.ClientIp),
                    new MySqlParameter(ParamRowTime,userdiamondlog.RowTime),
                    new MySqlParameter(ParamRefOrderNo,userdiamondlog.RefOrderNo)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>UserDiamondLogDb</returns>
        public static UserDiamondLogDb  ConvertToObject(DataRow dr)
        {
            var data = new UserDiamondLogDb
                {
                    Id = DbChange.ToLong(dr["Id"],0),
                    UId = DbChange.ToString(dr["UId"]),
                    Amount = DbChange.ToInt(dr["Amount"],0),
                    AfterAmount = DbChange.ToInt(dr["AfterAmount"],0),
                    ClientIp = DbChange.ToString(dr["ClientIp"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    RefOrderNo = DbChange.ToString(dr["RefOrderNo"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of UserDiamondLogDb</returns>
        public static List<UserDiamondLogDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<UserDiamondLogDb>(); 
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

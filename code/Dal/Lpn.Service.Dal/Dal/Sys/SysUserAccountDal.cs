using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述:[sys_user_account]E泊帐户表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    /// [sys_user_account]E泊帐户表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysUserAccountDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from sysuseraccount;";
        //新增插入语句
        protected const string SqlInsert = "insert into sysuseraccount(`UserID`,`BalanceMoney`,`Sign`,`Memo`,`OperateTime`,`OperatorID`) values(?UserID,?BalanceMoney,?Sign,?Memo,?OperateTime,?OperatorID);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from sysuseraccount where `UserID`=?UserID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update sysuseraccount set `BalanceMoney`=?BalanceMoney,`Sign`=?Sign,`Memo`=?Memo,`OperateTime`=?OperateTime,`OperatorID`=?OperatorID where `UserID`=?UserID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from sysuseraccount  where `UserID`=?UserID;";
        #endregion

        #region 参数
        protected const string ParamUserID = "?UserID";
        protected const string ParamBalanceMoney = "?BalanceMoney";
        protected const string ParamSign = "?Sign";
        protected const string ParamMemo = "?Memo";
        protected const string ParamOperateTime = "?OperateTime";
        protected const string ParamOperatorID = "?OperatorID";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysUserAccountDb</returns>
        public static List<SysUserAccountDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sysuseraccount">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysUserAccountDb sysuseraccount)
        {
            var param= GetInsertParams(sysuseraccount);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="userID">用户编号</param> 
        /// <returns>SysUserAccountDb</returns>
        public static SysUserAccountDb  GetByPriKey(int userID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserID,userID)
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
        /// <param name="sysuseraccount">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SysUserAccountDb sysuseraccount)
        {
            var param= GetUpdateParams(sysuseraccount);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="userID">用户编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int userID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserID,userID)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(SysUserAccountDb sysuseraccount)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserID,sysuseraccount.UserID),
                    new MySqlParameter(ParamBalanceMoney,sysuseraccount.BalanceMoney),
                    new MySqlParameter(ParamSign,sysuseraccount.Sign),
                    new MySqlParameter(ParamMemo,sysuseraccount.Memo),
                    new MySqlParameter(ParamOperateTime,sysuseraccount.OperateTime),
                    new MySqlParameter(ParamOperatorID,sysuseraccount.OperatorID)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysUserAccountDb sysuseraccount)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserID,sysuseraccount.UserID),
                    new MySqlParameter(ParamBalanceMoney,sysuseraccount.BalanceMoney),
                    new MySqlParameter(ParamSign,sysuseraccount.Sign),
                    new MySqlParameter(ParamMemo,sysuseraccount.Memo),
                    new MySqlParameter(ParamOperateTime,sysuseraccount.OperateTime),
                    new MySqlParameter(ParamOperatorID,sysuseraccount.OperatorID)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysUserAccountDb</returns>
        public static SysUserAccountDb  ConvertToObject(DataRow dr)
        {
            var data = new SysUserAccountDb
                {
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    BalanceMoney = DbChange.ToDecimal(dr["BalanceMoney"],0),
                    Sign = DbChange.ToString(dr["Sign"]),
                    Memo = DbChange.ToString(dr["Memo"]),
                    OperateTime = DbChange.ToDateTime(dr["OperateTime"],DateTime.MinValue),
                    OperatorID = DbChange.ToInt(dr["OperatorID"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysUserAccountDb</returns>
        public static List<SysUserAccountDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysUserAccountDb>(); 
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

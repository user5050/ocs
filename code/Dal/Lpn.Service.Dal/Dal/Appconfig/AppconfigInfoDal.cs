using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Appconfig;

/*
* 由自动生成工具完成
* 描述:[appconfig_info]用户配置 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Appconfig
{
    /// <summary>
    /// [appconfig_info]用户配置 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class AppconfigInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from appconfiginfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into appconfiginfo(`Class`,`UserID`,`Key`,`Value`) values(?Class,?UserID,?Key,?Value);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from appconfiginfo where `Class`=?Class and `UserID`=?UserID and `Key`=?Key;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update appconfiginfo set `Value`=?Value where `Class`=?Class and `UserID`=?UserID and `Key`=?Key;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from appconfiginfo  where `Class`=?Class and `UserID`=?UserID and `Key`=?Key;";
        #endregion

        #region 参数
        protected const string ParamClass = "?Class";
        protected const string ParamUserID = "?UserID";
        protected const string ParamKey = "?Key";
        protected const string ParamValue = "?Value";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of AppconfigInfoDb</returns>
        public static List<AppconfigInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="appconfiginfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(AppconfigInfoDb appconfiginfo)
        {
            var param= GetInsertParams(appconfiginfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="class1">分类</param> 
        /// <param name="userID">用户编号</param> 
        /// <param name="key">键</param> 
        /// <returns>AppconfigInfoDb</returns>
        public static AppconfigInfoDb  GetByPriKey(string class1,int userID,string key)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamClass,class1),
                    new MySqlParameter(ParamUserID,userID),
                    new MySqlParameter(ParamKey,key)
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
        /// <param name="appconfiginfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(AppconfigInfoDb appconfiginfo)
        {
            var param= GetUpdateParams(appconfiginfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="class1">分类</param> 
        /// <param name="userID">用户编号</param> 
        /// <param name="key">键</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string class1,int userID,string key)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamClass,class1),
                    new MySqlParameter(ParamUserID,userID),
                    new MySqlParameter(ParamKey,key)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(AppconfigInfoDb appconfiginfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamClass,appconfiginfo.Class),
                    new MySqlParameter(ParamUserID,appconfiginfo.UserID),
                    new MySqlParameter(ParamKey,appconfiginfo.Key),
                    new MySqlParameter(ParamValue,appconfiginfo.Value)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(AppconfigInfoDb appconfiginfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamClass,appconfiginfo.Class),
                    new MySqlParameter(ParamUserID,appconfiginfo.UserID),
                    new MySqlParameter(ParamKey,appconfiginfo.Key),
                    new MySqlParameter(ParamValue,appconfiginfo.Value)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>AppconfigInfoDb</returns>
        public static AppconfigInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new AppconfigInfoDb
                {
                    Class = DbChange.ToString(dr["Class"]),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    Key = DbChange.ToString(dr["Key"]),
                    Value = DbChange.ToString(dr["Value"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of AppconfigInfoDb</returns>
        public static List<AppconfigInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<AppconfigInfoDb>(); 
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

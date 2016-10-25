using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述:[sys_key]密钥信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    /// [sys_key]密钥信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysKeyDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from syskey;";
        //新增插入语句
        protected const string SqlInsert = "insert into syskey(`UserName`,`PublicKey`,`PrivateKey`) values(?UserName,?PublicKey,?PrivateKey);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from syskey where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update syskey set `UserName`=?UserName,`PublicKey`=?PublicKey,`PrivateKey`=?PrivateKey where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from syskey  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamUserName = "?UserName";
        protected const string ParamPublicKey = "?PublicKey";
        protected const string ParamPrivateKey = "?PrivateKey";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysKeyDb</returns>
        public static List<SysKeyDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="syskey">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysKeyDb syskey)
        {
            var param= GetInsertParams(syskey);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">密钥编号</param> 
        /// <returns>SysKeyDb</returns>
        public static SysKeyDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
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
        /// <param name="syskey">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SysKeyDb syskey)
        {
            var param= GetUpdateParams(syskey);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">密钥编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(SysKeyDb syskey)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,syskey.ID),
                    new MySqlParameter(ParamUserName,syskey.UserName),
                    new MySqlParameter(ParamPublicKey,syskey.PublicKey),
                    new MySqlParameter(ParamPrivateKey,syskey.PrivateKey)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysKeyDb syskey)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserName,syskey.UserName),
                    new MySqlParameter(ParamPublicKey,syskey.PublicKey),
                    new MySqlParameter(ParamPrivateKey,syskey.PrivateKey)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysKeyDb</returns>
        public static SysKeyDb  ConvertToObject(DataRow dr)
        {
            var data = new SysKeyDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    UserName = DbChange.ToString(dr["UserName"]),
                    PublicKey = DbChange.ToString(dr["PublicKey"]),
                    PrivateKey = DbChange.ToString(dr["PrivateKey"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysKeyDb</returns>
        public static List<SysKeyDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysKeyDb>(); 
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

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述:[sys_item_code]字典信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    /// [sys_item_code]字典信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysItemCodeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from sysitemcode;";
        //新增插入语句
        protected const string SqlInsert = "insert into sysitemcode(`Sort`,`Key`,`Value`,`Des`) values(?Sort,?Key,?Value,?Des);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from sysitemcode where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update sysitemcode set `Sort`=?Sort,`Key`=?Key,`Value`=?Value,`Des`=?Des where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from sysitemcode  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamSort = "?Sort";
        protected const string ParamKey = "?Key";
        protected const string ParamValue = "?Value";
        protected const string ParamDes = "?Des";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysItemCodeDb</returns>
        public static List<SysItemCodeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sysitemcode">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysItemCodeDb sysitemcode)
        {
            var param= GetInsertParams(sysitemcode);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">字典编号</param> 
        /// <returns>SysItemCodeDb</returns>
        public static SysItemCodeDb  GetByPriKey(int id)
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
        /// <param name="sysitemcode">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SysItemCodeDb sysitemcode)
        {
            var param= GetUpdateParams(sysitemcode);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">字典编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(SysItemCodeDb sysitemcode)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,sysitemcode.ID),
                    new MySqlParameter(ParamSort,sysitemcode.Sort),
                    new MySqlParameter(ParamKey,sysitemcode.Key),
                    new MySqlParameter(ParamValue,sysitemcode.Value),
                    new MySqlParameter(ParamDes,sysitemcode.Des)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysItemCodeDb sysitemcode)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSort,sysitemcode.Sort),
                    new MySqlParameter(ParamKey,sysitemcode.Key),
                    new MySqlParameter(ParamValue,sysitemcode.Value),
                    new MySqlParameter(ParamDes,sysitemcode.Des)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysItemCodeDb</returns>
        public static SysItemCodeDb  ConvertToObject(DataRow dr)
        {
            var data = new SysItemCodeDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    Sort = DbChange.ToString(dr["Sort"]),
                    Key = DbChange.ToString(dr["Key"]),
                    Value = DbChange.ToString(dr["Value"]),
                    Des = DbChange.ToString(dr["Des"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysItemCodeDb</returns>
        public static List<SysItemCodeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysItemCodeDb>(); 
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

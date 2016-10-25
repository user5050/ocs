using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述:[sys_version_resource] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    /// [sys_version_resource] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysVersionResourceDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from sysversionresource;";
        //新增插入语句
        protected const string SqlInsert = "insert into sysversionresource(`Id`,`Url`,`Hash`,`RowTime`,`OperatorName`,`Remark`) values(?Id,?Url,?Hash,?RowTime,?OperatorName,?Remark);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from sysversionresource where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update sysversionresource set `Url`=?Url,`Hash`=?Hash,`RowTime`=?RowTime,`OperatorName`=?OperatorName,`Remark`=?Remark where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from sysversionresource  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamUrl = "?Url";
        protected const string ParamHash = "?Hash";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamOperatorName = "?OperatorName";
        protected const string ParamRemark = "?Remark";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysVersionResourceDb</returns>
        public static List<SysVersionResourceDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sysversionresource">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysVersionResourceDb sysversionresource)
        {
            var param= GetInsertParams(sysversionresource);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">版本号</param> 
        /// <returns>SysVersionResourceDb</returns>
        public static SysVersionResourceDb  GetByPriKey(string id)
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
        /// <param name="sysversionresource">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SysVersionResourceDb sysversionresource)
        {
            var param= GetUpdateParams(sysversionresource);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">版本号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string id)
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
        public static MySqlParameter[]  GetUpdateParams(SysVersionResourceDb sysversionresource)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,sysversionresource.Id),
                    new MySqlParameter(ParamUrl,sysversionresource.Url),
                    new MySqlParameter(ParamHash,sysversionresource.Hash),
                    new MySqlParameter(ParamRowTime,sysversionresource.RowTime),
                    new MySqlParameter(ParamOperatorName,sysversionresource.OperatorName),
                    new MySqlParameter(ParamRemark,sysversionresource.Remark)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysVersionResourceDb sysversionresource)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,sysversionresource.Id),
                    new MySqlParameter(ParamUrl,sysversionresource.Url),
                    new MySqlParameter(ParamHash,sysversionresource.Hash),
                    new MySqlParameter(ParamRowTime,sysversionresource.RowTime),
                    new MySqlParameter(ParamOperatorName,sysversionresource.OperatorName),
                    new MySqlParameter(ParamRemark,sysversionresource.Remark)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysVersionResourceDb</returns>
        public static SysVersionResourceDb  ConvertToObject(DataRow dr)
        {
            var data = new SysVersionResourceDb
                {
                    Id = DbChange.ToString(dr["Id"]),
                    Url = DbChange.ToString(dr["Url"]),
                    Hash = DbChange.ToString(dr["Hash"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    OperatorName = DbChange.ToString(dr["OperatorName"]),
                    Remark = DbChange.ToString(dr["Remark"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysVersionResourceDb</returns>
        public static List<SysVersionResourceDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysVersionResourceDb>(); 
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

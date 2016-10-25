using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.App;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.App
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class AppVersionDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from app_version;";
        //新增插入语句
        protected const string SqlInsert = "insert into app_version(`Code`,`Des`,`Type`,`DownloadUrl`,`LastOperateTime`) values(?Code,?Des,?Type,?DownloadUrl,?LastOperateTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from app_version where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update app_version set `Code`=?Code,`Des`=?Des,`Type`=?Type,`DownloadUrl`=?DownloadUrl,`LastOperateTime`=?LastOperateTime where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from app_version  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamCode = "?Code";
        protected const string ParamDes = "?Des";
        protected const string ParamType = "?Type";
        protected const string ParamDownloadUrl = "?DownloadUrl";
        protected const string ParamLastOperateTime = "?LastOperateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of AppVersionDb</returns>
        public static List<AppVersionDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="appversion">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(AppVersionDb appversion)
        {
            var param= GetInsertParams(appversion);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">自增编号</param> 
        /// <returns>AppVersionDb</returns>
        public static AppVersionDb  GetByPriKey(int id)
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
        /// <param name="appversion">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(AppVersionDb appversion)
        {
            var param= GetUpdateParams(appversion);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">自增编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(AppVersionDb appversion)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,appversion.ID),
                    new MySqlParameter(ParamCode,appversion.Code),
                    new MySqlParameter(ParamDes,appversion.Des),
                    new MySqlParameter(ParamType,appversion.Type),
                    new MySqlParameter(ParamDownloadUrl,appversion.DownloadUrl),
                    new MySqlParameter(ParamLastOperateTime,appversion.LastOperateTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(AppVersionDb appversion)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCode,appversion.Code),
                    new MySqlParameter(ParamDes,appversion.Des),
                    new MySqlParameter(ParamType,appversion.Type),
                    new MySqlParameter(ParamDownloadUrl,appversion.DownloadUrl),
                    new MySqlParameter(ParamLastOperateTime,appversion.LastOperateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>AppVersionDb</returns>
        public static AppVersionDb  ConvertToObject(DataRow dr)
        {
            var data = new AppVersionDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    Code = DbChange.ToInt(dr["Code"],0),
                    Des = DbChange.ToString(dr["Des"]),
                    Type = DbChange.ToInt(dr["Type"],0),
                    DownloadUrl = DbChange.ToString(dr["DownloadUrl"]),
                    LastOperateTime = DbChange.ToDateTime(dr["LastOperateTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of AppVersionDb</returns>
        public static List<AppVersionDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<AppVersionDb>(); 
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

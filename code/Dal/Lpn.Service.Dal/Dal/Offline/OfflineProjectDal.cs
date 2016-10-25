using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Offline;

/*
* 由自动生成工具完成
* 描述:[offline_project]离线项目管理 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Offline
{
    /// <summary>
    /// [offline_project]离线项目管理 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OfflineProjectDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from offlineproject;";
        //新增插入语句
        protected const string SqlInsert = "insert into offlineproject(`ParkName`,`ProjectCode`,`ProjectName`,`RegisterNo`,`ExpireDate`,`RegisterCode`,`OperatorId`,`Operatetime`,`Projectversion`) values(?ParkName,?ProjectCode,?ProjectName,?RegisterNo,?ExpireDate,?RegisterCode,?OperatorId,?Operatetime,?Projectversion);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from offlineproject where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update offlineproject set `ParkName`=?ParkName,`ProjectCode`=?ProjectCode,`ProjectName`=?ProjectName,`RegisterNo`=?RegisterNo,`ExpireDate`=?ExpireDate,`RegisterCode`=?RegisterCode,`OperatorId`=?OperatorId,`Operatetime`=?Operatetime,`Projectversion`=?Projectversion where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from offlineproject  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkName = "?ParkName";
        protected const string ParamProjectCode = "?ProjectCode";
        protected const string ParamProjectName = "?ProjectName";
        protected const string ParamRegisterNo = "?RegisterNo";
        protected const string ParamExpireDate = "?ExpireDate";
        protected const string ParamRegisterCode = "?RegisterCode";
        protected const string ParamOperatorId = "?OperatorId";
        protected const string ParamOperatetime = "?Operatetime";
        protected const string ParamProjectversion = "?Projectversion";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OfflineProjectDb</returns>
        public static List<OfflineProjectDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="offlineproject">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OfflineProjectDb offlineproject)
        {
            var param= GetInsertParams(offlineproject);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">自增编号</param> 
        /// <returns>OfflineProjectDb</returns>
        public static OfflineProjectDb  GetByPriKey(int id)
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
        /// <param name="offlineproject">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OfflineProjectDb offlineproject)
        {
            var param= GetUpdateParams(offlineproject);
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
        public static MySqlParameter[]  GetUpdateParams(OfflineProjectDb offlineproject)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,offlineproject.ID),
                    new MySqlParameter(ParamParkName,offlineproject.ParkName),
                    new MySqlParameter(ParamProjectCode,offlineproject.ProjectCode),
                    new MySqlParameter(ParamProjectName,offlineproject.ProjectName),
                    new MySqlParameter(ParamRegisterNo,offlineproject.RegisterNo),
                    new MySqlParameter(ParamExpireDate,offlineproject.ExpireDate),
                    new MySqlParameter(ParamRegisterCode,offlineproject.RegisterCode),
                    new MySqlParameter(ParamOperatorId,offlineproject.OperatorId),
                    new MySqlParameter(ParamOperatetime,offlineproject.Operatetime),
                    new MySqlParameter(ParamProjectversion,offlineproject.Projectversion)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OfflineProjectDb offlineproject)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkName,offlineproject.ParkName),
                    new MySqlParameter(ParamProjectCode,offlineproject.ProjectCode),
                    new MySqlParameter(ParamProjectName,offlineproject.ProjectName),
                    new MySqlParameter(ParamRegisterNo,offlineproject.RegisterNo),
                    new MySqlParameter(ParamExpireDate,offlineproject.ExpireDate),
                    new MySqlParameter(ParamRegisterCode,offlineproject.RegisterCode),
                    new MySqlParameter(ParamOperatorId,offlineproject.OperatorId),
                    new MySqlParameter(ParamOperatetime,offlineproject.Operatetime),
                    new MySqlParameter(ParamProjectversion,offlineproject.Projectversion)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OfflineProjectDb</returns>
        public static OfflineProjectDb  ConvertToObject(DataRow dr)
        {
            var data = new OfflineProjectDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkName = DbChange.ToString(dr["ParkName"]),
                    ProjectCode = DbChange.ToString(dr["ProjectCode"]),
                    ProjectName = DbChange.ToString(dr["ProjectName"]),
                    RegisterNo = DbChange.ToString(dr["RegisterNo"]),
                    ExpireDate = DbChange.ToDateTime(dr["ExpireDate"],DateTime.MinValue),
                    RegisterCode = DbChange.ToString(dr["RegisterCode"]),
                    OperatorId = DbChange.ToInt(dr["OperatorId"],0),
                    Operatetime = DbChange.ToDateTime(dr["Operatetime"],DateTime.MinValue),
                    Projectversion = DbChange.ToString(dr["Projectversion"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OfflineProjectDb</returns>
        public static List<OfflineProjectDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OfflineProjectDb>(); 
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

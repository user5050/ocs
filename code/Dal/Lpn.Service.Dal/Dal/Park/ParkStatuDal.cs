using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_status]停车场状态 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_status]停车场状态 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkStatuDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkstatus;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkstatus(`ParkCode`,`Status`,`SystemStatus`,`EventTime`) values(?ParkCode,?Status,?SystemStatus,?EventTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkstatus where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkstatus set `ParkCode`=?ParkCode,`Status`=?Status,`SystemStatus`=?SystemStatus,`EventTime`=?EventTime where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkstatus  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamStatus = "?Status";
        protected const string ParamSystemStatus = "?SystemStatus";
        protected const string ParamEventTime = "?EventTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkStatuDb</returns>
        public static List<ParkStatuDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkstatu">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkStatuDb parkstatu)
        {
            var param= GetInsertParams(parkstatu);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">停车场状态编号</param> 
        /// <returns>ParkStatuDb</returns>
        public static ParkStatuDb  GetByPriKey(int id)
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
        /// <param name="parkstatu">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkStatuDb parkstatu)
        {
            var param= GetUpdateParams(parkstatu);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">停车场状态编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkStatuDb parkstatu)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkstatu.ID),
                    new MySqlParameter(ParamParkCode,parkstatu.ParkCode),
                    new MySqlParameter(ParamStatus,parkstatu.Status),
                    new MySqlParameter(ParamSystemStatus,parkstatu.SystemStatus),
                    new MySqlParameter(ParamEventTime,parkstatu.EventTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkStatuDb parkstatu)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkstatu.ParkCode),
                    new MySqlParameter(ParamStatus,parkstatu.Status),
                    new MySqlParameter(ParamSystemStatus,parkstatu.SystemStatus),
                    new MySqlParameter(ParamEventTime,parkstatu.EventTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkStatuDb</returns>
        public static ParkStatuDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkStatuDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    Status = DbChange.ToInt(dr["Status"],-1),
                    SystemStatus = DbChange.ToInt(dr["SystemStatus"],-1),
                    EventTime = DbChange.ToDateTime(dr["EventTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkStatuDb</returns>
        public static List<ParkStatuDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkStatuDb>(); 
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

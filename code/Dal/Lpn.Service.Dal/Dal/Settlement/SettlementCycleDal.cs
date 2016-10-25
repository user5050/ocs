using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Settlement;

/*
* 由自动生成工具完成
* 描述:[settlement_cycle]结算周期 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Settlement
{
    /// <summary>
    /// [settlement_cycle]结算周期 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SettlementCycleDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from settlementcycle;";
        //新增插入语句
        protected const string SqlInsert = "insert into settlementcycle(`ParkID`,`StartTime`,`EndTime`) values(?ParkID,?StartTime,?EndTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from settlementcycle where `ParkID`=?ParkID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update settlementcycle set `StartTime`=?StartTime,`EndTime`=?EndTime where `ParkID`=?ParkID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from settlementcycle  where `ParkID`=?ParkID;";
        #endregion

        #region 参数
        protected const string ParamParkID = "?ParkID";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamEndTime = "?EndTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SettlementCycleDb</returns>
        public static List<SettlementCycleDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="settlementcycle">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SettlementCycleDb settlementcycle)
        {
            var param= GetInsertParams(settlementcycle);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="parkID">停车场编号</param> 
        /// <returns>SettlementCycleDb</returns>
        public static SettlementCycleDb  GetByPriKey(int parkID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parkID)
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
        /// <param name="settlementcycle">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SettlementCycleDb settlementcycle)
        {
            var param= GetUpdateParams(settlementcycle);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="parkID">停车场编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int parkID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parkID)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(SettlementCycleDb settlementcycle)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,settlementcycle.ParkID),
                    new MySqlParameter(ParamStartTime,settlementcycle.StartTime),
                    new MySqlParameter(ParamEndTime,settlementcycle.EndTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SettlementCycleDb settlementcycle)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,settlementcycle.ParkID),
                    new MySqlParameter(ParamStartTime,settlementcycle.StartTime),
                    new MySqlParameter(ParamEndTime,settlementcycle.EndTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SettlementCycleDb</returns>
        public static SettlementCycleDb  ConvertToObject(DataRow dr)
        {
            var data = new SettlementCycleDb
                {
                    ParkID = DbChange.ToInt(dr["ParkID"],0),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["EndTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SettlementCycleDb</returns>
        public static List<SettlementCycleDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SettlementCycleDb>(); 
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

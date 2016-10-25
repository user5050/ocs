using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Monthly;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Monthly
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class MonthlyTimecarinfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from monthly_timecarinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into monthly_timecarinfo(`ParkCode`,`MonthlySort`,`Starttime`,`Endtime`,`Isholiday`,`MonthFee`,`OverFee`,`ParktotalLot`,`ParkLot`,`UpdateTime`,`IsValid`,`MinNumberOfRenew`) values(?ParkCode,?MonthlySort,?Starttime,?Endtime,?Isholiday,?MonthFee,?OverFee,?ParktotalLot,?ParkLot,?UpdateTime,?IsValid,?MinNumberOfRenew);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from monthly_timecarinfo where `ParkCode`=?ParkCode and `MonthlySort`=?MonthlySort;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update monthly_timecarinfo set `Starttime`=?Starttime,`Endtime`=?Endtime,`Isholiday`=?Isholiday,`MonthFee`=?MonthFee,`OverFee`=?OverFee,`ParktotalLot`=?ParktotalLot,`ParkLot`=?ParkLot,`UpdateTime`=?UpdateTime,`IsValid`=?IsValid,`MinNumberOfRenew`=?MinNumberOfRenew where `ParkCode`=?ParkCode and `MonthlySort`=?MonthlySort;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from monthly_timecarinfo  where `ParkCode`=?ParkCode and `MonthlySort`=?MonthlySort;";
        #endregion

        #region 参数
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamMonthlySort = "?MonthlySort";
        protected const string ParamStarttime = "?Starttime";
        protected const string ParamEndtime = "?Endtime";
        protected const string ParamIsholiday = "?Isholiday";
        protected const string ParamMonthFee = "?MonthFee";
        protected const string ParamOverFee = "?OverFee";
        protected const string ParamParktotalLot = "?ParktotalLot";
        protected const string ParamParkLot = "?ParkLot";
        protected const string ParamUpdateTime = "?UpdateTime";
        protected const string ParamIsValid = "?IsValid";
        protected const string ParamMinNumberOfRenew = "?MinNumberOfRenew";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MonthlyTimecarinfoDb</returns>
        public static List<MonthlyTimecarinfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="monthlytimecarinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MonthlyTimecarinfoDb monthlytimecarinfo)
        {
            var param= GetInsertParams(monthlytimecarinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="parkCode">停车场编码</param> 
        /// <param name="monthlySort">时段模式</param> 
        /// <returns>MonthlyTimecarinfoDb</returns>
        public static MonthlyTimecarinfoDb  GetByPriKey(string parkCode,int monthlySort)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkCode),
                    new MySqlParameter(ParamMonthlySort,monthlySort)
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
        /// <param name="monthlytimecarinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MonthlyTimecarinfoDb monthlytimecarinfo)
        {
            var param= GetUpdateParams(monthlytimecarinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="parkCode">停车场编码</param> 
        /// <param name="monthlySort">时段模式</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string parkCode,int monthlySort)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkCode),
                    new MySqlParameter(ParamMonthlySort,monthlySort)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(MonthlyTimecarinfoDb monthlytimecarinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,monthlytimecarinfo.ParkCode),
                    new MySqlParameter(ParamMonthlySort,monthlytimecarinfo.MonthlySort),
                    new MySqlParameter(ParamStarttime,monthlytimecarinfo.Starttime),
                    new MySqlParameter(ParamEndtime,monthlytimecarinfo.Endtime),
                    new MySqlParameter(ParamIsholiday,monthlytimecarinfo.Isholiday),
                    new MySqlParameter(ParamMonthFee,monthlytimecarinfo.MonthFee),
                    new MySqlParameter(ParamOverFee,monthlytimecarinfo.OverFee),
                    new MySqlParameter(ParamParktotalLot,monthlytimecarinfo.ParktotalLot),
                    new MySqlParameter(ParamParkLot,monthlytimecarinfo.ParkLot),
                    new MySqlParameter(ParamUpdateTime,monthlytimecarinfo.UpdateTime),
                    new MySqlParameter(ParamIsValid,monthlytimecarinfo.IsValid),
                    new MySqlParameter(ParamMinNumberOfRenew,monthlytimecarinfo.MinNumberOfRenew)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MonthlyTimecarinfoDb monthlytimecarinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,monthlytimecarinfo.ParkCode),
                    new MySqlParameter(ParamMonthlySort,monthlytimecarinfo.MonthlySort),
                    new MySqlParameter(ParamStarttime,monthlytimecarinfo.Starttime),
                    new MySqlParameter(ParamEndtime,monthlytimecarinfo.Endtime),
                    new MySqlParameter(ParamIsholiday,monthlytimecarinfo.Isholiday),
                    new MySqlParameter(ParamMonthFee,monthlytimecarinfo.MonthFee),
                    new MySqlParameter(ParamOverFee,monthlytimecarinfo.OverFee),
                    new MySqlParameter(ParamParktotalLot,monthlytimecarinfo.ParktotalLot),
                    new MySqlParameter(ParamParkLot,monthlytimecarinfo.ParkLot),
                    new MySqlParameter(ParamUpdateTime,monthlytimecarinfo.UpdateTime),
                    new MySqlParameter(ParamIsValid,monthlytimecarinfo.IsValid),
                    new MySqlParameter(ParamMinNumberOfRenew,monthlytimecarinfo.MinNumberOfRenew)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MonthlyTimecarinfoDb</returns>
        public static MonthlyTimecarinfoDb  ConvertToObject(DataRow dr)
        {
            var data = new MonthlyTimecarinfoDb
                {
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    MonthlySort = DbChange.ToInt(dr["MonthlySort"],0),
                    Starttime = DbChange.ToString(dr["Starttime"]),
                    Endtime = DbChange.ToString(dr["Endtime"]),
                    Isholiday = DbChange.ToInt(dr["Isholiday"],0),
                    MonthFee = DbChange.ToDouble(dr["MonthFee"],0D),
                    OverFee = DbChange.ToString(dr["OverFee"]),
                    ParktotalLot = DbChange.ToInt(dr["ParktotalLot"],0),
                    ParkLot = DbChange.ToInt(dr["ParkLot"],0),
                    UpdateTime = DbChange.ToDateTime(dr["UpdateTime"],DateTime.MinValue),
                    IsValid = DbChange.ToInt(dr["IsValid"],0),
                    MinNumberOfRenew = DbChange.ToInt(dr["MinNumberOfRenew"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of MonthlyTimecarinfoDb</returns>
        public static List<MonthlyTimecarinfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MonthlyTimecarinfoDb>(); 
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

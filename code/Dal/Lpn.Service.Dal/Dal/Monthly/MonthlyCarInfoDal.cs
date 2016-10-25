using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Monthly;

/*
* 由自动生成工具完成
* 描述:[monthly_car_info]月租车辆信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Monthly
{
    /// <summary>
    /// [monthly_car_info]月租车辆信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class MonthlyCarInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from monthlycarinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into monthlycarinfo(`ParkCode`,`CarNo`,`TillDate`,`SpaceDesc`,`UserID`,`CreatedByApp`,`MonthlySort`,`BalanceMoney`,`IsVip`) values(?ParkCode,?CarNo,?TillDate,?SpaceDesc,?UserID,?CreatedByApp,?MonthlySort,?BalanceMoney,?IsVip);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from monthlycarinfo where `ParkCode`=?ParkCode and `CarNo`=?CarNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update monthlycarinfo set `TillDate`=?TillDate,`SpaceDesc`=?SpaceDesc,`UserID`=?UserID,`CreatedByApp`=?CreatedByApp,`MonthlySort`=?MonthlySort,`BalanceMoney`=?BalanceMoney,`IsVip`=?IsVip where `ParkCode`=?ParkCode and `CarNo`=?CarNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from monthlycarinfo  where `ParkCode`=?ParkCode and `CarNo`=?CarNo;";
        #endregion

        #region 参数
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamTillDate = "?TillDate";
        protected const string ParamSpaceDesc = "?SpaceDesc";
        protected const string ParamUserID = "?UserID";
        protected const string ParamCreatedByApp = "?CreatedByApp";
        protected const string ParamMonthlySort = "?MonthlySort";
        protected const string ParamBalanceMoney = "?BalanceMoney";
        protected const string ParamIsVip = "?IsVip";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MonthlyCarInfoDb</returns>
        public static List<MonthlyCarInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="monthlycarinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MonthlyCarInfoDb monthlycarinfo)
        {
            var param= GetInsertParams(monthlycarinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="parkCode">停车场编码</param> 
        /// <param name="carNo">车牌号</param> 
        /// <returns>MonthlyCarInfoDb</returns>
        public static MonthlyCarInfoDb  GetByPriKey(string parkCode,string carNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkCode),
                    new MySqlParameter(ParamCarNo,carNo)
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
        /// <param name="monthlycarinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MonthlyCarInfoDb monthlycarinfo)
        {
            var param= GetUpdateParams(monthlycarinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="parkCode">停车场编码</param> 
        /// <param name="carNo">车牌号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string parkCode,string carNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkCode),
                    new MySqlParameter(ParamCarNo,carNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(MonthlyCarInfoDb monthlycarinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,monthlycarinfo.ParkCode),
                    new MySqlParameter(ParamCarNo,monthlycarinfo.CarNo),
                    new MySqlParameter(ParamTillDate,monthlycarinfo.TillDate),
                    new MySqlParameter(ParamSpaceDesc,monthlycarinfo.SpaceDesc),
                    new MySqlParameter(ParamUserID,monthlycarinfo.UserID),
                    new MySqlParameter(ParamCreatedByApp,monthlycarinfo.CreatedByApp),
                    new MySqlParameter(ParamMonthlySort,monthlycarinfo.MonthlySort),
                    new MySqlParameter(ParamBalanceMoney,monthlycarinfo.BalanceMoney),
                    new MySqlParameter(ParamIsVip,monthlycarinfo.IsVip)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MonthlyCarInfoDb monthlycarinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,monthlycarinfo.ParkCode),
                    new MySqlParameter(ParamCarNo,monthlycarinfo.CarNo),
                    new MySqlParameter(ParamTillDate,monthlycarinfo.TillDate),
                    new MySqlParameter(ParamSpaceDesc,monthlycarinfo.SpaceDesc),
                    new MySqlParameter(ParamUserID,monthlycarinfo.UserID),
                    new MySqlParameter(ParamCreatedByApp,monthlycarinfo.CreatedByApp),
                    new MySqlParameter(ParamMonthlySort,monthlycarinfo.MonthlySort),
                    new MySqlParameter(ParamBalanceMoney,monthlycarinfo.BalanceMoney),
                    new MySqlParameter(ParamIsVip,monthlycarinfo.IsVip)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MonthlyCarInfoDb</returns>
        public static MonthlyCarInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new MonthlyCarInfoDb
                {
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    TillDate = DbChange.ToDateTime(dr["TillDate"],DateTime.MinValue),
                    SpaceDesc = DbChange.ToString(dr["SpaceDesc"]),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    CreatedByApp = DbChange.ToInt(dr["CreatedByApp"],0),
                    MonthlySort = DbChange.ToInt(dr["MonthlySort"],0),
                    BalanceMoney = DbChange.ToDecimal(dr["BalanceMoney"],0),
                    IsVip = DbChange.ToInt(dr["IsVip"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of MonthlyCarInfoDb</returns>
        public static List<MonthlyCarInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MonthlyCarInfoDb>(); 
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

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Thirdparty;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Thirdparty
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ThirdpartyMonthlySyncDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from thirdparty_monthly_sync;";
        //新增插入语句
        protected const string SqlInsert = "insert into thirdparty_monthly_sync(`ParkCode`,`TrdUserToken`,`PartnerId`,`Mobile`,`Name`,`CarNos`,`StartTime`,`TillTime`,`Consume`,`ParkingNos`,`ParkingAmount`,`AmountPerMonth`,`State`,`RowTime`) values(?ParkCode,?TrdUserToken,?PartnerId,?Mobile,?Name,?CarNos,?StartTime,?TillTime,?Consume,?ParkingNos,?ParkingAmount,?AmountPerMonth,?State,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from thirdparty_monthly_sync where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update thirdparty_monthly_sync set `ParkCode`=?ParkCode,`TrdUserToken`=?TrdUserToken,`PartnerId`=?PartnerId,`Mobile`=?Mobile,`Name`=?Name,`CarNos`=?CarNos,`StartTime`=?StartTime,`TillTime`=?TillTime,`Consume`=?Consume,`ParkingNos`=?ParkingNos,`ParkingAmount`=?ParkingAmount,`AmountPerMonth`=?AmountPerMonth,`State`=?State,`RowTime`=?RowTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from thirdparty_monthly_sync  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamTrdUserToken = "?TrdUserToken";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamMobile = "?Mobile";
        protected const string ParamName = "?Name";
        protected const string ParamCarNos = "?CarNos";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamTillTime = "?TillTime";
        protected const string ParamConsume = "?Consume";
        protected const string ParamParkingNos = "?ParkingNos";
        protected const string ParamParkingAmount = "?ParkingAmount";
        protected const string ParamAmountPerMonth = "?AmountPerMonth";
        protected const string ParamState = "?State";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ThirdpartyMonthlySyncDb</returns>
        public static List<ThirdpartyMonthlySyncDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="thirdpartymonthlysync">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ThirdpartyMonthlySyncDb thirdpartymonthlysync)
        {
            var param= GetInsertParams(thirdpartymonthlysync);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ThirdpartyMonthlySyncDb</returns>
        public static ThirdpartyMonthlySyncDb  GetByPriKey(long id)
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
        /// <param name="thirdpartymonthlysync">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ThirdpartyMonthlySyncDb thirdpartymonthlysync)
        {
            var param= GetUpdateParams(thirdpartymonthlysync);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(long id)
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
        public static MySqlParameter[]  GetUpdateParams(ThirdpartyMonthlySyncDb thirdpartymonthlysync)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,thirdpartymonthlysync.Id),
                    new MySqlParameter(ParamParkCode,thirdpartymonthlysync.ParkCode),
                    new MySqlParameter(ParamTrdUserToken,thirdpartymonthlysync.TrdUserToken),
                    new MySqlParameter(ParamPartnerId,thirdpartymonthlysync.PartnerId),
                    new MySqlParameter(ParamMobile,thirdpartymonthlysync.Mobile),
                    new MySqlParameter(ParamName,thirdpartymonthlysync.Name),
                    new MySqlParameter(ParamCarNos,thirdpartymonthlysync.CarNos),
                    new MySqlParameter(ParamStartTime,thirdpartymonthlysync.StartTime),
                    new MySqlParameter(ParamTillTime,thirdpartymonthlysync.TillTime),
                    new MySqlParameter(ParamConsume,thirdpartymonthlysync.Consume),
                    new MySqlParameter(ParamParkingNos,thirdpartymonthlysync.ParkingNos),
                    new MySqlParameter(ParamParkingAmount,thirdpartymonthlysync.ParkingAmount),
                    new MySqlParameter(ParamAmountPerMonth,thirdpartymonthlysync.AmountPerMonth),
                    new MySqlParameter(ParamState,thirdpartymonthlysync.State),
                    new MySqlParameter(ParamRowTime,thirdpartymonthlysync.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ThirdpartyMonthlySyncDb thirdpartymonthlysync)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,thirdpartymonthlysync.ParkCode),
                    new MySqlParameter(ParamTrdUserToken,thirdpartymonthlysync.TrdUserToken),
                    new MySqlParameter(ParamPartnerId,thirdpartymonthlysync.PartnerId),
                    new MySqlParameter(ParamMobile,thirdpartymonthlysync.Mobile),
                    new MySqlParameter(ParamName,thirdpartymonthlysync.Name),
                    new MySqlParameter(ParamCarNos,thirdpartymonthlysync.CarNos),
                    new MySqlParameter(ParamStartTime,thirdpartymonthlysync.StartTime),
                    new MySqlParameter(ParamTillTime,thirdpartymonthlysync.TillTime),
                    new MySqlParameter(ParamConsume,thirdpartymonthlysync.Consume),
                    new MySqlParameter(ParamParkingNos,thirdpartymonthlysync.ParkingNos),
                    new MySqlParameter(ParamParkingAmount,thirdpartymonthlysync.ParkingAmount),
                    new MySqlParameter(ParamAmountPerMonth,thirdpartymonthlysync.AmountPerMonth),
                    new MySqlParameter(ParamState,thirdpartymonthlysync.State),
                    new MySqlParameter(ParamRowTime,thirdpartymonthlysync.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ThirdpartyMonthlySyncDb</returns>
        public static ThirdpartyMonthlySyncDb  ConvertToObject(DataRow dr)
        {
            var data = new ThirdpartyMonthlySyncDb
                {
                    Id = DbChange.ToLong(dr["Id"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    TrdUserToken = DbChange.ToString(dr["TrdUserToken"]),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    Mobile = DbChange.ToString(dr["Mobile"]),
                    Name = DbChange.ToString(dr["Name"]),
                    CarNos = DbChange.ToString(dr["CarNos"]),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    TillTime = DbChange.ToDateTime(dr["TillTime"],DateTime.MinValue),
                    Consume = DbChange.ToDouble(dr["Consume"],0D),
                    ParkingNos = DbChange.ToString(dr["ParkingNos"]),
                    ParkingAmount = DbChange.ToInt(dr["ParkingAmount"],0),
                    AmountPerMonth = DbChange.ToDouble(dr["AmountPerMonth"],0D),
                    State = DbChange.ToInt(dr["State"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ThirdpartyMonthlySyncDb</returns>
        public static List<ThirdpartyMonthlySyncDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ThirdpartyMonthlySyncDb>(); 
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

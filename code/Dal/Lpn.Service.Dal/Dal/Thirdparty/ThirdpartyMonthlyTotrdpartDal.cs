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
    public partial class ThirdpartyMonthlyTotrdpartDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from thirdparty_monthly_totrdpart;";
        //新增插入语句
        protected const string SqlInsert = "insert into thirdparty_monthly_totrdpart(`PartnerId`,`ParkCode`,`TrdUserToken`,`StartTime`,`TillTime`,`Amount`,`ParkingAmount`,`Consume`,`Time`,`IsSync`) values(?PartnerId,?ParkCode,?TrdUserToken,?StartTime,?TillTime,?Amount,?ParkingAmount,?Consume,?Time,?IsSync);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from thirdparty_monthly_totrdpart where `PartnerId`=?PartnerId and `ParkCode`=?ParkCode and `TrdUserToken`=?TrdUserToken;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update thirdparty_monthly_totrdpart set `StartTime`=?StartTime,`TillTime`=?TillTime,`Amount`=?Amount,`ParkingAmount`=?ParkingAmount,`Consume`=?Consume,`Time`=?Time,`IsSync`=?IsSync where `PartnerId`=?PartnerId and `ParkCode`=?ParkCode and `TrdUserToken`=?TrdUserToken;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from thirdparty_monthly_totrdpart  where `PartnerId`=?PartnerId and `ParkCode`=?ParkCode and `TrdUserToken`=?TrdUserToken;";
        #endregion

        #region 参数
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamTrdUserToken = "?TrdUserToken";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamTillTime = "?TillTime";
        protected const string ParamAmount = "?Amount";
        protected const string ParamParkingAmount = "?ParkingAmount";
        protected const string ParamConsume = "?Consume";
        protected const string ParamTime = "?Time";
        protected const string ParamIsSync = "?IsSync";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ThirdpartyMonthlyTotrdpartDb</returns>
        public static List<ThirdpartyMonthlyTotrdpartDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="thirdpartymonthlytotrdpart">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ThirdpartyMonthlyTotrdpartDb thirdpartymonthlytotrdpart)
        {
            var param= GetInsertParams(thirdpartymonthlytotrdpart);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="partnerId">合作商</param> 
        /// <param name="parkCode">停车场编号</param> 
        /// <param name="trdUserToken">三方用户标示</param> 
        /// <returns>ThirdpartyMonthlyTotrdpartDb</returns>
        public static ThirdpartyMonthlyTotrdpartDb  GetByPriKey(string partnerId,string parkCode,string trdUserToken)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPartnerId,partnerId),
                    new MySqlParameter(ParamParkCode,parkCode),
                    new MySqlParameter(ParamTrdUserToken,trdUserToken)
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
        /// <param name="thirdpartymonthlytotrdpart">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ThirdpartyMonthlyTotrdpartDb thirdpartymonthlytotrdpart)
        {
            var param= GetUpdateParams(thirdpartymonthlytotrdpart);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="partnerId">合作商</param> 
        /// <param name="parkCode">停车场编号</param> 
        /// <param name="trdUserToken">三方用户标示</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string partnerId,string parkCode,string trdUserToken)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPartnerId,partnerId),
                    new MySqlParameter(ParamParkCode,parkCode),
                    new MySqlParameter(ParamTrdUserToken,trdUserToken)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ThirdpartyMonthlyTotrdpartDb thirdpartymonthlytotrdpart)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPartnerId,thirdpartymonthlytotrdpart.PartnerId),
                    new MySqlParameter(ParamParkCode,thirdpartymonthlytotrdpart.ParkCode),
                    new MySqlParameter(ParamTrdUserToken,thirdpartymonthlytotrdpart.TrdUserToken),
                    new MySqlParameter(ParamStartTime,thirdpartymonthlytotrdpart.StartTime),
                    new MySqlParameter(ParamTillTime,thirdpartymonthlytotrdpart.TillTime),
                    new MySqlParameter(ParamAmount,thirdpartymonthlytotrdpart.Amount),
                    new MySqlParameter(ParamParkingAmount,thirdpartymonthlytotrdpart.ParkingAmount),
                    new MySqlParameter(ParamConsume,thirdpartymonthlytotrdpart.Consume),
                    new MySqlParameter(ParamTime,thirdpartymonthlytotrdpart.Time),
                    new MySqlParameter(ParamIsSync,thirdpartymonthlytotrdpart.IsSync)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ThirdpartyMonthlyTotrdpartDb thirdpartymonthlytotrdpart)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPartnerId,thirdpartymonthlytotrdpart.PartnerId),
                    new MySqlParameter(ParamParkCode,thirdpartymonthlytotrdpart.ParkCode),
                    new MySqlParameter(ParamTrdUserToken,thirdpartymonthlytotrdpart.TrdUserToken),
                    new MySqlParameter(ParamStartTime,thirdpartymonthlytotrdpart.StartTime),
                    new MySqlParameter(ParamTillTime,thirdpartymonthlytotrdpart.TillTime),
                    new MySqlParameter(ParamAmount,thirdpartymonthlytotrdpart.Amount),
                    new MySqlParameter(ParamParkingAmount,thirdpartymonthlytotrdpart.ParkingAmount),
                    new MySqlParameter(ParamConsume,thirdpartymonthlytotrdpart.Consume),
                    new MySqlParameter(ParamTime,thirdpartymonthlytotrdpart.Time),
                    new MySqlParameter(ParamIsSync,thirdpartymonthlytotrdpart.IsSync)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ThirdpartyMonthlyTotrdpartDb</returns>
        public static ThirdpartyMonthlyTotrdpartDb  ConvertToObject(DataRow dr)
        {
            var data = new ThirdpartyMonthlyTotrdpartDb
                {
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    TrdUserToken = DbChange.ToString(dr["TrdUserToken"]),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    TillTime = DbChange.ToDateTime(dr["TillTime"],DateTime.MinValue),
                    Amount = DbChange.ToInt(dr["Amount"],0),
                    ParkingAmount = DbChange.ToInt(dr["ParkingAmount"],0),
                    Consume = DbChange.ToDouble(dr["Consume"],0D),
                    Time = DbChange.ToDateTime(dr["Time"],DateTime.MinValue),
                    IsSync = DbChange.ToInt(dr["IsSync"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ThirdpartyMonthlyTotrdpartDb</returns>
        public static List<ThirdpartyMonthlyTotrdpartDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ThirdpartyMonthlyTotrdpartDb>(); 
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

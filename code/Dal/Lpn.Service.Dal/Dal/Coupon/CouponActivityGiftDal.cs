using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Coupon;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Coupon
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CouponActivityGiftDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from coupon_activity_gift;";
        //新增插入语句
        protected const string SqlInsert = "insert into coupon_activity_gift(`CouponActivityId`,`Name`,`Amount`,`Number`,`RangeType`,`UseRange`,`ParkLimitType`,`ParkCodes`,`Way`,`StartDate`,`EndDate`,`Days`,`Summary`,`RowTime`,`Operator`,`GiftAmountType`,`GiftAmount`) values(?CouponActivityId,?Name,?Amount,?Number,?RangeType,?UseRange,?ParkLimitType,?ParkCodes,?Way,?StartDate,?EndDate,?Days,?Summary,?RowTime,?Operator,?GiftAmountType,?GiftAmount);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from coupon_activity_gift where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update coupon_activity_gift set `CouponActivityId`=?CouponActivityId,`Name`=?Name,`Amount`=?Amount,`Number`=?Number,`RangeType`=?RangeType,`UseRange`=?UseRange,`ParkLimitType`=?ParkLimitType,`ParkCodes`=?ParkCodes,`Way`=?Way,`StartDate`=?StartDate,`EndDate`=?EndDate,`Days`=?Days,`Summary`=?Summary,`RowTime`=?RowTime,`Operator`=?Operator,`GiftAmountType`=?GiftAmountType,`GiftAmount`=?GiftAmount where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from coupon_activity_gift  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamCouponActivityId = "?CouponActivityId";
        protected const string ParamName = "?Name";
        protected const string ParamAmount = "?Amount";
        protected const string ParamNumber = "?Number";
        protected const string ParamRangeType = "?RangeType";
        protected const string ParamUseRange = "?UseRange";
        protected const string ParamParkLimitType = "?ParkLimitType";
        protected const string ParamParkCodes = "?ParkCodes";
        protected const string ParamWay = "?Way";
        protected const string ParamStartDate = "?StartDate";
        protected const string ParamEndDate = "?EndDate";
        protected const string ParamDays = "?Days";
        protected const string ParamSummary = "?Summary";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamOperator = "?Operator";
        protected const string ParamGiftAmountType = "?GiftAmountType";
        protected const string ParamGiftAmount = "?GiftAmount";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CouponActivityGiftDb</returns>
        public static List<CouponActivityGiftDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="couponactivitygift">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CouponActivityGiftDb couponactivitygift)
        {
            var param= GetInsertParams(couponactivitygift);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">礼包id</param> 
        /// <returns>CouponActivityGiftDb</returns>
        public static CouponActivityGiftDb  GetByPriKey(int id)
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
        /// <param name="couponactivitygift">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CouponActivityGiftDb couponactivitygift)
        {
            var param= GetUpdateParams(couponactivitygift);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">礼包id</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
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
        public static MySqlParameter[]  GetUpdateParams(CouponActivityGiftDb couponactivitygift)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,couponactivitygift.Id),
                    new MySqlParameter(ParamCouponActivityId,couponactivitygift.CouponActivityId),
                    new MySqlParameter(ParamName,couponactivitygift.Name),
                    new MySqlParameter(ParamAmount,couponactivitygift.Amount),
                    new MySqlParameter(ParamNumber,couponactivitygift.Number),
                    new MySqlParameter(ParamRangeType,couponactivitygift.RangeType),
                    new MySqlParameter(ParamUseRange,couponactivitygift.UseRange),
                    new MySqlParameter(ParamParkLimitType,couponactivitygift.ParkLimitType),
                    new MySqlParameter(ParamParkCodes,couponactivitygift.ParkCodes),
                    new MySqlParameter(ParamWay,couponactivitygift.Way),
                    new MySqlParameter(ParamStartDate,couponactivitygift.StartDate),
                    new MySqlParameter(ParamEndDate,couponactivitygift.EndDate),
                    new MySqlParameter(ParamDays,couponactivitygift.Days),
                    new MySqlParameter(ParamSummary,couponactivitygift.Summary),
                    new MySqlParameter(ParamRowTime,couponactivitygift.RowTime),
                    new MySqlParameter(ParamOperator,couponactivitygift.Operator),
                    new MySqlParameter(ParamGiftAmountType,couponactivitygift.GiftAmountType),
                    new MySqlParameter(ParamGiftAmount,couponactivitygift.GiftAmount)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CouponActivityGiftDb couponactivitygift)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponActivityId,couponactivitygift.CouponActivityId),
                    new MySqlParameter(ParamName,couponactivitygift.Name),
                    new MySqlParameter(ParamAmount,couponactivitygift.Amount),
                    new MySqlParameter(ParamNumber,couponactivitygift.Number),
                    new MySqlParameter(ParamRangeType,couponactivitygift.RangeType),
                    new MySqlParameter(ParamUseRange,couponactivitygift.UseRange),
                    new MySqlParameter(ParamParkLimitType,couponactivitygift.ParkLimitType),
                    new MySqlParameter(ParamParkCodes,couponactivitygift.ParkCodes),
                    new MySqlParameter(ParamWay,couponactivitygift.Way),
                    new MySqlParameter(ParamStartDate,couponactivitygift.StartDate),
                    new MySqlParameter(ParamEndDate,couponactivitygift.EndDate),
                    new MySqlParameter(ParamDays,couponactivitygift.Days),
                    new MySqlParameter(ParamSummary,couponactivitygift.Summary),
                    new MySqlParameter(ParamRowTime,couponactivitygift.RowTime),
                    new MySqlParameter(ParamOperator,couponactivitygift.Operator),
                    new MySqlParameter(ParamGiftAmountType,couponactivitygift.GiftAmountType),
                    new MySqlParameter(ParamGiftAmount,couponactivitygift.GiftAmount)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CouponActivityGiftDb</returns>
        public static CouponActivityGiftDb  ConvertToObject(DataRow dr)
        {
            var data = new CouponActivityGiftDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    CouponActivityId = DbChange.ToInt(dr["CouponActivityId"],0),
                    Name = DbChange.ToString(dr["Name"]),
                    Amount = DbChange.ToInt(dr["Amount"],0),
                    Number = DbChange.ToInt(dr["Number"],0),
                    RangeType = DbChange.ToInt(dr["RangeType"],0),
                    UseRange = DbChange.ToString(dr["UseRange"]),
                    ParkLimitType = DbChange.ToInt(dr["ParkLimitType"],0),
                    ParkCodes = DbChange.ToString(dr["ParkCodes"]),
                    Way = DbChange.ToInt(dr["Way"],0),
                    StartDate = DbChange.ToDateTime(dr["StartDate"],DateTime.MinValue),
                    EndDate = DbChange.ToDateTime(dr["EndDate"],DateTime.MinValue),
                    Days = DbChange.ToInt(dr["Days"],0),
                    Summary = DbChange.ToString(dr["Summary"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    Operator = DbChange.ToString(dr["Operator"]),
                    GiftAmountType = DbChange.ToInt(dr["GiftAmountType"],0),
                    GiftAmount = DbChange.ToInt(dr["GiftAmount"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CouponActivityGiftDb</returns>
        public static List<CouponActivityGiftDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CouponActivityGiftDb>(); 
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

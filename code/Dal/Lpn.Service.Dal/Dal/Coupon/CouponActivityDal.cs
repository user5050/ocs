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
    public partial class CouponActivityDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from coupon_activity;";
        //新增插入语句
        protected const string SqlInsert = "insert into coupon_activity(`Name`,`Type`,`City`,`StartTime`,`ExpiredTime`,`Weeks`,`MinMoney`,`MaxMoney`,`Description`,`ActivityId`,`ActivityUrl`,`ShareDesc`,`RechargeDesc`,`GiftAmount`,`RowTime`,`Operator`,`GiftGetType`,`GiftRandomCnt`,`LimitUserType`) values(?Name,?Type,?City,?StartTime,?ExpiredTime,?Weeks,?MinMoney,?MaxMoney,?Description,?ActivityId,?ActivityUrl,?ShareDesc,?RechargeDesc,?GiftAmount,?RowTime,?Operator,?GiftGetType,?GiftRandomCnt,?LimitUserType);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from coupon_activity where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update coupon_activity set `Name`=?Name,`Type`=?Type,`City`=?City,`StartTime`=?StartTime,`ExpiredTime`=?ExpiredTime,`Weeks`=?Weeks,`MinMoney`=?MinMoney,`MaxMoney`=?MaxMoney,`Description`=?Description,`ActivityId`=?ActivityId,`ActivityUrl`=?ActivityUrl,`ShareDesc`=?ShareDesc,`RechargeDesc`=?RechargeDesc,`GiftAmount`=?GiftAmount,`RowTime`=?RowTime,`Operator`=?Operator,`GiftGetType`=?GiftGetType,`GiftRandomCnt`=?GiftRandomCnt,`LimitUserType`=?LimitUserType where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from coupon_activity  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamName = "?Name";
        protected const string ParamType = "?Type";
        protected const string ParamCity = "?City";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamExpiredTime = "?ExpiredTime";
        protected const string ParamWeeks = "?Weeks";
        protected const string ParamMinMoney = "?MinMoney";
        protected const string ParamMaxMoney = "?MaxMoney";
        protected const string ParamDescription = "?Description";
        protected const string ParamActivityId = "?ActivityId";
        protected const string ParamActivityUrl = "?ActivityUrl";
        protected const string ParamShareDesc = "?ShareDesc";
        protected const string ParamRechargeDesc = "?RechargeDesc";
        protected const string ParamGiftAmount = "?GiftAmount";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamOperator = "?Operator";
        protected const string ParamGiftGetType = "?GiftGetType";
        protected const string ParamGiftRandomCnt = "?GiftRandomCnt";
        protected const string ParamLimitUserType = "?LimitUserType";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CouponActivityDb</returns>
        public static List<CouponActivityDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="couponactivity">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CouponActivityDb couponactivity)
        {
            var param= GetInsertParams(couponactivity);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">活动id</param> 
        /// <returns>CouponActivityDb</returns>
        public static CouponActivityDb  GetByPriKey(int id)
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
        /// <param name="couponactivity">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CouponActivityDb couponactivity)
        {
            var param= GetUpdateParams(couponactivity);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">活动id</param> 
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
        public static MySqlParameter[]  GetUpdateParams(CouponActivityDb couponactivity)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,couponactivity.Id),
                    new MySqlParameter(ParamName,couponactivity.Name),
                    new MySqlParameter(ParamType,couponactivity.Type),
                    new MySqlParameter(ParamCity,couponactivity.City),
                    new MySqlParameter(ParamStartTime,couponactivity.StartTime),
                    new MySqlParameter(ParamExpiredTime,couponactivity.ExpiredTime),
                    new MySqlParameter(ParamWeeks,couponactivity.Weeks),
                    new MySqlParameter(ParamMinMoney,couponactivity.MinMoney),
                    new MySqlParameter(ParamMaxMoney,couponactivity.MaxMoney),
                    new MySqlParameter(ParamDescription,couponactivity.Description),
                    new MySqlParameter(ParamActivityId,couponactivity.ActivityId),
                    new MySqlParameter(ParamActivityUrl,couponactivity.ActivityUrl),
                    new MySqlParameter(ParamShareDesc,couponactivity.ShareDesc),
                    new MySqlParameter(ParamRechargeDesc,couponactivity.RechargeDesc),
                    new MySqlParameter(ParamGiftAmount,couponactivity.GiftAmount),
                    new MySqlParameter(ParamRowTime,couponactivity.RowTime),
                    new MySqlParameter(ParamOperator,couponactivity.Operator),
                    new MySqlParameter(ParamGiftGetType,couponactivity.GiftGetType),
                    new MySqlParameter(ParamGiftRandomCnt,couponactivity.GiftRandomCnt),
                    new MySqlParameter(ParamLimitUserType,couponactivity.LimitUserType)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CouponActivityDb couponactivity)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamName,couponactivity.Name),
                    new MySqlParameter(ParamType,couponactivity.Type),
                    new MySqlParameter(ParamCity,couponactivity.City),
                    new MySqlParameter(ParamStartTime,couponactivity.StartTime),
                    new MySqlParameter(ParamExpiredTime,couponactivity.ExpiredTime),
                    new MySqlParameter(ParamWeeks,couponactivity.Weeks),
                    new MySqlParameter(ParamMinMoney,couponactivity.MinMoney),
                    new MySqlParameter(ParamMaxMoney,couponactivity.MaxMoney),
                    new MySqlParameter(ParamDescription,couponactivity.Description),
                    new MySqlParameter(ParamActivityId,couponactivity.ActivityId),
                    new MySqlParameter(ParamActivityUrl,couponactivity.ActivityUrl),
                    new MySqlParameter(ParamShareDesc,couponactivity.ShareDesc),
                    new MySqlParameter(ParamRechargeDesc,couponactivity.RechargeDesc),
                    new MySqlParameter(ParamGiftAmount,couponactivity.GiftAmount),
                    new MySqlParameter(ParamRowTime,couponactivity.RowTime),
                    new MySqlParameter(ParamOperator,couponactivity.Operator),
                    new MySqlParameter(ParamGiftGetType,couponactivity.GiftGetType),
                    new MySqlParameter(ParamGiftRandomCnt,couponactivity.GiftRandomCnt),
                    new MySqlParameter(ParamLimitUserType,couponactivity.LimitUserType)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CouponActivityDb</returns>
        public static CouponActivityDb  ConvertToObject(DataRow dr)
        {
            var data = new CouponActivityDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    Name = DbChange.ToString(dr["Name"]),
                    Type = DbChange.ToInt(dr["Type"],0),
                    City = DbChange.ToString(dr["City"]),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    ExpiredTime = DbChange.ToDateTime(dr["ExpiredTime"],DateTime.MinValue),
                    Weeks = DbChange.ToString(dr["Weeks"]),
                    MinMoney = DbChange.ToDouble(dr["MinMoney"],0D),
                    MaxMoney = DbChange.ToDouble(dr["MaxMoney"],0D),
                    Description = DbChange.ToString(dr["Description"]),
                    ActivityId = DbChange.ToString(dr["ActivityId"]),
                    ActivityUrl = DbChange.ToString(dr["ActivityUrl"]),
                    ShareDesc = DbChange.ToString(dr["ShareDesc"]),
                    RechargeDesc = DbChange.ToString(dr["RechargeDesc"]),
                    GiftAmount = DbChange.ToInt(dr["GiftAmount"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    Operator = DbChange.ToString(dr["Operator"]),
                    GiftGetType = DbChange.ToInt(dr["GiftGetType"],0),
                    GiftRandomCnt = DbChange.ToInt(dr["GiftRandomCnt"],0),
                    LimitUserType = DbChange.ToInt(dr["LimitUserType"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CouponActivityDb</returns>
        public static List<CouponActivityDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CouponActivityDb>(); 
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

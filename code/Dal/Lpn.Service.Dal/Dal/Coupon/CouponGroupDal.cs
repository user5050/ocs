using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Coupon;

/*
* 由自动生成工具完成
* 描述:[coupon_group]优惠组 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Coupon
{
    /// <summary>
    /// [coupon_group]优惠组 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CouponGroupDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from coupongroup;";
        //新增插入语句
        protected const string SqlInsert = "insert into coupongroup(`CouponGroupID`,`ParkCode`,`UserId`,`CouponType`,`CouponMoney`,`Money1`,`Money2`,`Money3`,`Num1`,`Num2`,`Num3`,`CreatTime`,`StartTime`,`ExpireTime`,`EffectiveTime`,`IsTest`,`Num1Remainder`,`Num2Remainder`,`Num3Remainder`,`OrderNo`,`Url`,`Summary`,`ActivityId`,`PreSendMobile`) values(?CouponGroupID,?ParkCode,?UserId,?CouponType,?CouponMoney,?Money1,?Money2,?Money3,?Num1,?Num2,?Num3,?CreatTime,?StartTime,?ExpireTime,?EffectiveTime,?IsTest,?Num1Remainder,?Num2Remainder,?Num3Remainder,?OrderNo,?Url,?Summary,?ActivityId,?PreSendMobile);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from coupongroup where `CouponGroupID`=?CouponGroupID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update coupongroup set `ParkCode`=?ParkCode,`UserId`=?UserId,`CouponType`=?CouponType,`CouponMoney`=?CouponMoney,`Money1`=?Money1,`Money2`=?Money2,`Money3`=?Money3,`Num1`=?Num1,`Num2`=?Num2,`Num3`=?Num3,`CreatTime`=?CreatTime,`StartTime`=?StartTime,`ExpireTime`=?ExpireTime,`EffectiveTime`=?EffectiveTime,`IsTest`=?IsTest,`Num1Remainder`=?Num1Remainder,`Num2Remainder`=?Num2Remainder,`Num3Remainder`=?Num3Remainder,`OrderNo`=?OrderNo,`Url`=?Url,`Summary`=?Summary,`ActivityId`=?ActivityId,`PreSendMobile`=?PreSendMobile where `CouponGroupID`=?CouponGroupID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from coupongroup  where `CouponGroupID`=?CouponGroupID;";
        #endregion

        #region 参数
        protected const string ParamCouponGroupID = "?CouponGroupID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamUserId = "?UserId";
        protected const string ParamCouponType = "?CouponType";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamMoney1 = "?Money1";
        protected const string ParamMoney2 = "?Money2";
        protected const string ParamMoney3 = "?Money3";
        protected const string ParamNum1 = "?Num1";
        protected const string ParamNum2 = "?Num2";
        protected const string ParamNum3 = "?Num3";
        protected const string ParamCreatTime = "?CreatTime";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamExpireTime = "?ExpireTime";
        protected const string ParamEffectiveTime = "?EffectiveTime";
        protected const string ParamIsTest = "?IsTest";
        protected const string ParamNum1Remainder = "?Num1Remainder";
        protected const string ParamNum2Remainder = "?Num2Remainder";
        protected const string ParamNum3Remainder = "?Num3Remainder";
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamUrl = "?Url";
        protected const string ParamSummary = "?Summary";
        protected const string ParamActivityId = "?ActivityId";
        protected const string ParamPreSendMobile = "?PreSendMobile";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CouponGroupDb</returns>
        public static List<CouponGroupDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="coupongroup">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CouponGroupDb coupongroup)
        {
            var param= GetInsertParams(coupongroup);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="couponGroupID">优惠组编号</param> 
        /// <returns>CouponGroupDb</returns>
        public static CouponGroupDb  GetByPriKey(string couponGroupID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponGroupID,couponGroupID)
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
        /// <param name="coupongroup">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CouponGroupDb coupongroup)
        {
            var param= GetUpdateParams(coupongroup);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="couponGroupID">优惠组编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string couponGroupID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponGroupID,couponGroupID)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(CouponGroupDb coupongroup)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponGroupID,coupongroup.CouponGroupID),
                    new MySqlParameter(ParamParkCode,coupongroup.ParkCode),
                    new MySqlParameter(ParamUserId,coupongroup.UserId),
                    new MySqlParameter(ParamCouponType,coupongroup.CouponType),
                    new MySqlParameter(ParamCouponMoney,coupongroup.CouponMoney),
                    new MySqlParameter(ParamMoney1,coupongroup.Money1),
                    new MySqlParameter(ParamMoney2,coupongroup.Money2),
                    new MySqlParameter(ParamMoney3,coupongroup.Money3),
                    new MySqlParameter(ParamNum1,coupongroup.Num1),
                    new MySqlParameter(ParamNum2,coupongroup.Num2),
                    new MySqlParameter(ParamNum3,coupongroup.Num3),
                    new MySqlParameter(ParamCreatTime,coupongroup.CreatTime),
                    new MySqlParameter(ParamStartTime,coupongroup.StartTime),
                    new MySqlParameter(ParamExpireTime,coupongroup.ExpireTime),
                    new MySqlParameter(ParamEffectiveTime,coupongroup.EffectiveTime),
                    new MySqlParameter(ParamIsTest,coupongroup.IsTest),
                    new MySqlParameter(ParamNum1Remainder,coupongroup.Num1Remainder),
                    new MySqlParameter(ParamNum2Remainder,coupongroup.Num2Remainder),
                    new MySqlParameter(ParamNum3Remainder,coupongroup.Num3Remainder),
                    new MySqlParameter(ParamOrderNo,coupongroup.OrderNo),
                    new MySqlParameter(ParamUrl,coupongroup.Url),
                    new MySqlParameter(ParamSummary,coupongroup.Summary),
                    new MySqlParameter(ParamActivityId,coupongroup.ActivityId),
                    new MySqlParameter(ParamPreSendMobile,coupongroup.PreSendMobile)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CouponGroupDb coupongroup)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponGroupID,coupongroup.CouponGroupID),
                    new MySqlParameter(ParamParkCode,coupongroup.ParkCode),
                    new MySqlParameter(ParamUserId,coupongroup.UserId),
                    new MySqlParameter(ParamCouponType,coupongroup.CouponType),
                    new MySqlParameter(ParamCouponMoney,coupongroup.CouponMoney),
                    new MySqlParameter(ParamMoney1,coupongroup.Money1),
                    new MySqlParameter(ParamMoney2,coupongroup.Money2),
                    new MySqlParameter(ParamMoney3,coupongroup.Money3),
                    new MySqlParameter(ParamNum1,coupongroup.Num1),
                    new MySqlParameter(ParamNum2,coupongroup.Num2),
                    new MySqlParameter(ParamNum3,coupongroup.Num3),
                    new MySqlParameter(ParamCreatTime,coupongroup.CreatTime),
                    new MySqlParameter(ParamStartTime,coupongroup.StartTime),
                    new MySqlParameter(ParamExpireTime,coupongroup.ExpireTime),
                    new MySqlParameter(ParamEffectiveTime,coupongroup.EffectiveTime),
                    new MySqlParameter(ParamIsTest,coupongroup.IsTest),
                    new MySqlParameter(ParamNum1Remainder,coupongroup.Num1Remainder),
                    new MySqlParameter(ParamNum2Remainder,coupongroup.Num2Remainder),
                    new MySqlParameter(ParamNum3Remainder,coupongroup.Num3Remainder),
                    new MySqlParameter(ParamOrderNo,coupongroup.OrderNo),
                    new MySqlParameter(ParamUrl,coupongroup.Url),
                    new MySqlParameter(ParamSummary,coupongroup.Summary),
                    new MySqlParameter(ParamActivityId,coupongroup.ActivityId),
                    new MySqlParameter(ParamPreSendMobile,coupongroup.PreSendMobile)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CouponGroupDb</returns>
        public static CouponGroupDb  ConvertToObject(DataRow dr)
        {
            var data = new CouponGroupDb
                {
                    CouponGroupID = DbChange.ToString(dr["CouponGroupID"]),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    UserId = DbChange.ToInt(dr["UserId"],0),
                    CouponType = DbChange.ToInt(dr["CouponType"],0),
                    CouponMoney = DbChange.ToDecimal(dr["CouponMoney"],0),
                    Money1 = DbChange.ToDecimal(dr["Money1"],0),
                    Money2 = DbChange.ToDecimal(dr["Money2"],0),
                    Money3 = DbChange.ToDecimal(dr["Money3"],0),
                    Num1 = DbChange.ToInt(dr["Num1"],0),
                    Num2 = DbChange.ToInt(dr["Num2"],0),
                    Num3 = DbChange.ToInt(dr["Num3"],0),
                    CreatTime = DbChange.ToDateTime(dr["CreatTime"],DateTime.MinValue),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    ExpireTime = DbChange.ToDateTime(dr["ExpireTime"],DateTime.MinValue),
                    EffectiveTime = DbChange.ToDateTime(dr["EffectiveTime"],DateTime.MinValue),
                    IsTest = DbChange.ToInt(dr["IsTest"],0),
                    Num1Remainder = DbChange.ToInt(dr["Num1Remainder"],0),
                    Num2Remainder = DbChange.ToInt(dr["Num2Remainder"],0),
                    Num3Remainder = DbChange.ToInt(dr["Num3Remainder"],0),
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    Url = DbChange.ToString(dr["Url"]),
                    Summary = DbChange.ToString(dr["Summary"]),
                    ActivityId = DbChange.ToString(dr["ActivityId"]),
                    PreSendMobile = DbChange.ToString(dr["PreSendMobile"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CouponGroupDb</returns>
        public static List<CouponGroupDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CouponGroupDb>(); 
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

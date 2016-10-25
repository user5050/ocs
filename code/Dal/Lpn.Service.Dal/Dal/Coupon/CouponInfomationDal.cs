using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Coupon;

/*
* 由自动生成工具完成
* 描述:[coupon_infomation]优惠券信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Coupon
{
    /// <summary>
    /// [coupon_infomation]优惠券信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CouponInfomationDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from couponinfomation;";
        //新增插入语句
        protected const string SqlInsert = "insert into couponinfomation(`CouponID`,`ParkCode`,`CouponMoney`,`CouponType`,`UserID`,`CouponGroupID`,`Creattime`,`Starttime`,`Expiretime`,`Effectivetime`,`State`,`NickName`,`HeadUrl`,`RandomStr`,`Name`,`RangeType`,`UseRange`,`ParkLimitType`,`ParkCodes`,`Summary`,`IsView`) values(?CouponID,?ParkCode,?CouponMoney,?CouponType,?UserID,?CouponGroupID,?Creattime,?Starttime,?Expiretime,?Effectivetime,?State,?NickName,?HeadUrl,?RandomStr,?Name,?RangeType,?UseRange,?ParkLimitType,?ParkCodes,?Summary,?IsView);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from couponinfomation where `CouponID`=?CouponID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update couponinfomation set `ParkCode`=?ParkCode,`CouponMoney`=?CouponMoney,`CouponType`=?CouponType,`UserID`=?UserID,`CouponGroupID`=?CouponGroupID,`Creattime`=?Creattime,`Starttime`=?Starttime,`Expiretime`=?Expiretime,`Effectivetime`=?Effectivetime,`State`=?State,`NickName`=?NickName,`HeadUrl`=?HeadUrl,`RandomStr`=?RandomStr,`Name`=?Name,`RangeType`=?RangeType,`UseRange`=?UseRange,`ParkLimitType`=?ParkLimitType,`ParkCodes`=?ParkCodes,`Summary`=?Summary,`IsView`=?IsView where `CouponID`=?CouponID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from couponinfomation  where `CouponID`=?CouponID;";
        #endregion

        #region 参数
        protected const string ParamCouponID = "?CouponID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamCouponType = "?CouponType";
        protected const string ParamUserID = "?UserID";
        protected const string ParamCouponGroupID = "?CouponGroupID";
        protected const string ParamCreattime = "?Creattime";
        protected const string ParamStarttime = "?Starttime";
        protected const string ParamExpiretime = "?Expiretime";
        protected const string ParamEffectivetime = "?Effectivetime";
        protected const string ParamState = "?State";
        protected const string ParamNickName = "?NickName";
        protected const string ParamHeadUrl = "?HeadUrl";
        protected const string ParamRandomStr = "?RandomStr";
        protected const string ParamName = "?Name";
        protected const string ParamRangeType = "?RangeType";
        protected const string ParamUseRange = "?UseRange";
        protected const string ParamParkLimitType = "?ParkLimitType";
        protected const string ParamParkCodes = "?ParkCodes";
        protected const string ParamSummary = "?Summary";
        protected const string ParamIsView = "?IsView";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CouponInfomationDb</returns>
        public static List<CouponInfomationDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="couponinfomation">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CouponInfomationDb couponinfomation)
        {
            var param= GetInsertParams(couponinfomation);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="couponID">优惠券信息编号</param> 
        /// <returns>CouponInfomationDb</returns>
        public static CouponInfomationDb  GetByPriKey(string couponID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponID,couponID)
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
        /// <param name="couponinfomation">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CouponInfomationDb couponinfomation)
        {
            var param= GetUpdateParams(couponinfomation);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="couponID">优惠券信息编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string couponID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponID,couponID)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(CouponInfomationDb couponinfomation)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponID,couponinfomation.CouponID),
                    new MySqlParameter(ParamParkCode,couponinfomation.ParkCode),
                    new MySqlParameter(ParamCouponMoney,couponinfomation.CouponMoney),
                    new MySqlParameter(ParamCouponType,couponinfomation.CouponType),
                    new MySqlParameter(ParamUserID,couponinfomation.UserID),
                    new MySqlParameter(ParamCouponGroupID,couponinfomation.CouponGroupID),
                    new MySqlParameter(ParamCreattime,couponinfomation.Creattime),
                    new MySqlParameter(ParamStarttime,couponinfomation.Starttime),
                    new MySqlParameter(ParamExpiretime,couponinfomation.Expiretime),
                    new MySqlParameter(ParamEffectivetime,couponinfomation.Effectivetime),
                    new MySqlParameter(ParamState,couponinfomation.State),
                    new MySqlParameter(ParamNickName,couponinfomation.NickName),
                    new MySqlParameter(ParamHeadUrl,couponinfomation.HeadUrl),
                    new MySqlParameter(ParamRandomStr,couponinfomation.RandomStr),
                    new MySqlParameter(ParamName,couponinfomation.Name),
                    new MySqlParameter(ParamRangeType,couponinfomation.RangeType),
                    new MySqlParameter(ParamUseRange,couponinfomation.UseRange),
                    new MySqlParameter(ParamParkLimitType,couponinfomation.ParkLimitType),
                    new MySqlParameter(ParamParkCodes,couponinfomation.ParkCodes),
                    new MySqlParameter(ParamSummary,couponinfomation.Summary),
                    new MySqlParameter(ParamIsView,couponinfomation.IsView)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CouponInfomationDb couponinfomation)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponID,couponinfomation.CouponID),
                    new MySqlParameter(ParamParkCode,couponinfomation.ParkCode),
                    new MySqlParameter(ParamCouponMoney,couponinfomation.CouponMoney),
                    new MySqlParameter(ParamCouponType,couponinfomation.CouponType),
                    new MySqlParameter(ParamUserID,couponinfomation.UserID),
                    new MySqlParameter(ParamCouponGroupID,couponinfomation.CouponGroupID),
                    new MySqlParameter(ParamCreattime,couponinfomation.Creattime),
                    new MySqlParameter(ParamStarttime,couponinfomation.Starttime),
                    new MySqlParameter(ParamExpiretime,couponinfomation.Expiretime),
                    new MySqlParameter(ParamEffectivetime,couponinfomation.Effectivetime),
                    new MySqlParameter(ParamState,couponinfomation.State),
                    new MySqlParameter(ParamNickName,couponinfomation.NickName),
                    new MySqlParameter(ParamHeadUrl,couponinfomation.HeadUrl),
                    new MySqlParameter(ParamRandomStr,couponinfomation.RandomStr),
                    new MySqlParameter(ParamName,couponinfomation.Name),
                    new MySqlParameter(ParamRangeType,couponinfomation.RangeType),
                    new MySqlParameter(ParamUseRange,couponinfomation.UseRange),
                    new MySqlParameter(ParamParkLimitType,couponinfomation.ParkLimitType),
                    new MySqlParameter(ParamParkCodes,couponinfomation.ParkCodes),
                    new MySqlParameter(ParamSummary,couponinfomation.Summary),
                    new MySqlParameter(ParamIsView,couponinfomation.IsView)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CouponInfomationDb</returns>
        public static CouponInfomationDb  ConvertToObject(DataRow dr)
        {
            var data = new CouponInfomationDb
                {
                    CouponID = DbChange.ToString(dr["CouponID"]),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    CouponMoney = DbChange.ToDecimal(dr["CouponMoney"],0),
                    CouponType = DbChange.ToInt(dr["CouponType"],0),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    CouponGroupID = DbChange.ToString(dr["CouponGroupID"]),
                    Creattime = DbChange.ToDateTime(dr["Creattime"],DateTime.MinValue),
                    Starttime = DbChange.ToDateTime(dr["Starttime"],DateTime.MinValue),
                    Expiretime = DbChange.ToDateTime(dr["Expiretime"],DateTime.MinValue),
                    Effectivetime = DbChange.ToDateTime(dr["Effectivetime"],DateTime.MinValue),
                    State = DbChange.ToInt(dr["State"],0),
                    NickName = DbChange.ToString(dr["NickName"]),
                    HeadUrl = DbChange.ToString(dr["HeadUrl"]),
                    RandomStr = DbChange.ToString(dr["RandomStr"]),
                    Name = DbChange.ToString(dr["Name"]),
                    RangeType = DbChange.ToInt(dr["RangeType"],0),
                    UseRange = DbChange.ToString(dr["UseRange"]),
                    ParkLimitType = DbChange.ToInt(dr["ParkLimitType"],0),
                    ParkCodes = DbChange.ToString(dr["ParkCodes"]),
                    Summary = DbChange.ToString(dr["Summary"]),
                    IsView = DbChange.ToInt(dr["IsView"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CouponInfomationDb</returns>
        public static List<CouponInfomationDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CouponInfomationDb>(); 
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

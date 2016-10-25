using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Coupon;

/*
* 由自动生成工具完成
* 描述:[coupon_template]优惠模板 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Coupon
{
    /// <summary>
    /// [coupon_template]优惠模板 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CouponTemplateDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from coupontemplate;";
        //新增插入语句
        protected const string SqlInsert = "insert into coupontemplate(`CouponTemplateID`,`CouponName`,`CouponType`,`CouponMoney`,`Money1`,`Money2`,`Money3`,`Num1`,`Num2`,`Num3`,`EffectiveTime`,`Way`,`StartDate`,`EndDate`,`Days`,`Url`,`Summary`,`Weeks`) values(?CouponTemplateID,?CouponName,?CouponType,?CouponMoney,?Money1,?Money2,?Money3,?Num1,?Num2,?Num3,?EffectiveTime,?Way,?StartDate,?EndDate,?Days,?Url,?Summary,?Weeks);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from coupontemplate where `CouponTemplateID`=?CouponTemplateID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update coupontemplate set `CouponName`=?CouponName,`CouponType`=?CouponType,`CouponMoney`=?CouponMoney,`Money1`=?Money1,`Money2`=?Money2,`Money3`=?Money3,`Num1`=?Num1,`Num2`=?Num2,`Num3`=?Num3,`EffectiveTime`=?EffectiveTime,`Way`=?Way,`StartDate`=?StartDate,`EndDate`=?EndDate,`Days`=?Days,`Url`=?Url,`Summary`=?Summary,`Weeks`=?Weeks where `CouponTemplateID`=?CouponTemplateID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from coupontemplate  where `CouponTemplateID`=?CouponTemplateID;";
        #endregion

        #region 参数
        protected const string ParamCouponTemplateID = "?CouponTemplateID";
        protected const string ParamCouponName = "?CouponName";
        protected const string ParamCouponType = "?CouponType";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamMoney1 = "?Money1";
        protected const string ParamMoney2 = "?Money2";
        protected const string ParamMoney3 = "?Money3";
        protected const string ParamNum1 = "?Num1";
        protected const string ParamNum2 = "?Num2";
        protected const string ParamNum3 = "?Num3";
        protected const string ParamEffectiveTime = "?EffectiveTime";
        protected const string ParamWay = "?Way";
        protected const string ParamStartDate = "?StartDate";
        protected const string ParamEndDate = "?EndDate";
        protected const string ParamDays = "?Days";
        protected const string ParamUrl = "?Url";
        protected const string ParamSummary = "?Summary";
        protected const string ParamWeeks = "?Weeks";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CouponTemplateDb</returns>
        public static List<CouponTemplateDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="coupontemplate">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CouponTemplateDb coupontemplate)
        {
            var param= GetInsertParams(coupontemplate);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="couponTemplateID">优惠模板编号</param> 
        /// <returns>CouponTemplateDb</returns>
        public static CouponTemplateDb  GetByPriKey(string couponTemplateID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponTemplateID,couponTemplateID)
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
        /// <param name="coupontemplate">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CouponTemplateDb coupontemplate)
        {
            var param= GetUpdateParams(coupontemplate);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="couponTemplateID">优惠模板编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string couponTemplateID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponTemplateID,couponTemplateID)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(CouponTemplateDb coupontemplate)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponTemplateID,coupontemplate.CouponTemplateID),
                    new MySqlParameter(ParamCouponName,coupontemplate.CouponName),
                    new MySqlParameter(ParamCouponType,coupontemplate.CouponType),
                    new MySqlParameter(ParamCouponMoney,coupontemplate.CouponMoney),
                    new MySqlParameter(ParamMoney1,coupontemplate.Money1),
                    new MySqlParameter(ParamMoney2,coupontemplate.Money2),
                    new MySqlParameter(ParamMoney3,coupontemplate.Money3),
                    new MySqlParameter(ParamNum1,coupontemplate.Num1),
                    new MySqlParameter(ParamNum2,coupontemplate.Num2),
                    new MySqlParameter(ParamNum3,coupontemplate.Num3),
                    new MySqlParameter(ParamEffectiveTime,coupontemplate.EffectiveTime),
                    new MySqlParameter(ParamWay,coupontemplate.Way),
                    new MySqlParameter(ParamStartDate,coupontemplate.StartDate),
                    new MySqlParameter(ParamEndDate,coupontemplate.EndDate),
                    new MySqlParameter(ParamDays,coupontemplate.Days),
                    new MySqlParameter(ParamUrl,coupontemplate.Url),
                    new MySqlParameter(ParamSummary,coupontemplate.Summary),
                    new MySqlParameter(ParamWeeks,coupontemplate.Weeks)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CouponTemplateDb coupontemplate)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCouponTemplateID,coupontemplate.CouponTemplateID),
                    new MySqlParameter(ParamCouponName,coupontemplate.CouponName),
                    new MySqlParameter(ParamCouponType,coupontemplate.CouponType),
                    new MySqlParameter(ParamCouponMoney,coupontemplate.CouponMoney),
                    new MySqlParameter(ParamMoney1,coupontemplate.Money1),
                    new MySqlParameter(ParamMoney2,coupontemplate.Money2),
                    new MySqlParameter(ParamMoney3,coupontemplate.Money3),
                    new MySqlParameter(ParamNum1,coupontemplate.Num1),
                    new MySqlParameter(ParamNum2,coupontemplate.Num2),
                    new MySqlParameter(ParamNum3,coupontemplate.Num3),
                    new MySqlParameter(ParamEffectiveTime,coupontemplate.EffectiveTime),
                    new MySqlParameter(ParamWay,coupontemplate.Way),
                    new MySqlParameter(ParamStartDate,coupontemplate.StartDate),
                    new MySqlParameter(ParamEndDate,coupontemplate.EndDate),
                    new MySqlParameter(ParamDays,coupontemplate.Days),
                    new MySqlParameter(ParamUrl,coupontemplate.Url),
                    new MySqlParameter(ParamSummary,coupontemplate.Summary),
                    new MySqlParameter(ParamWeeks,coupontemplate.Weeks)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CouponTemplateDb</returns>
        public static CouponTemplateDb  ConvertToObject(DataRow dr)
        {
            var data = new CouponTemplateDb
                {
                    CouponTemplateID = DbChange.ToString(dr["CouponTemplateID"]),
                    CouponName = DbChange.ToString(dr["CouponName"]),
                    CouponType = DbChange.ToInt(dr["CouponType"],0),
                    CouponMoney = DbChange.ToInt(dr["CouponMoney"],0),
                    Money1 = DbChange.ToInt(dr["Money1"],0),
                    Money2 = DbChange.ToInt(dr["Money2"],0),
                    Money3 = DbChange.ToInt(dr["Money3"],0),
                    Num1 = DbChange.ToInt(dr["Num1"],0),
                    Num2 = DbChange.ToInt(dr["Num2"],0),
                    Num3 = DbChange.ToInt(dr["Num3"],0),
                    EffectiveTime = DbChange.ToDateTime(dr["EffectiveTime"],DateTime.MinValue),
                    Way = DbChange.ToInt(dr["Way"],0),
                    StartDate = DbChange.ToDateTime(dr["StartDate"],DateTime.MinValue),
                    EndDate = DbChange.ToDateTime(dr["EndDate"],DateTime.MinValue),
                    Days = DbChange.ToInt(dr["Days"],0),
                    Url = DbChange.ToString(dr["Url"]),
                    Summary = DbChange.ToString(dr["Summary"]),
                    Weeks = DbChange.ToString(dr["Weeks"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CouponTemplateDb</returns>
        public static List<CouponTemplateDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CouponTemplateDb>(); 
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

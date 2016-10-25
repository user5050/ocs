using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Coupon;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Coupon
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CouponInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from coupon_info;";
        //新增插入语句
        protected const string SqlInsert = "insert into coupon_info(`Id`,`Uid`,`CouponName`,`Amount`,`MinOrderMoney`,`ExpiredTime`,`State`,`IsView`) values(?Id,?Uid,?CouponName,?Amount,?MinOrderMoney,?ExpiredTime,?State,?IsView);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from coupon_info where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update coupon_info set `Uid`=?Uid,`CouponName`=?CouponName,`Amount`=?Amount,`MinOrderMoney`=?MinOrderMoney,`ExpiredTime`=?ExpiredTime,`State`=?State,`IsView`=?IsView where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from coupon_info  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamUid = "?Uid";
        protected const string ParamCouponName = "?CouponName";
        protected const string ParamAmount = "?Amount";
        protected const string ParamMinOrderMoney = "?MinOrderMoney";
        protected const string ParamExpiredTime = "?ExpiredTime";
        protected const string ParamState = "?State";
        protected const string ParamIsView = "?IsView";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CouponInfoDb</returns>
        public static List<CouponInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="couponinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CouponInfoDb couponinfo)
        {
            var param= GetInsertParams(couponinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">优惠券id</param> 
        /// <returns>CouponInfoDb</returns>
        public static CouponInfoDb  GetByPriKey(string id)
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
        /// <param name="couponinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CouponInfoDb couponinfo)
        {
            var param= GetUpdateParams(couponinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">优惠券id</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string id)
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
        public static MySqlParameter[]  GetUpdateParams(CouponInfoDb couponinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,couponinfo.Id),
                    new MySqlParameter(ParamUid,couponinfo.Uid),
                    new MySqlParameter(ParamCouponName,couponinfo.CouponName),
                    new MySqlParameter(ParamAmount,couponinfo.Amount),
                    new MySqlParameter(ParamMinOrderMoney,couponinfo.MinOrderMoney),
                    new MySqlParameter(ParamExpiredTime,couponinfo.ExpiredTime),
                    new MySqlParameter(ParamState,couponinfo.State),
                    new MySqlParameter(ParamIsView,couponinfo.IsView)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CouponInfoDb couponinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,couponinfo.Id),
                    new MySqlParameter(ParamUid,couponinfo.Uid),
                    new MySqlParameter(ParamCouponName,couponinfo.CouponName),
                    new MySqlParameter(ParamAmount,couponinfo.Amount),
                    new MySqlParameter(ParamMinOrderMoney,couponinfo.MinOrderMoney),
                    new MySqlParameter(ParamExpiredTime,couponinfo.ExpiredTime),
                    new MySqlParameter(ParamState,couponinfo.State),
                    new MySqlParameter(ParamIsView,couponinfo.IsView)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CouponInfoDb</returns>
        public static CouponInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new CouponInfoDb
                {
                    Id = DbChange.ToString(dr["Id"]),
                    Uid = DbChange.ToString(dr["Uid"]),
                    CouponName = DbChange.ToString(dr["CouponName"]),
                    Amount = DbChange.ToInt(dr["Amount"],0),
                    MinOrderMoney = DbChange.ToInt(dr["MinOrderMoney"],0),
                    ExpiredTime = DbChange.ToDateTime(dr["ExpiredTime"],DateTime.MinValue),
                    State = DbChange.ToInt(dr["State"],0),
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
        /// <returns>List of CouponInfoDb</returns>
        public static List<CouponInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CouponInfoDb>(); 
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

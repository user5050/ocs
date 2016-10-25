using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Model.Db.Coupon;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/22
*/
namespace OneCoin.Service.Dal.Dal.Coupon
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    
    public partial class CouponInfoDal 
    {
        #region SQL
        //根据主键更新整行数据
        protected const string SqlUpdateStatusByPriKey = "update couponinfo set `State`=?State where `Id`=?Id;";
        //获取优惠券信息
        protected const string SqlGetUserCouponByPage = "select  * from couponinfo  where   Uid=?Uid order by  `IsView` desc limit ?Skip,?Take;";
        //更新过期的优惠券
        protected const string SqlUpdateExpriedCoupon = "update couponinfo set state=0 where (state = 1) and expiretime < now();";
        //更新优惠券查看状态
        protected const string SqlUpdateViewedCoupon = "update couponinfo set `IsView`=1 where Uid=?Uid;";
        // 删除过期优惠券 
        protected const string SqlRemoveLongExpiredCoupon = "delete from couponinfomation  where  state = 0  and ExpiredTime <= now();";
        //获取根据主键查询
        protected const string SqlGetById = "SELECT * FROM  `couponinfomation` WHERE Id=?Id;";

         #endregion

        #region 参数 
        protected const string ParamSkip = "?Skip";
        protected const string ParamTake = "?Take";  
        #endregion

        #region 更新优惠券状态

        /// <summary>
        /// 更新优惠券状态
        /// </summary>
        /// <param name="conn">更新对象</param>
        /// <param name="couponId"></param>
        /// <param name="state"></param>
        /// <returns>bool(true or false)</returns>
        public static bool UpdateStatusByPriKey(MySqlConnection conn, string couponId, int state)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,couponId),
                    new MySqlParameter(ParamState,state)
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlUpdateStatusByPriKey, true, param);

            return result > 0;
        }
        #endregion

        #region 更新过期优惠券状态

        /// <summary>
        /// 更新过期优惠券状态
        /// </summary>  
        /// <returns>bool(true or false)</returns>
        public static bool UpdateExpriedCoupon()
        {
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateExpriedCoupon, null);

            return result > 0;
        }
        #endregion

         
        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="couponinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn, CouponInfoDb couponinfo)
        {
            var param = GetInsertParams(couponinfo);
            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert, true, param);

            return result > 0;
        }
        #endregion

        public static List<CouponInfoDb> GetUserCouponByPage(string userId, int skip, int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,userId),
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetUserCouponByPage, param);

            return ConvertToObjects(dr);
        }
         
         
        public static void RemoveLongExpiredCoupon(DateTime expiretime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamExpiredTime,expiretime)
                };

            DbHelper.ExecuteReaderIdentity(ConntionStr, SqlRemoveLongExpiredCoupon, param);
        }
         

      
        /// <summary>
        /// 查询指定时间之前是否存在优惠券
        /// </summary>
        /// <param name="uid"></param> 
        /// <returns></returns>
        public static bool UpdateViewedCoupon(string uid)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,uid)
                };

            var result = DbHelper.ExecuteReaderIdentity(ConntionStr, SqlUpdateViewedCoupon, param);

            return result > 0;
        }

     }
}

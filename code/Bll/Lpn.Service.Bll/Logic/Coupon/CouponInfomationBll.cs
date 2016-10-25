using System.Collections.Generic;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Coupon;
using OneCoin.Service.Model.Db.Coupon;
using OneCoin.Service.Model.Entity.Coupon;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Bll.Logic.Coupon
{
    public class CouponInfoBll  : BllBase
    {
        #region 获取优惠券列表

        /// <summary>
        /// 获取优惠券列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static List<CouponInfoDb> GetByUsers(string userId, int skip, int take)
        {
            var data= CouponInfoDal.GetUserCouponByPage(userId, skip, take);

            // 设置优惠券已查看
            CouponInfoDal.UpdateViewedCoupon(userId);


            return data;
        }
        
        #endregion

        #region internal

     
        /// <summary>
        /// 更新优惠券状态 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="couponId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        internal static bool UpdateStatusByPriKey(MySqlConnection conn, string couponId, int state)
        {
            if (string.IsNullOrEmpty(couponId)) return false;

            return CouponInfoDal.UpdateStatusByPriKey(conn, couponId, state);
        }

        /// <summary>
        /// 设置优惠券已使用
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="couponId"></param>
        /// <returns></returns>
        internal static bool SetUsed(MySqlConnection conn, string couponId)
        {
            if (string.IsNullOrEmpty(couponId)) return false;

            return CouponInfoDal.UpdateStatusByPriKey(conn, couponId, (int)CouponState.Used);
        }

           

        /// <summary>
        /// 获取优惠券金额
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns></returns>
        internal static int GetCouponMoney(string couponId)
        {
            if (string.IsNullOrEmpty(couponId)) return 0;

            var data = CouponInfoDal.GetByPriKey(couponId);

            return data != null ? data.Amount : 0;
        }
         

        internal static bool Save(MySqlConnection conn, CouponInfoDb data)
        {
            return CouponInfoDal.Insert(conn, data);
        }
         

        internal static CouponInfoDb GetById(string couponid)
        {
            return CouponInfoDal.GetByPriKey(couponid);
        }
         
        #endregion

        
    }
}

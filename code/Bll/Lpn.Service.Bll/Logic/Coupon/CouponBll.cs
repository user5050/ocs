using System;
using System.Linq;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Coupon;
using OneCoin.Service.Model.Extension.Coupon;
using OneCoin.Service.Model.Result;

namespace OneCoin.Service.Bll.Logic.Coupon
{
    public class CouponBll : BllBase
    {
        #region 获取优惠券
         
        /// <summary>
        /// 获取优惠券
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto GetCouponList(string userId, int skip, int take)
        {
            var datas = CouponInfoBll.GetByUsers(userId, skip, take);
             
            return ResultDto.DefaultSuccess(datas.ToDtoV2());
        }
         
        #endregion
         
        #region 获取支付可用优惠券
  

        #region 优惠券是否满足使用场景

        /// <summary>
        /// 优惠券是否满足使用场景
        /// </summary>
        /// <param name="couponId"></param>
        /// <param name="orderMoney"></param>
        /// <returns></returns>
        internal static bool IsCanUse(string couponId, int orderMoney)
        {
            var coupon = CouponInfoBll.GetById(couponId);
            if (coupon == null) return false;

            if (coupon.MinOrderMoney > orderMoney) return false;
            if (coupon.ExpiredTime < DateTime.Now) return false;

            return coupon.State == 1;
        }
        #endregion

        #region 获取支付可用优惠券
        /// <summary>
        /// 获取支付可用优惠券
        /// </summary> 
        /// <param name="userId"></param> 
        /// <param name="orderMoney"></param>
        /// <returns></returns>
        public static ResultDto GetPaymentCanUse(string userId, int orderMoney)
        {
            var datas = CouponInfoBll.GetByUsers(userId, 0, 50);

            return ResultDto.DefaultSuccess(datas.Where(x => x.MinOrderMoney <= orderMoney && x.State == 1 && x.ExpiredTime > DateTime.Now).ToDtoV2());
        }

        #endregion

        #endregion 

        #region internal

        internal static void RemoveLongExpiredCoupon()
        {
            CouponInfoDal.RemoveLongExpiredCoupon(DateTime.Now.Date.AddDays(-2));
        }

        internal static bool UpdateExpriedCoupon()
        {
            return CouponInfoDal.UpdateExpriedCoupon();
        }
         
        #endregion
    }
}

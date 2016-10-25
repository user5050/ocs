using System;
using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Model.Db.Coupon;
using OneCoin.Service.Model.Dto.Response.Coupon;
using OneCoin.Service.Model.Entity.Coupon;
using OneCoin.Service.Model.Extension.Dto;

namespace OneCoin.Service.Model.Extension.Coupon
{
    public static class CouponExtension
    {

        #region 优惠券列表

        /// <summary>
        /// 优惠券列表
        /// </summary>
        /// <param name="datas"></param> 
        /// <returns></returns>
        public static List<ResCouponInfoDto> ToDtoV2(this IEnumerable<CouponInfoDb> datas)
        {
            return datas.Select(p => p.ToDtoV2()).ToList();
        }


        /// <summary>
        /// 优惠券列表
        /// </summary>
        /// <param name="data"></param> 
        /// <returns></returns>
        public static ResCouponInfoDto ToDtoV2(this CouponInfoDb data)
        {
            return new ResCouponInfoDto
                {
                    couponid = data.Id,
                    couponmoney = data.Amount,
                    expiretime = data.ExpiredTime.ToDateFormat(),
                    state = data.ExpiredTime < DateTime.Now ? CouponState.Invalid : (CouponState) data.State,
                    name = data.CouponName
                };
        } 
        #endregion

       
    }
}

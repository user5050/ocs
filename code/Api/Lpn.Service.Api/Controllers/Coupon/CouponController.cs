using System.Web.Mvc;
using OneCoin.Service.Api.Core;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Api.Filters;
using OneCoin.Service.Bll.Logic.Coupon;
using OneCoin.Service.Model.Dto.Request.Coupon;

namespace OneCoin.Service.Api.Controllers.Coupon
{ 
    public class CouponController : BaseController
    {  

        // 查看我的优惠券
        // GET: /Coupon/couponsofuser
        [UserAuthFilter]
        public ActionResult CouponsOfUser(ReqCouponsOfUserDto data)
        { 
            return new ClientResult(CouponBll.GetCouponList(UserId, data.Skip, data.Take));
        }


        // 查看可使用的优惠券
        // GET: /Coupon/couponscanuse
        [UserAuthFilter]
        public ActionResult CouponsCanUse(ReqCouponsOfUserDto data)
        {
            return new ClientResult(CouponBll.GetPaymentCanUse(UserId, data.OrderMoney));
        } 
    }
}

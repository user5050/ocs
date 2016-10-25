using System.Collections.Generic;

namespace OneCoin.Service.Model.Dto.Request.Coupon
{
    public class ReqSendCouponToUserDto
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public List<string> Mobiles { get; set; }


        /// <summary>
        /// 优惠券活动id
        /// </summary>
        public int CouponActivityId { get; set; }
    }
}

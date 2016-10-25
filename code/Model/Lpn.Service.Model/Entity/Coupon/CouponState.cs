
/*
 * 名称：用户优惠券状态
 * 作者：lee
 * 时间：2015/10/13
 * 说明：用户优惠券状态
 */

namespace OneCoin.Service.Model.Entity.Coupon
{
    public enum CouponState
    {
        /// <summary>
        /// 无效
        /// </summary>
        Invalid=0,

        /// <summary>
        /// 有效
        /// </summary>
        Valid=1, 

        /// <summary>
        /// 已使用
        /// </summary>
        Used = 2, 

    }
}

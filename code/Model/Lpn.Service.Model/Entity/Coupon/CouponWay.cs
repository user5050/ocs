/*
 * 名称：优惠券有效方式
 * 作者：lee
 * 时间：2015/10/13
 * 说明：优惠券有效方式
 */

namespace OneCoin.Service.Model.Entity.Coupon
{
    public enum CouponWay
    {
        /// <summary>
        /// 时间范围
        /// </summary>
        TimeRange=1,

        /// <summary>
        /// 有效的间隔天数
        /// </summary>
        DayInterval=2
    }
}

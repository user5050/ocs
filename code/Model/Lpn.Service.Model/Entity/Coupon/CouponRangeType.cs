/*
 * 名称：优惠券使用范围类型
 * 作者：lee
 * 时间：2016/04/26
 * 说明：范围类型
 */


namespace OneCoin.Service.Model.Entity.Coupon
{
    public enum CouponRangeType
    {
        /// <summary>
        /// 通用
        /// </summary>
        All= -1,

        /// <summary>
        /// h5活动(需要填写活动id)
        /// </summary>
        HtmlActivity = 1,

        /// <summary>
        /// 临停支付
        /// </summary>
        Pay = 2,

        /// <summary>
        /// 时段月租购买/续费
        /// </summary>
        PayMonthlyTime=3,


        /// <summary>
        /// 月租续费
        /// </summary>
        PayMonthly = 4, 

    }
}

/*
 * 名称：优惠券停车场限制类型(-1不限制1指定停车场2只在优惠券获得的停车场使用)
 * 作者：lee
 * 时间：2016/04/26
 * 说明：停车场限制类型
 */


namespace OneCoin.Service.Model.Entity.Coupon
{
    public enum CouponParkLimitType
    {
        /// <summary>
        /// 通用
        /// </summary>
        All= -1,

        /// <summary>
        /// 指定停车场(多个)
        /// </summary>
        LimitPark = 1,

        /// <summary>
        /// 只在优惠券获得的停车场使用
        /// </summary>
        MatchSroucePark = 2,
        
        /// <summary>
        /// 停车场所在区域
        /// </summary>
        ParkArea=3
    }
}

/*
 * 名称：优惠券有效方式
 * 作者：lee
 * 时间：2015/10/13
 *      2016/04/26  lee 修改  增加了 14以后的类型  4,5,6类型将被废弃
 * 说明：优惠券有效方式
 */

namespace OneCoin.Service.Model.Entity.Coupon
{
    public enum CouponType
    {
        /// <summary>
        /// 注册成功
        /// </summary>
        Regist = 1,

        /// <summary>
        /// 完成找车
        /// </summary>
        FindCar = 2,

        /// <summary>
        /// 临停支付
        /// </summary>
        Pay=3,

        /// <summary>
        /// 充值少量金额(废弃)
        /// </summary>
        RechargeLessMoney=4,

        /// <summary>
        /// 充值大量金额(废弃)
        /// </summary>
        RechargeBigMoney=5,

        /// <summary>
        /// 充值100金额(废弃)
        /// </summary>
        RechargeBigMoney100 = 6,

        /// <summary>
        /// 充值(v2.0版本新增)
        /// </summary>
        Recharge = 14,

        /// <summary>
        /// 时段月租支付(v2.0版本新增)
        /// </summary>
        PayMonthlyTime = 15,

        /// <summary>
        /// 月租支付(v2.0版本新增)
        /// </summary>
        PayMonthly = 16,

        /// <summary>
        /// 推荐新人(v2.0版本新增)
        /// </summary>
        RecommendNew = 17,

        /// <summary>
        /// html网页活动(v2.0版本新增)
        /// </summary>
        HtmlActivity=18,

        /// <summary>
        /// 管理员发放 
        /// </summary>
        SendByAdmin = 99
    }
}
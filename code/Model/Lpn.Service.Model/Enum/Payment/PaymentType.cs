namespace OneCoin.Service.Model.Enum.Payment
{
    public enum PaymentType
    {
        /// <summary>
        /// 银联支付
        /// </summary>
        UnionPay = 0,

        /// <summary>
        /// 微信支付
        /// </summary>
        WeixinPay = 1,

        /// <summary>
        /// 支付宝支付
        /// </summary>
        AliPay = 2,

        /// <summary>
        /// 宜泊支付(账号余额支付)
        /// </summary>
        EPark = 3,

        
        /// <summary>
        /// 泊泊支付
        /// </summary>
        BoBoPay=4,

        /// <summary>
        /// 易支付
        /// </summary>
        BestPay = 5,

        /// <summary>
        /// 易支付手机版
        /// </summary>
        BestPayMobile = 6,

        /// <summary>
        /// 合作商支付
        /// </summary>
        Partner = 7,
    }
}

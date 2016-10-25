namespace Lpn.Proxy.BoBo.Api.Model.Request
{
    public class ReqCarInOrOutDto
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string carNumber { get; set; }

        /// <summary>
        /// 进场时间
        /// </summary>
        public string importTime { get; set; }

        /// <summary>
        /// 出厂时间
        /// </summary>
        public string exportTime { get; set; }

        /// <summary>
        /// 消费金额（单位为分）
        /// </summary>
        public string conAmount { get; set; }

        /// <summary>
        ///  1:现金支付，2:app支付
        /// </summary>
        public string paymentMethod { get; set; }
    }
}

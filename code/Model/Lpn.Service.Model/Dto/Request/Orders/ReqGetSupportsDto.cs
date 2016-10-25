using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Model.Dto.Request.Orders
{
    public class ReqGetSupportsDto
    {
        /// <summary>
        /// 停车场编号
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// 支付停车费 = 0,
        /// 账户充值 = 1,
        /// 支付月租 = 2,
        /// 租用车位 = 3,
        /// 自动缴费 = 4
        /// </summary>
        public PaymentPurpose Purpose { get; set; }
    }
}

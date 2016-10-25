using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Payment.Entity
{


    /// <summary>
    /// 支付查询传入的参数
    /// </summary>
    public class PurchaseQueryReq
    {
        public PaymentType PaymentType
        { set; get; }

        public PaymentPurpose Purpose 
        { set; get; }


        /// <summary>
        /// 是否微信App支付(区分公众号支付)
        /// </summary>
        public bool  IsWxApp{ set; get; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo
        { set; get; }

        /// <summary>
        /// 订单时间
        /// </summary>
        public string OrderTime
        { set; get; }

        /// <summary>
        /// 支付成功的回传流水号
        /// </summary>
        public string QN{ set; get; }


        public string ParkCode
        { set; get; }
        

        public PurchaseQueryReq()
        {
            this.PaymentType = PaymentType.UnionPay;
            this.OrderNo = "";
            this.OrderTime = "";
            this.QN = "";
        }
    }
}

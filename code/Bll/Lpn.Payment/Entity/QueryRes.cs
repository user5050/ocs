using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Payment.Entity
{
    /// <summary>
    /// 支付结果查询的反馈结果
    /// </summary>
    public class PurchaseQueryRes : PurchaseQueryReq
    {

        /// <summary>
        /// 成功=true,失败=false
        /// </summary>
        public bool Result
        { set; get; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg
        { set; get; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public float OrderMoney
        { set; get; }

        /// <summary>
        /// 订单描述
        /// </summary>
        public string OrderDesc
        { set; get; }

        /// <summary>
        /// 订单透传信息
        /// </summary>
        public string Reserved
        { set; get; }

        /// <summary>
        /// 支付目的
        /// </summary>
        public PaymentPurpose Purpose
        { set; get; }


        /// <summary>
        /// 支付失败，是否可用删除订单
        /// </summary>
        public bool IsCanDelOrder
        { set; get; }

        public PurchaseQueryRes()
            : base()
        {
            this.OrderMoney = 0;
            this.OrderDesc = "";
            this.Reserved = "";
            this.Result = false;
            this.ErrMsg = "";
            this.Purpose = PaymentPurpose.支付停车费; 
 
        }

        public override string ToString()
        {
            return string.Format("Result:{0};OrderNo:{1};OrderTime:{2};OrderMoney:{3};ErrMsg:{4};Purpose:{5};Qn:{6}",
                Result.ToString(),
                OrderNo,
                OrderTime,
                OrderMoney,
                ErrMsg,
                Purpose.ToString(),
                QN
                );
        }

    }
}

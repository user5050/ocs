namespace OneCoin.Service.Model.Entity.Payment
{
    public class PurchaseNotify
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo
        { set; get; }
         
 
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description
        { set; get; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderMoney
        { set; get; }
         
         
        /// <summary>
        /// 支付成功反馈的流水号
        /// </summary>
        public string Qn
        { set; get; }
    }
}

using System;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Model.Entity.Payment
{
    /// <summary>
    /// 撤销的订单对象
    /// </summary>
    public class CanceledPaymentInfo
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo
        { set; get; }

        /// <summary>
        /// 是否微信App支付(区分公众号支付)
        /// </summary>
        public bool IsWxApp { set; get; }

        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime OrderTime
        { set; get; }
         
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderMoney
        { set; get; }

        /// <summary>
        /// 停车场编码
        /// </summary>
        public string ParkCode
        { set; get; }
 
    
        /// <summary>
        /// 支付成功时存储的流水号
        /// </summary>
        public string qn
        { set; get; }

        /// <summary>
        /// 撤销成功的订单号
        /// </summary>
        public string CancelOrderNo
        { set; get; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MerId { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// 支付目的
        /// </summary>
        public PaymentPurpose Purpose { get; set; }

        
    }
}

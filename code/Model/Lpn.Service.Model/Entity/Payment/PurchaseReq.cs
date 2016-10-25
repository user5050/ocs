using System;
using OneCoin.Service.Model.Enum.Payment;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Entity.Payment
{ 
    public class PurchaseReq
    {
        /// <summary>
        /// 成功=1,失败=0
        /// </summary>
        public int Result
        { set; get; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg
        { set; get; }

        public PaymentType PaymentType
        { set; get; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [JsonProperty("orderno")]
        public string OrderNo
        { set; get; }

        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime OrderTime
        { set; get; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description
        { set; get; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public int OrderMoney
        { set; get; }

        /// <summary>
        /// 停车场编码
        /// </summary>
        public string ParkCode
        { set; get; }

        /// <summary>
        /// 停车场名称
        /// </summary>
        public string ParkName
        { set; get; }

        /// <summary>
        /// 入场时间
        /// </summary>
        public DateTime EntranceTime
        { set; get; }

        /// <summary>
        /// 离场时间
        /// </summary>
        public DateTime ExitTime
        { set; get; }

        /// <summary>
        /// 对应车牌
        /// </summary>
        public string CarNo
        { set; get; }

        public string UserId
        { set; get; }

        /// <summary>
        /// 支付目的
        /// </summary>
        public PaymentPurpose Purpose
        { set; get; }


        /// <summary>
        /// 支付用途
        /// </summary>
        public PaymentSubPurpose SubPurpose
        { set; get; }

        /// <summary>
        /// 支付成功反馈的流水号
        /// </summary>
        public string Qn
        { set; get; }

        /// <summary>
        /// 月租车到期日期
        /// </summary>
        public DateTime TillDate
        { set; get; }

        /// <summary>
        /// 续费几个月
        /// </summary>
        public int RenewalMonths
        { get; set; }

        /// <summary>
        /// vip续费几个月
        /// </summary>
        public int RenewalMonthsVip
        { get; set; }
      
        public int WxpayType
        {
            get;
            set;
        }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public int CouponMoney { get; set; }


        /// <summary>
        /// 停车场已经抵扣的金额(对账使用)
        /// </summary>
        public int DeduMoney { get; set; }

        /// <summary>
        /// 停车场抵扣券ID
        /// </summary>
        public string DeduId { get; set; }

        /// <summary>
        /// 应收金额
        /// </summary>
        public int TotalMoney { get; set; }

        /// <summary>
        /// 优惠券ID
        /// </summary>
        public string CouponId { get; set; }

        /// <summary>
        /// 公众号OpenId
        /// </summary>
        public string OpenId { get; set; }


        /// <summary>
        /// 客户端类型
        /// </summary>
        public int ClientType { get; set; }
         

        /// <summary>
        /// 商户号
        /// </summary>
        public string MerId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string SaleId { get; set; }

        /// <summary>
        /// 时段月租时段模式
        /// </summary>
        public int MonthlySort { get; set; }

        /// <summary>
        /// 合作商ID
        /// </summary>
        public string PartnerId { get; set; }
  
        /// <summary>
        /// goods_tag商品标记(微信有效)
        /// </summary>
        public string ExtreGoodsTag { get; set; }


        /// <summary>
        /// 活动id
        /// </summary>
        public string ActivityId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string ActivityName { get; set; }

        /// <summary>
        /// 支付返回地址
        /// </summary>
        public string MerchantUrl { get; set; }

        /// <summary>
        /// 客户端ip
        /// </summary>
        public string ClientIp { get; set; }

        public int Extre { get; set; }

        #region 会员vip

        public int IsVip { get; set; }

        /// <summary>
        /// VIP费用
        /// </summary> 
        public double VipMoney { get; set; }

        /// <summary>
        /// vip月租车到期日期
        /// </summary>
        public DateTime TillDateVip{ set; get; }

        
        #endregion


    }
}

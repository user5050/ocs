using System;

namespace OneCoin.Service.Model.Dto.Request.Orders
{
    public class ReqGetPurchaseOrderNoDto : RequestBaseDto
    {
        /// <summary>
        /// 积分用户标识
        /// </summary>
        public string IntegralUserToken { get; set; }
        public string CardNo { get; set; }
        public string parkcode { get; set; }
        public string carno { get; set; }
        public decimal ordermoney { get; set; }
        public DateTime entertime { get; set; }
        public DateTime exittime { get; set; }
        public int paymenttype { get; set; } 
        public string orderdesc { get; set; }
        public string couponid { get; set; }
        public string openId { get; set; }
        public string DeductionId { get; set; }
        public decimal DeductionMoney { get; set; } 
    }
}

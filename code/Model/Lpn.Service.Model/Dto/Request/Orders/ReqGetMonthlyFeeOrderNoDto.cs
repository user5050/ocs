namespace OneCoin.Service.Model.Dto.Request.Orders
{
    public class ReqGetMonthlyFeeOrderNoDto : RequestBaseDto
    { 

        public int OrderMoney { get; set; }

        public int PaymentType { get; set; }
         
        public string OrderDesc { get; set; }  

        /// <summary>
        /// 优惠券ID
        /// </summary>
        public string CouponId { get; set; }

        public string GameNo { get; set; } 
    }
}

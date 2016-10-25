using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Model.Dto.Request.Coupon
{
    public class ReqCouponsCanPayDto : RequestBaseDto
    {
        public string ParkCode { get; set; }
        public string CarNo { get; set; }
        public string ActivityId { get; set; }
        public PaymentPurpose Purpose { get; set; }  
    }
}

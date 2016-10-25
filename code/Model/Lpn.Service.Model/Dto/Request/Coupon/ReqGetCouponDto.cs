using OneCoin.Service.Model.Entity.Coupon;

namespace OneCoin.Service.Model.Dto.Request.Coupon
{
    public class ReqGetCouponDto : RequestBaseDto
    { 
        public CouponType Type { get; set; }
        public string   OrderNo { get; set; }
        public string   ActivityId { get; set; }
        public decimal  Money { get; set; }
        public string   Mobile { get; set; }
        public string GiftId { get; set; }
        public string TempId { get; set; }
    }
}

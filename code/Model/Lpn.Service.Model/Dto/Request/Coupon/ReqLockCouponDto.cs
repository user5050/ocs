namespace OneCoin.Service.Model.Dto.Request.Coupon
{
    public class ReqLockCouponDto : RequestBaseDto
    {
        public string ParkCode { get; set; }
        public string Couponid { get; set; }
        public string Carno { get; set; }
    }
}

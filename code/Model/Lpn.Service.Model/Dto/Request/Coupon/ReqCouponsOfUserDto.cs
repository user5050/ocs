namespace OneCoin.Service.Model.Dto.Request.Coupon
{
    public class ReqCouponsOfUserDto : RequestBaseDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public int OrderMoney { get; set; }
    }
}

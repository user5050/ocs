namespace OneCoin.Service.Model.Dto.Request.Coupon
{
    public class ReqGetShareDto : RequestBaseDto
    {
        public string Username { get; set; }
        public string GroupId { get; set; }
        public string Nickname { get; set; }
        public string Headurl { get; set; }
    }
}

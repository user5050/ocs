namespace OneCoin.Service.Model.Dto.Request.Orders
{
    public class ReqGetChargeOrderNoDto : RequestBaseDto
    {
        public string chargeusername { get; set; }
        public int ordermoney { get; set; }
        public int paymenttype { get; set; } 
        public string orderdesc { get; set; }
        public string openId { get; set; } 

    }
}

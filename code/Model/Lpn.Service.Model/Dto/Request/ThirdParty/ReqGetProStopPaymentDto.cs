namespace OneCoin.Service.Model.Dto.Request.ThirdParty
{
    public class ReqGetProStopPaymentDto
    {
        public string ParkCode { get; set; }

        //入场截止时间
        public string EntranceTime { get; set; }

        //出场截止时间
        public string ExitTime { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; } 
    }
}

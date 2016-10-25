namespace OneCoin.Service.Model.Dto.Request.ThirdParty
{
    public class ReqGetRenewalDto
    {
        /// <summary>
        /// 停车场编号
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// 缴费时间（大于等于）
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 记录数
        /// </summary>
        public int Take { get; set; }
    }
}

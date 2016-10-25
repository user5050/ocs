namespace OneCoin.Service.Model.Dto.Request
{
    public class RequestBaseDto
    {
        public int totalmoney { get; set; }

        /// <summary>
        /// 支付返回地址
        /// </summary>
        public string MerchantUrl { get; set; }

        /// <summary>
        /// 客户端ip
        /// </summary>
        public string ClientIp { get; set; }

    }


    public class RequestPageDto
    {
        public int Skip { get; set; }

        public int Take { get; set; }
    }

    public class ReqIntIdDto
    {
        public int Id { get; set; } 
    }

    public class ReqStrIdDto
    {
        public string Id { get; set; }
    }
}

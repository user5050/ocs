using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Orders
{
    public class ResOrderDto
    {
        [JsonProperty("orderno")]
        public string OrderNo { get; set; }

        [JsonProperty("ordermoney")]
        public decimal OrderMoney { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("extre")]
        public object Extre { get; set; }
    }
}

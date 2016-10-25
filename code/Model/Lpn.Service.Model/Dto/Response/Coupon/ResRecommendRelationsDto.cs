using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Coupon
{
    public class ResRecommendRelationsDto
    {
        [JsonProperty("totalamount")]
        public int  TotalAmount { get; set; }

        [JsonProperty("logs")]
        public List<ResRecommendRelationsItemDto> Items { get; set; }
    }


    public class ResRecommendRelationsItemDto
    {
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }
    }
}

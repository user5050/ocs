using System.Collections.Generic;
using OneCoin.Service.Model.Dto.Response.Coupon;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Entity.Coupon
{
    public class GetGiftDto
    {
        [JsonProperty("coupons")]
        public List<ResCouponInfoDto> Coupons { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("giftid")]
        public string GiftId { get; set; }
        
    }
}

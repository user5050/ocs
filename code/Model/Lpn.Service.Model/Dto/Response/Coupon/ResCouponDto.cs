using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Coupon
{
    public class ResCouponDto
    {
        /// <summary>
        /// 礼包ID
        /// </summary> 
        [JsonProperty("giftid")]
        public string GiftId { get; set; }

        /// <summary>
        /// 优惠券面额
        /// </summary>
        [JsonProperty("money")]
        public decimal Money { get; set; }

        /// <summary>
        /// 礼包分享描述信息
        /// </summary>
        [JsonProperty("giftdesc")]
        public string GiftDesc { get; set; }

        /// <summary>
        /// 礼包展示url
        /// </summary>
        [JsonProperty("viewurl")]
        public string ViewUrl { get; set; }
    }
}

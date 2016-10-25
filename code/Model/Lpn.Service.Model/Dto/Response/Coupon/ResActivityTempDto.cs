using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Coupon
{
    public class ResActivityTempDto
    {
        /// <summary>
        /// 模板id
        /// </summary> 
        [JsonProperty("tempid")]
        public string TempId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 背景图片地址
        /// </summary>
        [JsonProperty("backgroundimgurl")]
        public string BackGroundImgUrl { get; set; }

        /// <summary>
        /// 优惠券活动id
        /// </summary>
        [JsonProperty("activityid")]
        public string RefActivityId { get; set; }

        /// <summary>
        /// 活动说明
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }
    }
}

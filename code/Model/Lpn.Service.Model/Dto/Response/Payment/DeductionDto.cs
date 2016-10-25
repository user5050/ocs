using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Payment
{
    public class DeductionDto
    {
        /// <summary>
        /// 抵扣ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 抵扣名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 抵扣金额
        /// </summary>
        [JsonProperty("money")]
        public double Money { get; set; }

        /// <summary>
        /// 抵扣类型(0金额抵扣1全抵扣)
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        [JsonProperty("timeout")]
        public string TimeOut { get; set; }
    }
}

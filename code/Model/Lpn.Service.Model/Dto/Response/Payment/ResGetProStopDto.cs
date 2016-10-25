using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Payment
{
    public class ResGetProStopDto
    {
        [JsonProperty("parkcode")]
        public string ParkCode { get; set; }
        [JsonProperty("parkname")]
        public string ParkName { get; set; }
        [JsonProperty("vehicleno")]
        public string VehicleNo { get; set; }
        [JsonProperty("entertime")]
        public string EnterTime { get; set; }
        [JsonProperty("exittime")]
        public string ExitTime { get; set; }
        [JsonProperty("alltime")]
        public int AllTime { get; set; }
        [JsonProperty("moneytime")]
        public int MoneyTime { get; set; }
        [JsonProperty("money")]
        public double Money { get; set; }
        [JsonProperty("freetime")]
        public int FreeTime { get; set; }
        [JsonProperty("enablecoupon")]
        public int EnableCoupon { get; set; }
        [JsonProperty("paysupports")]
        public List<int> PaySupports { get; set; }
        [JsonProperty("deductions")]
        public List<DeductionDto> Deductions { get; set; }
        [JsonProperty("carinimgid")]
        public string CarInImgId { get; set; }
        [JsonIgnore]
        public string PartnerId { get; set; }
    }
}

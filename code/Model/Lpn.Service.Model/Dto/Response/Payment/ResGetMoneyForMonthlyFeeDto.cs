using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Payment
{
    public class ResGetMoneyForMonthlyFeeDto
    {
        [JsonProperty("parkcode")]
        public string ParkCode { get; set; }

        [JsonProperty("parkname")]
        public string ParkName { get; set; }

        [JsonProperty("vehicleno")]
        public string VehicleNo { get; set; }

        [JsonProperty("money")]
        public double Money { get; set; }

        [JsonProperty("tilldate")]
        public string TillDate { get; set; }

        [JsonProperty("renewaldate")]
        public string RenewalDate { get; set; }

        [JsonProperty("renewalmonths")]
        public int RenewalMonths { get; set; }

        [JsonProperty("renewalmonthsvip")]
        public int RenewalMonthsVip { get; set; }

        [JsonProperty("paysupports")]
        public List<int> PaySupports { get; set; }

        /// <summary>
        /// 是否社区停车场
        /// </summary>
        [JsonProperty("isvippark")]
        public int IsVipPark { get; set; }

        /// <summary>
        /// 是否会员
        /// </summary>
        [JsonProperty("isvip")]
        public int IsVip { get; set; }

        /// <summary>
        /// Vip到期
        /// </summary>
        [JsonProperty("viptilldate")]
        public string VipTillDate { get; set; }

        /// <summary>
        /// VIP费用
        /// </summary>
        [JsonProperty("vipmoney")]
        public double VipMoney { get; set; }
         
         
        /// <summary>
        /// 是否已试用
        /// </summary>
        [JsonProperty("isviptryout")]
        public bool IsVipTryOut { get; set; }
 
     
        /// <summary>
        /// 会员缴费描述
        /// </summary>
        [JsonProperty("vipdesc")]
        public string VipDesc { get; set; }
    }
}

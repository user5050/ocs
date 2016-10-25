using System;
using OneCoin.Service.Model.Entity.Coupon;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Coupon
{
    public class ResCouponInfoDto
    {
        public string couponid { get; set; }
        public decimal couponmoney { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }

        public string parkname { get; set; }

        public string expiretime { get; set; }
        public string starttime { get; set; }
        

        [JsonProperty("lockbycarno", NullValueHandling = NullValueHandling.Ignore)]
        public string lockbycarno { get; set; }

        public CouponState state { get; set; }

        [JsonProperty("viewed",NullValueHandling = NullValueHandling.Ignore)]
        public int? viewed { get; set; } 
    }
}

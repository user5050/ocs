using System.Collections.Generic;
using OneCoin.Service.Model.Entity.Config;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Model.Entity.Partnerpay
{
    public class PartnerpayControlDto
    {
        /// <summary>
        /// 停车场编号
        /// </summary>
        public string ParkCode { get; set; }
         

        /// <summary>
        /// 配置信息
        /// </summary>
        public Dictionary<PaymentType,PayConfig> Configs { get; set; }

        /// <summary>
        /// 支持的支付平台
        /// </summary>
        public List<int> SupportPlatform { get; set; }
    }
}

using System;
using System.Collections.Generic;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Model.Entity.Payment
{
    public class CallBackPaymentInfo
    {
        /// <summary>
        /// 停车场编号
        /// </summary>
        public String ParkCode { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public PaymentType Type { get; set; }

        /// <summary>
        /// 支付目的
        /// </summary>
        public PaymentPurpose Purpose { get; set; }

        /// <summary>
        /// 回传的参数
        /// </summary>
        public IDictionary<String, String> Param { get; set; }
    }
}

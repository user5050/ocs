using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lpn.Proxy.BoBo.Api.Model.Request
{
    public class ReqofflinePayDto
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string carNumber { get; set; }

        /// <summary>
        /// 是否线下缴费（1：是，0：否）
        /// </summary>
        public string linepayment { get; set; }


        /// <summary>
        /// 消费金额（单位为分）
        /// </summary>
        public string conAmount { get; set; }
         
 
    }
}

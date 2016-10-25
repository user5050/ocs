using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCoin.Payment.Plugins.BestPay.Core.Res
{
    public class ResCreateTimeStamp
    {
           /// <summary>
            /// 
            /// </summary>
            public bool Success { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Result { get; set; }


            public string errorCode { get; set; }

            public string errorMsg { get; set; }
    }
}

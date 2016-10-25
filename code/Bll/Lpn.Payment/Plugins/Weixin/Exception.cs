using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCE.Payment.Plugins.Weixin
{
    public class WxPayException : Exception
    {
        public WxPayException(string msg)
            : base(msg)
        {

        }
    }
}

using System;

namespace Lpn.Payment.Plugins.WeixinApp
{
    public class WxPayException : Exception
    {
        public WxPayException(string msg)
            : base(msg)
        {

        }
    }
}

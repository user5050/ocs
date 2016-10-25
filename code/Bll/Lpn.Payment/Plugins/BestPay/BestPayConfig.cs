using System;
using System.Configuration;

namespace OneCoin.Payment.Plugins.BestPay
{
    public class BestPayConfig
    { 
        public const string PayWebUrl = "https://webpaywg.bestpay.com.cn/payWeb.do";
        public const string CreateTimeStampUrl = "https://webpaywg.bestpay.com.cn/createTimeStamp.do";
        public const string CommOrderQueryUrl = "https://webpaynotice.bestpay.com.cn/commorderQuery.do";
        public const string PayRefundUrl = "https://webpaywg.bestpay.com.cn/refund/commonRefund";//普通退款

        //支付成功回调的URL
        public static String BackmerchantUrl
        {
            get { return string.Format("{0}{1}", ConfigurationSettings.AppSettings["paymentFeedbackUrl"], "BestPayCallBack"); }
        }
    }
}

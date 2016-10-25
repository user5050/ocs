using System;
using System.Configuration;

namespace PCE.Payment.Plugins.Weixin
{
    /**
    * 	配置账号信息
    */
    public class WxPayConfig : WxPayConfigBase
    {
        //=======【基本信息设置】=====================================
        /* 微信公众号信息配置
        * APPID：绑定支付的APPID（必须配置）
        * MCHID：商户号（必须配置）
        * KEY：商户支付密钥，参考开户邮件设置（必须配置）
        * APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
        */


        public const string SSLCERT_PATH = "cert/apiclient_cert.p12";
        public const string SSLCERT_PASSWORD = "1233410002"; 
    }


    public class WxAppPayConfig : WxPayConfigBase
    {
        //=======【基本信息设置】=====================================
        /* 微信App信息配置
        * APPID：绑定支付的APPID（必须配置）
        * MCHID：商户号（必须配置）
        * KEY：商户支付密钥，参考开户邮件设置（必须配置）
        * APPSECRET：App帐号secert
        */
        //public const string APPID = "wx7c67eca9b231a6f0";
        //public const string MCHID = "1253950101";
        //public const string KEY = "7a931000cec312266cb0c87663602cab";
        //public const string APPSECRET = "1ff586d18158498e79978130431657e0";

       
        //public const string NOTIFY_URL = "http://test.wx.web.ebopark.com/example/ResultNotifyPage.aspx";


        //=======【证书路径设置】===================================== 
        /* 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
        */
        public const string SSLCERT_PATH = "d:/cert/testapiclient_cert.p12";
        public const string SSLCERT_PASSWORD = "1233410002"; 
         
    }

    public class WxPayConfigBase
    { 
         //=======【支付结果通知url】===================================== 

        /* 支付结果通知回调url，用于商户接收支付结果
        */
        //支付成功回调的URL
        public static String NOTIFY_URL
        {
            get { return string.Format("{0}{1}", ConfigurationSettings.AppSettings["paymentFeedbackUrl"], "WexinCallBack"); }

        }

        //=======【商户系统后台机器IP】===================================== 
        /* 此参数可手动配置也可在程序中自动获取
        */
        public const string IP = "211.149.218.205";


        //=======【代理服务器设置】===================================
        /* 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
        */
        //public const string PROXY_URL = "http://10.152.18.220:8080";
        public const string PROXY_URL = "http://10.152.18.220:8080";
        //=======【上报信息配置】===================================
        /* 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
        */
        public const int REPORT_LEVENL = 1;

        //=======【日志级别】===================================
        /* 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
        */
        public const int LOG_LEVENL = 3;
    }
}
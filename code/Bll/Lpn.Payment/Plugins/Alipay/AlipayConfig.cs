using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.3
    /// 日期：2012-07-05
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 
    /// 如何获取安全校验码和合作身份者ID
    /// 1.用您的签约支付宝账号登录支付宝网站(www.alipay.com)
    /// 2.点击“商家服务”(https://b.alipay.com/order/myOrder.htm)
    /// 3.点击“查询合作者身份(PID)”、“查询安全校验码(Key)”
    /// </summary>
    public class Config
    {
        #region 字段
        private static object _lock = new object();
        private static string partner = "";
        private static string private_key = "";
        private static string public_key = "";
        private static string input_charset = "";
        private static string sign_type = "";
        private static string notify_url = "";
        private static string singleQueryService = "";
        private static string key = "";
        private static string cancel_notify_url = "";
        private static string querySign_Type = "";
        #endregion

        static Config()
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //合作身份者ID，以2088开头由16位纯数字组成的字符串
            //partner = "2088511496515591";// 
            //TODO partner = "2088021125505184";
            //交易安全检验码，由数字和字母组成的32位字符串
            //key = "k4f7kpo64y2dvd88bot18bpjikkjm6bi";//fa4epdcwgea8b0ghfi89y6wiwestnhp8 
            //TODO key = "fa4epdcwgea8b0ghfi89y6wiwestnhp8";
            //商户的私钥
           // private_key = @"MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBALDQVMc5Fg0vHdQw0fNvProWrG2wmjEe1Jtwwq42jQVfheYnkm4lBTW9MFiS9FDDPqQH7YT7dh87OMN9JHMrz3NWMtSk52Bl1yaCvKrxZ84+IUaqZpY51kiio3g3Y5WiEVryf4hXeVZhWU7Gz0MVDYtPjDqKLAWp8Op91EP7lfpBAgMBAAECgYAs15k4sXyrOVDaWMtWbtc8wLVYWFqyrHwFNBLbthAL1c8SsOSNNKxela2mORbnSK0hUrVlbZTmlNFvmtRctTa2QIJlXBdFzDds+OBjmSzYB88xOYMsNk3O5gXdua9WVRKS/S0owadCcd6QSds5vDKAjN3igmndGh8b/qco2dhiwQJBAOG560atJdu1H/jiJM5Y7tk5YlHajZKBpnDVGBbKhY0au66cblmpBq/FCTk4z33GRabfbU9gR20ahLCw3Tg2lNkCQQDIhw2GYvwPixixapLN5HuMChWXXdDn3ZJJY/sgaYAkWgL3rLuYIM08Kwaoz5WncnLIGqzZgoNa8g7n38cqXQ+pAkBF17b6uVx7bMGlyqNEzbOptt27IfqoGEGdq/G2K5fDH0BvOKvURj5xaHAAKpnY+t5WUc+Kvemb0pa37SGl4Q2RAkEAidbTxDGcZC7P/XxthxvslPmFl/PEGu3ilZIlWEVM8S/yZD+W/95kVVyaCkYO7/gq0EQN1sHw+v3yow7ev88SaQJARbiWBmOZg8ztZN1iFeA/cL19AoAE8CbRWBSRNg+HO4LFVnoS4lt0o/blKL3bRUsPeCQy7txhv31J5nGnad2sdQ==";
            //TODO private_key = @"MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAOqMaC71ZmCwJDYNyE0xJ+DNbS9pvxrRvgCX1DSDmmKsLRIic2Ejw7Lbbn/YXwMUiwrnh88Wk8FItkS6pfcC9bwcyCabB8Hk6tPLe2n+wZmlNRECiucMXyoDj6hG9SblRcibU95faeQVeWDMYt7IVIp8PU/1zkO2vrIVQwxdguw3AgMBAAECgYAWVfKh7iqmsH9ySlO1ziWPCeEI79gMFMc0RUEnExVDqkPMg01bhc1gHfdi41cA8xbenffX572AXY1F9ERTxotiBOuUJEKIuEPmVEi87tIAJLy2LVyAGQR6kY3DvSafLWAmXWCtyoJAXGEP93Ts+ypGSpyuFMl0GpBPXBxQJaGgUQJBAPc9GkYCYWF0cpfjZPFSBLiKb0WU7RH6hI1EL+Ff+FO86blu/C8sujwPp74/ItO8Hq2jSpuKFOYbLOH+1RNQ+pkCQQDy3C5s8svT4Bo7I3nFFLnaNsGl4V23GSWvtTSYg30+QKWOn6Lt6MrnwJZKcSkFfBlnhZsilN8yP0XZfTjPT69PAkAyxTdp/P8mVhVaH3YRIDib9MGY1lZAhONHZyM18tE50OdmDuZ2gYbU4podtTVfqZfbLFcbzaUxA4+Z8QysZMqxAkEAgv4aGG+5WzXUUDOpWZD9UeMY/jUZzEnHFwgBL4Y0xqAt7EjUo8hdsTUim1KAEtJGDZ11+Ogdn0ebkFzHiKJtZwJBAOo6zRxKgONMBggNXXAX0/1IPNevLYAoZkWbXFJgnQ3w4dGwAE5g/b0syK/WZlv9jLVN6Zbb8qaaVWFIDIcBGXQ=";


            //商户公钥（已上传到支付宝平台）
            /*
             MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB
             */

            //支付宝的公钥，无需修改该值
            public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";
                         //MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDqjGgu9WZgsCQ2DchNMSfgzW0vab8a0b4Al9Q0g5pirC0SInNhI8Oy225/2F8DFIsK54fPFpPBSLZEuqX3AvW8HMgmmwfB5OrTy3tp/sGZpTURAornDF8qA4+oRvUm5UXIm1PeX2nkFXlgzGLeyFSKfD1P9c5Dtr6yFUMMXYLsNwIDAQAB



            //单订单查询服务名
            singleQueryService = "single_trade_query";


            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



            //字符编码格式 目前支持 gbk 或 utf-8
            input_charset = "utf-8";

            //签名方式，选择项：RSA、DSA、MD5
            sign_type = "RSA";

            //查询使用的签名方式
            querySign_Type = "MD5";
        }

        #region 属性

        /// <summary>
        /// 获取或设交易安全校验码
        /// </summary>
        public static string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 单订单查询服务名
        /// </summary>
        public static string SingleQueryService
        { get { return singleQueryService; } }


        //支付成功回调的URL
        public static String Notify_URL
        {
            get
            {

                if (notify_url.Equals(""))
                {
                    lock (_lock)
                    {
                        notify_url = string.Format("{0}{1}", ConfigurationSettings.AppSettings["paymentFeedbackUrl"], "AlipayCallBack");
                    }
                }

                return notify_url;
            }

        }

        public static String Cancel_Notify_URL
        {
            get
            {

                if (cancel_notify_url.Equals(""))
                {
                    lock (_lock)
                    {
                        cancel_notify_url = string.Format("{0}{1}", ConfigurationSettings.AppSettings["paymentFeedbackUrl"], "AlipayCancelCallBack");
                    }
                }

                return cancel_notify_url;
            }
        
        }


        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public static string Partner
        {
            get { return partner; }
            set { partner = value; }
        }

        /// <summary>
        /// 获取或设置商户的私钥
        /// </summary>
        public static string Private_key
        {
            get { return private_key; }
            set { private_key = value; }
        }

        /// <summary>
        /// 获取或设置支付宝的公钥
        /// </summary>
        public static string Public_key
        {
            get { return public_key; }
            set { public_key = value; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public static string Input_charset
        {
            get { return input_charset; }
        }

        /// <summary>
        /// 获取签名方式
        /// </summary>
        public static string Sign_type
        {
            get { return sign_type; }
        }

        public static string QuerySign_Type
        {
            get { return querySign_Type; }
        }

        #endregion
    }
}
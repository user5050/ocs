using System;
using System.Configuration;

namespace Com.UnionPay.Upmp
{
    /// <summary>
    /// 类名：UpmpConfig
    /// 功能：配置类
    /// 版本：1.0
    /// 日期：2013-1-30
    /// 作者：中国银联UPMP团队
    /// 版权：中国银联
    /// 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己的需要，按照技术文档编写,并非一定要使用该代码。该代码仅供参考。
    /// </summary>
    public class UpmpConfig
    {
        private static object _lock = new object();

        private string _MER_BACK_END_URL = "";

        private string _MER_BACK_END_VoidURL = "";

        private string _TRADE_URL="";

        private string _QUERY_URL="";


        #region 字段
        // 版本号
        public String VERSION;

        // 编码方式
        public String CHARSET;
        
        // 商户代码
        public String MER_ID;

        // 异步回调通知URL
        public String MER_BACK_END_URL
        {
            get {

                if (_MER_BACK_END_URL.Equals(""))
                {
                    lock (_lock)
                    {
                        _MER_BACK_END_URL = string.Format("{0}{1}", ConfigurationSettings.AppSettings["paymentFeedbackUrl"], "UnionPayCallBack");
                    }
                }

                return _MER_BACK_END_URL;
            }
        
        }

        /// <summary>
        /// 撤费异步回调通知URL
        /// </summary>
        public String MER_BACK_END_VoidURL
        {
            get
            {

                if (_MER_BACK_END_VoidURL.Equals(""))
                {
                    lock (_lock)
                    {
                        _MER_BACK_END_VoidURL = string.Format("{0}{1}", ConfigurationSettings.AppSettings["paymentFeedbackUrl"], "UnionPayCanelCallBack");
                    }
                }

                return _MER_BACK_END_VoidURL;
            }

        }


       /// <summary>
       /// 订单流水号生成提交URL
       /// </summary>
       public string  TRADE_URL
       {
          get{
            if(_TRADE_URL.Equals(""))
            {
               lock(_lock)
               {
                 _TRADE_URL= string.Format("{0}{1}", ConfigurationSettings.AppSettings["unionPayUrl"], "trade");
               }
            }
              return _TRADE_URL;
          }
       }

       /// <summary>
       /// 订单查询使用使用的URL
       /// </summary>
       public string QUERY_URL
       {
          get{
             if(_QUERY_URL.Equals(""))
             {
                lock(_lock)
                {
                    _QUERY_URL = string.Format("{0}{1}", ConfigurationSettings.AppSettings["unionPayUrl"], "query");
                }
             }
             return _QUERY_URL;
          }
       }
           
             



        // 返回URL
        public String MER_FRONT_RETURN_URL;

        // 前台通知URL
        public String MER_FRONT_END_URL;

        // 返回URL

        // 加密方式
        public String SIGN_TYPE;

        // 商城密匙，需要和银联商户网站上配置的一样
        public String SECURITY_KEY;

        // 成功应答码
        public String RESPONSE_CODE_SUCCESS = "00";


        // 签名
        public String SIGNATURE = "signature";

        // 签名方法
        public String SIGN_METHOD = "signMethod";

        // 应答码
        public String RESPONSE_CODE = "respCode";

        // 应答信息
        public String RESPONSE_MSG = "respMsg";

        #endregion

        private UpmpConfig()
        {
            /*
             商户名：宜泊科技
             商户号：898510175231001

              
            合作密钥（测试环境）：QTBkVHobpAZEWihJA9JIgs9heexcAvQW
            交易地址（测试环境）upmp.trade.url=https://101.231.204.80:5000/gateway/api/backTransReq.do
            查询地址（测试环境）upmp.query.url=https://101.231.204.80:5000/gateway/api/queryTrans.do

            合作密钥（正式环境）：O3LbiAGxGDMTFEa4AnTBErpWzbMpRJz6
            交易URL（正式环境）：https://mgate.unionpay.com/gateway/merchant/trade
            查询URL（正式环境）：https://mgate.unionpay.com/gateway/merchant/query

            */

            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //MER_ID = "880000000002278"; //测试用
             MER_ID = "898510148991064"; //生产用

           // SECURITY_KEY = "QTBkVHobpAZEWihJA9JIgs9heexcAvQW";   //测试用
            SECURITY_KEY = "O3LbiAGxGDMTFEa4AnTBErpWzbMpRJz6";  //正式环境
                        
            MER_FRONT_END_URL = "";                            

            VERSION = "2.1.4";
            CHARSET = "UTF-8";
            SIGN_TYPE = "MD5";

        }

        private static UpmpConfig _instance;

        /// <summary>
        /// 获取UpmpConfig单例
        /// </summary>
        /// <returns></returns>
        public static UpmpConfig GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UpmpConfig();
                    }
                }
            }

            return _instance;
        }
    }
}
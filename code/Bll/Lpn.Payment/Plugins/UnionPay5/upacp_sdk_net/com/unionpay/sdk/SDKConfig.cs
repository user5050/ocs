using System.Web.Configuration;

namespace upacp_sdk_net.com.unionpay.sdk{

    public class SDKConfig
    {
#if DEBUG
       private static string BaseUrl = "https://101.231.204.80:5000";
#else
        private static string BaseUrl = "https://gateway.95516.com"; 
#endif
         

        //private static string signCertPath = "D:\\ebapark\\certs\\acp_test_sign.pfx";  //功能：读取配置文件获取签名证书路径
        //private static string signCertPwd = "000000";//功能：读取配置文件获取签名证书密码
        //private static string validateCertDir = "D:\\ebapark\\certs\\";//功能：读取配置文件获取验签目录
        //public static string encryptCert = "D:\\ebapark\\certs\\acp_test_verify.cer";  //功能：加密公钥证书路径
        //public const string PUblicKey = "";


        private static string cardRequestUrl = BaseUrl + "/gateway/api/cardTransReq.do";  //功能：有卡交易路径;
        private static string appRequestUrl =  BaseUrl+"/gateway/api/appTransReq.do";  //功能：appj交易路径;
        private static string singleQueryUrl = BaseUrl + "/gateway/api/queryTrans.do"; //功能：读取配置文件获取交易查询地址
        private static string fileTransUrl = "https://101.231.204.80:5000";  //功能：读取配置文件获取文件传输类交易地址
        private static string frontTransUrl = BaseUrl + "/gateway/api/frontTransReq.do"; //功能：读取配置文件获取前台交易地址


        private static string backTransUrl = BaseUrl + "/gateway/api/backTransReq.do";//功能：读取配置文件获取后台交易地址
        private static string batTransUrl = BaseUrl + "/gateway/api/batchTrans.do";//功能：读取配批量交易地址

        private static string frontUrl = WebConfigurationManager.AppSettings["paymentFeedbackUrl"] + "UnionPayCallBack";//功能：读取配置文件获取前台通知地址
        private static string backUrl = WebConfigurationManager.AppSettings["paymentFeedbackUrl"] + "UnionPayCallBack";//功能：读取配置文件获取前台通知地址

        public static string CardRequestUrl
        {
            get { return SDKConfig.cardRequestUrl; }
            set { SDKConfig.cardRequestUrl = value; }
        }
        public static string AppRequestUrl
        {
            get { return SDKConfig.appRequestUrl; }
            set { SDKConfig.appRequestUrl = value; }
        }

        public static string FrontTransUrl
        {
            get { return SDKConfig.frontTransUrl; }
            set { SDKConfig.frontTransUrl = value; }
        }
        //public static string EncryptCert
        //{
        //    get { return SDKConfig.encryptCert; }
        //    set { SDKConfig.encryptCert = value; }
        //}


        public static string BackTransUrl
        {
            get { return SDKConfig.backTransUrl; }
            set { SDKConfig.backTransUrl = value; }
        }

        public static string SingleQueryUrl
        {
            get { return SDKConfig.singleQueryUrl; }
            set { SDKConfig.singleQueryUrl = value; }
        }

        public static string FileTransUrl
        {
            get { return SDKConfig.fileTransUrl; }
            set { SDKConfig.fileTransUrl = value; }
        }

        //public static string SignCertPath
        //{
        //    get { return SDKConfig.signCertPath; }
        //    set { SDKConfig.signCertPath = value; }
        //}

        //public static string SignCertPwd
        //{
        //    get { return SDKConfig.signCertPwd; }
        //    set { SDKConfig.signCertPwd = value; }
        //}

        //public static string ValidateCertDir
        //{
        //    get { return SDKConfig.validateCertDir; }
        //    set { SDKConfig.validateCertDir = value; }
        //}
        public static string BatTransUrl
        {
            get { return SDKConfig.batTransUrl; }
            set { SDKConfig.batTransUrl = value; }
        }
        public static string BackUrl
        {
            get { return SDKConfig.backUrl; }
            set { SDKConfig.backUrl = value; }
        }
        public static string FrontUrl
        {
            get { return SDKConfig.frontUrl; }
            set { SDKConfig.frontUrl = value; }
        }
    }
}
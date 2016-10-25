using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using OneCoin.Payment.Plugins.BestPayH5.H5ForM;
using OneCoin.Service.Helper.Http;

namespace Kulv.YCF.Payment.Wing.H5ForM
{
    public class H5Util : CryptTool
    {
        private readonly String[] hexDigits = { "0", "1", "2", "3", "4", "5",
            "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

        public H5Util()
        {
            ENV_URL = "https://capi.bestpay.com.cn"; // 生产地址
            ORDER_URL = "https://webpaywg.bestpay.com.cn/order.action"; //下单地址
        }

        public string ENV_URL
        {
            get;
            protected set;
        }

        public string ORDER_URL
        {
            get;
            protected set;
        }

        public String AESKey { get; private set; }

        public RsaKeyBO RsaKeyBO { get; private set; }

        public String AESEncryData { get; private set; }

        public String RSAEncryData { get; private set; }

        private CreateOrderAndPayParams OrderAndPayParams { get; set; }

        private class CreateOrderAndPayParams
        {
            public string ORDERSEQ { get; set; }
            public string ORDERREQTRANSEQ { get; set; }
            public string ORDERTIME { get; set; }
            public string ORDERAMOUNT { get; set; }
            public string PRODUCTID { get; set; }
            public string Description { get; set; }
            public string CURTYPE { get; set; }
            public string PackageName { get; set; }
            public string ATTACHAMOUNT { get; set; }
            public string UserPhone { get; set; }
            public string BEFOREMERCHANTURL { get; set; }
            public string BACKMERCHANTURL { get; set; }
            public string BUSITYPE { get; set; }
            public string SWTICHACC { get; set; }
            public string ORDERVALIDITYTIME { get; set; }
            public string SIGNTYPE { get; set; }
        }

        //初始化参数
        public H5Util InitParameters(string ORDERSEQ, string ORDERREQTRANSEQ, string ORDERTIME, string ORDERAMOUNT, string Description, string PackageName, string UserPhone,
            string BEFOREMERCHANTURL, string BACKMERCHANTURL, string ORDERVALIDITYTIME)
        {
            const String SWTICHACC = "false";
            const string BUSITYPE = "04";
            const string PRODUCTID = "04";
            const string CURTYPE = "RMB";
            const string ATTACHAMOUNT = "0.00";
            const string SIGNTYPE = "MD5";
            OrderAndPayParams = new CreateOrderAndPayParams();
            OrderAndPayParams.ORDERSEQ = ORDERSEQ;
            OrderAndPayParams.ORDERREQTRANSEQ = ORDERREQTRANSEQ;
            OrderAndPayParams.ORDERTIME = ORDERTIME;
            OrderAndPayParams.ORDERAMOUNT = ORDERAMOUNT;
            OrderAndPayParams.PRODUCTID = PRODUCTID;
            OrderAndPayParams.Description = Description;
            OrderAndPayParams.PackageName = PackageName;
            OrderAndPayParams.ATTACHAMOUNT = ATTACHAMOUNT;
            OrderAndPayParams.UserPhone = UserPhone;
            OrderAndPayParams.BEFOREMERCHANTURL = BEFOREMERCHANTURL;
            OrderAndPayParams.BACKMERCHANTURL = BACKMERCHANTURL;
            OrderAndPayParams.BUSITYPE = BUSITYPE;
            OrderAndPayParams.SWTICHACC = SWTICHACC;
            OrderAndPayParams.ORDERVALIDITYTIME = ORDERVALIDITYTIME;
            OrderAndPayParams.SIGNTYPE = SIGNTYPE;
            OrderAndPayParams.CURTYPE = CURTYPE;

            return this;
        }

        public H5Util Encrypt()
        {
            GetAESKey(32);
            GetPublicKey();
            
            AESEncryData = AES.EncryptWithIV(DictionaryToQuery(GetPayParams()), AESKey);
            RSAEncryData = RSA.SignData(AESKey, RsaKeyBO.PubKey);
            return this;
        }

        private Dictionary<string, string> GetPayParams()
        {
            //-----------------------------
            //设置支付参数
            //-----------------------------

            var payParameters = new Dictionary<string, string>
                {
                    {"SERVICE", SERVICE},
                    {"MERCHANTPWD", MERCHANTPWD},
                    {"MERCHANTID", MERCHANTID},
                    {"SUBMERCHANTID", ""},
                    {"ORDERSEQ", OrderAndPayParams.ORDERSEQ},
                    {"ORDERREQTRANSEQ", OrderAndPayParams.ORDERREQTRANSEQ},
                    {"ORDERTIME", OrderAndPayParams.ORDERTIME},
                    {"ORDERAMOUNT", OrderAndPayParams.ORDERAMOUNT},
                    {"PRODUCTID", OrderAndPayParams.PRODUCTID},
                    {"PRODUCTDESC", OrderAndPayParams.Description},
                    {"CURTYPE", OrderAndPayParams.CURTYPE},
                    {"SUBJECT", OrderAndPayParams.PackageName},
                    {"PRODUCTAMOUNT", OrderAndPayParams.ORDERAMOUNT},
                    {"ATTACHAMOUNT", OrderAndPayParams.ATTACHAMOUNT},
                    {"CUSTOMERID", OrderAndPayParams.UserPhone},
                    {"BEFOREMERCHANTURL", OrderAndPayParams.BEFOREMERCHANTURL},
                    {"BACKMERCHANTURL", OrderAndPayParams.BACKMERCHANTURL},
                    {"BUSITYPE", OrderAndPayParams.BUSITYPE},
                    {"SWTICHACC", OrderAndPayParams.SWTICHACC},
                    {"ATTACH", ""},
                    {"ORDERVALIDITYTIME", OrderAndPayParams.ORDERVALIDITYTIME},
                    {"WAPCHANNEL", ""},
                    {"SIGNTYPE", OrderAndPayParams.SIGNTYPE},
                    {"DIVDETAILS", ""},
                    {"ACCOUNTID", ""},
                    {"USERIP", ""},
                    {"tid", ""},
                    {"key_index", ""},
                    {"key_tid", ""}
                };
           

            var sourceStr = string.Format("SERVICE={0}&MERCHANTID={1}&MERCHANTPWD={2}&SUBMERCHANTID={3}&BACKMERCHANTURL={4}&ORDERSEQ={5}&ORDERREQTRANSEQ={6}&ORDERTIME={7}&ORDERVALIDITYTIME={8}&CURTYPE={9}&ORDERAMOUNT={10}&SUBJECT={11}&PRODUCTID={12}&PRODUCTDESC={13}&CUSTOMERID={14}&SWTICHACC={15}&KEY={16}",
              SERVICE, MERCHANTID, MERCHANTPWD, "", OrderAndPayParams.BACKMERCHANTURL, OrderAndPayParams.ORDERSEQ,
              OrderAndPayParams.ORDERREQTRANSEQ, OrderAndPayParams.ORDERTIME, OrderAndPayParams.ORDERVALIDITYTIME, OrderAndPayParams.CURTYPE, OrderAndPayParams.ORDERAMOUNT, OrderAndPayParams.PackageName, OrderAndPayParams.PRODUCTID, OrderAndPayParams.Description,
              OrderAndPayParams.UserPhone, OrderAndPayParams.SWTICHACC, MERCHANTkey);


            var sign = Md5Digest(sourceStr); //MAC校验域   默认为0，当加密方式为1时有意义，采用标准的MD5算法
            
            payParameters.Add("SIGN", sign);
            
            
            return payParameters;
        }

        public String CreateRequestUrl()
        {
            return ENV_URL + "/gateway.pay?platform=wap_3.0" + "&encryStr=" + HttpUtility.UrlEncode(AESEncryData) + "&keyIndex=" + RsaKeyBO.KeyIndex + "&encryKey=" + HttpUtility.UrlEncode(RSAEncryData);
        }

        public H5Util CreateOrder()
        {
            Dictionary<string, string> parameters = GetOrderParams();
            var orderResult = SendCreateOrder(parameters, ORDER_URL, Encoding.UTF8);
            //TODO:转化结果集
            if (String.IsNullOrEmpty(orderResult)) throw new Exception("翼支付下单失败，返回结果集不能为空");
            String[] resultArray = orderResult.Split('&');
            if (resultArray.Count() < 1) throw new Exception("翼支付下单失败，返回结果集格式不正确");
            //00 & 手机客户端下单成功     //1101 & 订单号或者流水号重复，请勿重复提交交易。
            if (resultArray[0] != "00" && resultArray[0] != "1101") throw new Exception("翼支付下单失败，订单未创建成功" + orderResult);
            return this;
        }

        private Dictionary<string, string> GetOrderParams()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MERCHANTID", MERCHANTID);
            //parameters.Add("SUBMERCHANTID", MERCHANTID);
            parameters.Add("ORDERSEQ", OrderAndPayParams.ORDERSEQ);
            parameters.Add("ORDERREQTRANSEQ", OrderAndPayParams.ORDERREQTRANSEQ);
            parameters.Add("ORDERREQTIME", OrderAndPayParams.ORDERTIME);
            parameters.Add("TRANSCODE", "01");
            parameters.Add("ORDERAMT", OrderAndPayParams.ORDERAMOUNT);
            parameters.Add("ORDERCCY", OrderAndPayParams.CURTYPE);
            parameters.Add("SERVICECODE", "05");
            parameters.Add("PRODUCTID", OrderAndPayParams.PRODUCTID);
            parameters.Add("PRODUCTDESC", OrderAndPayParams.Description);
            parameters.Add("LOGINNO", "");
            parameters.Add("PROVINCECODE", "");
            parameters.Add("CITYCODE", "");
            parameters.Add("DIVDETAILS", "");
            parameters.Add("ENCODETYPE", "1");
            parameters.Add("ATTACH", "");
            parameters.Add("requestSystem", "1");
            var mac = String.Format("MERCHANTID={0}&ORDERSEQ={1}&ORDERREQTRANSEQ={2}&ORDERREQTIME={3}&KEY={4}", MERCHANTID, OrderAndPayParams.ORDERSEQ, OrderAndPayParams.ORDERREQTRANSEQ, OrderAndPayParams.ORDERTIME, MERCHANTkey);
            var macSign = Md5Digest(mac);
            parameters.Add("MAC", macSign);
            return parameters;
        }

        /// <summary>
        /// http的基本post方法
        /// </summary>
        /// <param name="reqData">请求数据</param>
        /// <param name="url">URL地址</param>
        /// <param name="encoding">编码</param>
        /// <returns>服务器返回的数据</returns>
        private String SendCreateOrder(Dictionary<String, String> reqData, String reqUrl, Encoding encoding)
        {
            string postData = DictionaryToQuery(reqData);
            byte[] byteArray = encoding.GetBytes(postData);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(reqUrl);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = byteArray.Length;
            request.ServicePoint.Expect100Continue = false;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);

            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream(), encoding);
            String sResult = reader.ReadToEnd();

            requestStream.Close();
            reader.Close();
            webResponse.Close();
            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                return sResult;
            }
            else
            {
                string httpStatus = Enum.GetName(typeof(HttpStatusCode), webResponse.StatusCode);
                throw new Exception("翼支付下单失败，请求返回状态【httpStatus】：" + httpStatus);
            }
        }

        private static string DictionaryToQuery(Dictionary<string, string> query)
        {
            List<string> list = new List<string>();
            foreach (var item in query.Keys)
            {
                list.Add(item + "=" + query[item]);
            }

            return string.Join("&", list);
        }

        /**
        * 获取公钥
        *
        * @return 公钥json
        * @throws IOException
        */
        public void GetPublicKey()
        {
            var result = WebRequestUtil.PostAndResponse<PublicKeyData>(ENV_URL + "/common/interface", new { keyIndex = "", encryKey = "", encryStr = "", interCode = "INTER.SYSTEM.001" });
            if (!result.Success)
            {
                throw new Exception("翼支付获取公钥失败");
            }
            RsaKeyBO = result.Result;
        }

        public void GetAESKey(int length)
        {
            AESKey = Spanner.Join("12345678901234567890123456789012".ToCharArray(0,32).OrderBy(x=>Guid.NewGuid().GetHashCode()).ToList(),"");
        }

        public String Md5Digest(String mac)
        {
            return byteArrayToHexString(md5Digest(Encoding.GetEncoding("utf-8").GetBytes(mac)));
        }
        public String byteArrayToHexString(byte[] b)
        {
            StringBuilder resultSb = new StringBuilder();
            for (int i = 0; i < b.Length; i++)
            {
                resultSb.Append(byteToHexString(b[i]));
            }
            return resultSb.ToString();
        }

        private String byteToHexString(byte b)
        {
            int n = b;
            if (n < 0)
                n = 256 + n;
            int d1 = n / 16;
            int d2 = n % 16;
            return hexDigits[d1] + hexDigits[d2];
        }

        public byte[] md5Digest(byte[] macArray)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(macArray);

            return data;
        }
    }
}

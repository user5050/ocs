using System.Collections.Generic;
using System.Text;
using System;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace upacp_sdk_net.com.unionpay.sdk
{
    public class SDKUtil
    {

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <param name="pfx"></param>
        /// <param name="pfxPwd"></param>
        /// <returns></returns>
        public static bool Sign(Dictionary<string, string> data, Encoding encoding, string pfx, string pfxPwd)
        {
            //设置签名证书序列号 ？

            data["certId"] = CertUtil.GetSignCertId(pfx,pfxPwd);

            //将Dictionary信息转换成key1=value1&key2=value2的形式
            string stringData = CreateLinkString(data, true, false);

            string stringSign = null;

            byte[] signDigest = SecurityUtil.Sha1X16(stringData, encoding);

            string stringSignDigest = BitConverter.ToString(signDigest).Replace("-", "").ToLower();

            byte[] byteSign = SecurityUtil.SignBySoft(CertUtil.GetSignProviderFromPfx(pfx, pfxPwd), encoding.GetBytes(stringSignDigest));

            stringSign = Convert.ToBase64String(byteSign);

            //设置签名域值
            data["signature"] = stringSign;

            return true;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <param name="publicCer"></param>
        /// <returns></returns>
        public static bool Validate(Dictionary<string, string> data, Encoding encoding,string publicCer)
        {
            //获取签名
            string signValue = data["signature"];
            byte[] signByte = Convert.FromBase64String(signValue);
            data.Remove("signature");
            string stringData = CreateLinkString(data, true, false);
            byte[] signDigest = SecurityUtil.Sha1X16(stringData, encoding);
            string stringSignDigest = BitConverter.ToString(signDigest).Replace("-", "").ToLower();

            RSACryptoServiceProvider provider = CertUtil.GetValidateProviderFromPath(publicCer);
            if (null == provider)
            {
                return false;
            }
            return SecurityUtil.ValidateBySoft(provider, signByte, encoding.GetBytes(stringSignDigest));
        }

        /// <summary>
        /// 将字符串key1=value1&key2=value2转换为Dictionary数据结构。
        /// deprecated：为兼容原始sdk没加中文编码，遇到中文乱码请改调用parseQString。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Dictionary<string, string> CoverStringToDictionary(string str)
        {
            return parseQString(str, Encoding.UTF8);
        }

        /// <summary>
        /// 将字符串key1=value1&key2=value2转换为Dictionary数据结构。
        /// 这个故事告诉我们，应答报文不带url编码是一件无比蛋疼的事。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Dictionary<string, string> parseQString(string str, Encoding encoding)
        {
            var dictionary = new Dictionary<String, String>();
            int len = str.Length;
            var temp = new StringBuilder();
            char curChar;
            String key = null;
            bool isKey = true;
            bool isOpen = false;//值里有嵌套
            char openName = '\0'; //关闭符

            for (int i = 0; i < len; i++)
            {// 遍历整个带解析的字符串
                curChar = str[i];// 取当前字符
                if (isOpen)
                {
                    if (curChar == openName)
                    {
                        isOpen = false;
                    }
                    temp.Append(curChar);
                } 
                else if (curChar == '{')
                {
                    isOpen = true;
                    openName = '}';
                    temp.Append(curChar);
                }
                else if (curChar == '[')
                {
                    isOpen = true;
                    openName = ']';
                    temp.Append(curChar);
                }
                else if (isKey && curChar == '=')
                {// 如果当前生成的是key且如果读取到=分隔符
                    key = temp.ToString();
                    temp = new StringBuilder();
                    isKey = false;
                }
                else if (curChar == '&' && !isOpen)
                {// 如果读取到&分割符
                    putKeyValueToDictionary(temp, isKey, key, dictionary, encoding);
                    temp = new StringBuilder();
                    isKey = true;
                }
                else
                {
                    temp.Append(curChar);
                }
            }

            putKeyValueToDictionary(temp, isKey, key, dictionary, encoding);

            return dictionary;
 
        }


        private static void putKeyValueToDictionary(StringBuilder temp, bool isKey, String key, Dictionary<String, String> Dictionary, Encoding encoding)
        {
            if (isKey)
            {
                key = temp.ToString();
                if (key.Length == 0)
                {
                    throw new System.Exception("QString format illegal");
                }
                Dictionary[key] = "";
            }
            else
            {
                if (key.Length == 0)
                {
                    throw new System.Exception("QString format illegal");
                }
                //Dictionary[key] = HttpUtility.UrlDecode(temp.ToString(), encoding);
                Dictionary[key] = temp.ToString();
            }
        }

        public static string CreateAutoSubmitForm(string url, Dictionary<string, string> data, Encoding encoding)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendFormat("<meta http-equiv=\"Content-Type\" content=\"text/html; charset={0}\" />", encoding);
            html.AppendLine("</head>");
            html.AppendLine("<body onload=\"OnLoadSubmit();\">");
            html.AppendFormat("<form id=\"pay_form\" action=\"{0}\" method=\"post\">", url);
            foreach (KeyValuePair<string, string> kvp in data)
            {
                html.AppendFormat("<input type=\"hidden\" name=\"{0}\" id=\"{0}\" value=\"{1}\" />", kvp.Key, kvp.Value);
            }
            html.AppendLine("</form>");
            html.AppendLine("<script type=\"text/javascript\">");
            html.AppendLine("<!--");
            html.AppendLine("function OnLoadSubmit()");
            html.AppendLine("{");
            html.AppendLine("document.getElementById(\"pay_form\").submit();");
            html.AppendLine("}");
            html.AppendLine("//-->");
            html.AppendLine("</script>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            return html.ToString();
        }
        

        /**
        /// <summary>
        /// 将Dictionary内容排序后输出为键值对字符串,供打印报文使用
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PrintDictionaryToString(Dictionary<string, string> data)
        {
            //如果不加stringComparer.Ordinal，排序方式和java treemap有差异
            SortedDictionary<string, string> treeMap = new SortedDictionary<string, string>(StringComparer.Ordinal); 

            foreach (KeyValuePair<string, string> kvp in data)
            {
                treeMap.Add(kvp.Key, kvp.Value);
            }

            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> element in treeMap)
            {
                builder.Append(element.Key + "=" + element.Value + "&");
            }

            return builder.ToString().Substring(0, builder.Length - 1);
        }
        */

        /// <summary>
        /// 把请求要素按照“参数=参数值”的模式用“&”字符拼接成字符串
        /// </summary>
        /// <param name="para">请求要素</param>
        /// <param name="sort">是否需要根据key值作升序排列</param>
        /// <param name="encode">是否需要URL编码</param>
        /// <returns>拼接成的字符串</returns>
        public static String CreateLinkString(Dictionary<String, String> para, bool sort, bool encode)
        {
            List<String> list = new List<String>(para.Keys);

            if (sort)
                list.Sort(StringComparer.Ordinal);

            StringBuilder sb = new StringBuilder();
            foreach (String key in list)
            {
                String value = para[key];
                if (encode && value != null)
                {
                    try
                    {
                        value = HttpUtility.UrlEncode(value);
                    }
                    catch (Exception ex)
                    {
                        //LogError(ex);
                        return "#ERROR: HttpUtility.UrlEncode Error!" + ex.Message;
                    }
                }

                sb.Append(key).Append("=").Append(value).Append("&");

            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }

 

        /// <summary>
        /// pinblock 16进制计算
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>

        public static string PrintHexString(byte[] b)
        {

            var sb = new StringBuilder();

            for (int i = 0; i < b.Length; i++)
            {
                string hex = Convert.ToString(b[i] & 0xFF, 16);
                if (hex.Length == 1)
                {
                    hex = '0' + hex;
                }
                sb.Append("0x");
                sb.Append(hex + " ");
            }
            sb.Append("");
            return sb.ToString();
        }



        /// <summary>
        /// 密码pinblock加密
        /// </summary>
        /// <param name="card"></param>
        /// <param name="pwd"></param>
        /// <param name="encryptCert"></param>
        /// <returns></returns>
        public static string EncryptPin(string card, string pwd, string encryptCert)
        {

            /** 生成PIN Block **/
            byte[] pinBlock = SecurityUtil.pin2PinBlockWithCardNO(pwd, card);
            PrintHexString(pinBlock);


            var pc = new X509Certificate2(Encoding.ASCII.GetBytes(encryptCert));
            var p = new RSACryptoServiceProvider();

            p = (RSACryptoServiceProvider)pc.PublicKey.Key;

            byte[] enBytes = p.Encrypt(pinBlock, false);

            return Convert.ToBase64String(enBytes);


           // return SecurityUtil.EncryptPin(pwd, card, encoding);
        }


        /// <summary>
        /// 数据加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <param name="encryptCert"></param>
        /// <returns></returns>
        public static string EncryptData(string data, Encoding encoding, string encryptCert)
        {

            var pc = new X509Certificate2(Encoding.ASCII.GetBytes(encryptCert));
            var p = new RSACryptoServiceProvider();

            p = (RSACryptoServiceProvider)pc.PublicKey.Key;

            byte[] enBytes = p.Encrypt(encoding.GetBytes(data), false);

            return Convert.ToBase64String(enBytes);
        }
    }
}
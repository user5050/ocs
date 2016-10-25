using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Com.UnionPay.Upmp
{

    /// <summary>
    /// 类名：UpmpCore
    /// 功能：交易服务接口公用函数类
    /// 版本：1.0
    /// 日期：2013-1-30
    /// 作者：中国银联UPMP团队
    /// 版权：中国银联
    /// 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己的需要，按照技术文档编写,并非一定要使用该代码。该代码仅供参考。
    /// </summary>
    public class UpmpCore
    {
        public const String QSTRING_SPLIT = "&";
        public const String QSTRING_EQUAL = "=";

        /// <summary>
        /// 除去请求要素中的空值和签名参数
        /// </summary>
        /// <param name="para">请求要素</param>
        /// <returns>去掉空值与签名参数后的请求要素</returns>
        public static Dictionary<String, String> ParaFilter(Dictionary<String, String> para)
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            if (para == null || para.Count <= 0)
            {
                return result;
            }

            foreach (String key in para.Keys)
            {
                String value = para[key];
                if (value == null || value.Equals("") || String.Equals(key, UpmpConfig.GetInstance().SIGNATURE, StringComparison.CurrentCultureIgnoreCase)
                    || String.Equals(key, UpmpConfig.GetInstance().SIGN_METHOD, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                result[key] = value;
            }

            return result;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="req">需要签名的要素</param>
        /// <returns>签名结果字符串</returns>
        public static String BuildSignature(Dictionary<String, String> req)
        {
            // 除去数组中的空值和签名参数
            Dictionary<String, String> para = ParaFilter(req);
            String prestr = CreateLinkString(para, true, false);
            prestr = prestr + QSTRING_SPLIT + MD5(UpmpConfig.GetInstance().SECURITY_KEY);
            return MD5(prestr);
        }

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
                list.Sort();

            StringBuilder sb = new StringBuilder();
            foreach (String key in list)
            {
                String value = para[key];
                if (encode && value != null)
                {
                    try
                    {
                        value = HttpUtility.UrlEncode(value, Encoding.GetEncoding(UpmpConfig.GetInstance().CHARSET));
                    }
                    catch (Exception ex)
                    {
                        //LogError(ex);
                        return "#ERROR: HttpUtility.UrlEncode Error!" + ex.Message;
                    }
                }

                sb.Append(key).Append(QSTRING_EQUAL).Append(value).Append(QSTRING_SPLIT);

            }

            return sb.Length > 0 ? sb.Remove(sb.Length - 1, 1).ToString() :"";
            //return sb.Remove(sb.Length - 1, 1).ToString();
        }

        /// <summary>
        /// 解析应答字符串，生成应答要素
        /// </summary>
        /// <param name="str">需要解析的字符串</param>
        /// <returns>解析的结果map</returns>
        public static Dictionary<String, String> ParseQString(String str)
        {

            Dictionary<String, String> Dictionary = new Dictionary<String, String>();
            int len = str.Length;
            StringBuilder temp = new StringBuilder();
            char curChar;
            String key = null;
            bool isKey = true;

            for (int i = 0; i < len; i++)
            {// 遍历整个带解析的字符串
                curChar = str[i];// 取当前字符

                if (curChar == '&')
                {// 如果读取到&分割符
                    putKeyValueToDictionary(temp, isKey, key, Dictionary);
                    temp = new StringBuilder();
                    isKey = true;
                }
                else
                {
                    if (isKey)
                    {// 如果当前生成的是key
                        if (curChar == '=')
                        {// 如果读取到=分隔符
                            key = temp.ToString();
                            temp = new StringBuilder();
                            isKey = false;
                        }
                        else
                        {
                            temp.Append(curChar);
                        }
                    }
                    else
                    {// 如果当前生成的是value
                        temp.Append(curChar);
                    }
                }
            }

            putKeyValueToDictionary(temp, isKey, key, Dictionary);

            return Dictionary;
        }

        private static void putKeyValueToDictionary(StringBuilder temp, bool isKey, String key, Dictionary<String, String> Dictionary)
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

                Dictionary[key] = HttpUtility.UrlDecode(temp.ToString(), Encoding.GetEncoding(UpmpConfig.GetInstance().CHARSET));
            }
        }

        /// <summary>
        /// http的基本post方法
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postData">post的数据内容</param>
        /// <returns>服务器返回的数据</returns>
        public static string Post(string url, string postData)
        {
            #region 打印发送的串
            //LogControl.Instance.Debug("提交数据:\r\nURL:{0}\r\n{1}\r\n",url,postData);
            #endregion

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 30000;
                request.Method = "POST";
                request.ContentLength = byteArray.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(byteArray, 0, byteArray.Length);
                requestStream.Close();

                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
                String sResult = reader.ReadToEnd();
                reader.Close();

                #region 打印接收的串
                //LogControl.Instance.Debug("反馈数据:\r\n{0}\r\n", sResult);
                #endregion

                return sResult;
            }
            catch (Exception ex)
            {
                return "<error>" + ex.Message + "</error>";
            }

        }

        /// <summary>
        /// 计算MD5
        /// </summary>
        /// <param name="str">计算MD5的输入字符串</param>
        /// <returns>MD5后的结果</returns>
        public static string MD5(string str)
        {
            byte[] MD5Source = Encoding.GetEncoding(UpmpConfig.GetInstance().CHARSET).GetBytes(str);

            System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash_byte = get_md5.ComputeHash(MD5Source, 0, MD5Source.Length);
            string result = System.BitConverter.ToString(hash_byte);
            result = result.Replace("-", "");

            return result.ToLower();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Serialization;
using OneCoin.Service.Helper.TextAnalyze;

namespace OneCoin.Service.Helper.Http
{
    public class Spanner
    {
        public delegate int ItemWeight<T>(T item);

        /// <summary>
        ///  计算页总数
        /// </summary>
        /// <param name="rowTotal">记录总数</param>
        /// <param name="pageSize">页大小</param>
        /// <returns>页总数</returns>
        public static int TotalPage(int rowTotal, int pageSize)
        {
            try
            {
                return (int)Math.Ceiling((decimal)rowTotal / pageSize);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        ///  xhtml文本输出清理非法字符
        /// </summary>
        /// <returns></returns>
        public static string ClearToXHtmlOutput(string strContent)
        {
            if (string.IsNullOrEmpty(strContent))
                return strContent;

            //xml输出屏蔽非法字符
            strContent = ClearAllHtmlTag(strContent);

            return ClearToXmlOutput(strContent);
        }


        /// <summary>
        /// 滤除script引用和区块
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterScript(string str)
        {
            const string pattern = @"<script[\s\S]+</script *>";
            return Regex.Replace(str, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        ///  xml输出转义非法字符(br不转义)
        /// </summary>
        /// <returns></returns>
        public static string ClearToXmlOutput(string strContent)
        {
            if (string.IsNullOrEmpty(strContent))
                return strContent;

            //Xml非法字符转义
            strContent = Regex.Replace(strContent, "&(?!quot;)(?!apos;)(?!gt;)(?!amp;)(?!lt;)(?!nbsp;)", "&amp;", RegexOptions.IgnoreCase);

            strContent = Regex.Replace(strContent, @"<(?!br\/>)", "&lt;", RegexOptions.IgnoreCase);
            strContent = Regex.Replace(strContent, @"(?<!<br\/)>", "&gt;", RegexOptions.IgnoreCase);
            strContent = Regex.Replace(strContent, "'", "&apos;", RegexOptions.IgnoreCase);
            strContent = Regex.Replace(strContent, "\"", "&quot;", RegexOptions.IgnoreCase);
            strContent = Regex.Replace(strContent, "<br>", "<br/>", RegexOptions.IgnoreCase);

            return strContent;
        }

        /// <summary>
        /// xml 属性值过滤
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string ClearToXmlProperty(string strContent)
        {
            if (string.IsNullOrEmpty(strContent))
                return strContent;

            strContent = strContent.Replace("&nbsp;", " ");
            strContent = strContent.Replace("&", "");
            strContent = strContent.Replace("<", "");
            strContent = strContent.Replace("\"", "");


            return strContent;
        }

        #region  屏蔽xml中非法字符
        /// <summary>
        /// 屏蔽xml中非法字符(0x00-0x080x0b-0x0c0x0e-0x1f)
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string CleanToXmlOutput(string strContent)
        {
            //0x00 - 0x08
            //0x0b - 0x0c
            //0x0e - 0x1f
            var regex = new Regex("[\x00-\x08\x0b-\x0c\x0e-\x1f]", RegexOptions.IgnoreCase);

            return regex.Replace(strContent, "");

        }
        #endregion

        public static string DateTimeToJson(DateTime dt)
        {
            return SimpleSerialization.ObjectToJson(dt).Replace("\"", "");
        }

        /// <summary>
        /// 返回Ip地址部分(eg: 127.2.34.4  partId=3  return=4) 
        /// </summary>
        /// <param name="IpAddrees">Ip地址</param>
        /// <param name="partId">下标(0开始)</param>
        /// <returns></returns>
        public static string GetIpAddressPart(string IpAddrees, int partId)
        {
            try
            {
                return IpAddrees.Split('.')[partId];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ReadFile(string filePath, Encoding encoding)
        {
            string sTmp;
            try
            {
                using (StreamReader sr = new StreamReader(filePath, encoding))
                {
                    sTmp = sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                sTmp = string.Empty;
            }

            return sTmp;
        }

        /// <summary>
        /// 清除所有HTML标记(BR保留,p标记替换为BR)
        /// </summary>
        /// <param name="srouce">源内容</param>
        /// <returns>处理后内容</returns>
        public static string ClearAllHtmlTag(string srouce)
        {
            srouce = Regex.Replace(srouce, "<p>", "<br/>", RegexOptions.IgnoreCase);
            srouce = Regex.Replace(srouce, @"<(?!br)\/?[^>]+>", "", RegexOptions.IgnoreCase);
            srouce = Regex.Replace(srouce, "<br>", "<br/>", RegexOptions.IgnoreCase);

            return srouce;
        }

        /// <summary>
        /// 清除所有HTML标记(BR,p标记替换为换行符)
        /// </summary>
        /// <param name="srouce">源内容</param>
        /// <returns>处理后内容</returns>
        public static string ClearAllHtmlTagWBKLine(string srouce)
        {
            srouce = Regex.Replace(srouce, "<p>", "\r\n", RegexOptions.IgnoreCase);
            srouce = Regex.Replace(srouce, @"<(?!br)\/?[^>]+>", "", RegexOptions.IgnoreCase);
            srouce = Regex.Replace(srouce, @"<br\/?>", "\r\n", RegexOptions.IgnoreCase);

            return srouce;
        }

        const string RemoveRegex = @"[<].*?[>]";
        public static string RemoveHtml(string srouce)
        {
            return Regex.Replace(srouce, RemoveRegex, "", RegexOptions.IgnoreCase)
                .Replace("\n", "")
                .Replace("&nbsp;", " ")
                .Replace("&ldquo;", "“")
                .Replace("&rdquo;", "”")
                .Replace("&quot;", "\"")
                .Replace("&amp;", "&")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("\t", "")
                .Replace("\r", "");
        }

        /// <summary>
        /// 读取站点文件内容
        /// </summary>
        /// <param name="fileUrlPath"></param>
        /// <returns></returns>
        public static string ReadSiteFile(string fileUrlPath)
        {
            return ReadFile(HttpContext.Current.Server.MapPath(fileUrlPath), Encoding.Default);
        }

        #region 友好提示

        /// <summary>
        /// 友好提示
        /// </summary>
        /// <returns></returns>
        public static string SBeatitude()
        {
            string sTmp;
            if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 8)
            {
                sTmp = "早晨好!";
            }
            else if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 11)
            {
                sTmp = "上午好!";
            }
            else if (DateTime.Now.Hour >= 11 && DateTime.Now.Hour < 14)
            {
                sTmp = "中午好!";
            }
            else if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 17)
            {
                sTmp = "下午好!";
            }
            else if (DateTime.Now.Hour >= 17 && DateTime.Now.Hour < 20)
            {
                sTmp = "傍晚好!";
            }
            else if (DateTime.Now.Hour >= 20)
            {
                sTmp = "晚上好!";
            }
            else if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 5)
            {
                sTmp = "凌晨好!";
            }
            else
            {
                sTmp = "您好!";
            }
            return sTmp;
        }

        #endregion

        /// <summary>
        ///  返回分隔符字符串信息
        /// </summary>
        /// <param name="source">源字符串(123-232-232)</param>
        /// <param name="spliter">分隔符(-)</param>
        /// <returns>字符数组(string[]{123,232,232})</returns>
        public static string[] SpliteStrings(string source, string spliter)
        {
            if (string.IsNullOrEmpty(source))
                return new string[] { };


            return source.Split(spliter.ToCharArray());
        }

        /// <summary>
        /// 返回分隔符字符串信息(排除空字符)
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="spliter">分隔符</param>
        /// <returns>字符数组</returns>
        public static string[] SpliteStringsClearEmpty(string source, string spliter)
        {
            var parts = SpliteStrings(source, spliter);

            if (parts.Length > 0)
            {
                var list = new List<string>();

                foreach (var part in parts)
                {
                    if (!string.IsNullOrEmpty(part))
                        list.Add(part);
                }

                parts = list.ToArray();
            }

            return parts;
        }

        /// <summary>
        /// 返回分隔符字符串的整型信息
        /// </summary>
        /// <param name="source">源字符串(123-232-232)</param>
        /// <param name="spliter">分隔符(-)</param>
        /// <returns>int[]</returns>
        public static int[] SpliteInts(string source, string spliter)
        {
            if (!string.IsNullOrEmpty(source))
            {
                string[] values = source.Split(spliter.ToCharArray());
                var intValues = new List<int>();

                if (values != null)
                {
                    int intValue;

                    foreach (string value in values)
                    {
                        if (int.TryParse(value, out intValue))
                            intValues.Add(intValue);
                    }

                }

                return intValues.ToArray();
            }

            return new int[] { };
        }

        public static long[] SpliteLongs(string source, string spliter)
        {
            if (!string.IsNullOrEmpty(source))
            {
                string[] values = source.Split(spliter.ToCharArray());
                var intValues = new List<long>();

                if (values != null)
                {
                    long intValue;

                    foreach (string value in values)
                    {
                        if (long.TryParse(value, out intValue))
                            intValues.Add(intValue);
                    }

                }

                return intValues.ToArray();
            }

            return new long[] { };
        }

        public static double[] SpliteDouble(string source, string spliter)
        {
            if (!string.IsNullOrEmpty(source))
            {
                string[] values = source.Split(spliter.ToCharArray());
                var intValues = new List<double>();

                if (values != null)
                {
                    double intValue;

                    foreach (string value in values)
                    {
                        if (double.TryParse(value, out intValue))
                            intValues.Add(intValue);
                    }

                }

                return intValues.ToArray();
            }

            return new double[] { };
        }

        /// <summary>
        /// 将集合值连接成指定连接符字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="lists">集合</param>
        /// <param name="connectString">连接符</param>
        /// <returns>字符</returns>
        public static string Join<T>(IEnumerable<T> lists, string connectString)
        {
            if (lists == null)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (T item in lists)
            {
                sb.AppendFormat("{0}{1}", item, connectString);
            }

            if (!string.IsNullOrEmpty(connectString))
            {
                if (sb.Length > connectString.Length)
                    sb.Remove(sb.Length - connectString.Length, connectString.Length);
            }

            return sb.ToString();
        }

        public static string CombinUrlParam(IDictionary<string, string> parameters)
        {
            if (parameters == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (var item in parameters.Keys)
            {
                sb.AppendFormat("{0}={1}&", item, HttpUtility.UrlEncode(parameters[item]));
            }

            if (sb.Length > 0)
            {
                sb.Length--;
            }

            return sb.ToString();
        }

        /// <summary>
        /// 返回随即数字字符
        /// </summary>
        /// <param name="minLength">最小长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns>string</returns>
        public static string GetRandomNumber(int minLength, int maxLength)
        {
            Random random = new Random();
            int length = random.Next(minLength, maxLength);

            StringBuilder content = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                content.Append(random.Next(0, 9));
            }

            return content.ToString();
        }

        /// <summary>
        /// 获取GUID(-符合被移除)
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string GetSession(string deviceToken)
        {
            var pre = string.IsNullOrEmpty(deviceToken) ? GetGuid() : deviceToken;
            pre = pre.Substring(0, Math.Min(18, pre.Length));

            return string.Format("{0}{1}", pre, DateTime.Now.ToString("yyyyMMddHHmmss"));
        }

        #region 获取服务器IP最后一组数字

        /// <summary>
        /// 获取服务器IP最后一组数字
        /// </summary>
        /// <returns></returns>
        public static string GetServerIPPart4()
        {
            try
            {
                string sTmp = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
                if (!string.IsNullOrEmpty(sTmp))
                {
                    sTmp = sTmp.Split('.')[3];
                }
                else
                {
                    sTmp = "0";
                }

                return sTmp;
            }
            catch (Exception)
            {

                return "0";
            }

        }


        public static string GetLocalIp() //获取本地IP
        {
            try
            {
                var ipHost = Dns.Resolve(Dns.GetHostName());
                var ipAddr = ipHost.AddressList[0];

                return ipAddr.ToString();

            }
            catch (Exception)
            { 
                return string.Empty;
            }
            
        }

        #endregion

        #region  获取随机订单号(24位)
        public static string GetRandOrderId()
        {
            try
            {
                var sb = new StringBuilder();
                var random = new Random();
                sb.Append(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                sb.Append(random.Next(1000000, 9999999));

                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion


        #region  获取随机订单号(20位)
        public static string GetOrderNo()
        {
            try
            {
                var sb = new StringBuilder(); 
                sb.Append(DateTime.Now.ToString("yyMMddHHmmssfff"));

                for (int i = 0; i < 4; i++)
                {
                    sb.Append(new Random(Guid.NewGuid().GetHashCode()).Next(0, 9));
                }

                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        #region 获取返回记录范围信息
        /// <summary>
        /// 获取返回记录范围信息
        /// </summary>
        /// <param name="totalCount">总记录数</param>
        /// <param name="pageIndex">页下标</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="startIndex">out 开始下标</param>
        /// <param name="retCount">out 大小</param>
        /// <returns>记录范围是否有效</returns>
        public static bool GetRangeInfo(int totalCount, int pageIndex, int pageSize, out  int startIndex, out  int retCount)
        {
            startIndex = (pageIndex - 1) * pageSize;
            retCount = 0;

            if (startIndex < 0)
            {
                startIndex = 0;
                return false;
            }

            if (startIndex >= totalCount)
            {
                startIndex = totalCount - 1;
                return false;
            }

            retCount = totalCount - startIndex < pageSize ? totalCount - startIndex : pageSize;

            return true;
        }





        public static List<T> GetRangeInfo<T>(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            if (source == null)
                return new List<T>();

            int totalCount = source.Count();
            int startIndex = (pageIndex - 1) * pageSize;

            if (startIndex < 0 || startIndex >= totalCount)
                return new List<T>();

            int retCount = totalCount - startIndex < pageSize ? totalCount - startIndex : pageSize;


            return source.Skip(startIndex).Take(retCount).ToList();
        }
        #endregion

        #region 获取页总数
        public static int GetPageTotal(int count, int pageSize)
        {
            return Math.Max(1, (int)Math.Ceiling((count * 1.0) / pageSize));
        }
        #endregion

        #region 返回浏览器第一首选语言
        /// <summary>
        /// 返回浏览器第一首选语言
        /// </summary>
        /// <returns></returns>
        public static string HttpHeaderFirstLanguage()
        {
            string[] acceptLaguages = HttpContext.Current.Request.UserLanguages;

            if (acceptLaguages != null)
                return acceptLaguages[0].ToLower();

            return string.Empty;
        }
        #endregion

        #region 返回浏览器语言集合
        /// <summary>
        /// 返回浏览器语言集合
        /// </summary>
        /// <returns>如果不存在，返回null</returns>
        public static string[] HttpHeaderLanguages()
        {
            return HttpContext.Current.Request.UserLanguages;

        }

        #endregion

        #region 检查是否浏览器第一首选语言
        /// <summary>
        /// 检查是否浏览器第一首选语言
        /// </summary>
        /// <returns></returns>
        public static bool IsFirstLanguage(string languageName)
        {
            try
            {
                string[] acceptLaguages = HttpContext.Current.Request.UserLanguages;

                if (acceptLaguages != null)
                    return acceptLaguages[0].Contains(languageName);

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion

        #region 返回浏览器第一首选语言
        /// <summary>
        /// 返回浏览器第一首选语言
        /// </summary>
        /// <returns></returns>
        public static bool IsContainedLanguage(string languageName)
        {
            string[] acceptLaguages = HttpContext.Current.Request.UserLanguages;

            if (acceptLaguages != null)
                foreach (string laguage in acceptLaguages)
                {
                    if (laguage.Contains(languageName))
                        return true;
                }

            return false;
        }
        #endregion

        public static string MakeCacheKey(params object[] paramlist)
        {
            if (paramlist == null || paramlist.Length < 1)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (object param in paramlist)
            {
                sb.Append(param);
                sb.Append("^$^");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 作用：将字符串内容转化为16进制数据编码，其逆过程是Decode
        /// 转换的过程是直接把字符转换成Unicode字符,比如数字"3"-->0033,汉字"我"-->U+6211
        /// </summary>
        /// <param name="strEncode">需要转化的原始字符串</param>
        /// <returns></returns>
        public static string Encode2Unicode(string strEncode)
        {
            if (string.IsNullOrEmpty(strEncode))
                return string.Empty;


            StringBuilder sb = new StringBuilder();
            var chars = strEncode.ToCharArray();
            foreach (short shortx in chars)
            {
                sb.AppendFormat(@"\u{0}", shortx.ToString("X4"));
            }

            return sb.ToString();
        }

        /// <summary>
        ///作用：将16进制数据编码转化为字符串，是Encode的逆过程
        /// </summary>
        /// <param name="strDecode"></param>
        /// <returns></returns>
        public static string DecodeUnicode(string strDecode)
        {
            if (string.IsNullOrEmpty(strDecode))
                return string.Empty;

            strDecode = strDecode.Replace(@"\u", "");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strDecode.Length / 4; i++)
            {
                sb.Append((char)short.Parse(strDecode.Substring(i * 4, 4), NumberStyles.HexNumber));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string XmlSerializer(Type type, object source)
        {
            if (source == null)
                return string.Empty;

            XmlSerializer xml = new XmlSerializer(type);
            var ms = new MemoryStream();

            xml.Serialize(ms, source);
            ms.Position = 0;

            var buffer = new byte[ms.Length];
            ms.Read(buffer, 0, buffer.Length);
            ms.Close();

            return Encoding.UTF8.GetString(buffer);
        }

        public static bool IsInString(string source, string findPart, string spliter)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(findPart))
                return true;


            return string.Format("{0}{1}{0}", spliter, source).ToLower().Contains(string.Format("{0}{1}{0}", spliter, findPart).ToLower());
        }

        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                var m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// 正则查找值,返回groups 1
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="source">源字符串</param>
        public static string GetRegexValue(string pattern, string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = reg.Match(source);

            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        /// <summary>
        /// 利用串并行做深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry"></param>
        /// <returns></returns>
        public static T DeepClone<T>(T entry)
        {
            using (var sr = new MemoryStream())
            {
                var formater = new BinaryFormatter();

                formater.Context = new StreamingContext(StreamingContextStates.Clone);
                formater.Serialize(sr, entry);
                sr.Position = 0;

                var obj = (T)formater.Deserialize(sr);

                return obj;
            }

        }

        /// <summary>
        /// 获取url基地址
        /// </summary>
        /// <returns>eg:http://www.asp.com</returns>
        public static string GetRequestBaseUrl(HttpContext current)
        {
            if (current != null)
            {
                return string.Format("{0}://{1}{2}{3}", current.Request.Url.Scheme, current.Request.Url.Host,
                    current.Request.Url.Port == 80 ? "" : ":" + current.Request.Url.Port.ToString(),
                    current.Request.ApplicationPath == "/" ? "" : current.Request.ApplicationPath
                    );
            }

            return string.Empty;
        }

        public static string GetRequestBaseUrl(string url)
        {
            var uri = new Uri(url);
            if (uri != null)
            {
                return string.Format("{0}://{1}{2}", uri.Scheme, uri.Host,
                    uri.Port == 80 ? "" : ":" + uri.Port.ToString());
            }

            return string.Empty;
        }

        public static string GetCurrentRequestBaseUrl()
        {
            return GetRequestBaseUrl(HttpContext.Current);
        }

        /// <summary>
        /// 获取绝对路径url完全地址
        /// </summary>
        /// <param name="virtualPath">/test/test.aspx</param>
        /// <returns>http://www.asp.com/test/test.aspx</returns>
        public static string CombineFullUrl(string virtualPath)
        {
            var baseUrl = GetCurrentRequestBaseUrl();
            return string.Format("{0}/{1}", baseUrl, virtualPath.StartsWith("/") ? virtualPath.Substring(1,
                virtualPath.Length - 1) : virtualPath);
        }

        /// <summary>
        /// 是否通过MD5签名验证
        /// </summary>
        /// <param name="signParam"></param>
        /// <param name="markKey"></param>
        /// <returns></returns>
        public static bool IsPassedMD5Sign(string signParam, string markKey)
        {
            var sign = HttpHelper.GetPramaValue(signParam, "");
            if (string.IsNullOrEmpty(sign))
            {
                return false;
            }

            return string.Compare(sign, GetCurrentParamSignMD5Value(signParam, markKey), true) == 0;
        }

        /// <summary>
        /// 获取参数MD5签名字符
        /// </summary>
        /// <param name="markKey">掩码</param>
        /// <returns></returns>
        public static string GetCurrentParamSignMD5Value(string signParam, string markKey)
        {
            var sourceString = GetCurrentParamSignString(signParam, markKey);
            return string.IsNullOrEmpty(sourceString) ? string.Empty : EncryptMgr.MD5(sourceString);
        }

        /// <summary>
        /// 生成MD5加签字符串
        /// </summary>
        /// <param name="markKey"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static string GetParamSignMD5Value(string markKey, SortedList<string, string> keyValues)
        {
            if (keyValues != null)
            {
                var sb = new StringBuilder();
                foreach (var item in keyValues)
                {
                    sb.AppendFormat("{0}{1}", item.Key, item.Value);
                }
                sb.Append(markKey);

                return EncryptMgr.MD5(sb.ToString());
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取参数拼接后字符(url,form字典排序)
        /// </summary>
        /// <param name="signParam">排除的签名参数名</param>
        /// <param name="markKey">掩码</param>
        /// <returns></returns>
        public static string GetCurrentParamSignString(string signParam, string markKey)
        {
            if (HttpContext.Current != null)
            {
                var parameters = new SortedList<string, string>();
                foreach (var item in HttpContext.Current.Request.QueryString.Keys)
                {
                    parameters.Add(item.ToString(), HttpContext.Current.Request.QueryString[item.ToString()]);
                }
                foreach (var item in HttpContext.Current.Request.Form.Keys)
                {
                    parameters.Add(item.ToString(), HttpContext.Current.Request.Form[item.ToString()]);
                }

                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(signParam))
                    parameters.Remove(signParam);

                foreach (var item in parameters)
                {
                    sb.AppendFormat("{0}{1}", item.Key, item.Value);
                }
                sb.Append(markKey);

                return sb.ToString();
            }

            return string.Empty;
        }

        public static string GetRequestInputStream(Encoding encoding)
        {
            return GetRequestInputStream(encoding, true);
        }

        public static string GetRequestInputStream(Encoding encoding, bool enableDecode)
        { 
            HttpContext.Current.Request.InputStream.Position = 0;

            var sr = new StreamReader(HttpContext.Current.Request.InputStream, encoding);

            var input = sr.ReadToEnd();
            if (!string.IsNullOrEmpty(input) && enableDecode)
            {
                return HttpUtility.UrlDecode(input);
            }

            return input; 
        }

        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string GetFileContent(string filePath, Encoding encoding)
        {
            using (var f = new StreamReader(File.OpenRead(filePath), encoding))
            {
                return f.ReadToEnd();
            }
        }
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="source">编码字符串</param>
        /// <returns></returns>
        public static string ConvertToBase64(string source)
        {
            //byte[] bytes = Encoding.Default.GetBytes(source);
            //return Convert.ToBase64String(bytes);
            return ConvertToBase64(source, Encoding.UTF8);
        }
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="source">编码字符串</param>
        /// <param name="encoding">Encoding</param>
        /// <returns></returns>
        public static string ConvertToBase64(string source, Encoding encoding)
        {
            return Convert.ToBase64String(encoding.GetBytes(source));
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="source">解码字符串</param>
        /// <returns></returns>
        public static string ConvertFromBase64(string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                byte[] btye = Convert.FromBase64String(source);
                return Encoding.UTF8.GetString(btye);
            }

            return source;
        }



        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="source">解码字符串</param>
        /// <returns></returns>
        public static string TryConvertFromBase64(string source)
        {
            try
            {
                if (!string.IsNullOrEmpty(source))
                {
                    byte[] btye = Convert.FromBase64String(source);
                    return Encoding.UTF8.GetString(btye);
                }
            }
            catch (Exception)
            {
            }


            return source;
        }

        /// <summary>
        /// 获取http请求信息(full url,form,inputstream)
        /// </summary>
        /// <param name="request">HtttpRequest</param>
        /// <returns></returns>
        public static string GetHttpRequestInfo(HttpRequest request)
        {
            if (request != null)
            {
                var sb = new StringBuilder();

                sb.AppendLine(request.Url.OriginalString);
                sb.AppendLine(GetRequestInputStream(Encoding.UTF8));
                return sb.ToString();
            }

            return string.Empty;
        }

        #region 取随机值
        /// <summary>
        /// 取随机值
        /// </summary>
        /// <param name="min">开始值(包含)</param>
        /// <param name="max">结束值(包含)</param>
        /// <returns></returns>
        public static int Random(int min, int max)
        {
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            return rd.Next(min, max + 1);//获取随机的概率值
        }

        /// <summary>
        /// 取随机值（Double）
        /// </summary>
        /// <param name="min">开始值(包含)</param>
        /// <param name="max">结束值(包含)</param>
        /// <returns></returns>
        public static double Random(double min, double max)
        {
            var rd = new Random(Guid.NewGuid().GetHashCode());
            return rd.Next((int)(min * 10000), (int)(max * 10000 + 1)) / 10000.0;//获取随机的概率值
        }

        private const string RandomStr = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public static string GetRandomStr(int len)
        {
            var ranLen = RandomStr.Length;
            var sb = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                var rd = new Random(Guid.NewGuid().GetHashCode());
                var index= rd.Next(0, ranLen);//获取随机的概率值

                sb.Append(RandomStr.Substring(index, 1));
            }

            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// 转换为中文数值
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToCNNumber(int number)
        {
            switch (number)
            {
                case 1:
                    return "一";
                case 2:
                    return "二";
                case 3:
                    return "三";
                case 4:
                    return "四";
                case 5:
                    return "五";
                case 6:
                    return "六";
                case 7:
                    return "七";
                case 8:
                    return "八";
                case 9:
                    return "九";
                case 10:
                    return "十";
                default:
                    throw new NotImplementedException("未实现");
            }
        }

        public static string ToCNDayOfWeek(DayOfWeek dayOfWeek)
        {
            var desc = "";
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    desc = "星期五";
                    break;
                case DayOfWeek.Monday:
                    desc = "星期一";
                    break;
                case DayOfWeek.Saturday:
                    desc = "星期六";
                    break;
                case DayOfWeek.Sunday:
                    desc = "星期日";
                    break;
                case DayOfWeek.Thursday:
                    desc = "星期四";
                    break;
                case DayOfWeek.Tuesday:
                    desc = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    desc = "星期三";
                    break;
                default:
                    break;
            }

            return desc;
        }

        public static bool CheckResourceIsValid(string resourceUrl)
        {
            var resource = string.Empty;
            try
            {
                using (var client = new WebClient())
                {
                    resource = client.DownloadString(resourceUrl);
                }
            }
            catch (Exception)
            {
            }

            return !string.IsNullOrEmpty(resource);
        }

        public static string CombinMulitItemDescriptions(IList<string> items, string formatter, string spliter)
        {
            var sb = new StringBuilder();
            if (items != null)
            {
                var groups = items.GroupBy(p => p);
                foreach (var item in groups)
                {
                    sb.Append(string.Format(formatter, item.Key, item.Count()));
                    sb.Append(spliter);
                }

                if (sb.Length > 0)
                {
                    sb.Length -= spliter.Length;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 简单表达式计算
        /// </summary>
        /// <param name="expression">支持()+-*~</param>
        /// <returns></returns>
        public static double ComputeSimpleMathExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return 0;
            }

            if (RegexComm.IsRegexMatch(expression, @"^[\d\.]+$", RegexOptions.IgnoreCase))
            {
                return Change.ToDouble(expression, 0);
            }

            //括号解析
            const string multiExp = @"\(([^\)\(]+)\)";
            var multiParts = RegexComm.GetMatches(expression, multiExp, RegexOptions.IgnoreCase);
            while (multiParts.Count > 0)
            {
                var item = multiParts[0];
                var replacedValue = item.Groups[0].Value;
                var computeExpress = item.Groups[1].Value;

                var value = ComputeSimpleMathExpressionItem(computeExpress);


                expression = expression.Replace(replacedValue, value.ToString());
                multiParts = RegexComm.GetMatches(expression, multiExp, RegexOptions.IgnoreCase);
            }

            return ComputeSimpleMathExpressionItem(expression);
        }

        private static double ComputeSimpleMathExpressionItem(string expression)
        {
            const string simpleExp = @"(-?[\d\.]+)(\*|\/)(-?[\d\.]+)";

            var multiParts = RegexComm.GetMatches(expression, simpleExp, RegexOptions.IgnoreCase);
            while (multiParts.Count > 0)
            {
                var item = multiParts[0];
                var x = Change.ToDouble(item.Groups[1].Value, 0);
                var op = item.Groups[2].Value.Trim();
                var y = Change.ToDouble(item.Groups[3].Value, 0);

                expression = expression.Replace(item.Groups[0].Value, (op == "*" ? (x * y) : (x / y)).ToString());
                multiParts = RegexComm.GetMatches(expression, simpleExp, RegexOptions.IgnoreCase);
            }


            const string simpleExp2 = @"(-?[\d\.]+)([+\~-])(-?[\d\.]+)";
            multiParts = RegexComm.GetMatches(expression, simpleExp2, RegexOptions.IgnoreCase);
            while (multiParts.Count > 0)
            {
                var item = multiParts[0];
                var x = Change.ToDouble(item.Groups[1].Value, 0);
                var exp = item.Groups[2].Value;
                var y = Change.ToDouble(item.Groups[3].Value, 0);

                if (exp == "+")
                {
                    expression = expression.Replace(item.Groups[0].Value, (x + y).ToString());
                }
                else if (exp == "~")
                {
                    expression = expression.Replace(item.Groups[0].Value, new Random().Next((int)x, (int)y + 1).ToString());
                }
                else if (exp == "-")
                {
                    expression = expression.Replace(item.Groups[0].Value, (x - y).ToString());
                }
                else
                {
                    throw new NotSupportedException("不支持的表达式");
                }

                multiParts = RegexComm.GetMatches(expression, simpleExp2, RegexOptions.IgnoreCase);
            }

            return Change.ToDouble(expression, 0);
        }

        /// <summary>
        /// 根据权值随机获取项目
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="datas">集合</param>
        /// <param name="itemWeight">权值</param>
        /// <returns></returns>
        public static T GetRandomItem<T>(IList<T> datas, ItemWeight<T> itemWeight)
        {
            var totalWeight = datas.Sum(p => itemWeight(p));
            var random = Random(1, totalWeight);

            var curWeight = 0;
            foreach (var item in datas)
            {
                curWeight += itemWeight(item);

                if (random <= curWeight)
                {
                    return item;
                }
            }

            return datas.OrderBy(p => Guid.NewGuid().GetHashCode()).FirstOrDefault();
        }

        /// <summary>
        /// 随机获取项目
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static T GetRandomItem<T>(IEnumerable<T> datas)
        {
            return datas.OrderBy(p => Guid.NewGuid().GetHashCode()).FirstOrDefault();
        }


        ///// <summary>
        ///// 判断是否在概率中
        ///// </summary>
        ///// <param name="percent">几率(0~100)</param>
        ///// <returns>在概率中则true,否则false</returns>
        //public static bool IsInRange(int percent)
        //{
        //    if (percent > 100 || percent < 0)
        //    {
        //        throw new ArgumentOutOfRangeException("percent", "参数有效范围(0~100)");
        //    }

        //    var random = Random(0, 100);
        //    return percent >= random;
        //}

        /// <summary>
        /// 判断是否在概率中:100中的概率是从1开始不是0，0的话没有概率
        /// </summary>
        /// <param name="percent">几率(1~100)</param>
        /// <returns>在概率中则true,否则false</returns>
        public static bool IsInRange(int percent)
        {
            if (percent >= 100)
            {
                return true;
            }
            if (percent < 1)
            {
                return false;
            }

            var random = Random(1, 100);
            return percent >= random;
        }

        /// <summary>
        /// 根据随机个数随机获取集合
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="datas">集合</param>
        /// <param name="count">随机个数</param>
        /// <param name="bRepeat">是否可重复</param>
        /// <returns></returns>
        public static List<T> GetRandomItems<T>(List<T> datas, int count, bool bRepeat = false)
        {
            var totalCount = datas.Count;

            if (count >= totalCount)
            {
                if (bRepeat)
                {
                    //当所得集合可以重复时
                    var ret = new List<T>();
                    for (int i = 0; i < count; i++)
                    {
                        var random = Random(0, totalCount - 1);
                        ret.Add(datas[random]);
                    }
                    return datas;
                }
                else
                {
                    //随机个数大于集合数量，返回全部集合
                    return datas;
                }
            }
            else
            {
                var datass = new List<T>();

                for (int i = 0; i < count; i++)
                {
                    var random = Random(0, totalCount - 1);

                    if (!bRepeat)
                    {
                        //随机不重复的数据个数加入集合
                        if (!datass.Contains(datas[random]))
                        {
                            datass.Add(datas[random]);
                        }
                        else
                        {
                            //继续随机
                            i--;
                        }
                    }
                    else
                    {
                        datass.Add(datas[random]);
                    }
                }
                return datass;
            }
        }

        /// <summary>
        /// 根据总值和列表值获取相应的值的个数
        /// </summary>
        /// <param name="totalNumber">总值</param>
        /// <param name="numbers">列表值</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<int, int> GetDicNumber(int totalNumber, List<int> numbers)
        {
            var dic = new Dictionary<int, int>();

            //降序排序
            numbers = numbers.OrderByDescending(p => p).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                //非最小值
                if (i < numbers.Count - 1)
                {
                    //小于值，直接跳出
                    if (totalNumber >= numbers[i])
                    {
                        //Key值
                        var dicKey = numbers[i];
                        //Value值
                        var dicValue = totalNumber / numbers[i];

                        //剩余值
                        totalNumber = totalNumber % numbers[i];

                        dic.Add(dicKey, dicValue);
                    }
                }
                else //最小值，四舍五入
                {
                    //小于值的一半，直接跳出
                    if (totalNumber < numbers[i] / 2) break;

                    //Key值
                    var dicKey = numbers[i];
                    //Value值
                    var dicValue = Math.Max(1, totalNumber / numbers[i]);

                    dic.Add(dicKey, dicValue);
                }
            }

            return dic;
        }

        /// <summary>
        /// 获取http 请求InputStream字符串(UTF8编码)
        /// </summary>
        /// <returns></returns>
        public static string GetHttpFormData()
        {
            var buffer = new byte[HttpContext.Current.Request.InputStream.Length];
            HttpContext.Current.Request.InputStream.Position = 0;
            HttpContext.Current.Request.InputStream.Read(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(buffer);
        }


        const double EarthRadius = 6378.137;//地球的半径
        public static int GetInterval(double lat1, double lng1, double lat2, double lng2)
        {
            var radLat1 = lat1 * Math.PI / 180.0;
            var radLat2 = lat2 * Math.PI / 180.0;
            var radLng1 = lng1 * Math.PI / 180.0;
            var radLng2 = lng2 * Math.PI / 180.0;

            var a = radLat1 - radLat2;
            var b = radLng1 - radLng2;
            var s = 2 * Math.Sin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));

            s = s * EarthRadius;
            s = Math.Round(s * 10000) / 10000;
            s = s * 1000;

            return (int)Math.Ceiling(s);
        }




        // DateTime时间格式转换为Unix时间戳格式
        private static readonly DateTime StartTime = DateTime.Parse("1970-1-1 00:00:00");
        public static long DateTimeToStamp(DateTime time)
        {
            return (long)(time.ToUniversalTime().Subtract(StartTime).TotalMilliseconds);
        }

        public static long DateTimeToStamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000)/10000000;
        }


    

        public static DateTime StampToDateTime(long stamp)
        {
            return (StartTime.AddMilliseconds(stamp)).ToLocalTime();
        }

        /// <summary>
        /// 计算相似度
        /// </summary>
        /// <param name="isbns"></param>
        /// <param name="compareIsbns"></param>
        /// <returns></returns>
        public static int ComputeSimilarity(List<string> isbns, List<string> compareIsbns)
        {
            if (isbns == null || isbns.Count <= 0) return 0;
            if (compareIsbns == null || compareIsbns.Count <= 0) return 0;

            var total = isbns.Count;
            var similarity = isbns.Count(compareIsbns.Contains);


            return (int)(Math.Ceiling(similarity * 1.0 / total * 100));
        }

        /// <summary>
        /// 计算相似度
        /// </summary>
        /// <param name="myCnt">我的书籍总数</param>
        /// <param name="uCnt">对方书籍总数</param>
        /// <param name="similarityCount">相似的数据总数</param>
        /// <returns></returns>
        public static int ComputeSimilarity(int myCnt, int uCnt, int similarityCount)
        {
            var total = Math.Max(myCnt, uCnt);
            if (total <= 0) return 0;

            return (int)(Math.Ceiling(similarityCount * 1.0 / total * 100));
        }

        /// <summary>
        /// 获取指定类型的所有公共属性名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<string> GetPublicProperties(Type type)
        {
            if (type == null) return new List<string>();

            var properites = type.GetProperties(System.Reflection.BindingFlags.Public);

            var results = new List<string>();
            foreach (var item in properites)
            {
                if (item.CanRead || item.CanWrite)
                {
                    results.Add(item.Name);
                }
            }

            return results;
        }

        /// <summary>
        /// 手机号码打马赛克
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static string MarkMobile(string mobile)
        {
            if (string.IsNullOrEmpty(mobile)) return string.Empty;

            // 格式 138****2877
            return string.Format("{0}****{1}", mobile.Substring(0, 3), mobile.Substring(mobile.Length - 4, 4));
        }


        /// <summary>
        /// 获取指定最长内容
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="maxLen">最大返回长度</param>
        /// <returns></returns>
        public static string GetSubStr(string source, int maxLen)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            return source.Substring(0, Math.Min(maxLen, source.Length));
        }


        public static string UnicodeToStr(string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                var strlist = source.Replace("//", "").Split('u');
                try
                {
                    var sb = new StringBuilder();

                    for (int i = 1; i < strlist.Length; i++)
                    {
                        //将unicode字符转为10进制整数，然后转为char中文字符  
                        sb.Append((char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber));
                    }

                    return sb.ToString();
                }
                catch (FormatException ex)
                {
                }
            }

            return string.Empty;
        }


        #region 身份证验证程序
        public static bool CheckDriverID(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckDriverID18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckDriverID15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckDriverID18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        private static bool CheckDriverID15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
        #endregion

        #region 获取月数
        /// <summary>
        /// 获取月数
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static int IntervalMonth(DateTime startTime, DateTime endTime)
        { 
            var month = (int)endTime.Subtract(startTime).TotalDays/31;

            while (startTime.AddMonths(month+1) <=endTime)
            {
                month += 1;
            }

            return Math.Min(12,month);

        }
        #endregion
    }
}
using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace OneCoin.Service.Helper.Http
{
    public class HttpHelper
    {
        #region 用户Ip地址

        /// <summary>
        ///  获取用户Ip地址(包括获取Wap网关IP地址)
        /// </summary>
        public static string UserTrueIp
        {
            get
            {
                try
                {
                    string sfIp = SquidForwardIp;
                    if (!string.IsNullOrEmpty(sfIp)) return sfIp;

                    //网关IP地址
                    string trueIp = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];

                    if (string.IsNullOrEmpty(trueIp))
                        //用户Ip地址
                        return HttpContext.Current.Request.UserHostAddress;

                    return trueIp;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }


        /// <summary>
        /// 用户IP地址
        /// </summary>
        public static string UserHostAddress
        {
            get { return HttpContext.Current.Request.UserHostAddress; }
        }


        /// <summary>
        /// 代理服务信息
        /// </summary>
        public static string SquidForwardIp
        {
            get
            {
                try
                {
                    string forwordList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


                    if (string.IsNullOrEmpty(forwordList))
                        return string.Empty;


                    string[] ipList = forwordList.Split(new[] {','});
                    if (ipList.Length >= 2)
                    {
                        return ipList[0];
                    }


                    if (ipList.Length == 1)
                    {
                        return ipList[0];
                    }

                    if (!forwordList.StartsWith("10."))
                    {
                        return forwordList;
                    }
                }
                catch (Exception)
                {
                    return string.Empty;
                }


                return string.Empty;
            }
        }


        /// <summary>
        /// 获取用户Ip地址(不获取Wap网关IP地址)
        /// </summary>
        public static string UseIpWithOutWapIsp
        {
            get
            {
                try
                {
                    //用户Ip地址
                    return UserTrueIp;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        #endregion

        #region 检查Referer路径是否为指定路径

        /// <summary>
        /// 检查Referrer路径是否为指定路径
        /// </summary>
        /// <param name="path">指定路径</param>
        /// <returns>true or false</returns>
        public static bool IsFromPath(string path)
        {
            string curReferrer = HttpContext.Current.Request.ServerVariables["http_referer"];

            if (!string.IsNullOrEmpty(curReferrer))
            {
                return curReferrer.IndexOf(path.Trim()) > 0;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 获得指定参数值

        /// <summary>
        /// 获得指定参数值
        /// </summary>
        /// <param name="pramaName">参数名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetPramaValue(string pramaName, int defaultValue)
        {
            int ret = defaultValue;

            try
            {
                string pramaValue = GetPramaValue(pramaName,"");

                if (!string.IsNullOrEmpty(pramaValue))
                {
                    if( int.TryParse( pramaValue , out ret ) == false)
                        ret = defaultValue;
                }
            }
            catch
            {
            }

            return ret;
        }



        public static long GetPramaValue(string pramaName, long defaultValue)
        {
            long ret = defaultValue;

            try
            {
                string pramaValue = GetPramaValue(pramaName, "");

                if (!string.IsNullOrEmpty(pramaValue))
                {
                    if (long.TryParse(pramaValue, out ret) == false)
                        ret = defaultValue;
                }
            }
            catch
            {
            }

            return ret;
        }


        public static double GetPramaValue(string pramaName, double defaultValue)
        {
            double ret = defaultValue;

            try
            {
                string pramaValue = GetPramaValue(pramaName, "");

                if (!string.IsNullOrEmpty(pramaValue))
                {
                    if (double.TryParse(pramaValue, out ret) == false)
                        ret = defaultValue;
                }
            }
            catch
            {
            }

            return ret;
        }


        /// <summary>
        /// 获得指定参数值
        /// </summary>  
        /// <param name="pramaName">参数名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetPramaValue(string pramaName, string defaultValue)
        {
            string ret = defaultValue;

            try
            {
                string pramaValue = HttpContext.Current.Request.QueryString[pramaName];

                if (!string.IsNullOrEmpty(pramaValue))
                {
                    ret = pramaValue;
                }

                /*else*/ 
                {
                    //form 字段加密
                    /*if (string.Compare(ConfigurationManager.AppSettings["EnableHttpEncrypt"], "true", true) == 0)
                    {
                        var formValue =  HttpFormDecryptModule.GetItem(pramaName);
                        if (!string.IsNullOrEmpty(formValue))
                        {
                            //ret = MoqiEncryptMgr.DecryptDataWithBase64(ret, ConfigurationManager.AppSettings["HttpEncryptKey"]);
                            ret = formValue;
                        }
                    }
                    else*/
                    {
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form[pramaName]))
                        {
                            ret = HttpContext.Current.Request.Form[pramaName];
                        }
                    }
                }
            }
            catch
            {
            }

            return ret;
        }


        public static bool GetPramaValue(string pramaName, bool defaultValue)
        {
            bool ret = defaultValue;

            try
            {
                string pramaValue = GetPramaValue(pramaName, "");
                ret = string.Compare(pramaValue , "true", true ) == 0 ;
            }
            catch
            {
            }

            return ret;
        }

        /// <summary>
        /// 获得指定参数值
        /// </summary>
        /// <param name="pramaName">参数名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime GetPramaValue(string pramaName, DateTime defaultValue)
        {
            DateTime ret = defaultValue;

            try
            {
                string pramaValue = GetPramaValue(pramaName, "");

                if (DateTime.TryParse(pramaValue ,out ret) == false )
                    ret = defaultValue;
            }
            catch
            {
            }

            return ret;
        }

        #endregion


        #region  获取当前服务器名

        public static string GetDomian()
        {
            string domian = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];

            return domian;
        }

        #endregion

        #region  获取当前页面名称
        /// <summary>
        /// 页面名称(后缀)
        /// </summary>
        public static string ScriptName
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["Script_NAME"];
                ;
            }
        }

        /// <summary>
        /// 页面名称
        /// </summary>
        public static string PageName
        {
            get
            {
                string absolutePath = HttpContext.Current.Request.Url.AbsolutePath;

                if(! string.IsNullOrEmpty(absolutePath))
                {
                    Regex regex = new Regex(@"(\w+)\.?[^\/]*$", RegexOptions.IgnoreCase);

                    Match match = regex.Match(absolutePath);
                    if(match.Success)
                    {
                        return match.Groups[1].Value;
                    }
                }

                return string.Empty;
            }
        }


        #endregion

        #region  获取当前服务器IP

        public static string ServerIP
        {
            get { return HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]; }
        }

        #endregion

        #region  获取HTTP_ACCEPT信息

        /// <summary>
        /// 获取HTTP_ACCEPT信息
        /// </summary>
        public static string HttpAccept
        {
            get { return HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT"]; }
        }

        #endregion

        #region  获取设备宽度(象素)

        /// <summary>
        ///  获取设备宽度(象素)
        /// </summary>
        public static int UAWidthPixel
        {
            get
            {
                string uapixels = string.Empty;


                //reg:240x320
                string pixels = HttpContext.Current.Request.ServerVariables["HTTP_UA_PIXELS"];


                if (! string.IsNullOrEmpty(pixels))
                {
                    Regex regex = new Regex(@"(\d+)x(\d+)", RegexOptions.IgnoreCase);

                    if (regex.IsMatch(pixels))
                    {
                        Match match = regex.Match(pixels);

                        uapixels = match.Groups[1].Value;
                    }
                }


                int width;

                if (! int.TryParse(uapixels, out width))
                {
                    width = 230;
                }

                return width;
            }
        }

        #endregion

        #region  获取设备高度(象素)

        /// <summary>
        ///  获取设备高度(象素)
        /// </summary>
        public static int UAHeightPixel
        {
            get
            {
                string uapixels = string.Empty;


                //reg:240x320
                string pixels = HttpContext.Current.Request.ServerVariables["HTTP_UA_PIXELS"];

                if (!string.IsNullOrEmpty(pixels))
                {
                    Regex regex = new Regex(@"(\d+)x(\d+)", RegexOptions.IgnoreCase);

                    if (regex.IsMatch(pixels))
                    {
                        Match match = regex.Match(pixels);

                        uapixels = match.Groups[2].Value;
                    }
                }


                int height;

                if (!int.TryParse(uapixels, out height))
                {
                    height = 310;
                }

                return height;
            }
        }

        #endregion

        #region  跳转

        public static void Redirect(string address)
        {
            HttpContext.Current.Response.Redirect(address);
            HttpContext.Current.Response.End();
        }

        #endregion

        #region 获取远程url数据内容

        /// <summary>
        ///   获取远程url数据内容
        /// </summary>
        /// <param name="url">url地址"http://www.qidian.com"</param>
        /// <param name="coding">返回数据编码</param>
        /// <returns>字符串</returns>
        public static string GetContent(string url, Encoding coding)
        {
            using (var client = new WebClient())
            {
                byte[] buffer = client.DownloadData(url);

                return coding.GetString(buffer);
            }
        }

        /// <summary>
        ///   获取远程url数据内容
        /// </summary>
        /// <param name="url">url地址"http://www.qidian.com"</param>
        /// <returns>字节数组</returns>
        public static byte[] GetContent(string url)
        {
            using (var client = new WebClient())
            {
                byte[] buffer = client.DownloadData(url);

                return buffer;
            }
        }

        #endregion

        #region  url编解码
      /// <summary>
        ///  url编码
      /// </summary>
      /// <param name="url"></param>
      /// <returns></returns>
        public static string UrlEncode(string url)
      {
          return HttpContext.Current.Server.UrlEncode(url);
      }

      /// <summary>
      ///  url解码 
      /// </summary>
      /// <param name="url"></param>
      /// <returns></returns>
      public static string UrlDecode(string url)
      {
          return HttpContext.Current.Server.UrlDecode(url);
      }

      #endregion



    }
}
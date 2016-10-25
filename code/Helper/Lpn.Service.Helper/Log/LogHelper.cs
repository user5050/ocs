using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Mail;
using OneCoin.Service.Helper.TextAnalyze;
using log4net;

namespace OneCoin.Service.Helper.Log
{
    public class LogHelper
    {
        public static string PreTitle { get; set; }
        public static List<string> ErrorLogs = new List<string>();

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="logTitle">日志标题</param>
        /// <param name="logString">日志内容</param>
        /// <param name="isError"></param>
        /// <param name="isTrace"></param>
        /// <param name="isNotify"></param>
        private static void SaveLog(string logTitle, string logString, bool isError = false, bool isTrace = false, bool isNotify = false)
        {
            var env = "online";
#if DEBUG
            env = "test";
#endif

            logTitle = string.Format("[{2}-{3}-{0}]{1}", PreTitle, logTitle, Spanner.GetLocalIp(), env);

            var request = string.Empty;
            var userAgent = string.Empty;
            if (HttpContext.Current != null)
            {
                try
                {
                    request = Spanner.GetHttpRequestInfo(HttpContext.Current.Request);

#if !DEBUG

                    request = RegexComm.GetRegexReplacedValue(request, "token=([0-9a-zA-Z]+)", "***", 1, RegexOptions.IgnoreCase);
                    request = RegexComm.GetRegexReplacedValue(request, "openid\":\"([^\"]+)\"", "***", 1, RegexOptions.IgnoreCase);
#endif

                    userAgent = HttpContext.Current.Request.UserAgent;
                    userAgent += HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                    userAgent += HttpContext.Current.Request.ServerVariables["content-type"];
                    userAgent += HttpHelper.UserTrueIp;


                }
                catch (Exception)
                {
                }
            }

#if !DEBUG
            logString = RegexComm.GetRegexReplacedValue(logString, "privatekey\":\"([^\"]+)\"", "***", 1, RegexOptions.IgnoreCase);
            logString = RegexComm.GetRegexReplacedValue(logString, "token\":\"([^\"]+)\"", "***", 1, RegexOptions.IgnoreCase);
#endif

            if (isError)
            {
                var content = string.Format("\r\n标题:{0}\t时间:{3}\t代理:{4}\r\n内容：{1}\r\n请求:{2}", logTitle, logString, request, DateTime.Now, userAgent);
                LogManager.GetLogger("Logger").Error(content);


                if (isNotify)
                {
                    var mailContent = string.Format("<tr style=\"background-color:gray\"><td colspan=\"2\">{3}</td></tr><tr><td>{0}</td><td>{2}</td></tr><tr><td colspan=\"2\">{1}</td></tr>", userAgent, logString.Substring(0, Math.Min(200, logString.Length)), DateTime.Now, logTitle);

#if !DEBUG
                    SendLogToMail(mailContent);
#endif
                }
                
            }
            else if (isTrace)
            {
                LogManager.GetLogger("Logger").InfoFormat("\r\n标题:{0}\t代理:{3}\r\n内容：{1}\r\n请求:{2}", logTitle, logString, request, userAgent);

            }
            else
            {
                LogManager.GetLogger("Logger").DebugFormat("\r\n标题:{0}\t代理:{3}\r\n内容：{1}\r\n请求:{2}", logTitle, logString, request, userAgent);
            }
        }




        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="message">信息</param>
        public static void Add(string message)
        {
            SaveLog("无", message);
        }

        /// <summary>
        /// 跟踪日志
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
        {
            SaveLog("无", message, false, true);
        }


        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="ex">异常信息对象</param>
        /// <param name="isNotify"></param>
        public static void Add(string title, Exception ex, bool isNotify = true)
        {
            Add(title, null, ex, isNotify);
        }


        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="ex">异常信息对象</param>
        /// <param name="isNotify"></param>
        public static void Add(string title, string content, Exception ex, bool isNotify = true)
        {
            var logStringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(content))
            {
                logStringBuilder.AppendLine(content);
            }


            for (int i = 0; i < 5; i++)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    logStringBuilder.Append("Message:\r\n");
                    logStringBuilder.Append(ex.Message);
                    logStringBuilder.Append("\r\n");
                }
                if (!string.IsNullOrEmpty(ex.StackTrace))
                {
                    logStringBuilder.Append("StackTrace:\r\n");
                    logStringBuilder.Append(ex.StackTrace);
                    logStringBuilder.Append("\r\n");
                }
                if (!string.IsNullOrEmpty(ex.Source))
                {
                    logStringBuilder.Append("Source:\r\n");
                    logStringBuilder.Append(ex.Source);
                    logStringBuilder.Append("\r\n");
                }
                if (!string.IsNullOrEmpty(ex.HelpLink))
                {
                    logStringBuilder.Append("HelpLink:\r\n");
                    logStringBuilder.Append(ex.HelpLink);
                    logStringBuilder.Append("\r\n");
                }

                if (ex.InnerException == null)
                {
                    break;
                }

                ex = ex.InnerException;
            }

            SaveLog(title, logStringBuilder.ToString(), ex != null, false, isNotify);
        }

        private static DateTime _lastSendTime = DateTime.Now.AddMinutes(-10);
        private static void SendLogToMail(string error)
        {
            try
            {
                if (ErrorLogs.Count > 50 || (ErrorLogs.Count > 0 && DateTime.Now.Subtract(_lastSendTime).TotalHours > 1))
                {
                    var temp = ErrorLogs;
                    ErrorLogs = new List<string>();
                    if (DateTime.Now.Subtract(_lastSendTime).TotalMinutes > 10)
                    {
                        var isSerious = temp.Count > 50 && DateTime.Now.Subtract(_lastSendTime).TotalMinutes <= 15;
                        _lastSendTime = DateTime.Now;

                        if (isSerious)
                        {
                            temp.Insert(0, "<tr style=\"background-color:red\"><td colspan=\"2\"><strong>严重错误，可能需要立即处理.</strong></td></tr>");
                        }

                        const string html = "<HTML><style>table{{border:1px;background-color:black;font-size:11;}}tr{{background-color:#fff;width:100%;}}td{{background-color:#fff;min-width:200px;}}.line{{background-color:gray;}}</style><BODY><table>{0}</table></BODY></HTML>";
                        AsyncSendMail(string.Format(html, Spanner.Join(temp, "")), isSerious, temp.Count);
                    }
                }

                ErrorLogs.Add(error);
            }
            catch (Exception ex)
            {
#if DEBUG
                LogManager.GetLogger("Logger").Error(ex.StackTrace);
#endif
            }
        }

        private static void AsyncSendMail(string content, bool isSerious, int count)
        {
            ThreadPool.QueueUserWorkItem(p => MailHelper.Send("devfeedback@sina.com", string.Format("服务[{2}]异常[{0} {1}条]", isSerious ? "严重" : "一般", count, PreTitle), content, true));
        }
    }
}

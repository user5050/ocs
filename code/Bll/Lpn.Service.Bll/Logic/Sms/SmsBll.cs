using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Notification;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Config;
using OneCoin.Sms;
using OneCoin.Service.Model.Result;
using OneCoin.Service.Cache.Vcode;
using OneCoin.Service.Model.Enum;

namespace OneCoin.Service.Bll.Logic.Sms
{
    public class SmsBll : BllBase
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="smsConfig"></param>
        /// <param name="mobile">手机号</param>
        /// <param name="randomCode">随机码</param>
        /// <returns></returns>
        public static ResultDto SmsSend(string smsConfig, string mobile, string randomCode)
        {
            //type=chanzorService;username=eboche;pwd=152433;server=http://sms.chanzor.com:8001/sms.aspx?action=send
             
            var success =  NotificationHelper.NotificationSmsForVCode(mobile, randomCode, "5");
            if (success)
            {
                if (VCodeCacheMgr.SetVCode(mobile, randomCode))
                {
                    return ResultDto.DefaultSuccess();
                }

            }
            return ResultDto.DefaultError(ResultState.SmsSendFailed, "短信发送失败");
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="randomCode">验证码</param>
        /// <returns>成功或失败</returns>
        public static bool Validate(string mobile, string randomCode)
        {
            if (VCodeCacheMgr.IsWhiteMobile(mobile))
                return true;

#if DEBUG
            return true;
#endif

            string code = VCodeCacheMgr.GetVCode(mobile);
            return randomCode == code;
        }


        internal static bool SmsSend(string mobile, string content)
        {
            //type=chanzorService;username=eboche;pwd=152433;server=http://sms.chanzor.com:8001/sms.aspx?action=send

            string type = string.Empty;
            string userName = string.Empty;
            string pwd = string.Empty;
            string server = string.Empty;

            string[] array = WebConfig.SmsConfig.Split(';');
            foreach (var item in array)
            {
                string[] tmp = item.Split('=');
                switch (tmp[0].ToLower())
                {
                    case "type":
                        type = tmp[1].Trim();
                        break;
                    case "server":
                        server = item.Replace("server=", "");
                        break;
                    case "username":
                        userName = tmp[1].Trim();
                        break;
                    case "pwd":
                        pwd = tmp[1].Trim();
                        break;
                }
            }

            string message;

            var msg = content;
             
#if DEBUG
            LogHelper.Add("发送短信:"+ msg);
#endif

            if (SmsMgr.Send(type, server, userName, pwd, mobile, msg, out message))
            {
                LogHelper.Add(string.Format("短信发送成功:{0} {1} {2}", mobile, msg ,message));

                return true;
            }

            LogHelper.Add(string.Format("短信发送失败:{0} {1} {2}", mobile, msg, message));

            return false;
        }
    }
}

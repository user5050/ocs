using System;
using System.Web;
using OneCoin.Service.Helper.Http;

namespace OneCoin.Service.Helper.Communication
{
    public class SmsService
    {
        private static readonly string SMSServiceAddress = "http://sms.phpcms.cn/api.php?op=sms_service&";
        /// <summary>
        /// 发送短信服务(SIP短信通)
        /// http://www.phpcms.cn
        /// </summary>
        /// <param name="smsUid"></param>
        /// <param name="smsPid"></param>
        /// <param name="smsPwd"></param>
        /// <param name="mobileNo">手机号码</param>
        /// <param name="tempId">消息模板</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static bool SendMessage(string smsUid,string smsPid,string smsPwd,string mobileNo,string tempId, string content)
        {
            try
            {
                var client = new HttpClient();
                var param = string.Format("sms_uid={0}&sms_pid={1}&sms_passwd={2}&mobile={3}&send_txt={4}&charset=utf-8&tplid={5}",
                    smsUid, smsPid, smsPwd, mobileNo, HttpUtility.UrlEncode(content ), tempId);

                client.Url = string.Format("{0}{1}", SMSServiceAddress, param);
                var ret = client.GetString();

                if (!string.IsNullOrEmpty(ret))
                {
                    var rets = Spanner.SpliteStringsClearEmpty(ret, "#");
                    if (rets.Length > 0)
                    {
                        return rets[0] == "0";
                    }
                }
            }
            catch (Exception )
            {
            }

            return false;
        }

        /// <summary>
        /// 发送短信服务(SIP短信通)
        /// http://www.phpcms.cn
        /// </summary>
        /// <param name="config">smsUid#smsPid#smsPwd#tempId#mobileNo</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static bool SendMessage(string config, string content)
        {
            var configItems = Spanner.SpliteStringsClearEmpty(config, "#");
            if (configItems.Length >= 5)
            {
                return SendMessage(configItems[0], configItems[1], configItems[2], configItems[4], configItems[3], content);
            }

            return false;
        }

    }
}

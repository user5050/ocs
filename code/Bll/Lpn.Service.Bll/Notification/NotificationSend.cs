using System;
using System.Net;
using System.Text;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Entity.Notification;
using Newtonsoft.Json;

namespace OneCoin.Service.Bll.Notification
{
    public class NotificationSend
    {
        public static void SendNotification(MessageInfo info)
        {
            try
            {
                var json = JsonConvert.SerializeObject(info);
                var data = Encoding.UTF8.GetBytes(json);
                using (var client = new WebClient())
                {
                    client.Headers.Remove("content-type");
                    client.Headers.Add("content-type", "application/json");
                    client.Encoding = Encoding.UTF8;
                    string strUrl = WebConfig.MessageUrl;
                    client.UploadData(string.Format("{0}{1}", strUrl, "Message"), data);
                }

#if DEBUG
                LogHelper.Add(string.Format("发送消息{0}",json));
#endif
            }
            catch (Exception ex )
            {              
                LogHelper.Add("发送消息失败，错误原因：{0}",ex);
            }

        }
    }
}

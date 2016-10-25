using OneCoin.Service.Bll.Logic.Sms;

namespace OneCoin.Service.Bll.Notification
{
    public class NotificationHelper
    {
        public static bool NotificationSmsForVCode(string mobile, string vcode, string validTime)
        {
            return SmsBll.SmsSend(mobile, string.Format("")); 
        }
        
    }
}

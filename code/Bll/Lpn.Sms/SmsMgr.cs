using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCoin.Sms
{
    public class SmsMgr
    {
        public static bool Send(string type, string url, string UserName, string Pwd, string Mbno, string Msg, out string messgage)
        {
            messgage = "";
            ISMS sms = null;
            if (type == "lingkai")
            {
                sms = new SMSservice();
            }
            else
            {
                sms = new chanzorService();
            }
            sms.Url = url;
 

            return sms.SendMessage(UserName, Pwd, Mbno, Msg, ref messgage);
        }
    }
}

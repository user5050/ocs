using System; 

namespace OneCoin.Service.Model.Entity.Notification
{
    public class MessageInfo
    {
        /// <summary>
        /// 安卓token
        /// </summary>
        public string AndroidToken { get; set; }

        /// <summary>
        /// 苹果token
        /// </summary>
        public string IOSToken { get; set; }

        /// <summary>
        /// 微信ID
        /// </summary>
        public string OpenID { get; set; }

        public Device Payload { get; set; }

        public Extra Extra { get; set; }

        public MessageInfo()
        {
            this.AndroidToken = "";
            this.IOSToken = "";
            this.OpenID = "";
        }

    }

    public class Device
    {
        public string Title { get; set; }
        public int Type { get; set; }
        public string Parkcode { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        public string Viewed { get; set; }
        public string Url { get; set; }
        public string SN { get; set; }

        public Device()
        {
            this.Parkcode = "";
            this.Url = "";
            this.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.Viewed = "false";
            this.SN = "0";

        }
    }

    public class Extra
    { 
        public string Url { get; set; }

        public string First { get; set; }

        public string Keyword1 { get; set; }

        public string Keyword2 { get; set; }

        public string Keyword3 { get; set; }

        public string Keyword4 { get; set; }

        public string Keyword5 { get; set; }

        public string Remark { get; set; }

        public string Firstcolor { get; set; }

        public string Keyword1color { get; set; }

        public string Keyword2color { get; set; }

        public string Keyword3color { get; set; }

        public string Keyword4color { get; set; }

        public string Keyword5color { get; set; }

        public string Remarkcolor { get; set; }

        public Extra()
        {
            this.Url = "";
            this.First = "";
            this.Keyword1 = "";
            this.Keyword2 = "";
            this.Keyword3 = "";
            this.Keyword4 = "";
            this.Keyword5 = "";
            this.Remark = "";
            this.Firstcolor = "#000000";
            this.Keyword1color = "#000000";
            this.Keyword2color = "#000000";
            this.Keyword3color = "#000000";
            this.Keyword4color = "#000000";
            this.Keyword5color = "#000000";
            this.Remarkcolor = "#000000";
        }
    }
}

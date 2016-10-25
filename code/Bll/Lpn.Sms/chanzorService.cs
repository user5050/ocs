using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace OneCoin.Sms
{
    class chanzorService : ISMS
    {
        //http://sms.chanzor.com:8001/sms.aspx?action=send&account=账号&password=密码&mobile=手机号&content=内容&sendTime=
        //string CorpID = "";
        //string Pwd = "";
        //string modeo = "";
        //string neirong = "";
        private string url;
        public string Url
        {
            set { url = value; }
        }

        private bool getResponse(string account, string password, string mobile, string content,ref string message)
        {
            string url = this.url;//"http://sms.chanzor.com:8001/sms.aspx?action=send";
            string postStrTpl = "userid=&account={0}&password={1}&mobile={2}&sendTime=&content={3}";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, mobile, content));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            bool success = false;
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string xml = reader.ReadToEnd();
                Console.WriteLine(xml);
                XDocument doc = XDocument.Parse(xml);
                var ad = from item in doc.Descendants("returnsms")
                         select item;
                foreach (var item in ad)
                {
                    success = item.Element("returnstatus").Value == "Success";//Success Faild
                    message = item.Element("message").Value;
                    break;
                }
                //反序列化upfileMmsMsg.Text
                //实现自己的逻辑
            }
            else
            {
                //访问失败
            }
            return success;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="CorpID">帐号</param>
        /// <param name="Pwd">密码</param>
        /// <param name="Mbno">电话号码</param>
        /// <param name="Msg">内容</param>
        /// <returns></returns>
        public bool SendMessage(string CorpID, string Pwd, string Mbno, string Msg, ref string result)
        {
            try
            {
                return getResponse(CorpID, Pwd, Mbno, Msg, ref result);
            }
            catch (System.Net.WebException WebExcp)
            {
                result = "网络错误，无法连接到服务器！";
                return false;
            }
        }

    }
}

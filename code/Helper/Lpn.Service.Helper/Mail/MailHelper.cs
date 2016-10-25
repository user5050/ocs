using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;

namespace OneCoin.Service.Helper.Mail
{
    public class MailHelper
    {
        //定义邮件服务器及系统账户信息
        private const String MailHost = "smtp.ym.163.com";
        private const String SenderAddress = "support@iic.mobi";
        private const String SenderPassword = "support!";

        #region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">收件人</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="isBodyHtml"></param>
        public static void Send(string mailTo, String subject, String body, bool isBodyHtml)
        {
            try
            {
                //定义邮件消息对象
                var mailMessage = new MailMessage { From = new MailAddress(SenderAddress) };

                //添加到收件人列表中
                var mailTos = Spanner.SpliteStrings(mailTo, ";");
                foreach (var to in mailTos)
                {
                    mailMessage.To.Add(to);
                }

                //构造主题和内容
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isBodyHtml;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.SubjectEncoding = Encoding.UTF8;

                //初始化邮件发送客户端
                var smtp = new SmtpClient(MailHost)
                {
                    Credentials = new NetworkCredential(SenderAddress, SenderPassword)
                };


                //发送邮件
                smtp.Send(mailMessage);
            }
            catch (Exception ex)
            {
                LogHelper.Add("发送邮件", ex);
            }
        }
        #endregion
    }
}

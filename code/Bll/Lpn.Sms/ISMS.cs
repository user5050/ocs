using System;
namespace OneCoin.Sms
{
    /// <summary>
    /// 短信发送接口
    /// </summary>
    interface ISMS
    {
        /// <summary>
        /// 短信发送
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Pwd">密码</param>
        /// <param name="Mbno">手机号</param>
        /// <param name="Msg">短信消息</param>
        /// <param name="result">发送结果</param>
        /// <returns>是否成功</returns>
        bool SendMessage(string UserName, string Pwd, string Mbno, string Msg, ref string result);

        /// <summary>
        /// 发送地址
        /// </summary>
        string Url { set; }
    }
}

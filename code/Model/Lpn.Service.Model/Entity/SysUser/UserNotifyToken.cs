namespace OneCoin.Service.Model.Entity.SysUser
{
    public class UserNotifyToken
    {
        /// <summary>
        /// IOS标识UUID
        /// </summary>
        public string Ios { get; set; }

        /// <summary>
        /// Andriod标识
        /// </summary>
        public string Andriod { get; set; }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string WeiXin { get; set; }
    }
}

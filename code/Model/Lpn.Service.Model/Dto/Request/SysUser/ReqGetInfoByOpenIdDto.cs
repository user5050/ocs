namespace OneCoin.Service.Model.Dto.Request.SysUser
{
    public class ReqGetInfoByOpenIdDto : RequestBaseDto
    {
        /// <summary>
        /// 微信用户OpenId
        /// </summary>
        public string OpenId { get; set; }
    }
}

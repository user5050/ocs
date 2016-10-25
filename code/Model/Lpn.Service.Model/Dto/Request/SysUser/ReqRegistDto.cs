namespace OneCoin.Service.Model.Dto.Request.SysUser
{
    public class ReqRegistDto : RequestBaseDto
    {
        public string Mobile { get; set; }
        public string Vcode { get; set; } 
        public string Devicetoken { get; set; }
    }
}

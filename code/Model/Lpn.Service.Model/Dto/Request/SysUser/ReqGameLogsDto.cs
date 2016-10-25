using OneCoin.Service.Model.Enum.Product;

namespace OneCoin.Service.Model.Dto.Request.SysUser
{
    public class ReqGameLogsDto : RequestPageDto
    {
        public GameLogsType  Type { get; set; }
    }
}

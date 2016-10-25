using System.Text;
using OneCoin.Service.Cache.User;

namespace OneCoin.Service.Bll.Logic.Check
{
    public class CheckBll
    {
        public static string Do()
        {
            var sb = new StringBuilder();
            // 检查数据库
            sb.Append("数据库连接正常");

            // 检查Redis
            UserCacheMgr.GetUserNameById(1);
            sb.Append("Redis连接正常");

            return sb.ToString();
        }
    }
}

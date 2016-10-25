using System.Web;
using OneCoin.Service.Helper.TextAnalyze;

/*
 * 描述: 当前请求上下文管理
 * 包括当前请求对应的用户ID
 * 作者:lee
 * 创建时间:2015/10/21
 */

namespace OneCoin.Service.Bll.Core
{
    public class ContextMgr
    {
        /// <summary>
        /// 当前用户ID
        /// </summary>
        public static string UserId
        {
            get 
            {
                return Change.ToString(HttpContext.Current.Items["_id"]);
            }
            set
            {
               
                HttpContext.Current.Items["_id"] = value;
            }
        }



        /// <summary>
        /// 客户端类型
        /// </summary>
        public static int ClientType
        {
            get
            {
#if DEBUG
                if (HttpContext.Current == null)
                    return 0;
#endif

                return Change.ToInt(HttpContext.Current.Items["_ct"], 0);
            }
            set
            {

                HttpContext.Current.Items["_ct"] = value;
            }
        }
         
    }
}
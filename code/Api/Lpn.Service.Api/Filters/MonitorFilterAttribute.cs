using System.Web.Mvc;
using OneCoin.Service.Cache.Log;

/*
 * 描述: 监控类 
 * 作者:lee
 * 创建时间:2015/10/21
 */
namespace OneCoin.Service.Api.Filters
{
    /// <summary>
    /// 监控类
    /// </summary>
    public class MonitorFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogCacheMgr.IncrementQueryCnt(PartnerId, Modue);

            base.OnActionExecuting(filterContext);
        }
     
        /// <summary>
        /// 合作方id
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public string Modue { get; set; }
    }
}
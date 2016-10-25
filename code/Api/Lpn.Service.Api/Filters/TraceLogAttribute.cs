using System;
using System.Text;
using System.Web.Mvc;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Helper.Serialization;

namespace OneCoin.Service.Api.Filters
{
    public class TraceLogAttribute : ActionFilterAttribute
    {
        private readonly StringBuilder _log = new StringBuilder();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _log.AppendFormat("调用时间：{0}\r\n", DateTime.Now);
            _log.AppendFormat("Url：{0}\r\n", filterContext.RequestContext.HttpContext.Request.Url.OriginalString);
            _log.AppendFormat("Data：{0}\r\n", Spanner.GetHttpFormData());

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _log.AppendFormat("应答结果：{0}\r\n", SimpleSerialization.ObjectToJson(filterContext.Result));

            LogHelper.Trace(_log.ToString());
            _log.Clear();

            base.OnActionExecuted(filterContext);
        }
          
    }
}
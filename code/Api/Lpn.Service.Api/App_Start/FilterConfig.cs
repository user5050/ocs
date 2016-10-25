using System.Web.Mvc;
using OneCoin.Service.Api.Filters; 

namespace OneCoin.Service.Api.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UnHandlerExceptionFilterAttribute());

#if DEBUG
            filters.Add(new PerformanceStatAttribute());
#endif
        }
    }
}
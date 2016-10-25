using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OneCoin.Service.Api.App_Start;
using OneCoin.Service.Api.Filters;
using OneCoin.Service.Bll.Core;
using Newtonsoft.Json;

namespace OneCoin.Service.Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            PerformanceStatAttribute.WriteLog();
        }
         
    }
}
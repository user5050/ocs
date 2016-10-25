using System.Web.Mvc;
using System.Web.Routing;

namespace OneCoin.Service.Api.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "tianhong",
                url: "tianhong/{action}/{id}",
                defaults: new { controller = "PartnerService", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "ykb",
                url: "ykb/{action}/{id}",
                defaults: new { controller = "PartnerService", action="SendPrice",  id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Sync_1",
                url: "Sync/MothlyInfo/{id}",
                defaults: new { controller = "PartnerAction", action = "MonthlyInfoSync", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Sync_2",
                url: "Sync/Renewal/{id}",
                defaults: new { controller = "PartnerAction", action = "GetMonthlyRenewal", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Sync_3",
                url: "Sync/GetProStopPayment/{id}",
                defaults: new { controller = "PartnerAction", action = "GetProStopPayment", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
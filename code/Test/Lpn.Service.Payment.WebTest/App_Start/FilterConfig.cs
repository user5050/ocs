using System.Web;
using System.Web.Mvc;

namespace OneCoin.Service.Payment.WebTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
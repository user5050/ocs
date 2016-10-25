using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.Logic.Check;
using OneCoin.Service.Model.Dto.Response.PayPlatform;

namespace OneCoin.Service.Api.Controllers.Check
{
    public class CheckController : Controller
    {
        //
        // GET: /Check/

        public ActionResult Index()
        {
            var wr = new ResWexinCallBackDto { Return_code = "SUCCESS", Return_msg = "OK" };
            var retStr = wr.Serialize();

            return new TextResult(retStr, false) { ContentType = "text/xml" };
        }

    }
}

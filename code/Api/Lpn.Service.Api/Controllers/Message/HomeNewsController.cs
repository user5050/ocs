using System.Web.Mvc;
using OneCoin.Service.Api.Core;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.Logic.Msg;
using OneCoin.Service.Model.Dto.Request;

namespace OneCoin.Service.Api.Controllers.Message
{
    public class HomeNewsController : BaseController
    {
        //
        // GET: /Msg/

        public ActionResult Index(RequestPageDto data)
        {
            return new ClientResult(HomeNewsBll.Gets());
        }

        public ActionResult Detail(ReqIntIdDto  data)
        {
            return new ClientResult(HomeNewsBll.Gets());
        }
    }
}

using System.Web.Mvc;
using Lpn.Service.Api.Core;
using Lpn.Service.Api.Core.Result;
using Lpn.Service.Api.Filters;
using Lpn.Service.Bll.Logic.Car;
using Lpn.Service.Model.Dto.Request.Car;

namespace Lpn.Service.Api.Controllers.Car
{
    public class CarVerifyController : BaseController
    {
        //
        // GET: /CarVerify/
        [UserAuthFilter]
        public ActionResult State(ReqCarVerifyDto data)
        {
            return new ClientResult(CarVerifyBll.Query(data.CarNo));
        }


        [UserAuthFilter]
        public ActionResult Save(ReqCarVerifyDto data)
        {
            data.UserId = UserId;
            return new ClientResult(CarVerifyBll.Save(data));
        }

        [CommAuthFilter]
        public ActionResult NotifyState(ReqCarVerifyDto data)
        {
            data.UserId = UserId;
            return new ClientResult(CarVerifyBll.Save(data));
        }
    }
}

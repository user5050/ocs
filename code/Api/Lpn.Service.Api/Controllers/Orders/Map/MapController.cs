using System.Web.Mvc;
using Lpn.Service.Api.Core;
using Lpn.Service.Api.Core.Result;
using Lpn.Service.Bll.Logic.Map;
using Lpn.Service.Model.Dto.Request.Map;

namespace Lpn.Service.Api.Controllers.Map
{
    public class MapController : BaseController
    {
        //
        // GET: /Map/

        public ActionResult GetMapBase(ReqGetMapBaseDto data)
        {
            return new ClientResult(MapBll.GetBaseInfo(data));
        }

        public ActionResult GetMapDetail(ReqGetMapDetailDto data)
        {
            return new ClientResult(MapBll.GetDetailInfo(data));
        }

        public ActionResult GetParkFeeDetail(ReqGetFeeDto data)
        {
            return new ClientResult(MapBll.GetParkFee(data));
        }

        public ActionResult GetPos(ReqGetPosDto data)
        {
            return new ClientResult(MapBll.GetPos(data));
        }

    }
}

using System.Web.Mvc;
using OneCoin.Service.Api.Core;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Api.Filters;
using OneCoin.Service.Bll.Logic.Sys;
using OneCoin.Service.Model.Dto.Request.Banner;

namespace OneCoin.Service.Api.Controllers.Banner
{
    [UserAuthFilter]
    public class BannerController : BaseController
    {
        // 设置参数
        // GET: /Banner/Get
        public ActionResult Get(ReqGetDto data)
        {
            return new ClientResult(HomeBannerBll.Get());
        }
    }
}

using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Result;
using QiNiuTool.Core;

namespace OneCoin.Service.Api.Controllers.Resource
{
    public class ResourceController : Controller
    {
        // 获取资源存储上传凭证
        // GET: /resource/token

        public ActionResult Token()
        {
            return new ClientResult(ResultDto.DefaultSuccess(QiNiuApi.Token(WebConfig.ResourceBucket)));
        }
    }
}

using System.Web.Mvc;
using OneCoin.Service.Api.Core;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Api.Filters;
using OneCoin.Service.Bll.Logic.FeedBack;
using OneCoin.Service.Model.Dto.Request.FeedBack;

namespace OneCoin.Service.Api.Controllers.FeedBack
{
    public class FeedBackController : BaseController
    {
        // 保存反馈意见
        // GET: /FeedBack/Save
        [UserAuthFilter]
        public ActionResult Save(ReqFeedBackDto data)
        {
            return new ClientResult(FeedBackBll.Save(UserId, data.Content, data.Contact));
        } 
    }
}

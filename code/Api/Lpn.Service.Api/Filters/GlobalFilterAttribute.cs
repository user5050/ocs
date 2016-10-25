using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Result;
using System.Web.Mvc;
/*
 * 描述: 全局检查类 
 * 作者:lee
 * 创建时间:2015/10/21
 */
namespace OneCoin.Service.Api.Filters
{
    public class GlobalFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //分页
            var lastNo = HttpHelper.GetPramaValue("lastNo", 0);
            var take = HttpHelper.GetPramaValue("take", 20);

            if (lastNo < 0 || take < 0 || take > 1000)
            {
                filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalParameterError,"分页参数不正确"));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
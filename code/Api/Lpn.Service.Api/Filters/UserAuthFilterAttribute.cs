using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Result;

/*
 * 描述: 用户token检查类
 * 检查token的有效性，并转化为userid,保存到当前上下文环境中
 * 作者:lee
 * 创建时间:2015/10/21
 */

namespace OneCoin.Service.Api.Filters
{
    /// <summary>
    /// 对用户Session检测
    /// </summary>
    public class UserAuthFilterAttribute : UserTokenToIdFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetDoubleSignCheck(false);
            base.OnActionExecuting(filterContext);

            //用户ID
            var userId = ContextMgr.UserId;

            //是否允许检测
            if (WebConfig.EnableToken)
            { 
                //检测是否匹配 
                if (string.IsNullOrEmpty(userId))
                {
                    //匹配失败，返回错误提示
                    filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.AccountSessionError));
                }
             } 
        } 

    }
}
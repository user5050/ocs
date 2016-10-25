using System;
using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Result;
/*
 * 描述: 全局异常捕获类
 * 捕获所以的异常，并记录日志。
 * 作者:lee
 * 创建时间:2015/10/21
 */

namespace OneCoin.Service.Api.Filters
{
    /// <summary>
    /// 未处理的异常处理
    /// </summary>
    public class UnHandlerExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //捕获未处理的异常，并且隐藏到异常信息
            LogHelper.Add("未捕获的异常", filterContext.Exception,false);
            filterContext.ExceptionHandled = true;


            ResultDto retObj;
            //参数异常
            if (filterContext.Exception is ArgumentException)
            {
                retObj = ResultDto.DefaultError(ResultState.GlobalParameterError, "未处理的异常处理");
            }
            else
            {
#if DEBUG
                retObj = ResultDto.DefaultError(ResultState.GlobalSystemError, filterContext.Exception.Message);
#else
                retObj = ResultDto.DefaultError(ResultState.GlobalSystemError);
#endif


            }

            //返回错误信息
            filterContext.Result = new ClientResult(retObj);
        }
    }
}
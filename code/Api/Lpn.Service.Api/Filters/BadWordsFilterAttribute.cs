using System;
using System.Web;
using System.Web.Mvc;
using OneCoin.Service.Helper.Http;
/*
 * 描述: 脏字过滤类 
 * 作者:lee
 * 创建时间:2015/10/21
 */
namespace OneCoin.Service.Api.Filters
{
    /// <summary>
    /// 脏字过滤类
    /// </summary>
    public class BadWordsFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!string.IsNullOrEmpty(FilterParamaterName))
            {
                if (filterContext.ActionParameters.ContainsKey(FilterParamaterName))
                { 
                    var value = filterContext.ActionParameters[FilterParamaterName].ToString();
                    if (!string.IsNullOrEmpty(value) && string.Equals(HttpContext.Current.Request.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
                    {
                        value = HttpUtility.UrlDecode(value);
                    }


                    if (IsBase64String)
                    {
                        value = Spanner.ConvertFromBase64(value);
                    }


                    //if (FilterComp.IsContainBadword(value))
                    //{
                    //    filterContext.Result = new ClientResult(ResultDTO.DefaultError(Models.Enum.Result.ResultState.GlobalBadWordError));
                    //    return;
                    //}
                }
            }
            else
            {
                foreach (var item in filterContext.ActionParameters)
                {
                    if (item.Value != null)
                    {
                        var value = item.Value.ToString(); 
                        if (!string.IsNullOrEmpty(value) && string.Equals(HttpContext.Current.Request.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
                        {
                            value = HttpUtility.UrlDecode(value);
                        }


                        if (IsBase64String)
                        {
                            value = Spanner.ConvertFromBase64(value);
                        }

                        //if (FilterComp.IsContainBadword(value))
                        //{
                        //    filterContext.Result =
                        //        new ClientResult(
                        //            ResultDTO.DefaultError(Models.Enum.Result.ResultState.GlobalBadWordError));
                        //    return;
                        //}
                    }
                }
            }
        }

        /// <summary>
        /// 指定过滤参数
        /// </summary>
        public string FilterParamaterName { get; set; }

        /// <summary>
        /// 是否是base64字符
        /// </summary>
        public bool IsBase64String { get; set; }
    }
}
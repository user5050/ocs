using System.Linq;
using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Param;
using OneCoin.Service.Model.Result;

/*
 * 描述: 固定KEY签名 
 * 作者:lee
 * 创建时间:2015/11/12
 */

namespace OneCoin.Service.Api.Filters
{
    /// <summary>
    /// 固定KEY签名
    /// </summary>
    public class CommAuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        { 
            //是否允许检测
            if (WebConfig.EnableToken)
            {
                var json = Spanner.GetHttpFormData();
                CheckSign(filterContext, json, WebConfig.CommSignKey);
            }
             
            base.OnActionExecuting(filterContext);
        } 


        private void CheckSign(ActionExecutingContext filterContext,string data, string singKey)
        {
            if (string.IsNullOrEmpty(data)) return;

            if (!filterContext.HttpContext.Request.QueryString.AllKeys.Contains(ParamDefine.Sign))
            {
                filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalParameterError));
            }
            else
            {
                //签名验证
                var sign = filterContext.HttpContext.Request[ParamDefine.Sign];
                //MAC  KEY
                var source = string.Format("{0}{1}", data, singKey);

                //md5验证
                var rightSign = EncryptMgr.MD5(source);
                if (System.String.Compare(sign, rightSign, System.StringComparison.OrdinalIgnoreCase) != 0)
                {
                    filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalSignInvalid));
                }
            }
        }  
    }
}
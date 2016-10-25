using System.Linq;
using System.Text;
using System.Web.Mvc;
using Lpn.Service.Api.Core.Result;
using Lpn.Service.Helper.Encrypt;
using System.Collections.Generic;
using Lpn.Service.Model.Enum;
using Lpn.Service.Model.Param;
using Lpn.Service.Model.Result;
/*
 * 描述: 签名验证类
 * 验证签名是否正常
 * 作者:lee
 * 创建时间:2015/10/21
 */
namespace Lpn.Service.Api.Filters
{
    /// <summary>
    /// 接口签名认证
    /// </summary>
    public class SignFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        { 
#if DEBUG
            //return;
#endif 

            var parameters = new StringBuilder();
            var datas = new Dictionary<string, string>();

            // url参数数据
            foreach (var urlKey in filterContext.HttpContext.Request.QueryString.AllKeys)
            {
                datas[urlKey] = filterContext.HttpContext.Request.QueryString[urlKey];
            }

            // post数据
            foreach (var formKey in filterContext.HttpContext.Request.Form.AllKeys)
            {
                datas[formKey] = filterContext.HttpContext.Request.Form[formKey];
            }


            //#if !DEBUG
            //是否包含签名信息
            if (!datas.Keys.Contains(ParamDefine.Sign))
            {
                filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalParameterError));
            }
            else
            {
                //签名验证
                var sign = filterContext.HttpContext.Request[ParamDefine.Sign];

                //字典序排列
                foreach (var key in datas.Keys.ToList().OrderBy(p => p))
                {
                    if (string.Compare(key ,ParamDefine.Sign,true) != 0)
                    { 
                        parameters.AppendFormat("{0}={1}&", key, datas[key]);
                    }
                }

                if (parameters.Length > 0) parameters.Length--;

                //MAC  KEY
                //parameters.Append();


                //md5验证
                var rightSign = EncryptMgr.MD5(parameters.ToString());
                if (System.String.Compare(sign, rightSign, System.StringComparison.OrdinalIgnoreCase) != 0)
                {
                    filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalSignInvalid));
                }
                //#endif 
            }

            //#endif
            base.OnActionExecuting(filterContext);
        }

    }
}
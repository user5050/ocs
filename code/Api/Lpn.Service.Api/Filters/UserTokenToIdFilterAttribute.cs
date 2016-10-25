using System.Linq;
using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Cache.Token;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Param;
using OneCoin.Service.Model.Result;

namespace OneCoin.Service.Api.Filters
{
    public class UserTokenToIdFilterAttribute : ActionFilterAttribute
    {
        private bool _enableDoubleSignCheck = true;
        protected void SetDoubleSignCheck(bool enable)
        {
            _enableDoubleSignCheck = enable;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //用户ID
            var token = HttpHelper.GetPramaValue(ParamDefine.Token, string.Empty);
            var userId = TokenCacheMgr.GetUserId(token);

            if (!string.IsNullOrEmpty(userId))
            {
                ContextMgr.UserId = userId; 
            }


            /* 
             * 签名验证(2016/7/6 lee修改)
             * 1.如果是登录用户，则使用用户id作为key验证
             * 2.如果是未登录用户，则使用固定签名方式
            */
            var json = Spanner.GetHttpFormData();
            CheckSign(filterContext, json, userId);

             
            base.OnActionExecuting(filterContext);
        }

        #region private

        /// <summary>
        /// 签名验证(MD5)
        /// </summary>
        /// <param name="filterContext"></param>
        /// <param name="data"></param>
        /// <param name="key"></param>
        private void CheckSign(ActionExecutingContext filterContext, string data, string key)
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
                var source = string.Format("{0}{1}", data, key);

                //md5验证
                var rightSign = EncryptMgr.MD5(source);
                if (System.String.Compare(sign, rightSign, System.StringComparison.OrdinalIgnoreCase) != 0)
                {
                    if (_enableDoubleSignCheck)
                    {
                        //再次检查固定签名是否正确，如果固定签名正确则可以放行
                        source = string.Format("{0}{1}", data, WebConfig.CommSignKey);
                        //md5验证
                        rightSign = EncryptMgr.MD5(source);

                        if (System.String.Compare(sign, rightSign, System.StringComparison.OrdinalIgnoreCase) != 0)
                        {
#if DEBUG
                            LogHelper.Add(source);
#endif
                            filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalSignInvalid));
                        }
                    }
                    else
                    {
#if DEBUG
                        LogHelper.Add(source);
#endif
                        filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalSignInvalid));
                    }

                }
            }
        }
        #endregion

    }
}
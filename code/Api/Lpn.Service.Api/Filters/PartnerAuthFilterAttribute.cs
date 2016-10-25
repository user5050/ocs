using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Cache.Partner;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Helper.Serialization;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Param;
using OneCoin.Service.Model.Result;

/*
 * 描述: 用户token检查类
 * 检查token的有效性，并转化为userid,保存到当前上下文环境中
 * 作者:lee
 * 创建时间:2016/1/26
 */

namespace OneCoin.Service.Api.Filters
{
    /// <summary>
    /// 对合作商权限检测
    /// </summary>
    public class PartnerAuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //用户ID
            var partnerId = HttpHelper.GetPramaValue(ParamDefine.PartnerId, string.Empty);
            
            //是否允许检测
            if (WebConfig.EnableToken)
            {
                var key = PartnerCacheMgr.GetKey(partnerId);
                //检测是否匹配 
                if (string.IsNullOrEmpty(key))
                {
                    //匹配失败，返回错误提示
                    filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.AccountSessionError));
                }

                // 签名验证 
                var json = Spanner.GetHttpFormData();
                CheckSign(filterContext, json, key);

                // 检查车场编码是否已授权
                if (NeedCheckParkCode)
                {
                    if (!ParkCodeAuthed(partnerId, json))
                    {
                        //匹配失败，返回错误提示
                        filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalParameterError,"停车场编号未被授权"));
                    }
                }
            }
              
            base.OnActionExecuting(filterContext);
        }

        private bool ParkCodeAuthed(string partnerId, string json)
        {
            var paras = SimpleSerialization.JsonToObject<Dictionary<string, object>>(json);

            var parkCode = "";
            if (paras.ContainsKey("ParkCode"))
            {
                parkCode = paras["ParkCode"].ToString();
            }
            else if (paras.ContainsKey("parkCode"))
            {
                parkCode = paras["parkCode"].ToString();
            }
            else if (paras.ContainsKey("parkcode"))
            {
                parkCode = paras["parkcode"].ToString();
            }
            else if (paras.ContainsKey("Parkcode"))
            {
                parkCode = paras["Parkcode"].ToString();
            }

            if (string.IsNullOrWhiteSpace(parkCode))
            {
                return false;
            }

            return PartnerCacheMgr.IsAuthedParkCode(partnerId, parkCode);
        }
         

        private void CheckSign(ActionExecutingContext filterContext,string data, string key)
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
                    LogHelper.Add(source);

                    filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalSignInvalid));
                }
            }
        }


        /// <summary>
        /// 是否检查车场编号授权
        /// </summary>
        public bool NeedCheckParkCode { get; set; }
    }
}
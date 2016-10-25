using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.SysUser;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.TextAnalyze;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Param;
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
    /// 应用之间内部调用权限验证,对服务器(
    /// 120.25.71.67  云服
    /// 120.24.102.227 云服
    /// 120.25.135.84  负载均衡
    /// 182.150.28.182) 公司公网
    /// 127.*.*.* 192.168.*.* 局域网
    /// </summary>
    public class XServiceAuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var ip = HttpHelper.UserHostAddress;

            if (! DoAuth(ip))
            {
                filterContext.Result = new ClientResult(ResultDto.DefaultError(ResultState.GlobalSignInvalid, "应用之间内部调用权限验证"+ip));
            }
        }

        private bool DoAuth(string ip)
        { 
            /*
             * 局域网可用的ip地址范围为:
                A类地址10.0.0.0 - 10.255.255.255
                b类网172.16.0.0 - 172.31.255.255
                c类网192.168.0.0 -192.168.255.255
             */

            if (ip == "120.25.71.67" || ip == "120.24.102.227" || ip == "120.25.135.84" || ip == "182.150.28.182"
                || IpLocator.IsPrivateIp(ip)
                )
            {
                return true;
            }

            return false;
        } 
    }
}
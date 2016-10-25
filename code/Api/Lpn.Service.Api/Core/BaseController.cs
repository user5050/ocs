using System.Web.Mvc;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Param;

/*
 * 描述: 基础类 
 * 作者:lee
 * 创建时间:2015/10/21
 */

namespace OneCoin.Service.Api.Core
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前会话用户ID
        /// </summary>
        protected string UserId
        {
            get { return ContextMgr.UserId; }
        }


        /// <summary>
        /// 客户端类型
        /// </summary>
        protected int ClientType
        {
            get { return HttpHelper.GetPramaValue(ParamDefine.Client, 0); }
        }


        /// <summary>
        /// 合作商id
        /// </summary>
        protected string PartnerId
        {
            get
            {
                if (HttpContext == null) return "tianhong";

                return HttpHelper.GetPramaValue(ParamDefine.PartnerId, "");
            }
        }
    }
}
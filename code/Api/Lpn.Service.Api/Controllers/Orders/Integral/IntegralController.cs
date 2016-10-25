using System.Web.Mvc;
using Lpn.Service.Api.Core;
using Lpn.Service.Api.Core.Result;
using Lpn.Service.Api.Filters;
using Lpn.Service.Bll.Logic.Integral;
using Lpn.Service.Model.Dto.Request.Integral;
using Lpn.Service.Model.Dto.Request.Orders;

/*
 * 功能：停车场积分缴费
 * 作者：lee
 * 时间：2016/5/30
 * 详细：提供接口与客户端，用户可通过web来支付临停费用.
 *      积分余额由停车场提供
 *      积分余额使用规则，积分余额必须>=产生的停车费用才能使用，不能部分抵扣
 */

namespace Lpn.Service.Api.Controllers.Integral
{
    [CommAuthFilter]
    public class IntegralController : BaseController
    {
        /// <summary>
        /// 积分余额查询
        /// 返回的结果应该是积分折算后的RMB余额
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult Query(ReqIntegralQueryDto data)
        {
            return new ClientResult(IntegralBll.Query(data.PartnerId, data.IntegralUserToken));
        }


        /// <summary>
        /// 积分支付临停费用
        /// 直接通知停车场，平台不记录任何数据
        /// 建议停车场注意重复数据问题，如果重复提交请返回相关错误编码，比如：已支付或重复支付
        /// 暂不支持优惠券，抵扣
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult Pay(ReqGetPurchaseOrderNoDto data)
        {
            return new ClientResult(IntegralBll.Pay(data));
        }
    }
}

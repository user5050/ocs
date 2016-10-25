using System;
using System.Web.Mvc;
using OneCoin.Service.Api.Core;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Api.Filters;
using OneCoin.Service.Bll.Logic.Orders;
using OneCoin.Service.Model.Dto.Request.Orders;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Api.Controllers.Orders
{
    
    public class OrdersController : BaseController
    {
        // 获取月租支付订单号
        // GET: /Recharge/GetOrderNo
        [UserAuthFilter] //匿名查询
        public ActionResult GetOrderNo(ReqGetMonthlyFeeOrderNoDto data)
        {
            var req = new PurchaseReq
            {
                PaymentType = (PaymentType)data.PaymentType,
                Purpose = PaymentPurpose.商品购买,
                OrderMoney = data.OrderMoney,
                OrderTime = DateTime.Now,
                Description = data.OrderDesc,
                UserId = UserId, 
                ClientType = ClientType, 
                CouponId = data.CouponId,
                TotalMoney = data.totalmoney,
                ClientIp = data.ClientIp,
                MerchantUrl = data.MerchantUrl,
            };
             
            return new ClientResult(OrdersBll.GetMonthlyFeeOrder(req));
        }


        /// <summary>
        /// 获取充值订单号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [UserAuthFilter]
        public ActionResult GetChargeOrderNo(ReqGetChargeOrderNoDto data)
        {
            var req = new PurchaseReq
            {
                PaymentType = (PaymentType)data.paymenttype,
                Purpose = PaymentPurpose.账户充值,
                CarNo = data.chargeusername,
                ParkCode = "",
                OrderMoney = data.ordermoney,
                OrderTime = DateTime.Now,
                Description = data.orderdesc,
                UserId =  UserId,
                CouponMoney = 0,
                DeduMoney = 0,
                OpenId = data.openId,
                ClientType = ClientType,
                TotalMoney = data.totalmoney,
                ClientIp = data.ClientIp,
                MerchantUrl = data.MerchantUrl
            };
             
            return new ClientResult(OrdersBll.GetRechargeOrder(req));
        }

         
        /// <summary>
        /// 主动取消订单(由支付端确认后回调)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult CancelOrderNo(ReqCancelOrderNo data)
        {
            return new ClientResult(OrdersBll.CancelOrderNo(data.OrderNo));
        }
         

        /// <summary>
        /// 主动确认订单是否完成(由支付端确认后回调)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult ConfrimOrderNo(ReqCancelOrderNo data)
        {
            return new ClientResult(OrdersBll.ConfrimOrderNo(data.OrderNo));
        }
         

        /// <summary>
        /// 获取订单支持的平台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult GetSupports(ReqGetSupportsDto data)
        {
            return new ClientResult(OrdersBll.GetSupports(data.ParkCode,data.Purpose));
        }


          
        /// <summary>
        /// 测试订单
        /// </summary>
        /// <returns></returns>
        [UserTokenToIdFilter]
        public ActionResult GetTestOrderNo()
        {
            var ret= OrdersBll.GetTestOrder(new PurchaseReq
                {
                    OrderMoney = 10,
                    Purpose = PaymentPurpose.租用车位,
                    PaymentType = PaymentType.BestPayMobile,
                    OrderTime = DateTime.Now,
                    ClientIp = "182.150.28.182",
                    MerchantUrl = "http://localhost:52344/home/callback"
                });

            return new ClientResult(ret);
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using OneCoin.Payment;
using OneCoin.Payment.Entity;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.Coupon;
using OneCoin.Service.Bll.Logic.Orders.Task;
using OneCoin.Service.Bll.Logic.Partnerpay;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Dal.Dal.Orders;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Dto.Response.Orders;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Entity.Payment.Activity;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Enum.Payment;
using OneCoin.Service.Model.Result;

namespace OneCoin.Service.Bll.Logic.Orders
{
    public class OrdersBll : BllBase
    {
        #region 第三方平台支付成功后回调通知处理
        /// <summary>
        /// 第三方平台支付成功后回调通知处理
        /// </summary>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ResultDto PaySuccessCallBack(PaymentType type, IDictionary<String, String> param)
        {
            // 查询是否有订单号信息
            var orderNo = PaymentMgr.TryGetOrderNo(type, param);
            if (string.IsNullOrEmpty(orderNo)) return ResultDto.DefaultError(ResultState.GlobalParameterError);

            // 未有此订单，则返回正常，不需要通知
            var order = GetUnProcessOrder(orderNo);
            if (order == null) return ResultDto.DefaultSuccess();


            // 检查参数合法信及额外信息
            var req = PaymentMgr.CheckNotify(new CallBackPaymentInfo { Param = param, ParkCode = order.ParkCode, Type = type });
            if (req == null) return ResultDto.DefaultError(ResultState.GlobalParameterError);
            if (string.IsNullOrEmpty(req.Qn)) return ResultDto.DefaultError(ResultState.GlobalParameterError);


            //锁定订单并处理
            var isCommit = false;
            try
            {
                var conn = TransactionManager.GetCurrentConnection();

                // 预支付订单成功回调
                isCommit = OrdersPreBll.OrderSuccess(conn, req.OrderNo, req.Qn, req.OrderMoney);
            }
            finally
            {
                if (isCommit)
                {
                    TransactionManager.Commit();
                }
                else
                {
                    TransactionManager.Rollback();
                }
            }

            return isCommit ? ResultDto.DefaultSuccess(req.Description) : ResultDto.DefaultError(ResultState.GlobalParameterError);
        }
         
        #endregion
         
        #region 生成订单号

        #region 获取充值订单号

        /// <summary>
        /// 获取充值订单号
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static ResultDto GetRechargeOrder(PurchaseReq req)
        {
            // 宜泊支付 不支持充值
            if (req.Purpose != PaymentPurpose.账户充值 ||  req.PaymentType == PaymentType.EPark)
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }


            return GetOrder(req);
        }

        #endregion

        #region 获取月租支付订单号

        /// <summary>
        /// 获取月租支付订单号
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static ResultDto GetMonthlyFeeOrder(PurchaseReq req)
        {
            // 不支持充值
            if ((req.Purpose != PaymentPurpose.商品购买))
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }
  

            return GetOrder(req);
        }


        public static ResultDto GetTestOrder(PurchaseReq req)
        { 
            return GetOrder(req);
        }
         

        #endregion
         

        #endregion

        #region App订单主动回调确认

        #region 取消订单

        /// <summary>
        /// 取消订单
        /// </summary> 
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static ResultDto CancelOrderNo(string orderNo)
        {
            try
            {
                // 查询预支付
                var order = OrdersPreBll.GetOrders(orderNo);
                if (order == null) return ResultDto.DefaultError(ResultState.GlobalNotData);

                order.Description = string.Format("{0}(App订单主动回调确认--取消订单)", order.Description);
                if (OrdersPreBll.MoveToRecycle(order))
                {
                    return ResultDto.DefaultSuccess();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Add("取消订单", ex);
            }
            

            return ResultDto.DefaultSuccess();
        }
        #endregion

        #region 订单确认
        /// <summary>
        /// 订单确认
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static ResultDto ConfrimOrderNo(string orderNo)
        {
            var order = OrdersPreBll.GetOrders(orderNo);
            if (order == null) return ResultDto.DefaultError(ResultState.GlobalNotData);

            var res = new PurchaseQueryRes();
            // 检查参数合法信及额外信息
            PaymentMgr.Query(new PurchaseQueryReq
            {
                IsWxApp = string.IsNullOrEmpty(order.OpenId),
                OrderNo = orderNo,
                PaymentType = (PaymentType)order.PaymentType,
                OrderTime = order.OrderTime.ToString(CultureInfo.CurrentCulture)
            }, ref res);

            if (string.IsNullOrEmpty(res.QN)) return ResultDto.DefaultError(ResultState.GlobalParameterError);


            //锁定订单并处理
            var isCommit = false;
            try
            {
                var conn = TransactionManager.GetCurrentConnection();

                // 预支付订单成功回调
                isCommit = OrdersPreBll.OrderSuccess(conn, order.OrderNo, res.QN, new decimal(res.OrderMoney));
            }
            finally
            {
                if (isCommit)
                {
                    TransactionManager.Commit();

                    //通知任务立即处理此订单
                    OrdersTaskBll.RedirectProccessOrder(OrdersSuccesBll.GetOrders(res.OrderNo));

                }
                else
                {
                    TransactionManager.Rollback();
                }
            }

            return isCommit ? ResultDto.DefaultSuccess() : ResultDto.DefaultError(ResultState.GlobalParameterError);
        }
        #endregion

        #endregion

        #region 订单历史

        #region 获取我成功的订单号 

        #endregion

        #region 获取我撤费的订单号

         
        #endregion
         

        #endregion

        #region 获取停车场支持的支付方式

        /// <summary>
        /// 获取停车场支持的支付方式
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="purpose"></param>
        /// <returns></returns>
        public static ResultDto GetSupports(string parkCode, PaymentPurpose purpose)
        {
            var supports = PayConfigBll.SupportType(parkCode);

            //if (purpose != PaymentPurpose.账户充值)
            //{
            //    supports.Add((int)PaymentType.EPark);
            //}

            return ResultDto.DefaultSuccess(supports);
        }

        #endregion
         
        #region internal

        #region 获取订单金额

        /// <summary>
        /// 获取订单金额(预支付/完成支付)
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="parkCode"></param>
        /// <param name="purpose"></param>
        /// <returns></returns>
        internal static decimal GetOrderMoney(string orderNo,out string  parkCode,out PaymentPurpose purpose)
        {
            // 查询预支付
            var order = OrdersPreBll.GetOrders(orderNo);
            if (order != null)
            {
                parkCode = order.ParkCode;
                purpose = (PaymentPurpose)order.Purpose;
                return order.OrderMoney;
            }

            // 查询成功订单
            var sOrder = OrdersSuccesBll.GetOrders(orderNo);
            if (sOrder != null)
            {
                parkCode = sOrder.ParkCode;
                purpose = (PaymentPurpose)sOrder.Purpose;

                return sOrder.OrderMoney;
            }

            parkCode = "";
            purpose = (PaymentPurpose)(-1);
            return -1;
        }


        /// <summary>
        /// 获取订单金额(预支付/完成支付)
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        internal static decimal GetOrderMoney(string orderNo)
        {
            // 查询预支付
            var order = OrdersPreBll.GetOrders(orderNo);
            if (order != null) return order.OrderMoney;

            // 查询成功订单
            var sOrder = OrdersSuccesBll.GetOrders(orderNo);
            if (sOrder != null) return sOrder.OrderMoney;

            return -1;
        }

        #endregion

        #region 获取订单号

        internal static ResultDto GetOrder(PurchaseReq req)
        { 
            // 查询是否使用了优惠券
            if (!string.IsNullOrEmpty(req.CouponId))
            {
                // 使用的优惠券是否合法
                if (!CouponBll.IsCanUse(req.CouponId,req.TotalMoney))
                {
                    return ResultDto.DefaultError(ResultState.CouponCanntUse);
                }

                req.CouponMoney = Math.Min(req.TotalMoney > 0 ? req.TotalMoney : Int32.MaxValue, CouponInfoBll.GetCouponMoney(req.CouponId));
            }

            if (req.PaymentType == PaymentType.WeixinPay)
            {
                // 如果存在 OpenId ,则为微信公众号支付
                req.WxpayType = !string.IsNullOrEmpty(req.OpenId) ? 1 : 0;
            } 

            // 生成编号
            req.OrderNo = GenericOrderNo(req.UserId);

            if (req.TotalMoney <= 0)
            {
                req.TotalMoney = (int)req.OrderMoney + (int)req.CouponMoney;
            }

            // 检查金额
            if ((req.OrderMoney + req.CouponMoney + req.DeduMoney + (decimal)req.VipMoney) < req.TotalMoney)
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }

            // 检查应收
            if (req.TotalMoney <= 0)
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }

            // 微信活动
            req.ExtreGoodsTag = WebConfig.PayExtreGoodsTag;

            FillExtre(req);

            var res = new PurchaseRes();
            if (PaymentMgr.GetPurchaseNo(req, ref res))
            {
                if (OrdersPreBll.Add(req))
                {
                    return ResultDto.DefaultSuccess(new ResOrderDto
                    {
                        OrderNo = req.OrderNo,
                        Extre = res.ExtraParam,
                        OrderMoney = req.OrderMoney,
                        Description = req.Description
                    });
                }
            }

            return ResultDto.DefaultError(ResultState.GlobalParameterError);
        }


        private static void FillExtre(PurchaseReq req)
        {
             
        }

        #endregion

        #region 生成订单编号

        internal static string GenericOrderNo(string userId)
        {
            return string.Format("{0}{1}", Spanner.GetOrderNo(), userId.Substring(userId.Length-8,8));
        }
        #endregion

        #region 查询带确认的订单

        internal static OrdersPreDb GetUnProcessOrder(string orderNo)
        {
            var preOrder = OrdersPreBll.GetOrders(orderNo);
            if (preOrder != null) return preOrder;

            //查询回收站的订单,可能客户端异常导致正常的订单调用了CancelOrder接口，导致了订单回调失败
            //无法执行后续流程，造成用户缴费成功，但订单缺成了废单。
            var recyc = OrdersPreBll.GetRecycleOrder(orderNo);
            if (recyc != null)
            {
                OrdersPreBll.MoveToPre(recyc);
                return OrdersPreBll.GetOrders(orderNo);
            }

            return null;
        }
        #endregion

        #region 查询最后一笔临停订单

        /// <summary>
        /// 查询最后一笔临停订单
        /// </summary>
        /// <param name="carNo"></param>
        /// <param name="entranceTime"></param>
        /// <returns></returns>
        internal static OrdersSuccesDb GetLastPay(string carNo, DateTime entranceTime)
        {
            //查询指定时间后的订单
            var orderMinDate = DateTime.Now.AddDays(-3);

            return OrdersSuccesDal.FindLastPay(carNo, orderMinDate, entranceTime);
        }

        #endregion

        #region 历史订单
        /// <summary>
        /// 历史订单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startNo"></param>
        /// <param name="take"></param>
        /// <param name="propuses"></param>
        /// <returns></returns>
        internal static List<OrdersSuccesDb> GetOrders(int userId, string startNo, int take,List<int> propuses )
        {
            return OrdersSuccesDal.GetOrdersByPropuse(userId, startNo, take, propuses);
        }
        #endregion

        #endregion

        #region private

        /// <summary>
        /// 检查金额是否一致
        /// </summary>
        /// <returns></returns>
        private static bool CheckPrice()
        {
            return true;
        }

        /// <summary>
        /// 检查参数
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private static bool CheckParams(ActivityPurchaseReq req)
        {
            if (req.SubPurpose == PaymentSubPurpose.上门洗车)
            {
                if (string.IsNullOrEmpty(req.Name)
                    || string.IsNullOrEmpty(req.Contract)
                    || string.IsNullOrEmpty(req.ParkingLot)
                    || string.IsNullOrEmpty(req.PayDesc)
                    || string.IsNullOrEmpty(req.ServiceAddr)
                    || string.IsNullOrEmpty(req.ActivityName)
                    || string.IsNullOrEmpty(req.CarType)
                    || string.IsNullOrEmpty(req.CarNo))
                {
                    return false;
                }
            }
            else if (req.SubPurpose == PaymentSubPurpose.到店洗车)
            {
                if (string.IsNullOrEmpty(req.PayDesc)
                    || string.IsNullOrEmpty(req.CarType)
                    || string.IsNullOrEmpty(req.CarNo))
                {
                    return false;
                }
            }

            else if (req.SubPurpose == PaymentSubPurpose.房车露营地)
            {
                if(req.SelectedDate < DateTime.Now.Date) return false;
            }

            // 商品数量检查
            if (req.Amount <=0)
            {
               return false;
            }

            return true;
        }


        #endregion

        /// <summary>
        /// 部分订单号获取最新订单
        /// </summary>
        /// <param name="partOrderNo"></param>
        /// <returns></returns>
        internal static OrdersSuccesDb GetOrderByPartOrderNo(string partOrderNo)
        {
            return OrdersSuccesDal.GetOrdersByPartOrderNo(partOrderNo);
            
        }
    }
}

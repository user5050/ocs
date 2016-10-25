using System;
using OneCoin.Payment;
using OneCoin.Payment.Entity;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Bll.Logic.Orders.Task.OrderPreProccess
{
    public class OrderPreProccessBll
    {
        public static bool Proccess(OrdersPreDb order)
        {
            var isCanDelOrder = false;
            try
            {
                // 对应平台查询
                if (order.PaymentType != (int)PaymentType.EPark)
                {
                    var res =new PurchaseQueryRes();
                    if (PaymentMgr.Query(new PurchaseQueryReq
                        {
                            OrderNo=order.OrderNo,
                            OrderTime = order.OrderTime.ToString(),
                            PaymentType = (PaymentType)order.PaymentType
                            ,IsWxApp = string.IsNullOrEmpty(order.OpenId)
                        }, ref res))
                    {
                        // 查询成功
                        if (!string.IsNullOrEmpty(res.QN))
                        { 
                            var isCommit = false;
                            try
                            {
                                var conn = TransactionManager.GetCurrentConnection();

                                // 设置订单支付成功
                                isCommit = OrdersPreBll.OrderSuccess(conn, order.OrderNo, res.QN, order.OrderMoney);
                                return true;
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
                        }
                    }


                    // 对于时间过长的订单执行清理操作(1天后或微信只需要5分钟之后就过期,转移到回收站)
                    // 活动订单5分钟后失效
                    // 支付平台未查询到订单的
                    if ( res.IsCanDelOrder )
                    {
                        isCanDelOrder = true;
                    }
                }

                // 对于时间过长的订单执行清理操作(1天后或微信只需要5分钟之后就过期,转移到回收站)
                // 活动订单5分钟后失效
                // 支付平台未查询到订单的
                if ( isCanDelOrder 
                    || DateTime.Now.Subtract(order.OrderTime).TotalDays >= 1
                    || (order.PaymentType == (int)PaymentType.WeixinPay && DateTime.Now.Subtract(order.OrderTime).TotalMinutes >= 5)
                    || (order.Purpose == (int)PaymentPurpose.活动 && DateTime.Now.Subtract(order.OrderTime).TotalMinutes >= 5)
                    || (order.PaymentType == (int)PaymentType.EPark && DateTime.Now.Subtract(order.OrderTime).TotalMinutes >= 2)
                    )
                {
                    OrdersPreBll.MoveToRecycle(order);
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Add("支付成功后待处理异常", ex);
                return false;
            }
        }
    }
}

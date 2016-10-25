using OneCoin.Payment;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Orders;
using OneCoin.Service.Model.Enum.Payment;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess.Instance
{
    public class CancelOrderProccess : IOrderProccess
    {
        public bool Do(string orderNo)
        {
            //锁定订单并处理 
            var isCommit = false;
            try
            {
                var conn = TransactionManager.GetCurrentConnection();

                // 枷锁查询订单状态,如果已处理或者不符合条件则不处理
                var order = OrdersSuccesBll.GetOrdersForLock(conn, orderNo);
                if (order == null || order.Status != (int)OrdersStatus.待撤单)
                {
                    return false;
                }
                 

                // 支付平台是否支持撤单操作
                if (PaymentMgr.IsEnableCancel((PaymentType)order.PaymentType))
                {
                    // 查询是否有撤单订单号
                    var cp = new CanceledPaymentInfo
                        {
                            OrderNo=order.OrderNo,
                            OrderMoney = order.OrderMoney,
                            OrderTime = order.OrderTime,
                            ParkCode = order.ParkCode, 
                            qn = order.QN,
                            PaymentType = (PaymentType)order.PaymentType,
                            IsWxApp = string.IsNullOrEmpty(order.OpenId)
                        };

                    var cancelOrder = OrdersCanceledBll.GetOrder(order.OrderNo);

                    // 还没有发起撤单 
                    if (cancelOrder == null)
                    {
                        // 发起撤费请求,成功不表明撤费已经完成，只是说明平台已经接受了
                        // 撤费请求，需要主动查询(有些平台会异步回调)结果
                        if (PaymentMgr.CancelOrder(ref cp))
                        {
                            DoMarkCancelNo(order, cp);
                            cancelOrder = OrdersCanceledBll.GetOrder(order.OrderNo);
                        }
                    }

                    if (cancelOrder == null) return false;


                    cp = new CanceledPaymentInfo
                    {
                        CancelOrderNo = cancelOrder.CancelOrderNo,
                        ParkCode = cancelOrder.ParkCode,
                        OrderMoney = cancelOrder.OrderMoney,
                        OrderNo = cancelOrder.OrderNo,
                        OrderTime = cancelOrder.OrderTime,
                        PaymentType = (PaymentType)cancelOrder.PaymentType,
                        qn = cancelOrder.QN,
                        IsWxApp = string.IsNullOrEmpty(order.OpenId)
                    };

                    // 已经存在撤单号则直接查询状态
                    if (!string.IsNullOrEmpty(cancelOrder.CancelOrderNo))
                    {
                        // 查询是否撤费成功
                        if (PaymentMgr.CancelOrderQuery(ref cp))
                        {
                            isCommit = DoCancelOrder(conn, order);
                        }
                    }
                }
                //第三方不支持处理撤费
                else
                {
                    //所有支付方式， 直接退回账户
                    //if (order.PaymentType == (int)PaymentType.EPark)
                    {
                       
                    }
                    //else
                    //{
                    //    isCommit = DoUnProcessedCancelOrder(conn, order);
                    //}
                }
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

            return isCommit;
        }


        /// <summary>
        /// 标记撤费订单号
        /// </summary> 
        /// <param name="order"></param>
        /// <param name="cp"></param>
        /// <returns></returns>
        private bool DoMarkCancelNo(OrdersSuccesDb order, CanceledPaymentInfo cp)
        {
            // 新增撤单记录，此时还不能删除 成功订单记录表 中的数据，
            // 只有当撤费完全成功后才能删除 成功订单记录表 中数据
            // 这个时候 撤费表(IsProcessed=0) 和  成功订单表(status=待撤费状态) 会同时存在数据

            if (!string.IsNullOrEmpty(cp.CancelOrderNo))
            {
                return OrdersCanceledBll.Add(order, cp.CancelOrderNo, false, false);
            }

            return false;
        }


        /// <summary>
        /// 撤销已处理的订单
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private bool DoComplateCancelOrder(MySqlConnection conn, OrdersSuccesDb order)
        {
            // 已经成功撤销订单，而且已完成退费
            // 则需要将成功订单删除，并且保存撤销表数据
            // 撤销表数据状态为(已处理IsProcessed=1已确认IsChecked=1)
            if (OrdersSuccesBll.Remove(conn, order.OrderNo))
            {
                return OrdersCanceledBll.Add(conn, order, "", true, true);
            }

            return false;
        }

        /// <summary>
        /// 撤销已处理的订单
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private bool DoCancelOrder(MySqlConnection conn, OrdersSuccesDb order)
        {
            // 已经成功撤销订单，而且已完成退费
            // 则需要将成功订单删除，并且保存撤销表数据
            // 撤销表数据状态为(已处理IsProcessed=1已确认IsChecked=1)
            if (OrdersSuccesBll.Remove(conn, order.OrderNo))
            {
                return OrdersCanceledBll.Complate(conn, order.OrderNo, true, true, "撤单,退费完成");
            }

            return false;
        }
    }
}

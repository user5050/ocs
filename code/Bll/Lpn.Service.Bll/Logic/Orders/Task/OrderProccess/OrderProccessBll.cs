using System;
using System.Text;
using OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess.Instance;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Enum.Orders;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess
{
    public class OrderProccessBll : BaseProccess
    {
        public static bool Proccess(OrdersSuccesDb order)
        {
            if (!IsAllProccess(order.OrderNo))
            {
                return false;
            }

            var log = new StringBuilder();
            try
            {
                var isCancel = false;
                IOrderProccess iOrderProccess;
                if (order.Status == (int)OrdersStatus.支付成功后待处理)
                {
                    switch ((PaymentPurpose)order.Purpose)
                    {

                        case PaymentPurpose.商品购买:
                            iOrderProccess = new ProductOrderProccess();
                            break;


                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (order.Status == (int)OrdersStatus.待撤单)
                {
                    iOrderProccess = new CancelOrderProccess();
                    isCancel = true;
                }
                else
                {
                    throw new NotSupportedException();
                }


                log.AppendFormat("开始处理订单：{0}\r\n", order.OrderNo);


                // 订单执行成功
                if (iOrderProccess.Do(order.OrderNo))
                {
                    if (isCancel)
                    {
                        // 撤费提醒
                        //NotificationHelper.NotificationCombine203(order.UserID, order.ParkCode, order.OrderMoney.Tstr());
                    }

                    log.AppendFormat("成功\r\n");
                    LogHelper.Add(log.ToString());

                    return true;
                }

                // 加入到失败日志
                AddFault(order.OrderNo, order.OrderTime, (PaymentPurpose)order.Purpose);

                log.AppendFormat("失败\r\n");
                LogHelper.Add(log.ToString());
                return false;
            }
            catch (Exception ex)
            {
                log.AppendFormat("支付成功后待处理异常:{0}{1}", ex.Message, ex.StackTrace);
                LogHelper.Add(log.ToString());
                return false;
            }

        }
    }
}

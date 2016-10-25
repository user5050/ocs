using OneCoin.Service.Bll.Logic.Coupon;
using OneCoin.Service.Bll.Logic.Product;
using OneCoin.Service.Cache.Product;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Enum.Orders;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess.Instance
{
    public class ProductOrderProccess : BaseProccess, IOrderProccess
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
                if (order.Status != (int)OrdersStatus.支付成功后待处理)
                {
                    return false;
                }

                //处理
                if (ProductBll.Buy(conn, order))
                {
                    // 更新订单状态 
                    if (OrdersSuccesBll.UpdateStatus(conn, order.OrderNo, OrdersStatus.处理完成, PaymentSubPurpose.支付月租))
                    {
                        // 如果存在优惠券，则修改优惠券状态
                        if (!string.IsNullOrEmpty(order.CouponID))
                        {
                            CouponInfoBll.SetUsed(conn, order.CouponID);
                        }


                        ProductCacheMgr.ClearCacheMember(order.ParkCode);

                        isCommit = true;
                    }
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
    }
}

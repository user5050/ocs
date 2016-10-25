using System;
using System.Collections.Generic;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.Partnerpay;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Dal.Dal.Orders;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Entity.Payment;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Bll.Logic.Orders
{
    public class OrdersPreBll : BllBase
    {
        #region 新增预支付订单
        /// <summary>
        /// 新增预支付订单
        /// </summary> 
        /// <param name="req"></param>
        internal static bool Add(PurchaseReq req)
        {
            // 查询订单合作商ID
            var partnerId = PayConfigBll.GetPartnerId(req.ParkCode, req.PaymentType, req.Purpose, req.WxpayType == 0);

            // 标准表信息,注意传入抵扣金额
            var order = new OrdersPreDb
                {
                    CarNo = req.CarNo,
                    CouponID = req.CouponId,
                    CouponMoney = req.CouponMoney,
                    Description = req.Description,
                    OrderMoney = req.OrderMoney,
                    OrderNo = req.OrderNo,
                    OrderTime = req.OrderTime,
                    ParkCode = req.ParkCode,
                    PaymentType = (int)req.PaymentType,
                    Purpose = (int)req.Purpose,
                    DeduMoney = req.DeduMoney,
                    TotalMoney = req.TotalMoney,
                    UserID = req.UserId,
                    OpenId = req.OpenId,
                    ClientType = req.ClientType,
                    PartnerId = partnerId,
                    SubPurpose = (int)req.SubPurpose,
                    Extre = req.Extre
                };


            // 插入标准表
            return OrdersPreDal.Insert(order);
        }
        #endregion

        #region 预支付订单被三方平台确认

        internal static bool OrderSuccess(MySqlConnection conn, string orderNo, string qn, decimal money)
        {
            // 第三方流水号不存在则不通过
            if (string.IsNullOrEmpty(qn)) return false;


            // 查询预支付数据
            var preOrder = OrdersPreDal.GetByPriKeyForLock(conn, orderNo);

            if (preOrder == null) return true;//说明已经处理完成
            //if (preOrder.OrderMoney != money) return false;


            // 删除预支付订单,转移到成功支付订单表中，待其后续处理
            if (OrdersPreDal.DeleteByPriKey(conn, orderNo))
            {
                return OrdersSuccesBll.Add(conn, preOrder, qn);
            }

            return false;
        }

        #endregion


        internal static OrdersPreDb GetOrdersForLock(MySqlConnection conn, string orderNo)
        {
            return OrdersPreDal.GetByPriKeyForLock(conn, orderNo);
        }

        internal static OrdersPreDb GetOrders(string orderNo)
        {
            return OrdersPreDal.GetByPriKey(orderNo);
        }

        internal static List<OrdersPreDb> GetUnConfirmOrders(int orderNumPerTime, DateTime endTime)
        {
            return OrdersPreDal.GetUnConfirmOrders(orderNumPerTime, endTime);
        }

        internal static OrdersRecycleDb GetRecycleOrder(string orderNo)
        {
            return OrdersRecycleDal.GetByPriKey(orderNo);
        }

        internal static bool MoveToRecycle(OrdersPreDb order)
        {
            var isCommit = false;
            try
            {
                var conn = TransactionManager.GetCurrentConnection();

                // 是否有优惠券
                if (!string.IsNullOrEmpty(order.CouponID))
                {
                    // 将锁定的优惠券设置为有效
                    if (!Coupon.CouponInfoBll.UpdateStatusByPriKey(conn, order.CouponID, 1))
                    {
                        return false;
                    }
                }

                // 删除预支付订单
                if (OrdersPreDal.DeleteByPriKey(conn, order.OrderNo))
                {
                    // 添加到订单回收站
                    isCommit = OrdersRecycleDal.Insert(conn, order);
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
        /// 回收站转移到预发布平台
        /// </summary>
        /// <param name="recycleOrder"></param>
        /// <returns></returns>
        internal static bool MoveToPre(OrdersRecycleDb recycleOrder)
        {
            var isCommit = false;
            try
            {
                var conn = TransactionManager.GetCurrentConnection();

                // 删除回收站订单
                if (OrdersRecycleDal.Delete(conn, recycleOrder.OrderNo))
                {
                    // 添加到订单回收站
                    isCommit = OrdersPreDal.Insert(conn, recycleOrder);
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

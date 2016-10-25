using System;
using System.Collections.Generic;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Orders;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Enum.Orders;
using OneCoin.Service.Model.Enum.Payment;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Bll.Logic.Orders
{
    public class OrdersSuccesBll  : BllBase
    {
        #region 新增支付成功订单(事务)

        /// <summary>
        /// 获取部分订单号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        private static string GetOrderNoPart(string orderNo)
        {
            return orderNo.Substring(Math.Max(0,orderNo.Length - 12), 12);
        }
        #endregion

        #region 获取TOPN未做后续处理的成功订单

        /// <summary>
        /// 获取TOPN未做后续处理的成功订单
        /// </summary>
        /// <param name="topN">数量</param>
        /// <returns></returns>
        public static List<OrdersSuccesDb> GetUnProccessOrders(int topN=100)
        {
            return OrdersSuccesDal.GetTopNByStatus((int)OrdersStatus.支付成功后待处理, (int)OrdersStatus.待撤单, topN);
        }

        #endregion

        #region 获取订单信息

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo">数量</param>
        /// <returns></returns>
        public static OrdersSuccesDb GetOrdersForLock(MySqlConnection conn,string orderNo)
        {
            return OrdersSuccesDal.GetOrdersForLock(conn,orderNo);
        }

        #endregion

        #region 更新订单状态信息

        /// <summary>
        /// 更新订单状态信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo"></param>
        /// <param name="status"></param>
        /// <param name="subPurpose"></param> 
        /// <returns></returns>
        public static bool UpdateStatus(MySqlConnection conn, string orderNo, OrdersStatus status, PaymentSubPurpose subPurpose)
        {
            return OrdersSuccesDal.UpdateStatus(conn, orderNo, (int)status, (int)subPurpose);
        }

        public static bool UpdateStatus(MySqlConnection conn, string orderNo, OrdersStatus status, PaymentSubPurpose subPurpose, double couponMoney)
        {
            return OrdersSuccesDal.UpdateStatus(conn, orderNo, (int)status, (int)subPurpose, couponMoney);
        }
        #endregion

        #region internal

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        internal static bool Remove(MySqlConnection conn, string orderNo)
        {
            return OrdersSuccesDal.DeleteByPriKey(conn, orderNo);
        }
        #endregion

        #region 新增成功订单

        /// <summary>
        /// 新增成功订单
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="po"></param>
        /// <param name="qn"></param>
        /// <returns></returns>
        internal static bool Add(MySqlConnection conn, OrdersPreDb po,string qn)
        {
            // 标准表信息
            var order = new OrdersSuccesDb
            {
                CarNo = po.CarNo,
                CouponID = po.CouponID,
                CouponMoney = po.CouponMoney,
                Description = po.Description,
                OrderMoney = po.OrderMoney,
                OrderNo = po.OrderNo,
                OrderTime = po.OrderTime,
                ParkCode = po.ParkCode,
                PaymentType = po.PaymentType,
                Purpose = po.Purpose,
                TotalMoney = po.TotalMoney,
                UserID = po.UserID,
                QN = qn,
                DeduMoney=po.DeduMoney,
                Status = (int)OrdersStatus.支付成功后待处理,
                ClientType = po.ClientType,
                OpenId = po.OpenId,
                PartnerId = po.PartnerId,
                // 部分子类型是由本地停车场确认，因此此处根据规则初始化数据，停车场处理成功后再更新此值
                // SubPurpose = Purpose * 10 规则,见 PaymentPurpose 和 PaymentSubPurpose 枚举定义
                SubPurpose = po.SubPurpose> 0 ? po.SubPurpose: po.Purpose * 10 ,
                Extre = po.Extre,
                OrderNoPart = GetOrderNoPart(po.OrderNo)
            };

            return OrdersSuccesDal.Insert(conn, order);
        }


        internal static bool Add(MySqlConnection conn, OrdersSuccesDb order)
        {
            // 部分订单号
            order.OrderNoPart = GetOrderNoPart(order.OrderNo);

            return OrdersSuccesDal.Insert(conn, order);
        }
        #endregion

        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static OrdersSuccesDb GetOrders(string orderNo)
        {
            return OrdersSuccesDal.GetByPriKey(orderNo);
        }


        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="qn"></param>
        /// <returns></returns>
        internal static OrdersSuccesDb GetOrdersByQn(string qn)
        {
            return OrdersSuccesDal.GetOrdersByQn(qn);
        }


        /// <summary>
        /// 查询是否为预约车
        /// </summary> 
        /// <returns></returns>
        public static bool IsSubscribeCar(string carNo, DateTime entranceTime)
        {
            return OrdersSuccesDal.IsSubscribeCar(carNo,entranceTime);
        }

        /// <summary>
        /// 查询指定用户成功订单信息
        /// </summary>
        /// <param name="userId"></param> 
        /// <param name="startNo"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        internal static List<OrdersSuccesDb> GetSuccessOrders(int userId, string startNo, int take)
        {
            return OrdersSuccesDal.GetSuccessByUserId(userId, startNo, take);
        }

        
        /// <summary>
        /// 是否存在未处理的缴费订单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="parkCode"></param>
        /// <param name="carNo"></param>
        /// <param name="purpose"></param>
        /// <returns></returns>
        internal static bool IsExistsUnProccessed(int userId, string parkCode, string carNo,PaymentPurpose purpose)
        {
            return OrdersSuccesDal.IsExistsUnProccessed(userId, (int)OrdersStatus.支付成功后待处理, parkCode, carNo, (int)purpose);
        }
        #endregion

        #region 查询本次入场是否已经使用了优惠券

        /// <summary>
        /// 查询本次入场是否已经使用了优惠券
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="carNo"></param>
        /// <param name="enterTime"></param>
        /// <returns></returns>
        internal static bool IsUsedCoupon(string parkCode,string carNo, DateTime enterTime)
        {
            return OrdersSuccesDal.IsUsedCoupon(parkCode, carNo, enterTime);
        }
        #endregion
       
    }
}

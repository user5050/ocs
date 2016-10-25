using System.Collections.Generic;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Orders;
using OneCoin.Service.Model.Db.Orders;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Bll.Logic.Orders
{
    public class OrdersCanceledBll :BllBase
    {
        #region internal

        /// <summary>
        /// 新增取消的订单
        /// </summary> 
        /// <param name="orders"></param>
        /// <param name="cancelOrderNo"></param>
        /// <param name="isProcessed"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        internal static bool Add(OrdersSuccesDb orders, string cancelOrderNo, bool isProcessed,bool isChecked)
        {
            var cOrders = new OrdersCanceledDb
                {
                    CancelOrderNo = cancelOrderNo,
                    CouponID = orders.CouponID,
                    CarNo = orders.CarNo,
                    CouponMoney = (int)orders.CouponMoney,
                    Description = orders.Description,
                    IsChecked = isChecked?1:0,
                    IsProcessed = isProcessed?1:0,
                    OrderMoney = (int)orders.OrderMoney,
                    OrderNo = orders.OrderNo,
                    OrderTime = orders.OrderTime,
                    ParkCode = orders.ParkCode,
                    PaymentType = orders.PaymentType,
                    Purpose = orders.Purpose,
                    QN = orders.QN,
                    TotalMoney = (int)orders.TotalMoney,
                    UserID = orders.UserID,
                    ClientType = orders.ClientType,
                    OpenId = orders.OpenId,
                    PartnerId = orders.PartnerId,
                    DeduMoney = (int)orders.DeduMoney,
                    Extre = orders.Extre
                };


            return OrdersCanceledDal.Insert(cOrders);
        }

        /// <summary>
        /// 新增取消的订单(事务)
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orders"></param>
        /// <param name="cancelOrderNo"></param>
        /// <param name="isProcessed"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        internal static bool Add(MySqlConnection conn,OrdersSuccesDb orders, string cancelOrderNo, bool isProcessed, bool isChecked)
        {
            var cOrders = new OrdersCanceledDb
            {
                CancelOrderNo = cancelOrderNo,
                CouponID = orders.CouponID,
                CarNo = orders.CarNo,
                CouponMoney = (int)orders.CouponMoney,
                Description = orders.Description,
                IsChecked = isChecked ? 1 : 0,
                IsProcessed = isProcessed ? 1 : 0,
                OrderMoney = (int)orders.OrderMoney,
                OrderNo = orders.OrderNo,
                OrderTime = orders.OrderTime,
                ParkCode = orders.ParkCode,
                PaymentType = orders.PaymentType,
                Purpose = orders.Purpose,
                QN = orders.QN,
                TotalMoney = (int)orders.TotalMoney,
                UserID = orders.UserID,
                ClientType = orders.ClientType,
                OpenId = orders.OpenId,
                PartnerId = orders.PartnerId,
                DeduMoney = (int)orders.DeduMoney,
                Extre = orders.Extre,
                SubPurpose = orders.SubPurpose
            };


            return OrdersCanceledDal.Insert(conn,cOrders);
        }

        internal static OrdersCanceledDb GetOrder(string orderNo)
        {
            return OrdersCanceledDal.GetByPriKey(orderNo);
        }

        /// <summary>
        /// 处理和校验完成
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo"></param>
        /// <param name="isProcessed"></param>
        /// <param name="isChecked"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        internal static bool Complate(MySqlConnection conn, string orderNo, bool isProcessed, bool isChecked,string desc)
        {
            return OrdersCanceledDal.UpdateStatus(conn, orderNo, isProcessed ? 1 : 0, isChecked ? 1 : 0, desc);
        }


        /// <summary>
        /// 查询指定用户撤销订单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startNo"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        internal static List<OrdersCanceledDb> GetSuccessOrders(int userId, string startNo, int take)
        {
            return OrdersCanceledDal.GetSuccessByUserId(userId, startNo, take);
        }

        #endregion
    }
}

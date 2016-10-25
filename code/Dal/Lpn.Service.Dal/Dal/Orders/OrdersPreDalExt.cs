using System;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Model.Db.Orders;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Dal.Dal.Orders
{
    public partial class OrdersPreDal
    {
        #region SQL
        //获取根据主键查询
        protected const string SqlGetByPriKeyForLock = "select * from orders_pre where `OrderNo`=?OrderNo for update;";
        //获取未处理的订单号
        protected const string SqlGetUnConfirmOrders = "select * from orders_pre where ordertime < ?ordertime order by ordertime desc limit ?take;";
        #endregion


        #region 参数
        protected const string ParamTake = "?take"; 
        #endregion


        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderspre">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn, OrdersPreDb orderspre)
        {
            var param = GetInsertParams(orderspre);

            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert,true, param);

            return result > 0;
        }
        #endregion

        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderspre">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn, OrdersRecycleDb orderspre)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderspre.OrderNo),
                    new MySqlParameter(ParamOrderTime,orderspre.OrderTime),
                    new MySqlParameter(ParamOrderMoney,orderspre.OrderMoney),
                    new MySqlParameter(ParamParkCode,orderspre.ParkCode),
                    new MySqlParameter(ParamCarNo,orderspre.CarNo),
                    new MySqlParameter(ParamPaymentType,orderspre.PaymentType),
                    new MySqlParameter(ParamPurpose,orderspre.Purpose),
                    new MySqlParameter(ParamSubPurpose,orderspre.SubPurpose),
                    new MySqlParameter(ParamDescription,orderspre.Description),
                    new MySqlParameter(ParamUserID,orderspre.UserID),
                    new MySqlParameter(ParamCouponMoney,orderspre.CouponMoney),
                    new MySqlParameter(ParamDeduMoney,orderspre.DeduMoney),
                    new MySqlParameter(ParamTotalMoney,orderspre.TotalMoney),
                    new MySqlParameter(ParamCouponID,orderspre.CouponID),
                    new MySqlParameter(ParamOpenId,orderspre.OpenId),
                    new MySqlParameter(ParamClientType,orderspre.ClientType),
                    new MySqlParameter(ParamPartnerId,orderspre.PartnerId),
                    new MySqlParameter(ParamExtre,orderspre.Extre)
                };


            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert, true, param);

            return result > 0;
        }
        #endregion


        #region 根据主键删除表数据

        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool DeleteByPriKey(MySqlConnection conn,string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlDeleteByPriKey,true, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据(加锁)

        /// <summary>
        /// 获取主键查询数据(加锁)
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersPreDb</returns>
        public static OrdersPreDb GetByPriKeyForLock(MySqlConnection conn,string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
                };

            var dr = DbHelper.ExecuteDataTable(conn, SqlGetByPriKeyForLock, true,param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion

        #region 获取未处理的订单号
        /// <summary>
        /// 获取未处理的订单号
        /// </summary>
        /// <param name="orderNumPerTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static List<OrdersPreDb> GetUnConfirmOrders(int orderNumPerTime, DateTime endTime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderTime,endTime),
                    new MySqlParameter(ParamTake,orderNumPerTime)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetUnConfirmOrders, param);


            return ConvertToObjects(dr);
        }
        #endregion
    }
}

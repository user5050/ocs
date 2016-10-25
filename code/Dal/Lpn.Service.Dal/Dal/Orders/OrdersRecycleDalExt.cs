using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Model.Db.Orders;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Dal.Dal.Orders
{
    public partial class OrdersRecycleDal
    {
        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="ordersrecycle">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn,OrdersPreDb ordersrecycle)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersrecycle.OrderNo),
                    new MySqlParameter(ParamOrderTime,ordersrecycle.OrderTime),
                    new MySqlParameter(ParamOrderMoney,ordersrecycle.OrderMoney),
                    new MySqlParameter(ParamParkCode,ordersrecycle.ParkCode),
                    new MySqlParameter(ParamCarNo,ordersrecycle.CarNo),
                    new MySqlParameter(ParamPaymentType,ordersrecycle.PaymentType),
                    new MySqlParameter(ParamPurpose,ordersrecycle.Purpose),
                    new MySqlParameter(ParamDescription,ordersrecycle.Description),
                    new MySqlParameter(ParamUserID,ordersrecycle.UserID),
                    new MySqlParameter(ParamCouponMoney,ordersrecycle.CouponMoney),
                    new MySqlParameter(ParamDeduMoney,ordersrecycle.DeduMoney),
                    new MySqlParameter(ParamTotalMoney,ordersrecycle.TotalMoney),
                    new MySqlParameter(ParamCouponID,ordersrecycle.CouponID),
                    new MySqlParameter(ParamOpenId,ordersrecycle.OpenId),
                    new MySqlParameter(ParamClientType,ordersrecycle.ClientType),
                    new MySqlParameter(ParamSubPurpose,ordersrecycle.SubPurpose),
                    new MySqlParameter(ParamPartnerId,ordersrecycle.PartnerId),
                    new MySqlParameter(ParamExtre,ordersrecycle.Extre)
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert,true, param);

            return result > 0;
        }
        #endregion

        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Delete(MySqlConnection conn, string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo) 

                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlDeleteByPriKey, true, param);

            return result > 0;
        }
        #endregion
    }
}

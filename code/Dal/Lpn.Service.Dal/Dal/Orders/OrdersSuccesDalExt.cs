using System;
using System.Collections.Generic;
using System.Data;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Db.Orders;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Dal.Dal.Orders
{
    public partial  class OrdersSuccesDal
    {

        #region SQL
        //获取指定数量和状态的订单信息
        protected const string SqlGetTopNByStatus = "select * from orders_success where `status`=?status or `status`=?CancelStatus order by orderno desc  limit ?limit;";

        //获取根据主键查询
        protected const string SqlGetOrdersForLock = "select * from orders_success where `OrderNo`=?OrderNo for update;";

        //根据主键更新整行数据
        protected const string SqlUpdateStatusByPriKey = "update orders_success set `status`=?status,`SubPurpose`=?SubPurpose   where `OrderNo`=?OrderNo;";

        //根据主键更新整行数据
        protected const string SqlUpdateStatusCouponMoneyByPriKey = "update orders_success set `status`=?status,`SubPurpose`=?SubPurpose,CouponMoney=?CouponMoney   where `OrderNo`=?OrderNo;";
        
        //获取我的成功的订单
        protected const string SqlGetSuccessByUserId = "select * from orders_success where  `OrderNo` < ?StartNo and   userid=?UserId order by  `OrderTime` desc  limit ?take;";

        //是否存在未处理的临停缴费订单
        protected const string SqlIsExistsUnProccessed = "select 1 from orders_success where  `ParkCode` = ?ParkCode and `status`=?status and userid=?UserId  and CarNo=?CarNo  and Purpose=?Purpose  limit 1;";
        
        //是否存在未处理的临停缴费订单
        protected const string SqlIsUsedCoupon = "select 1 from orders_success a where  `ParkCode` = ?ParkCode and  CarNo=?CarNo and  CouponID <> '' and CouponID IS NOT NULL and exists(select 1 from orders_extre_carexit where a.`OrderNo`=orderno and entranceTime = ?EntranceTime)";

        //获取根据Qn查询
        protected const string SqlGetOrdersByQn = "select * from orders_success where `QN`=?QN limit 1;";

        //获取根据Qn查询
        protected const string SqlGetOrdersByPartOrderNo = "select * from orders_success where `OrderNoPart`=?OrderNoPart limit 1;";

        //查询是否为预约车
        protected const string SqlIsSubscribeCar = @"SELECT 1 FROM orders_success   a
INNER JOIN  orders_extre_subscribe b
ON a.`OrderNo`=b.OrderNo
WHERE a.`CarNo`=?CarNo AND b.`ActualEnterTime`=?EntranceTime LIMIT 1;";
        //查询临停支付最近一笔交易记录
        protected const string SqlFindLastPay = @" SELECT * FROM orders_success WHERE orderno in
(
SELECT orderno FROM  orders_extre_carexit  WHERE orderno IN(SELECT orderno FROM orders_success
WHERE carNo=?CarNo AND purpose=0  AND IsAutoPay=0 AND ordertime > ?OrderTime
) AND  EntranceTime =?EntranceTime
 
)  ORDER BY ordertime DESC limit 1; ";

        // 查询订单
        protected const string SqlGetOrdersByPurposeFormatter = @"SELECT * FROM 
(
	SELECT OrderNo,OrderTime,OrderMoney,CarNo,ParkCode,UserID,PaymentType,Purpose,SubPurpose,CouponMoney,DeduMoney,TotalMoney,IsAutoPay,0 AS Extre,Description
	FROM orders_success WHERE  
	`OrderNo` < ?StartNo   AND   userid=  ?UserId
	AND purpose IN({0})

	UNION ALL
	SELECT OrderNo,OrderTime,OrderMoney,CarNo,ParkCode,UserID,PaymentType,Purpose,SubPurpose,CouponMoney,DeduMoney,TotalMoney,0,1 AS Extre,Description
	FROM orders_canceled WHERE  
	`OrderNo` < ?StartNo  AND   userid= ?UserId
	AND purpose IN({0})
) a
ORDER BY  `OrderTime` DESC  LIMIT ?take;";

        #endregion

        #region 参数
        protected const string Paramlimit = "?limit";
        protected const string ParamCancelStatus = "?CancelStatus";
        protected const string ParamStartNo = "?StartNo";
        protected const string ParamTake = "?Take";
        protected const string ParamEntranceTime = "?EntranceTime"; 
        #endregion

        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderssucces">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn,OrdersSuccesDb orderssucces)
        {
            var param = GetInsertParams(orderssucces); 
            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert, true,param);

            return result > 0;
        }
        #endregion

        #region 获取指定数量和状态的订单信息

        /// <summary>
        /// 获取指定数量和状态的订单信息
        /// </summary>
        /// <param name="status">待处理的状态</param>
        /// <param name="cancelStatus">待撤销的订单状态</param>
        /// <param name="limit"></param>
        /// <returns>OrdersSuccesDb</returns>
        public static List<OrdersSuccesDb> GetTopNByStatus(int status,int cancelStatus,int limit)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramstatus,status),
                    new MySqlParameter(ParamCancelStatus,cancelStatus),
                    new MySqlParameter(Paramlimit,limit)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetTopNByStatus, param);


            return ConvertToObjects(dr);
        }
        #endregion

        #region 获取我的成功的订单

        /// <summary>
        /// 获取我的成功的订单
        /// </summary>
        public static List<OrdersSuccesDb> GetSuccessByUserId(int userId,string startNo, int take)
        {
            var param = new[]
                {  
                    new MySqlParameter(ParamUserID,userId),
                    new MySqlParameter(ParamStartNo,startNo),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetSuccessByUserId, param);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 获取我的订单(成功&撤单)

        /// <summary>
        /// 获取我的订单(成功&撤单)
        /// </summary>
        public static List<OrdersSuccesDb> GetOrdersByPropuse(int userId, string startNo, int take,IList<int> propuses )
        {
            var query = String.Format(SqlGetOrdersByPurposeFormatter, Spanner.Join(propuses, ","));
             
            var param = new[]
                {  
                    new MySqlParameter(ParamUserID,userId),
                    new MySqlParameter(ParamStartNo,startNo),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, query, param);

            return ConvertToSubObjects(dr);
        }
        #endregion

        #region 获取主键查询数据

        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersSuccesDb</returns>
        public static OrdersSuccesDb GetOrdersForLock(MySqlConnection conn, string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
                };

            var dr = DbHelper.ExecuteDataTable(conn, SqlGetOrdersForLock,true, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion 

        #region 获取根据Qn查询

        /// <summary>
        /// 获取根据Qn查询
        /// </summary> 
        /// <param name="qn">qn</param> 
        /// <returns>OrdersSuccesDb</returns>
        public static OrdersSuccesDb GetOrdersByQn(string qn)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamQN,qn)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetOrdersByQn, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion 

        #region 查询临停支付最近一笔交易记录

        /// <summary>
        /// 查询临停支付最近一笔交易记录
        /// </summary>  
        /// <returns>OrdersSuccesDb</returns>
        public static OrdersSuccesDb FindLastPay(string carNo, DateTime orderMinDate, DateTime entranceTime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carNo),
                    new MySqlParameter(ParamOrderTime,orderMinDate),
                    new MySqlParameter(ParamEntranceTime,entranceTime)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlFindLastPay, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion 

        #region 查询是否为预约车

        /// <summary>
        /// 查询是否为预约车
        /// </summary>
        /// <param name="carNo"></param>
        /// <param name="entranceTime"></param>
        /// <returns></returns>
        public static bool IsSubscribeCar(string carNo, DateTime entranceTime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carNo),
                    new MySqlParameter(ParamEntranceTime,entranceTime)
                };
              
            return DbHelper.ExecuteReaderIdentity(ConntionStr, SqlIsSubscribeCar, param) > 0;
        }

        #endregion


        #region 根据主键更新查询数据

        /// <summary>
        /// 根据主键更新查询数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo"></param>
        /// <param name="status"></param>
        /// <param name="subPurpose"></param>
        /// <returns>bool(true or false)</returns>
        public static bool UpdateStatus(MySqlConnection conn,string orderNo,int status,int subPurpose,double couponMoney)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo),
                    new MySqlParameter(Paramstatus,status),
                    new MySqlParameter(ParamSubPurpose,subPurpose),
                    new MySqlParameter(ParamCouponMoney,couponMoney),
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlUpdateStatusCouponMoneyByPriKey, true, param);

            return result > 0;
        }


        public static bool UpdateStatus(MySqlConnection conn, string orderNo, int status, int subPurpose)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo),
                    new MySqlParameter(Paramstatus,status),
                    new MySqlParameter(ParamSubPurpose,subPurpose), 
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlUpdateStatusByPriKey, true, param);

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

            var result = DbHelper.ExecuteNonQuery(conn, SqlDeleteByPriKey, true,param);

            return result > 0;
        }
        #endregion

        #region 是否存在未处理的临停缴费订单

        /// <summary>
        /// 是否存在未处理的临停缴费订单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <param name="parkCode"></param>
        /// <param name="carNo"></param>
        /// <param name="purpose"></param>
        /// <returns></returns>
        public static bool IsExistsUnProccessed(int userId, int state, string parkCode, string carNo,int purpose)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserID,userId),
                    new MySqlParameter(Paramstatus,state),
                    new MySqlParameter(ParamParkCode,parkCode),
                    new MySqlParameter(ParamCarNo,carNo),
                    new MySqlParameter(ParamPurpose,purpose)

                };

            return DbHelper.ExecuteReaderIdentity(ConntionStr, SqlIsExistsUnProccessed, param) > 0;
        }
        #endregion

        /// <summary>
        /// 查询本次入场是否已经使用了优惠券
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="carNo"></param>
        /// <param name="enterTime"></param>
        /// <returns></returns>
        public static bool IsUsedCoupon(string parkCode, string carNo, DateTime enterTime)
        {
            var param = new[]
                {   
                    new MySqlParameter(ParamParkCode,parkCode),
                    new MySqlParameter(ParamCarNo,carNo),
                    new MySqlParameter(ParamEntranceTime,enterTime)
                };

            return DbHelper.ExecuteReaderIdentity(ConntionStr, SqlIsUsedCoupon, param) > 0;
        }

        #region 获取根据partOrderNo查询

        /// <summary>
        /// 获取根据partOrderNo查询
        /// </summary> 
        /// <param name="partOrderNo">partOrderNo</param> 
        /// <returns>OrdersSuccesDb</returns>
        public static OrdersSuccesDb GetOrdersByPartOrderNo(string partOrderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNoPart,partOrderNo)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetOrdersByPartOrderNo, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion 
        

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersSuccesDb</returns>
        public static OrdersSuccesDb ConvertToSubObject(DataRow dr)
        {
            var data = new OrdersSuccesDb
            {
                OrderNo = DbChange.ToString(dr["OrderNo"]),
                OrderTime = DbChange.ToDateTime(dr["OrderTime"], DateTime.MinValue),
                OrderMoney = DbChange.ToDecimal(dr["OrderMoney"], 0),
                ParkCode = DbChange.ToString(dr["ParkCode"]),
                CarNo = DbChange.ToString(dr["CarNo"]),
                UserID = DbChange.ToString(dr["UserID"]),
                PaymentType = DbChange.ToInt(dr["PaymentType"], 0),
                Purpose = DbChange.ToInt(dr["Purpose"], 0),
                Description = DbChange.ToString(dr["Description"]),
                CouponMoney = DbChange.ToDecimal(dr["CouponMoney"], 0),
                DeduMoney = DbChange.ToDecimal(dr["DeduMoney"], 0),
                TotalMoney = DbChange.ToDecimal(dr["TotalMoney"], 0),
                IsAutoPay = DbChange.ToInt(dr["IsAutoPay"], 0),
                Extre = DbChange.ToInt(dr["Extre"], 0),
                SubPurpose = DbChange.ToInt(dr["SubPurpose"], 0),
            };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OrdersSuccesDb</returns>
        public static List<OrdersSuccesDb> ConvertToSubObjects(DataTable dt)
        {
            var datas = new List<OrdersSuccesDb>();
            if (null != dt && dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    datas.Add(ConvertToSubObject(dt.Rows[i]));
                }
            }

            return datas;
        }
        #endregion
    }
}

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Orders;

/*
* 由自动生成工具完成
* 描述:订单回收站 Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Orders
{
    /// <summary>
    /// 订单回收站 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OrdersRecycleDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from orders_recycle;";
        //新增插入语句
        protected const string SqlInsert = "insert into orders_recycle(`OrderNo`,`OrderTime`,`OrderMoney`,`ParkCode`,`CarNo`,`PaymentType`,`Purpose`,`SubPurpose`,`Description`,`UserID`,`CouponMoney`,`DeduMoney`,`TotalMoney`,`CouponID`,`ClientType`,`OpenId`,`PartnerId`,`Extre`,`RowTime`) values(?OrderNo,?OrderTime,?OrderMoney,?ParkCode,?CarNo,?PaymentType,?Purpose,?SubPurpose,?Description,?UserID,?CouponMoney,?DeduMoney,?TotalMoney,?CouponID,?ClientType,?OpenId,?PartnerId,?Extre,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from orders_recycle where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update orders_recycle set `OrderTime`=?OrderTime,`OrderMoney`=?OrderMoney,`ParkCode`=?ParkCode,`CarNo`=?CarNo,`PaymentType`=?PaymentType,`Purpose`=?Purpose,`SubPurpose`=?SubPurpose,`Description`=?Description,`UserID`=?UserID,`CouponMoney`=?CouponMoney,`DeduMoney`=?DeduMoney,`TotalMoney`=?TotalMoney,`CouponID`=?CouponID,`ClientType`=?ClientType,`OpenId`=?OpenId,`PartnerId`=?PartnerId,`Extre`=?Extre,`RowTime`=?RowTime where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from orders_recycle  where `OrderNo`=?OrderNo;";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamOrderTime = "?OrderTime";
        protected const string ParamOrderMoney = "?OrderMoney";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamPaymentType = "?PaymentType";
        protected const string ParamPurpose = "?Purpose";
        protected const string ParamSubPurpose = "?SubPurpose";
        protected const string ParamDescription = "?Description";
        protected const string ParamUserID = "?UserID";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamDeduMoney = "?DeduMoney";
        protected const string ParamTotalMoney = "?TotalMoney";
        protected const string ParamCouponID = "?CouponID";
        protected const string ParamClientType = "?ClientType";
        protected const string ParamOpenId = "?OpenId";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamExtre = "?Extre";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OrdersRecycleDb</returns>
        public static List<OrdersRecycleDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="ordersrecycle">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OrdersRecycleDb ordersrecycle)
        {
            var param= GetInsertParams(ordersrecycle);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersRecycleDb</returns>
        public static OrdersRecycleDb  GetByPriKey(string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByPriKey,param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion

        #region 根据主键更新查询数据
        /// <summary>
        /// 根据主键更新查询数据
        /// </summary>
        /// <param name="ordersrecycle">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OrdersRecycleDb ordersrecycle)
        {
            var param= GetUpdateParams(ordersrecycle);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(OrdersRecycleDb ordersrecycle)
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
                    new MySqlParameter(ParamSubPurpose,ordersrecycle.SubPurpose),
                    new MySqlParameter(ParamDescription,ordersrecycle.Description),
                    new MySqlParameter(ParamUserID,ordersrecycle.UserID),
                    new MySqlParameter(ParamCouponMoney,ordersrecycle.CouponMoney),
                    new MySqlParameter(ParamDeduMoney,ordersrecycle.DeduMoney),
                    new MySqlParameter(ParamTotalMoney,ordersrecycle.TotalMoney),
                    new MySqlParameter(ParamCouponID,ordersrecycle.CouponID),
                    new MySqlParameter(ParamClientType,ordersrecycle.ClientType),
                    new MySqlParameter(ParamOpenId,ordersrecycle.OpenId),
                    new MySqlParameter(ParamPartnerId,ordersrecycle.PartnerId),
                    new MySqlParameter(ParamExtre,ordersrecycle.Extre),
                    new MySqlParameter(ParamRowTime,ordersrecycle.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OrdersRecycleDb ordersrecycle)
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
                    new MySqlParameter(ParamSubPurpose,ordersrecycle.SubPurpose),
                    new MySqlParameter(ParamDescription,ordersrecycle.Description),
                    new MySqlParameter(ParamUserID,ordersrecycle.UserID),
                    new MySqlParameter(ParamCouponMoney,ordersrecycle.CouponMoney),
                    new MySqlParameter(ParamDeduMoney,ordersrecycle.DeduMoney),
                    new MySqlParameter(ParamTotalMoney,ordersrecycle.TotalMoney),
                    new MySqlParameter(ParamCouponID,ordersrecycle.CouponID),
                    new MySqlParameter(ParamClientType,ordersrecycle.ClientType),
                    new MySqlParameter(ParamOpenId,ordersrecycle.OpenId),
                    new MySqlParameter(ParamPartnerId,ordersrecycle.PartnerId),
                    new MySqlParameter(ParamExtre,ordersrecycle.Extre),
                    new MySqlParameter(ParamRowTime,ordersrecycle.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersRecycleDb</returns>
        public static OrdersRecycleDb  ConvertToObject(DataRow dr)
        {
            var data = new OrdersRecycleDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    OrderTime = DbChange.ToDateTime(dr["OrderTime"],DateTime.MinValue),
                    OrderMoney = DbChange.ToInt(dr["OrderMoney"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    PaymentType = DbChange.ToInt(dr["PaymentType"],0),
                    Purpose = DbChange.ToInt(dr["Purpose"],0),
                    SubPurpose = DbChange.ToInt(dr["SubPurpose"],0),
                    Description = DbChange.ToString(dr["Description"]),
                    UserID = DbChange.ToString(dr["UserID"]),
                    CouponMoney = DbChange.ToInt(dr["CouponMoney"],0),
                    DeduMoney = DbChange.ToInt(dr["DeduMoney"],0),
                    TotalMoney = DbChange.ToInt(dr["TotalMoney"],0),
                    CouponID = DbChange.ToString(dr["CouponID"]),
                    ClientType = DbChange.ToInt(dr["ClientType"],0),
                    OpenId = DbChange.ToString(dr["OpenId"]),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    Extre = DbChange.ToInt(dr["Extre"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OrdersRecycleDb</returns>
        public static List<OrdersRecycleDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OrdersRecycleDb>(); 
            if (null != dt && dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    datas.Add(ConvertToObject(dt.Rows[i]));
                }
            }

            return datas;
        }
        #endregion

     }
}

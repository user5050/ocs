using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Orders;

/*
* 由自动生成工具完成
* 描述:已支付待处理的订单列表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Orders
{
    /// <summary>
    /// 已支付待处理的订单列表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OrdersSuccesDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from orders_success;";
        //新增插入语句
        protected const string SqlInsert = "insert into orders_success(`OrderNo`,`OrderTime`,`OrderMoney`,`ParkCode`,`CarNo`,`UserID`,`PaymentType`,`Purpose`,`SubPurpose`,`Description`,`CouponMoney`,`DeduMoney`,`TotalMoney`,`CouponID`,`QN`,`status`,`OpenId`,`ClientType`,`PartnerId`,`IsAutoPay`,`Extre`,`OrderNoPart`) values(?OrderNo,?OrderTime,?OrderMoney,?ParkCode,?CarNo,?UserID,?PaymentType,?Purpose,?SubPurpose,?Description,?CouponMoney,?DeduMoney,?TotalMoney,?CouponID,?QN,?status,?OpenId,?ClientType,?PartnerId,?IsAutoPay,?Extre,?OrderNoPart);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from orders_success where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update orders_success set `OrderTime`=?OrderTime,`OrderMoney`=?OrderMoney,`ParkCode`=?ParkCode,`CarNo`=?CarNo,`UserID`=?UserID,`PaymentType`=?PaymentType,`Purpose`=?Purpose,`SubPurpose`=?SubPurpose,`Description`=?Description,`CouponMoney`=?CouponMoney,`DeduMoney`=?DeduMoney,`TotalMoney`=?TotalMoney,`CouponID`=?CouponID,`QN`=?QN,`status`=?status,`OpenId`=?OpenId,`ClientType`=?ClientType,`PartnerId`=?PartnerId,`IsAutoPay`=?IsAutoPay,`Extre`=?Extre,`OrderNoPart`=?OrderNoPart where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from orders_success  where `OrderNo`=?OrderNo;";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamOrderTime = "?OrderTime";
        protected const string ParamOrderMoney = "?OrderMoney";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamUserID = "?UserID";
        protected const string ParamPaymentType = "?PaymentType";
        protected const string ParamPurpose = "?Purpose";
        protected const string ParamSubPurpose = "?SubPurpose";
        protected const string ParamDescription = "?Description";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamDeduMoney = "?DeduMoney";
        protected const string ParamTotalMoney = "?TotalMoney";
        protected const string ParamCouponID = "?CouponID";
        protected const string ParamQN = "?QN";
        protected const string Paramstatus = "?status";
        protected const string ParamOpenId = "?OpenId";
        protected const string ParamClientType = "?ClientType";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamIsAutoPay = "?IsAutoPay";
        protected const string ParamExtre = "?Extre";
        protected const string ParamOrderNoPart = "?OrderNoPart";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OrdersSuccesDb</returns>
        public static List<OrdersSuccesDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="orderssucces">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OrdersSuccesDb orderssucces)
        {
            var param= GetInsertParams(orderssucces);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersSuccesDb</returns>
        public static OrdersSuccesDb  GetByPriKey(string orderNo)
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
        /// <param name="orderssucces">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OrdersSuccesDb orderssucces)
        {
            var param= GetUpdateParams(orderssucces);
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
        public static MySqlParameter[]  GetUpdateParams(OrdersSuccesDb orderssucces)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderssucces.OrderNo),
                    new MySqlParameter(ParamOrderTime,orderssucces.OrderTime),
                    new MySqlParameter(ParamOrderMoney,orderssucces.OrderMoney),
                    new MySqlParameter(ParamParkCode,orderssucces.ParkCode),
                    new MySqlParameter(ParamCarNo,orderssucces.CarNo),
                    new MySqlParameter(ParamUserID,orderssucces.UserID),
                    new MySqlParameter(ParamPaymentType,orderssucces.PaymentType),
                    new MySqlParameter(ParamPurpose,orderssucces.Purpose),
                    new MySqlParameter(ParamSubPurpose,orderssucces.SubPurpose),
                    new MySqlParameter(ParamDescription,orderssucces.Description),
                    new MySqlParameter(ParamCouponMoney,orderssucces.CouponMoney),
                    new MySqlParameter(ParamDeduMoney,orderssucces.DeduMoney),
                    new MySqlParameter(ParamTotalMoney,orderssucces.TotalMoney),
                    new MySqlParameter(ParamCouponID,orderssucces.CouponID),
                    new MySqlParameter(ParamQN,orderssucces.QN),
                    new MySqlParameter(Paramstatus,orderssucces.Status),
                    new MySqlParameter(ParamOpenId,orderssucces.OpenId),
                    new MySqlParameter(ParamClientType,orderssucces.ClientType),
                    new MySqlParameter(ParamPartnerId,orderssucces.PartnerId),
                    new MySqlParameter(ParamIsAutoPay,orderssucces.IsAutoPay),
                    new MySqlParameter(ParamExtre,orderssucces.Extre),
                    new MySqlParameter(ParamOrderNoPart,orderssucces.OrderNoPart)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OrdersSuccesDb orderssucces)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderssucces.OrderNo),
                    new MySqlParameter(ParamOrderTime,orderssucces.OrderTime),
                    new MySqlParameter(ParamOrderMoney,orderssucces.OrderMoney),
                    new MySqlParameter(ParamParkCode,orderssucces.ParkCode),
                    new MySqlParameter(ParamCarNo,orderssucces.CarNo),
                    new MySqlParameter(ParamUserID,orderssucces.UserID),
                    new MySqlParameter(ParamPaymentType,orderssucces.PaymentType),
                    new MySqlParameter(ParamPurpose,orderssucces.Purpose),
                    new MySqlParameter(ParamSubPurpose,orderssucces.SubPurpose),
                    new MySqlParameter(ParamDescription,orderssucces.Description),
                    new MySqlParameter(ParamCouponMoney,orderssucces.CouponMoney),
                    new MySqlParameter(ParamDeduMoney,orderssucces.DeduMoney),
                    new MySqlParameter(ParamTotalMoney,orderssucces.TotalMoney),
                    new MySqlParameter(ParamCouponID,orderssucces.CouponID),
                    new MySqlParameter(ParamQN,orderssucces.QN),
                    new MySqlParameter(Paramstatus,orderssucces.Status),
                    new MySqlParameter(ParamOpenId,orderssucces.OpenId),
                    new MySqlParameter(ParamClientType,orderssucces.ClientType),
                    new MySqlParameter(ParamPartnerId,orderssucces.PartnerId),
                    new MySqlParameter(ParamIsAutoPay,orderssucces.IsAutoPay),
                    new MySqlParameter(ParamExtre,orderssucces.Extre),
                    new MySqlParameter(ParamOrderNoPart,orderssucces.OrderNoPart)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersSuccesDb</returns>
        public static OrdersSuccesDb  ConvertToObject(DataRow dr)
        {
            var data = new OrdersSuccesDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    OrderTime = DbChange.ToDateTime(dr["OrderTime"],DateTime.MinValue),
                    OrderMoney = DbChange.ToDecimal(dr["OrderMoney"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    UserID = DbChange.ToString(dr["UserID"]),
                    PaymentType = DbChange.ToInt(dr["PaymentType"],0),
                    Purpose = DbChange.ToInt(dr["Purpose"],0),
                    SubPurpose = DbChange.ToInt(dr["SubPurpose"],0),
                    Description = DbChange.ToString(dr["Description"]),
                    CouponMoney = DbChange.ToDecimal(dr["CouponMoney"],0),
                    DeduMoney = DbChange.ToDecimal(dr["DeduMoney"],0),
                    TotalMoney = DbChange.ToDecimal(dr["TotalMoney"],0),
                    CouponID = DbChange.ToString(dr["CouponID"]),
                    QN = DbChange.ToString(dr["QN"]),
                    Status = DbChange.ToInt(dr["status"],0),
                    OpenId = DbChange.ToString(dr["OpenId"]),
                    ClientType = DbChange.ToInt(dr["ClientType"],0),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    IsAutoPay = DbChange.ToInt(dr["IsAutoPay"],0),
                    Extre = DbChange.ToInt(dr["Extre"],0),
                    OrderNoPart = DbChange.ToString(dr["OrderNoPart"])
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
        public static List<OrdersSuccesDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OrdersSuccesDb>(); 
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

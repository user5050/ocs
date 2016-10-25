using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Orders;

/*
* 由自动生成工具完成
* 描述:[orders_pre]订单预生成表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Orders
{
    /// <summary>
    /// [orders_pre]订单预生成表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OrdersPreDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from orders_pre;";
        //新增插入语句
        protected const string SqlInsert = "insert into orders_pre(`OrderNo`,`OrderTime`,`OrderMoney`,`ParkCode`,`CarNo`,`PaymentType`,`Purpose`,`SubPurpose`,`Description`,`UserID`,`CouponMoney`,`DeduMoney`,`TotalMoney`,`CouponID`,`OpenId`,`ClientType`,`PartnerId`,`Extre`) values(?OrderNo,?OrderTime,?OrderMoney,?ParkCode,?CarNo,?PaymentType,?Purpose,?SubPurpose,?Description,?UserID,?CouponMoney,?DeduMoney,?TotalMoney,?CouponID,?OpenId,?ClientType,?PartnerId,?Extre);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from orders_pre where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update orders_pre set `OrderTime`=?OrderTime,`OrderMoney`=?OrderMoney,`ParkCode`=?ParkCode,`CarNo`=?CarNo,`PaymentType`=?PaymentType,`Purpose`=?Purpose,`SubPurpose`=?SubPurpose,`Description`=?Description,`UserID`=?UserID,`CouponMoney`=?CouponMoney,`DeduMoney`=?DeduMoney,`TotalMoney`=?TotalMoney,`CouponID`=?CouponID,`OpenId`=?OpenId,`ClientType`=?ClientType,`PartnerId`=?PartnerId,`Extre`=?Extre where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from orders_pre  where `OrderNo`=?OrderNo;";
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
        protected const string ParamOpenId = "?OpenId";
        protected const string ParamClientType = "?ClientType";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamExtre = "?Extre";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OrdersPreDb</returns>
        public static List<OrdersPreDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="orderspre">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OrdersPreDb orderspre)
        {
            var param= GetInsertParams(orderspre);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersPreDb</returns>
        public static OrdersPreDb  GetByPriKey(string orderNo)
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
        /// <param name="orderspre">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OrdersPreDb orderspre)
        {
            var param= GetUpdateParams(orderspre);
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
        public static MySqlParameter[]  GetUpdateParams(OrdersPreDb orderspre)
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

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OrdersPreDb orderspre)
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

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersPreDb</returns>
        public static OrdersPreDb  ConvertToObject(DataRow dr)
        {
            var data = new OrdersPreDb
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
                    OpenId = DbChange.ToString(dr["OpenId"]),
                    ClientType = DbChange.ToInt(dr["ClientType"],0),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    Extre = DbChange.ToInt(dr["Extre"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OrdersPreDb</returns>
        public static List<OrdersPreDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OrdersPreDb>(); 
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

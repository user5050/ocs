using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Orders;

/*
* 由自动生成工具完成
* 描述:撤费表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Orders
{
    /// <summary>
    /// 撤费表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OrdersCanceledDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from orders_canceled;";
        //新增插入语句
        protected const string SqlInsert = "insert into orders_canceled(`OrderNo`,`OrderTime`,`OrderMoney`,`ParkCode`,`CarNo`,`UserID`,`PaymentType`,`Purpose`,`Description`,`QN`,`CancelOrderNo`,`IsProcessed`,`IsChecked`,`CouponMoney`,`DeduMoney`,`TotalMoney`,`CouponID`,`OpenId`,`ClientType`,`PartnerId`,`Extre`,`SubPurpose`) values(?OrderNo,?OrderTime,?OrderMoney,?ParkCode,?CarNo,?UserID,?PaymentType,?Purpose,?Description,?QN,?CancelOrderNo,?IsProcessed,?IsChecked,?CouponMoney,?DeduMoney,?TotalMoney,?CouponID,?OpenId,?ClientType,?PartnerId,?Extre,?SubPurpose);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from orders_canceled where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update orders_canceled set `OrderTime`=?OrderTime,`OrderMoney`=?OrderMoney,`ParkCode`=?ParkCode,`CarNo`=?CarNo,`UserID`=?UserID,`PaymentType`=?PaymentType,`Purpose`=?Purpose,`Description`=?Description,`QN`=?QN,`CancelOrderNo`=?CancelOrderNo,`IsProcessed`=?IsProcessed,`IsChecked`=?IsChecked,`CouponMoney`=?CouponMoney,`DeduMoney`=?DeduMoney,`TotalMoney`=?TotalMoney,`CouponID`=?CouponID,`OpenId`=?OpenId,`ClientType`=?ClientType,`PartnerId`=?PartnerId,`Extre`=?Extre,`SubPurpose`=?SubPurpose where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from orders_canceled  where `OrderNo`=?OrderNo;";
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
        protected const string ParamDescription = "?Description";
        protected const string ParamQN = "?QN";
        protected const string ParamCancelOrderNo = "?CancelOrderNo";
        protected const string ParamIsProcessed = "?IsProcessed";
        protected const string ParamIsChecked = "?IsChecked";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamDeduMoney = "?DeduMoney";
        protected const string ParamTotalMoney = "?TotalMoney";
        protected const string ParamCouponID = "?CouponID";
        protected const string ParamOpenId = "?OpenId";
        protected const string ParamClientType = "?ClientType";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamExtre = "?Extre";
        protected const string ParamSubPurpose = "?SubPurpose";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OrdersCanceledDb</returns>
        public static List<OrdersCanceledDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="orderscanceled">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OrdersCanceledDb orderscanceled)
        {
            var param= GetInsertParams(orderscanceled);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersCanceledDb</returns>
        public static OrdersCanceledDb  GetByPriKey(string orderNo)
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
        /// <param name="orderscanceled">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OrdersCanceledDb orderscanceled)
        {
            var param= GetUpdateParams(orderscanceled);
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
        public static MySqlParameter[]  GetUpdateParams(OrdersCanceledDb orderscanceled)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderscanceled.OrderNo),
                    new MySqlParameter(ParamOrderTime,orderscanceled.OrderTime),
                    new MySqlParameter(ParamOrderMoney,orderscanceled.OrderMoney),
                    new MySqlParameter(ParamParkCode,orderscanceled.ParkCode),
                    new MySqlParameter(ParamCarNo,orderscanceled.CarNo),
                    new MySqlParameter(ParamUserID,orderscanceled.UserID),
                    new MySqlParameter(ParamPaymentType,orderscanceled.PaymentType),
                    new MySqlParameter(ParamPurpose,orderscanceled.Purpose),
                    new MySqlParameter(ParamDescription,orderscanceled.Description),
                    new MySqlParameter(ParamQN,orderscanceled.QN),
                    new MySqlParameter(ParamCancelOrderNo,orderscanceled.CancelOrderNo),
                    new MySqlParameter(ParamIsProcessed,orderscanceled.IsProcessed),
                    new MySqlParameter(ParamIsChecked,orderscanceled.IsChecked),
                    new MySqlParameter(ParamCouponMoney,orderscanceled.CouponMoney),
                    new MySqlParameter(ParamDeduMoney,orderscanceled.DeduMoney),
                    new MySqlParameter(ParamTotalMoney,orderscanceled.TotalMoney),
                    new MySqlParameter(ParamCouponID,orderscanceled.CouponID),
                    new MySqlParameter(ParamOpenId,orderscanceled.OpenId),
                    new MySqlParameter(ParamClientType,orderscanceled.ClientType),
                    new MySqlParameter(ParamPartnerId,orderscanceled.PartnerId),
                    new MySqlParameter(ParamExtre,orderscanceled.Extre),
                    new MySqlParameter(ParamSubPurpose,orderscanceled.SubPurpose)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OrdersCanceledDb orderscanceled)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderscanceled.OrderNo),
                    new MySqlParameter(ParamOrderTime,orderscanceled.OrderTime),
                    new MySqlParameter(ParamOrderMoney,orderscanceled.OrderMoney),
                    new MySqlParameter(ParamParkCode,orderscanceled.ParkCode),
                    new MySqlParameter(ParamCarNo,orderscanceled.CarNo),
                    new MySqlParameter(ParamUserID,orderscanceled.UserID),
                    new MySqlParameter(ParamPaymentType,orderscanceled.PaymentType),
                    new MySqlParameter(ParamPurpose,orderscanceled.Purpose),
                    new MySqlParameter(ParamDescription,orderscanceled.Description),
                    new MySqlParameter(ParamQN,orderscanceled.QN),
                    new MySqlParameter(ParamCancelOrderNo,orderscanceled.CancelOrderNo),
                    new MySqlParameter(ParamIsProcessed,orderscanceled.IsProcessed),
                    new MySqlParameter(ParamIsChecked,orderscanceled.IsChecked),
                    new MySqlParameter(ParamCouponMoney,orderscanceled.CouponMoney),
                    new MySqlParameter(ParamDeduMoney,orderscanceled.DeduMoney),
                    new MySqlParameter(ParamTotalMoney,orderscanceled.TotalMoney),
                    new MySqlParameter(ParamCouponID,orderscanceled.CouponID),
                    new MySqlParameter(ParamOpenId,orderscanceled.OpenId),
                    new MySqlParameter(ParamClientType,orderscanceled.ClientType),
                    new MySqlParameter(ParamPartnerId,orderscanceled.PartnerId),
                    new MySqlParameter(ParamExtre,orderscanceled.Extre),
                    new MySqlParameter(ParamSubPurpose,orderscanceled.SubPurpose)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersCanceledDb</returns>
        public static OrdersCanceledDb  ConvertToObject(DataRow dr)
        {
            var data = new OrdersCanceledDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    OrderTime = DbChange.ToDateTime(dr["OrderTime"],DateTime.MinValue),
                    OrderMoney = DbChange.ToInt(dr["OrderMoney"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    UserID = DbChange.ToString(dr["UserID"]),
                    PaymentType = DbChange.ToInt(dr["PaymentType"],0),
                    Purpose = DbChange.ToInt(dr["Purpose"],0),
                    Description = DbChange.ToString(dr["Description"]),
                    QN = DbChange.ToString(dr["QN"]),
                    CancelOrderNo = DbChange.ToString(dr["CancelOrderNo"]),
                    IsProcessed = DbChange.ToInt(dr["IsProcessed"],0),
                    IsChecked = DbChange.ToInt(dr["IsChecked"],0),
                    CouponMoney = DbChange.ToInt(dr["CouponMoney"],0),
                    DeduMoney = DbChange.ToInt(dr["DeduMoney"],0),
                    TotalMoney = DbChange.ToInt(dr["TotalMoney"],0),
                    CouponID = DbChange.ToString(dr["CouponID"]),
                    OpenId = DbChange.ToString(dr["OpenId"]),
                    ClientType = DbChange.ToInt(dr["ClientType"],0),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    Extre = DbChange.ToInt(dr["Extre"],0),
                    SubPurpose = DbChange.ToInt(dr["SubPurpose"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OrdersCanceledDb</returns>
        public static List<OrdersCanceledDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OrdersCanceledDb>(); 
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

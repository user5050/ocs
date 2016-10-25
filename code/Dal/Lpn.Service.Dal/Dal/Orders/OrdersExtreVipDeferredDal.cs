using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Orders;

/*
* 由自动生成工具完成
* 描述:车辆支付订单额外信息表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Orders
{
    /// <summary>
    /// 车辆支付订单额外信息表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OrdersExtreVipDeferredDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from orders_extre_vip_deferred;";
        //新增插入语句
        protected const string SqlInsert = "insert into orders_extre_vip_deferred(`OrderNo`,`Money`,`TillDate`,`ForMonth`,`FreeDays`) values(?OrderNo,?Money,?TillDate,?ForMonth,?FreeDays);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from orders_extre_vip_deferred where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update orders_extre_vip_deferred set `Money`=?Money,`TillDate`=?TillDate,`ForMonth`=?ForMonth,`FreeDays`=?FreeDays where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from orders_extre_vip_deferred  where `OrderNo`=?OrderNo;";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamMoney = "?Money";
        protected const string ParamTillDate = "?TillDate";
        protected const string ParamForMonth = "?ForMonth";
        protected const string ParamFreeDays = "?FreeDays";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OrdersExtreVipDeferredDb</returns>
        public static List<OrdersExtreVipDeferredDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="ordersextrevipdeferred">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OrdersExtreVipDeferredDb ordersextrevipdeferred)
        {
            var param= GetInsertParams(ordersextrevipdeferred);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersExtreVipDeferredDb</returns>
        public static OrdersExtreVipDeferredDb  GetByPriKey(string orderNo)
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
        /// <param name="ordersextrevipdeferred">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OrdersExtreVipDeferredDb ordersextrevipdeferred)
        {
            var param= GetUpdateParams(ordersextrevipdeferred);
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
        public static MySqlParameter[]  GetUpdateParams(OrdersExtreVipDeferredDb ordersextrevipdeferred)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersextrevipdeferred.OrderNo),
                    new MySqlParameter(ParamMoney,ordersextrevipdeferred.Money),
                    new MySqlParameter(ParamTillDate,ordersextrevipdeferred.TillDate),
                    new MySqlParameter(ParamForMonth,ordersextrevipdeferred.ForMonth),
                    new MySqlParameter(ParamFreeDays,ordersextrevipdeferred.FreeDays)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OrdersExtreVipDeferredDb ordersextrevipdeferred)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersextrevipdeferred.OrderNo),
                    new MySqlParameter(ParamMoney,ordersextrevipdeferred.Money),
                    new MySqlParameter(ParamTillDate,ordersextrevipdeferred.TillDate),
                    new MySqlParameter(ParamForMonth,ordersextrevipdeferred.ForMonth),
                    new MySqlParameter(ParamFreeDays,ordersextrevipdeferred.FreeDays)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersExtreVipDeferredDb</returns>
        public static OrdersExtreVipDeferredDb  ConvertToObject(DataRow dr)
        {
            var data = new OrdersExtreVipDeferredDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    Money = DbChange.ToDouble(dr["Money"],0D),
                    TillDate = DbChange.ToDateTime(dr["TillDate"],DateTime.MinValue),
                    ForMonth = DbChange.ToInt(dr["ForMonth"],0),
                    FreeDays = DbChange.ToInt(dr["FreeDays"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OrdersExtreVipDeferredDb</returns>
        public static List<OrdersExtreVipDeferredDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OrdersExtreVipDeferredDb>(); 
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

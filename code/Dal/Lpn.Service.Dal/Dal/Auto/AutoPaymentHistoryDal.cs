using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Auto;

/*
* 由自动生成工具完成
* 描述:[auto_payment_history]自动扣费历史记录 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Auto
{
    /// <summary>
    /// [auto_payment_history]自动扣费历史记录 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class AutoPaymentHistoryDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from autopaymenthistory;";
        //新增插入语句
        protected const string SqlInsert = "insert into autopaymenthistory(`ParkCode`,`VehicleNo`,`MaxAutoPayment`,`MinMoney`,`Payment`,`UserId`,`Status`,`CouponMoney`,`CouponDescription`) values(?ParkCode,?VehicleNo,?MaxAutoPayment,?MinMoney,?Payment,?UserId,?Status,?CouponMoney,?CouponDescription);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from autopaymenthistory where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update autopaymenthistory set `ParkCode`=?ParkCode,`VehicleNo`=?VehicleNo,`MaxAutoPayment`=?MaxAutoPayment,`MinMoney`=?MinMoney,`Payment`=?Payment,`UserId`=?UserId,`Status`=?Status,`CouponMoney`=?CouponMoney,`CouponDescription`=?CouponDescription where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from autopaymenthistory  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamVehicleNo = "?VehicleNo";
        protected const string ParamMaxAutoPayment = "?MaxAutoPayment";
        protected const string ParamMinMoney = "?MinMoney";
        protected const string ParamPayment = "?Payment";
        protected const string ParamUserId = "?UserId";
        protected const string ParamStatus = "?Status";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamCouponDescription = "?CouponDescription";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of AutoPaymentHistoryDb</returns>
        public static List<AutoPaymentHistoryDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="autopaymenthistory">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(AutoPaymentHistoryDb autopaymenthistory)
        {
            var param= GetInsertParams(autopaymenthistory);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">自动扣费历史记录编号</param> 
        /// <returns>AutoPaymentHistoryDb</returns>
        public static AutoPaymentHistoryDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
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
        /// <param name="autopaymenthistory">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(AutoPaymentHistoryDb autopaymenthistory)
        {
            var param= GetUpdateParams(autopaymenthistory);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">自动扣费历史记录编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(AutoPaymentHistoryDb autopaymenthistory)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,autopaymenthistory.ID),
                    new MySqlParameter(ParamParkCode,autopaymenthistory.ParkCode),
                    new MySqlParameter(ParamVehicleNo,autopaymenthistory.VehicleNo),
                    new MySqlParameter(ParamMaxAutoPayment,autopaymenthistory.MaxAutoPayment),
                    new MySqlParameter(ParamMinMoney,autopaymenthistory.MinMoney),
                    new MySqlParameter(ParamPayment,autopaymenthistory.Payment),
                    new MySqlParameter(ParamUserId,autopaymenthistory.UserId),
                    new MySqlParameter(ParamStatus,autopaymenthistory.Status),
                    new MySqlParameter(ParamCouponMoney,autopaymenthistory.CouponMoney),
                    new MySqlParameter(ParamCouponDescription,autopaymenthistory.CouponDescription)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(AutoPaymentHistoryDb autopaymenthistory)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,autopaymenthistory.ParkCode),
                    new MySqlParameter(ParamVehicleNo,autopaymenthistory.VehicleNo),
                    new MySqlParameter(ParamMaxAutoPayment,autopaymenthistory.MaxAutoPayment),
                    new MySqlParameter(ParamMinMoney,autopaymenthistory.MinMoney),
                    new MySqlParameter(ParamPayment,autopaymenthistory.Payment),
                    new MySqlParameter(ParamUserId,autopaymenthistory.UserId),
                    new MySqlParameter(ParamStatus,autopaymenthistory.Status),
                    new MySqlParameter(ParamCouponMoney,autopaymenthistory.CouponMoney),
                    new MySqlParameter(ParamCouponDescription,autopaymenthistory.CouponDescription)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>AutoPaymentHistoryDb</returns>
        public static AutoPaymentHistoryDb  ConvertToObject(DataRow dr)
        {
            var data = new AutoPaymentHistoryDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    VehicleNo = DbChange.ToString(dr["VehicleNo"]),
                    MaxAutoPayment = DbChange.ToString(dr["MaxAutoPayment"]),
                    MinMoney = DbChange.ToString(dr["MinMoney"]),
                    Payment = DbChange.ToString(dr["Payment"]),
                    UserId = DbChange.ToInt(dr["UserId"],0),
                    Status = DbChange.ToInt(dr["Status"],0),
                    CouponMoney = DbChange.ToInt(dr["CouponMoney"],0),
                    CouponDescription = DbChange.ToString(dr["CouponDescription"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of AutoPaymentHistoryDb</returns>
        public static List<AutoPaymentHistoryDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<AutoPaymentHistoryDb>(); 
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

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Auto;

/*
* 由自动生成工具完成
* 描述:[auto_payment]自动扣费 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Auto
{
    /// <summary>
    /// [auto_payment]自动扣费 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class AutoPaymentDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from autopayment;";
        //新增插入语句
        protected const string SqlInsert = "insert into autopayment(`ParkCode`,`VehicleNo`,`MaxAutoPayment`,`MinMoney`,`Payment`,`UserId`,`Status`,`CouponMoney`,`CouponDescription`) values(?ParkCode,?VehicleNo,?MaxAutoPayment,?MinMoney,?Payment,?UserId,?Status,?CouponMoney,?CouponDescription);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from autopayment where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update autopayment set `ParkCode`=?ParkCode,`VehicleNo`=?VehicleNo,`MaxAutoPayment`=?MaxAutoPayment,`MinMoney`=?MinMoney,`Payment`=?Payment,`UserId`=?UserId,`Status`=?Status,`CouponMoney`=?CouponMoney,`CouponDescription`=?CouponDescription where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from autopayment  where `ID`=?ID;";
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
        /// <returns>List of AutoPaymentDb</returns>
        public static List<AutoPaymentDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="autopayment">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(AutoPaymentDb autopayment)
        {
            var param= GetInsertParams(autopayment);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">自动扣费编号</param> 
        /// <returns>AutoPaymentDb</returns>
        public static AutoPaymentDb  GetByPriKey(int id)
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
        /// <param name="autopayment">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(AutoPaymentDb autopayment)
        {
            var param= GetUpdateParams(autopayment);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">自动扣费编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(AutoPaymentDb autopayment)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,autopayment.ID),
                    new MySqlParameter(ParamParkCode,autopayment.ParkCode),
                    new MySqlParameter(ParamVehicleNo,autopayment.VehicleNo),
                    new MySqlParameter(ParamMaxAutoPayment,autopayment.MaxAutoPayment),
                    new MySqlParameter(ParamMinMoney,autopayment.MinMoney),
                    new MySqlParameter(ParamPayment,autopayment.Payment),
                    new MySqlParameter(ParamUserId,autopayment.UserId),
                    new MySqlParameter(ParamStatus,autopayment.Status),
                    new MySqlParameter(ParamCouponMoney,autopayment.CouponMoney),
                    new MySqlParameter(ParamCouponDescription,autopayment.CouponDescription)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(AutoPaymentDb autopayment)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,autopayment.ParkCode),
                    new MySqlParameter(ParamVehicleNo,autopayment.VehicleNo),
                    new MySqlParameter(ParamMaxAutoPayment,autopayment.MaxAutoPayment),
                    new MySqlParameter(ParamMinMoney,autopayment.MinMoney),
                    new MySqlParameter(ParamPayment,autopayment.Payment),
                    new MySqlParameter(ParamUserId,autopayment.UserId),
                    new MySqlParameter(ParamStatus,autopayment.Status),
                    new MySqlParameter(ParamCouponMoney,autopayment.CouponMoney),
                    new MySqlParameter(ParamCouponDescription,autopayment.CouponDescription)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>AutoPaymentDb</returns>
        public static AutoPaymentDb  ConvertToObject(DataRow dr)
        {
            var data = new AutoPaymentDb
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
        /// <returns>List of AutoPaymentDb</returns>
        public static List<AutoPaymentDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<AutoPaymentDb>(); 
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

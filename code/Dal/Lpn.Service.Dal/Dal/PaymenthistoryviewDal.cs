using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db;

/*
* 由自动生成工具完成
* 描述:VIEW Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal
{
    /// <summary>
    /// VIEW Dal帮助类
    /// </summary>
    [Serializable]
    public partial class PaymenthistoryviewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from paymenthistoryview;";
        //新增插入语句
        protected const string SqlInsert = "insert into paymenthistoryview(`OrderNo`,`OrderTime`,`OrderMoney`,`ParkCode`,`ParkName`,`City`,`CarNo`,`UserName`,`PaymentType`,`Purpose`,`CouponMoney`,`PartnerId`,`ClientType`,`status`,`TotalMoney`,`DeduMoney`,`SubPurpose`,`IsAutoPay`,`Description`,`PayDesc`) values(?OrderNo,?OrderTime,?OrderMoney,?ParkCode,?ParkName,?City,?CarNo,?UserName,?PaymentType,?Purpose,?CouponMoney,?PartnerId,?ClientType,?status,?TotalMoney,?DeduMoney,?SubPurpose,?IsAutoPay,?Description,?PayDesc);";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamOrderTime = "?OrderTime";
        protected const string ParamOrderMoney = "?OrderMoney";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamParkName = "?ParkName";
        protected const string ParamCity = "?City";
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamUserName = "?UserName";
        protected const string ParamPaymentType = "?PaymentType";
        protected const string ParamPurpose = "?Purpose";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamClientType = "?ClientType";
        protected const string Paramstatus = "?status";
        protected const string ParamTotalMoney = "?TotalMoney";
        protected const string ParamDeduMoney = "?DeduMoney";
        protected const string ParamSubPurpose = "?SubPurpose";
        protected const string ParamIsAutoPay = "?IsAutoPay";
        protected const string ParamDescription = "?Description";
        protected const string ParamPayDesc = "?PayDesc";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of PaymenthistoryviewDb</returns>
        public static List<PaymenthistoryviewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="paymenthistoryview">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(PaymenthistoryviewDb paymenthistoryview)
        {
            var param= GetInsertParams(paymenthistoryview);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(PaymenthistoryviewDb paymenthistoryview)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,paymenthistoryview.OrderNo),
                    new MySqlParameter(ParamOrderTime,paymenthistoryview.OrderTime),
                    new MySqlParameter(ParamOrderMoney,paymenthistoryview.OrderMoney),
                    new MySqlParameter(ParamParkCode,paymenthistoryview.ParkCode),
                    new MySqlParameter(ParamParkName,paymenthistoryview.ParkName),
                    new MySqlParameter(ParamCity,paymenthistoryview.City),
                    new MySqlParameter(ParamCarNo,paymenthistoryview.CarNo),
                    new MySqlParameter(ParamUserName,paymenthistoryview.UserName),
                    new MySqlParameter(ParamPaymentType,paymenthistoryview.PaymentType),
                    new MySqlParameter(ParamPurpose,paymenthistoryview.Purpose),
                    new MySqlParameter(ParamCouponMoney,paymenthistoryview.CouponMoney),
                    new MySqlParameter(ParamPartnerId,paymenthistoryview.PartnerId),
                    new MySqlParameter(ParamClientType,paymenthistoryview.ClientType),
                    new MySqlParameter(Paramstatus,paymenthistoryview.Status),
                    new MySqlParameter(ParamTotalMoney,paymenthistoryview.TotalMoney),
                    new MySqlParameter(ParamDeduMoney,paymenthistoryview.DeduMoney),
                    new MySqlParameter(ParamSubPurpose,paymenthistoryview.SubPurpose),
                    new MySqlParameter(ParamIsAutoPay,paymenthistoryview.IsAutoPay),
                    new MySqlParameter(ParamDescription,paymenthistoryview.Description),
                    new MySqlParameter(ParamPayDesc,paymenthistoryview.PayDesc)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>PaymenthistoryviewDb</returns>
        public static PaymenthistoryviewDb  ConvertToObject(DataRow dr)
        {
            var data = new PaymenthistoryviewDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    OrderTime = DbChange.ToDateTime(dr["OrderTime"],DateTime.MinValue),
                    OrderMoney = DbChange.ToDecimal(dr["OrderMoney"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    ParkName = DbChange.ToString(dr["ParkName"]),
                    City = DbChange.ToString(dr["City"]),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    UserName = DbChange.ToString(dr["UserName"]),
                    PaymentType = DbChange.ToInt(dr["PaymentType"],0),
                    Purpose = DbChange.ToInt(dr["Purpose"],0),
                    CouponMoney = DbChange.ToDecimal(dr["CouponMoney"],0),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    ClientType = DbChange.ToInt(dr["ClientType"],0),
                    Status = DbChange.ToInt(dr["status"],0),
                    TotalMoney = DbChange.ToDecimal(dr["TotalMoney"],0),
                    DeduMoney = DbChange.ToDecimal(dr["DeduMoney"],0),
                    SubPurpose = DbChange.ToInt(dr["SubPurpose"],0),
                    IsAutoPay = DbChange.ToInt(dr["IsAutoPay"],0),
                    Description = DbChange.ToString(dr["Description"]),
                    PayDesc = DbChange.ToString(dr["PayDesc"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of PaymenthistoryviewDb</returns>
        public static List<PaymenthistoryviewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<PaymenthistoryviewDb>(); 
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

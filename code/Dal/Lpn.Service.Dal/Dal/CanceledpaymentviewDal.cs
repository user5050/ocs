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
    public partial class CanceledpaymentviewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from canceledpaymentview;";
        //新增插入语句
        protected const string SqlInsert = "insert into canceledpaymentview(`OrderNo`,`OrderTime`,`OrderMoney`,`ParkCode`,`ParkName`,`City`,`CarNo`,`UserName`,`PaymentType`,`Purpose`,`Description`,`qn`,`CancelOrderNo`,`CouponMoney`,`PartnerId`,`TotalMoney`,`DeduMoney`,`IsChecked`,`UserID`) values(?OrderNo,?OrderTime,?OrderMoney,?ParkCode,?ParkName,?City,?CarNo,?UserName,?PaymentType,?Purpose,?Description,?qn,?CancelOrderNo,?CouponMoney,?PartnerId,?TotalMoney,?DeduMoney,?IsChecked,?UserID);";
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
        protected const string ParamDescription = "?Description";
        protected const string Paramqn = "?qn";
        protected const string ParamCancelOrderNo = "?CancelOrderNo";
        protected const string ParamCouponMoney = "?CouponMoney";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamTotalMoney = "?TotalMoney";
        protected const string ParamDeduMoney = "?DeduMoney";
        protected const string ParamIsChecked = "?IsChecked";
        protected const string ParamUserID = "?UserID";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CanceledpaymentviewDb</returns>
        public static List<CanceledpaymentviewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="canceledpaymentview">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CanceledpaymentviewDb canceledpaymentview)
        {
            var param= GetInsertParams(canceledpaymentview);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CanceledpaymentviewDb canceledpaymentview)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,canceledpaymentview.OrderNo),
                    new MySqlParameter(ParamOrderTime,canceledpaymentview.OrderTime),
                    new MySqlParameter(ParamOrderMoney,canceledpaymentview.OrderMoney),
                    new MySqlParameter(ParamParkCode,canceledpaymentview.ParkCode),
                    new MySqlParameter(ParamParkName,canceledpaymentview.ParkName),
                    new MySqlParameter(ParamCity,canceledpaymentview.City),
                    new MySqlParameter(ParamCarNo,canceledpaymentview.CarNo),
                    new MySqlParameter(ParamUserName,canceledpaymentview.UserName),
                    new MySqlParameter(ParamPaymentType,canceledpaymentview.PaymentType),
                    new MySqlParameter(ParamPurpose,canceledpaymentview.Purpose),
                    new MySqlParameter(ParamDescription,canceledpaymentview.Description),
                    new MySqlParameter(Paramqn,canceledpaymentview.Qn),
                    new MySqlParameter(ParamCancelOrderNo,canceledpaymentview.CancelOrderNo),
                    new MySqlParameter(ParamCouponMoney,canceledpaymentview.CouponMoney),
                    new MySqlParameter(ParamPartnerId,canceledpaymentview.PartnerId),
                    new MySqlParameter(ParamTotalMoney,canceledpaymentview.TotalMoney),
                    new MySqlParameter(ParamDeduMoney,canceledpaymentview.DeduMoney),
                    new MySqlParameter(ParamIsChecked,canceledpaymentview.IsChecked),
                    new MySqlParameter(ParamUserID,canceledpaymentview.UserID)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CanceledpaymentviewDb</returns>
        public static CanceledpaymentviewDb  ConvertToObject(DataRow dr)
        {
            var data = new CanceledpaymentviewDb
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
                    Description = DbChange.ToString(dr["Description"]),
                    Qn = DbChange.ToString(dr["qn"]),
                    CancelOrderNo = DbChange.ToString(dr["CancelOrderNo"]),
                    CouponMoney = DbChange.ToDecimal(dr["CouponMoney"],0),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    TotalMoney = DbChange.ToDecimal(dr["TotalMoney"],0),
                    DeduMoney = DbChange.ToDecimal(dr["DeduMoney"],0),
                    IsChecked = DbChange.ToInt(dr["IsChecked"],0),
                    UserID = DbChange.ToInt(dr["UserID"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CanceledpaymentviewDb</returns>
        public static List<CanceledpaymentviewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CanceledpaymentviewDb>(); 
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

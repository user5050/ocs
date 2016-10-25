using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Booking;

/*
* 由自动生成工具完成
* 描述:[booking_] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Booking
{
    /// <summary>
    /// [booking_] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class BookingDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from booking;";
        //新增插入语句
        protected const string SqlInsert = "insert into booking(`parkcode`,`bookingcode`,`carno`,`carType`,`starttime`,`endtime`,`result`,`userid`,`payment`,`payaccount`,`paymoney`,`eventtime`,`arrivetime`,`leavetime`,`effectivetime`,`money`,`parkingno`,`pretime`,`waittime`,`mobile`) values(?parkcode,?bookingcode,?carno,?carType,?starttime,?endtime,?result,?userid,?payment,?payaccount,?paymoney,?eventtime,?arrivetime,?leavetime,?effectivetime,?money,?parkingno,?pretime,?waittime,?mobile);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from booking where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update booking set `parkcode`=?parkcode,`bookingcode`=?bookingcode,`carno`=?carno,`carType`=?carType,`starttime`=?starttime,`endtime`=?endtime,`result`=?result,`userid`=?userid,`payment`=?payment,`payaccount`=?payaccount,`paymoney`=?paymoney,`eventtime`=?eventtime,`arrivetime`=?arrivetime,`leavetime`=?leavetime,`effectivetime`=?effectivetime,`money`=?money,`parkingno`=?parkingno,`pretime`=?pretime,`waittime`=?waittime,`mobile`=?mobile where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from booking  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramparkcode = "?parkcode";
        protected const string Parambookingcode = "?bookingcode";
        protected const string Paramcarno = "?carno";
        protected const string ParamcarType = "?carType";
        protected const string Paramstarttime = "?starttime";
        protected const string Paramendtime = "?endtime";
        protected const string Paramresult = "?result";
        protected const string Paramuserid = "?userid";
        protected const string Parampayment = "?payment";
        protected const string Parampayaccount = "?payaccount";
        protected const string Parampaymoney = "?paymoney";
        protected const string Parameventtime = "?eventtime";
        protected const string Paramarrivetime = "?arrivetime";
        protected const string Paramleavetime = "?leavetime";
        protected const string Parameffectivetime = "?effectivetime";
        protected const string Parammoney = "?money";
        protected const string Paramparkingno = "?parkingno";
        protected const string Parampretime = "?pretime";
        protected const string Paramwaittime = "?waittime";
        protected const string Parammobile = "?mobile";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of BookingDb</returns>
        public static List<BookingDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="booking">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(BookingDb booking)
        {
            var param= GetInsertParams(booking);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>BookingDb</returns>
        public static BookingDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,id)
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
        /// <param name="booking">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(BookingDb booking)
        {
            var param= GetUpdateParams(booking);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(BookingDb booking)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,booking.Id),
                    new MySqlParameter(Paramparkcode,booking.Parkcode),
                    new MySqlParameter(Parambookingcode,booking.Bookingcode),
                    new MySqlParameter(Paramcarno,booking.Carno),
                    new MySqlParameter(ParamcarType,booking.CarType),
                    new MySqlParameter(Paramstarttime,booking.Starttime),
                    new MySqlParameter(Paramendtime,booking.Endtime),
                    new MySqlParameter(Paramresult,booking.Result),
                    new MySqlParameter(Paramuserid,booking.Userid),
                    new MySqlParameter(Parampayment,booking.Payment),
                    new MySqlParameter(Parampayaccount,booking.Payaccount),
                    new MySqlParameter(Parampaymoney,booking.Paymoney),
                    new MySqlParameter(Parameventtime,booking.Eventtime),
                    new MySqlParameter(Paramarrivetime,booking.Arrivetime),
                    new MySqlParameter(Paramleavetime,booking.Leavetime),
                    new MySqlParameter(Parameffectivetime,booking.Effectivetime),
                    new MySqlParameter(Parammoney,booking.Money),
                    new MySqlParameter(Paramparkingno,booking.Parkingno),
                    new MySqlParameter(Parampretime,booking.Pretime),
                    new MySqlParameter(Paramwaittime,booking.Waittime),
                    new MySqlParameter(Parammobile,booking.Mobile)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(BookingDb booking)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkcode,booking.Parkcode),
                    new MySqlParameter(Parambookingcode,booking.Bookingcode),
                    new MySqlParameter(Paramcarno,booking.Carno),
                    new MySqlParameter(ParamcarType,booking.CarType),
                    new MySqlParameter(Paramstarttime,booking.Starttime),
                    new MySqlParameter(Paramendtime,booking.Endtime),
                    new MySqlParameter(Paramresult,booking.Result),
                    new MySqlParameter(Paramuserid,booking.Userid),
                    new MySqlParameter(Parampayment,booking.Payment),
                    new MySqlParameter(Parampayaccount,booking.Payaccount),
                    new MySqlParameter(Parampaymoney,booking.Paymoney),
                    new MySqlParameter(Parameventtime,booking.Eventtime),
                    new MySqlParameter(Paramarrivetime,booking.Arrivetime),
                    new MySqlParameter(Paramleavetime,booking.Leavetime),
                    new MySqlParameter(Parameffectivetime,booking.Effectivetime),
                    new MySqlParameter(Parammoney,booking.Money),
                    new MySqlParameter(Paramparkingno,booking.Parkingno),
                    new MySqlParameter(Parampretime,booking.Pretime),
                    new MySqlParameter(Paramwaittime,booking.Waittime),
                    new MySqlParameter(Parammobile,booking.Mobile)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>BookingDb</returns>
        public static BookingDb  ConvertToObject(DataRow dr)
        {
            var data = new BookingDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Bookingcode = DbChange.ToString(dr["bookingcode"]),
                    Carno = DbChange.ToString(dr["carno"]),
                    CarType = DbChange.ToString(dr["carType"]),
                    Starttime = DbChange.ToDateTime(dr["starttime"],DateTime.MinValue),
                    Endtime = DbChange.ToDateTime(dr["endtime"],DateTime.MinValue),
                    Result = DbChange.ToInt(dr["result"],0),
                    Userid = DbChange.ToInt(dr["userid"],0),
                    Payment = DbChange.ToString(dr["payment"]),
                    Payaccount = DbChange.ToString(dr["payaccount"]),
                    Paymoney = DbChange.ToDecimal(dr["paymoney"],0),
                    Eventtime = DbChange.ToDateTime(dr["eventtime"],DateTime.MinValue),
                    Arrivetime = DbChange.ToDateTime(dr["arrivetime"],DateTime.MinValue),
                    Leavetime = DbChange.ToDateTime(dr["leavetime"],DateTime.MinValue),
                    Effectivetime = DbChange.ToDateTime(dr["effectivetime"],DateTime.MinValue),
                    Money = DbChange.ToDecimal(dr["money"],0),
                    Parkingno = DbChange.ToString(dr["parkingno"]),
                    Pretime = DbChange.ToDateTime(dr["pretime"],DateTime.MinValue),
                    Waittime = DbChange.ToDateTime(dr["waittime"],DateTime.MinValue),
                    Mobile = DbChange.ToString(dr["mobile"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of BookingDb</returns>
        public static List<BookingDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<BookingDb>(); 
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

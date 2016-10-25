using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Booking;

/*
* 由自动生成工具完成
* 描述:[booking_checkout] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Booking
{
    /// <summary>
    /// [booking_checkout] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class BookingCheckoutDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from bookingcheckout;";
        //新增插入语句
        protected const string SqlInsert = "insert into bookingcheckout(`parkcode`,`starttime`,`endtime`,`successcount`,`failcount`,`timeoutcount`) values(?parkcode,?starttime,?endtime,?successcount,?failcount,?timeoutcount);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from bookingcheckout where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update bookingcheckout set `parkcode`=?parkcode,`starttime`=?starttime,`endtime`=?endtime,`successcount`=?successcount,`failcount`=?failcount,`timeoutcount`=?timeoutcount where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from bookingcheckout  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramparkcode = "?parkcode";
        protected const string Paramstarttime = "?starttime";
        protected const string Paramendtime = "?endtime";
        protected const string Paramsuccesscount = "?successcount";
        protected const string Paramfailcount = "?failcount";
        protected const string Paramtimeoutcount = "?timeoutcount";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of BookingCheckoutDb</returns>
        public static List<BookingCheckoutDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="bookingcheckout">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(BookingCheckoutDb bookingcheckout)
        {
            var param= GetInsertParams(bookingcheckout);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>BookingCheckoutDb</returns>
        public static BookingCheckoutDb  GetByPriKey(int id)
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
        /// <param name="bookingcheckout">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(BookingCheckoutDb bookingcheckout)
        {
            var param= GetUpdateParams(bookingcheckout);
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
        public static MySqlParameter[]  GetUpdateParams(BookingCheckoutDb bookingcheckout)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,bookingcheckout.Id),
                    new MySqlParameter(Paramparkcode,bookingcheckout.Parkcode),
                    new MySqlParameter(Paramstarttime,bookingcheckout.Starttime),
                    new MySqlParameter(Paramendtime,bookingcheckout.Endtime),
                    new MySqlParameter(Paramsuccesscount,bookingcheckout.Successcount),
                    new MySqlParameter(Paramfailcount,bookingcheckout.Failcount),
                    new MySqlParameter(Paramtimeoutcount,bookingcheckout.Timeoutcount)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(BookingCheckoutDb bookingcheckout)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkcode,bookingcheckout.Parkcode),
                    new MySqlParameter(Paramstarttime,bookingcheckout.Starttime),
                    new MySqlParameter(Paramendtime,bookingcheckout.Endtime),
                    new MySqlParameter(Paramsuccesscount,bookingcheckout.Successcount),
                    new MySqlParameter(Paramfailcount,bookingcheckout.Failcount),
                    new MySqlParameter(Paramtimeoutcount,bookingcheckout.Timeoutcount)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>BookingCheckoutDb</returns>
        public static BookingCheckoutDb  ConvertToObject(DataRow dr)
        {
            var data = new BookingCheckoutDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Starttime = DbChange.ToDateTime(dr["starttime"],DateTime.MinValue),
                    Endtime = DbChange.ToDateTime(dr["endtime"],DateTime.MinValue),
                    Successcount = DbChange.ToInt(dr["successcount"],0),
                    Failcount = DbChange.ToInt(dr["failcount"],0),
                    Timeoutcount = DbChange.ToInt(dr["timeoutcount"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of BookingCheckoutDb</returns>
        public static List<BookingCheckoutDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<BookingCheckoutDb>(); 
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

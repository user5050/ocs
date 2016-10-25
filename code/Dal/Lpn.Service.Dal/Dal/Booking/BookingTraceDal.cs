using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Booking;

/*
* 由自动生成工具完成
* 描述:[booking_trace] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Booking
{
    /// <summary>
    /// [booking_trace] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class BookingTraceDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from bookingtrace;";
        //新增插入语句
        protected const string SqlInsert = "insert into bookingtrace(`parkcode`,`bookingcode`,`state`,`message`,`eventtime`) values(?parkcode,?bookingcode,?state,?message,?eventtime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from bookingtrace where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update bookingtrace set `parkcode`=?parkcode,`bookingcode`=?bookingcode,`state`=?state,`message`=?message,`eventtime`=?eventtime where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from bookingtrace  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramparkcode = "?parkcode";
        protected const string Parambookingcode = "?bookingcode";
        protected const string Paramstate = "?state";
        protected const string Parammessage = "?message";
        protected const string Parameventtime = "?eventtime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of BookingTraceDb</returns>
        public static List<BookingTraceDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="bookingtrace">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(BookingTraceDb bookingtrace)
        {
            var param= GetInsertParams(bookingtrace);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>BookingTraceDb</returns>
        public static BookingTraceDb  GetByPriKey(int id)
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
        /// <param name="bookingtrace">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(BookingTraceDb bookingtrace)
        {
            var param= GetUpdateParams(bookingtrace);
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
        public static MySqlParameter[]  GetUpdateParams(BookingTraceDb bookingtrace)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,bookingtrace.Id),
                    new MySqlParameter(Paramparkcode,bookingtrace.Parkcode),
                    new MySqlParameter(Parambookingcode,bookingtrace.Bookingcode),
                    new MySqlParameter(Paramstate,bookingtrace.State),
                    new MySqlParameter(Parammessage,bookingtrace.Message),
                    new MySqlParameter(Parameventtime,bookingtrace.Eventtime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(BookingTraceDb bookingtrace)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkcode,bookingtrace.Parkcode),
                    new MySqlParameter(Parambookingcode,bookingtrace.Bookingcode),
                    new MySqlParameter(Paramstate,bookingtrace.State),
                    new MySqlParameter(Parammessage,bookingtrace.Message),
                    new MySqlParameter(Parameventtime,bookingtrace.Eventtime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>BookingTraceDb</returns>
        public static BookingTraceDb  ConvertToObject(DataRow dr)
        {
            var data = new BookingTraceDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Bookingcode = DbChange.ToString(dr["bookingcode"]),
                    State = DbChange.ToInt(dr["state"],0),
                    Message = DbChange.ToString(dr["message"]),
                    Eventtime = DbChange.ToDateTime(dr["eventtime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of BookingTraceDb</returns>
        public static List<BookingTraceDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<BookingTraceDb>(); 
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

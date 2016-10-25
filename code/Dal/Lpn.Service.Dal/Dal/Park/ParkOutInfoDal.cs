using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_out_info]车辆出场记录 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_out_info]车辆出场记录 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkOutInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkout_info;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkout_info(`ParkCode`,`Carno`,`EventTime`,`IsOrdered`,`CarImg`,`CarnoImg`,`CarCabImg`,`StartTime`,`MoneyAll`,`BookingCode`) values(?ParkCode,?Carno,?EventTime,?IsOrdered,?CarImg,?CarnoImg,?CarCabImg,?StartTime,?MoneyAll,?BookingCode);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkout_info where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkout_info set `ParkCode`=?ParkCode,`Carno`=?Carno,`EventTime`=?EventTime,`IsOrdered`=?IsOrdered,`CarImg`=?CarImg,`CarnoImg`=?CarnoImg,`CarCabImg`=?CarCabImg,`StartTime`=?StartTime,`MoneyAll`=?MoneyAll,`BookingCode`=?BookingCode where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkout_info  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamCarno = "?Carno";
        protected const string ParamEventTime = "?EventTime";
        protected const string ParamIsOrdered = "?IsOrdered";
        protected const string ParamCarImg = "?CarImg";
        protected const string ParamCarnoImg = "?CarnoImg";
        protected const string ParamCarCabImg = "?CarCabImg";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamMoneyAll = "?MoneyAll";
        protected const string ParamBookingCode = "?BookingCode";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkOutInfoDb</returns>
        public static List<ParkOutInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkoutinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkOutInfoDb parkoutinfo)
        {
            var param= GetInsertParams(parkoutinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">车辆出场记录编号</param> 
        /// <returns>ParkOutInfoDb</returns>
        public static ParkOutInfoDb  GetByPriKey(int id)
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
        /// <param name="parkoutinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkOutInfoDb parkoutinfo)
        {
            var param= GetUpdateParams(parkoutinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">车辆出场记录编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkOutInfoDb parkoutinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkoutinfo.ID),
                    new MySqlParameter(ParamParkCode,parkoutinfo.ParkCode),
                    new MySqlParameter(ParamCarno,parkoutinfo.Carno),
                    new MySqlParameter(ParamEventTime,parkoutinfo.EventTime),
                    new MySqlParameter(ParamIsOrdered,parkoutinfo.IsOrdered),
                    new MySqlParameter(ParamCarImg,parkoutinfo.CarImg),
                    new MySqlParameter(ParamCarnoImg,parkoutinfo.CarnoImg),
                    new MySqlParameter(ParamCarCabImg,parkoutinfo.CarCabImg),
                    new MySqlParameter(ParamStartTime,parkoutinfo.StartTime),
                    new MySqlParameter(ParamMoneyAll,parkoutinfo.MoneyAll),
                    new MySqlParameter(ParamBookingCode,parkoutinfo.BookingCode)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkOutInfoDb parkoutinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkoutinfo.ParkCode),
                    new MySqlParameter(ParamCarno,parkoutinfo.Carno),
                    new MySqlParameter(ParamEventTime,parkoutinfo.EventTime),
                    new MySqlParameter(ParamIsOrdered,parkoutinfo.IsOrdered),
                    new MySqlParameter(ParamCarImg,parkoutinfo.CarImg),
                    new MySqlParameter(ParamCarnoImg,parkoutinfo.CarnoImg),
                    new MySqlParameter(ParamCarCabImg,parkoutinfo.CarCabImg),
                    new MySqlParameter(ParamStartTime,parkoutinfo.StartTime),
                    new MySqlParameter(ParamMoneyAll,parkoutinfo.MoneyAll),
                    new MySqlParameter(ParamBookingCode,parkoutinfo.BookingCode)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkOutInfoDb</returns>
        public static ParkOutInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkOutInfoDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    Carno = DbChange.ToString(dr["Carno"]),
                    EventTime = DbChange.ToDateTime(dr["EventTime"],DateTime.MinValue),
                    IsOrdered = DbChange.ToInt(dr["IsOrdered"],-1),
                    CarImg = DbChange.ToString(dr["CarImg"]),
                    CarnoImg = DbChange.ToString(dr["CarnoImg"]),
                    CarCabImg = DbChange.ToString(dr["CarCabImg"]),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    MoneyAll = DbChange.ToDecimal(dr["MoneyAll"],0),
                    BookingCode = DbChange.ToString(dr["BookingCode"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkOutInfoDb</returns>
        public static List<ParkOutInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkOutInfoDb>(); 
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

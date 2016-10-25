using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Parkin;

/*
* 由自动生成工具完成
* 描述:车辆进场记录表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Parkin
{
    /// <summary>
    /// 车辆进场记录表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkinInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkin_info;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkin_info(`ParkCode`,`Carno`,`Eventtime`,`IsOrdered`,`CarImg`,`CarnoImg`,`CarCabimg`,`BookingCode`) values(?ParkCode,?Carno,?Eventtime,?IsOrdered,?CarImg,?CarnoImg,?CarCabimg,?BookingCode);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkin_info where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkin_info set `ParkCode`=?ParkCode,`Carno`=?Carno,`Eventtime`=?Eventtime,`IsOrdered`=?IsOrdered,`CarImg`=?CarImg,`CarnoImg`=?CarnoImg,`CarCabimg`=?CarCabimg,`BookingCode`=?BookingCode where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkin_info  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamCarno = "?Carno";
        protected const string ParamEventtime = "?Eventtime";
        protected const string ParamIsOrdered = "?IsOrdered";
        protected const string ParamCarImg = "?CarImg";
        protected const string ParamCarnoImg = "?CarnoImg";
        protected const string ParamCarCabimg = "?CarCabimg";
        protected const string ParamBookingCode = "?BookingCode";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkinInfoDb</returns>
        public static List<ParkinInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkininfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkinInfoDb parkininfo)
        {
            var param= GetInsertParams(parkininfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">车辆进场记录编号</param> 
        /// <returns>ParkinInfoDb</returns>
        public static ParkinInfoDb  GetByPriKey(int id)
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
        /// <param name="parkininfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkinInfoDb parkininfo)
        {
            var param= GetUpdateParams(parkininfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">车辆进场记录编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkinInfoDb parkininfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkininfo.ID),
                    new MySqlParameter(ParamParkCode,parkininfo.ParkCode),
                    new MySqlParameter(ParamCarno,parkininfo.Carno),
                    new MySqlParameter(ParamEventtime,parkininfo.Eventtime),
                    new MySqlParameter(ParamIsOrdered,parkininfo.IsOrdered),
                    new MySqlParameter(ParamCarImg,parkininfo.CarImg),
                    new MySqlParameter(ParamCarnoImg,parkininfo.CarnoImg),
                    new MySqlParameter(ParamCarCabimg,parkininfo.CarCabimg),
                    new MySqlParameter(ParamBookingCode,parkininfo.BookingCode)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkinInfoDb parkininfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkininfo.ParkCode),
                    new MySqlParameter(ParamCarno,parkininfo.Carno),
                    new MySqlParameter(ParamEventtime,parkininfo.Eventtime),
                    new MySqlParameter(ParamIsOrdered,parkininfo.IsOrdered),
                    new MySqlParameter(ParamCarImg,parkininfo.CarImg),
                    new MySqlParameter(ParamCarnoImg,parkininfo.CarnoImg),
                    new MySqlParameter(ParamCarCabimg,parkininfo.CarCabimg),
                    new MySqlParameter(ParamBookingCode,parkininfo.BookingCode)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkinInfoDb</returns>
        public static ParkinInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkinInfoDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    Carno = DbChange.ToString(dr["Carno"]),
                    Eventtime = DbChange.ToDateTime(dr["Eventtime"],DateTime.MinValue),
                    IsOrdered = DbChange.ToInt(dr["IsOrdered"],-1),
                    CarImg = DbChange.ToString(dr["CarImg"]),
                    CarnoImg = DbChange.ToString(dr["CarnoImg"]),
                    CarCabimg = DbChange.ToString(dr["CarCabimg"]),
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
        /// <returns>List of ParkinInfoDb</returns>
        public static List<ParkinInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkinInfoDb>(); 
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

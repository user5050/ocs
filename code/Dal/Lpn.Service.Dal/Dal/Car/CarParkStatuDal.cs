using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Car;

/*
* 由自动生成工具完成
* 描述:车辆进出场状态信息表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Car
{
    /// <summary>
    /// 车辆进出场状态信息表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CarParkStatuDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from car_park_status;";
        //新增插入语句
        protected const string SqlInsert = "insert into car_park_status(`CarNo`,`InOrOut`,`Time`,`ParkCode`) values(?CarNo,?InOrOut,?Time,?ParkCode);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from car_park_status where `CarNo`=?CarNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update car_park_status set `InOrOut`=?InOrOut,`Time`=?Time,`ParkCode`=?ParkCode where `CarNo`=?CarNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from car_park_status  where `CarNo`=?CarNo;";
        #endregion

        #region 参数
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamInOrOut = "?InOrOut";
        protected const string ParamTime = "?Time";
        protected const string ParamParkCode = "?ParkCode";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CarParkStatuDb</returns>
        public static List<CarParkStatuDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="carparkstatu">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CarParkStatuDb carparkstatu)
        {
            var param= GetInsertParams(carparkstatu);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="carNo">车牌号</param> 
        /// <returns>CarParkStatuDb</returns>
        public static CarParkStatuDb  GetByPriKey(string carNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carNo)
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
        /// <param name="carparkstatu">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CarParkStatuDb carparkstatu)
        {
            var param= GetUpdateParams(carparkstatu);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="carNo">车牌号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string carNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(CarParkStatuDb carparkstatu)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carparkstatu.CarNo),
                    new MySqlParameter(ParamInOrOut,carparkstatu.InOrOut),
                    new MySqlParameter(ParamTime,carparkstatu.Time),
                    new MySqlParameter(ParamParkCode,carparkstatu.ParkCode)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CarParkStatuDb carparkstatu)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carparkstatu.CarNo),
                    new MySqlParameter(ParamInOrOut,carparkstatu.InOrOut),
                    new MySqlParameter(ParamTime,carparkstatu.Time),
                    new MySqlParameter(ParamParkCode,carparkstatu.ParkCode)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CarParkStatuDb</returns>
        public static CarParkStatuDb  ConvertToObject(DataRow dr)
        {
            var data = new CarParkStatuDb
                {
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    InOrOut = DbChange.ToInt(dr["InOrOut"],0),
                    Time = DbChange.ToDateTime(dr["Time"],DateTime.MinValue),
                    ParkCode = DbChange.ToString(dr["ParkCode"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CarParkStatuDb</returns>
        public static List<CarParkStatuDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CarParkStatuDb>(); 
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

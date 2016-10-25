using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_points]停车场地图标记信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_points]停车场地图标记信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkPointDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkpoints;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkpoints(`ParkID`,`Lng`,`Lat`,`PointType`,`PointName`) values(?ParkID,?Lng,?Lat,?PointType,?PointName);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkpoints where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkpoints set `ParkID`=?ParkID,`Lng`=?Lng,`Lat`=?Lat,`PointType`=?PointType,`PointName`=?PointName where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkpoints  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkID = "?ParkID";
        protected const string ParamLng = "?Lng";
        protected const string ParamLat = "?Lat";
        protected const string ParamPointType = "?PointType";
        protected const string ParamPointName = "?PointName";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkPointDb</returns>
        public static List<ParkPointDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkpoint">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkPointDb parkpoint)
        {
            var param= GetInsertParams(parkpoint);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">停车场地图标记信息编</param> 
        /// <returns>ParkPointDb</returns>
        public static ParkPointDb  GetByPriKey(int id)
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
        /// <param name="parkpoint">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkPointDb parkpoint)
        {
            var param= GetUpdateParams(parkpoint);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">停车场地图标记信息编</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkPointDb parkpoint)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkpoint.ID),
                    new MySqlParameter(ParamParkID,parkpoint.ParkID),
                    new MySqlParameter(ParamLng,parkpoint.Lng),
                    new MySqlParameter(ParamLat,parkpoint.Lat),
                    new MySqlParameter(ParamPointType,parkpoint.PointType),
                    new MySqlParameter(ParamPointName,parkpoint.PointName)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkPointDb parkpoint)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parkpoint.ParkID),
                    new MySqlParameter(ParamLng,parkpoint.Lng),
                    new MySqlParameter(ParamLat,parkpoint.Lat),
                    new MySqlParameter(ParamPointType,parkpoint.PointType),
                    new MySqlParameter(ParamPointName,parkpoint.PointName)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkPointDb</returns>
        public static ParkPointDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkPointDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkID = DbChange.ToInt(dr["ParkID"],0),
                    Lng = DbChange.ToDouble(dr["Lng"],0D),
                    Lat = DbChange.ToDouble(dr["Lat"],0D),
                    PointType = DbChange.ToInt(dr["PointType"],0),
                    PointName = DbChange.ToString(dr["PointName"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkPointDb</returns>
        public static List<ParkPointDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkPointDb>(); 
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

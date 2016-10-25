using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_spaces_share_publish] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_spaces_share_publish] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkSpacesSharePublishDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkspacessharepublish;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkspacessharepublish(`SpaceID`,`IDX`,`BeginTime`,`EndTime`,`Price`,`CycleContex`,`CycleType`,`CreateTime`,`LastPublishTime`,`Publishstatus`,`Stamp`) values(?SpaceID,?IDX,?BeginTime,?EndTime,?Price,?CycleContex,?CycleType,?CreateTime,?LastPublishTime,?Publishstatus,?Stamp);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkspacessharepublish where `SpaceID`=?SpaceID and `IDX`=?IDX;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkspacessharepublish set `BeginTime`=?BeginTime,`EndTime`=?EndTime,`Price`=?Price,`CycleContex`=?CycleContex,`CycleType`=?CycleType,`CreateTime`=?CreateTime,`LastPublishTime`=?LastPublishTime,`Publishstatus`=?Publishstatus,`Stamp`=?Stamp where `SpaceID`=?SpaceID and `IDX`=?IDX;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkspacessharepublish  where `SpaceID`=?SpaceID and `IDX`=?IDX;";
        #endregion

        #region 参数
        protected const string ParamSpaceID = "?SpaceID";
        protected const string ParamIDX = "?IDX";
        protected const string ParamBeginTime = "?BeginTime";
        protected const string ParamEndTime = "?EndTime";
        protected const string ParamPrice = "?Price";
        protected const string ParamCycleContex = "?CycleContex";
        protected const string ParamCycleType = "?CycleType";
        protected const string ParamCreateTime = "?CreateTime";
        protected const string ParamLastPublishTime = "?LastPublishTime";
        protected const string ParamPublishstatus = "?Publishstatus";
        protected const string ParamStamp = "?Stamp";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkSpacesSharePublishDb</returns>
        public static List<ParkSpacesSharePublishDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkspacessharepublish">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkSpacesSharePublishDb parkspacessharepublish)
        {
            var param= GetInsertParams(parkspacessharepublish);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="spaceID"></param> 
        /// <param name="iDX"></param> 
        /// <returns>ParkSpacesSharePublishDb</returns>
        public static ParkSpacesSharePublishDb  GetByPriKey(string spaceID,int iDX)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSpaceID,spaceID),
                    new MySqlParameter(ParamIDX,iDX)
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
        /// <param name="parkspacessharepublish">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkSpacesSharePublishDb parkspacessharepublish)
        {
            var param= GetUpdateParams(parkspacessharepublish);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="spaceID"></param> 
        /// <param name="iDX"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string spaceID,int iDX)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSpaceID,spaceID),
                    new MySqlParameter(ParamIDX,iDX)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ParkSpacesSharePublishDb parkspacessharepublish)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSpaceID,parkspacessharepublish.SpaceID),
                    new MySqlParameter(ParamIDX,parkspacessharepublish.IDX),
                    new MySqlParameter(ParamBeginTime,parkspacessharepublish.BeginTime),
                    new MySqlParameter(ParamEndTime,parkspacessharepublish.EndTime),
                    new MySqlParameter(ParamPrice,parkspacessharepublish.Price),
                    new MySqlParameter(ParamCycleContex,parkspacessharepublish.CycleContex),
                    new MySqlParameter(ParamCycleType,parkspacessharepublish.CycleType),
                    new MySqlParameter(ParamCreateTime,parkspacessharepublish.CreateTime),
                    new MySqlParameter(ParamLastPublishTime,parkspacessharepublish.LastPublishTime),
                    new MySqlParameter(ParamPublishstatus,parkspacessharepublish.Publishstatus),
                    new MySqlParameter(ParamStamp,parkspacessharepublish.Stamp)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkSpacesSharePublishDb parkspacessharepublish)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSpaceID,parkspacessharepublish.SpaceID),
                    new MySqlParameter(ParamIDX,parkspacessharepublish.IDX),
                    new MySqlParameter(ParamBeginTime,parkspacessharepublish.BeginTime),
                    new MySqlParameter(ParamEndTime,parkspacessharepublish.EndTime),
                    new MySqlParameter(ParamPrice,parkspacessharepublish.Price),
                    new MySqlParameter(ParamCycleContex,parkspacessharepublish.CycleContex),
                    new MySqlParameter(ParamCycleType,parkspacessharepublish.CycleType),
                    new MySqlParameter(ParamCreateTime,parkspacessharepublish.CreateTime),
                    new MySqlParameter(ParamLastPublishTime,parkspacessharepublish.LastPublishTime),
                    new MySqlParameter(ParamPublishstatus,parkspacessharepublish.Publishstatus),
                    new MySqlParameter(ParamStamp,parkspacessharepublish.Stamp)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkSpacesSharePublishDb</returns>
        public static ParkSpacesSharePublishDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkSpacesSharePublishDb
                {
                    SpaceID = DbChange.ToString(dr["SpaceID"]),
                    IDX = DbChange.ToInt(dr["IDX"],0),
                    BeginTime = DbChange.ToString(dr["BeginTime"]),
                    EndTime = DbChange.ToString(dr["EndTime"]),
                    Price = DbChange.ToDecimal(dr["Price"],0),
                    CycleContex = DbChange.ToString(dr["CycleContex"]),
                    CycleType = DbChange.ToInt(dr["CycleType"],0),
                    CreateTime = DbChange.ToDateTime(dr["CreateTime"],DateTime.MinValue),
                    LastPublishTime = DbChange.ToDateTime(dr["LastPublishTime"],DateTime.MinValue),
                    Publishstatus = DbChange.ToInt(dr["Publishstatus"],-1),
                    Stamp = DbChange.ToDateTime(dr["Stamp"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkSpacesSharePublishDb</returns>
        public static List<ParkSpacesSharePublishDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkSpacesSharePublishDb>(); 
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

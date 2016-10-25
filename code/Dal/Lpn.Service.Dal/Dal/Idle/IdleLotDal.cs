using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Idle;

/*
* 由自动生成工具完成
* 描述:[idle_lots]空闲泊位 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Idle
{
    /// <summary>
    /// [idle_lots]空闲泊位 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class IdleLotDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from idlelots;";
        //新增插入语句
        protected const string SqlInsert = "insert into idlelots(`ParkCode`,`OperateCount`,`VipCount`,`EventTime`) values(?ParkCode,?OperateCount,?VipCount,?EventTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from idlelots where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update idlelots set `ParkCode`=?ParkCode,`OperateCount`=?OperateCount,`VipCount`=?VipCount,`EventTime`=?EventTime where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from idlelots  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamOperateCount = "?OperateCount";
        protected const string ParamVipCount = "?VipCount";
        protected const string ParamEventTime = "?EventTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of IdleLotDb</returns>
        public static List<IdleLotDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="idlelot">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(IdleLotDb idlelot)
        {
            var param= GetInsertParams(idlelot);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">空闲泊位编号</param> 
        /// <returns>IdleLotDb</returns>
        public static IdleLotDb  GetByPriKey(int id)
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
        /// <param name="idlelot">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(IdleLotDb idlelot)
        {
            var param= GetUpdateParams(idlelot);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">空闲泊位编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(IdleLotDb idlelot)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,idlelot.ID),
                    new MySqlParameter(ParamParkCode,idlelot.ParkCode),
                    new MySqlParameter(ParamOperateCount,idlelot.OperateCount),
                    new MySqlParameter(ParamVipCount,idlelot.VipCount),
                    new MySqlParameter(ParamEventTime,idlelot.EventTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(IdleLotDb idlelot)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,idlelot.ParkCode),
                    new MySqlParameter(ParamOperateCount,idlelot.OperateCount),
                    new MySqlParameter(ParamVipCount,idlelot.VipCount),
                    new MySqlParameter(ParamEventTime,idlelot.EventTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>IdleLotDb</returns>
        public static IdleLotDb  ConvertToObject(DataRow dr)
        {
            var data = new IdleLotDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    OperateCount = DbChange.ToInt(dr["OperateCount"],0),
                    VipCount = DbChange.ToInt(dr["VipCount"],0),
                    EventTime = DbChange.ToDateTime(dr["EventTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of IdleLotDb</returns>
        public static List<IdleLotDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<IdleLotDb>(); 
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

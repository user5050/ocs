using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_lock]车位锁信息表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_lock]车位锁信息表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkLockDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parklock;";
        //新增插入语句
        protected const string SqlInsert = "insert into parklock(`LockCode`,`BindNo`,`LockRandomCode`,`CreateTime`,`Creator`,`ClientType`) values(?LockCode,?BindNo,?LockRandomCode,?CreateTime,?Creator,?ClientType);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parklock where `LockId`=?LockId;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parklock set `LockCode`=?LockCode,`BindNo`=?BindNo,`LockRandomCode`=?LockRandomCode,`CreateTime`=?CreateTime,`Creator`=?Creator,`ClientType`=?ClientType where `LockId`=?LockId;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parklock  where `LockId`=?LockId;";
        #endregion

        #region 参数
        protected const string ParamLockId = "?LockId";
        protected const string ParamLockCode = "?LockCode";
        protected const string ParamBindNo = "?BindNo";
        protected const string ParamLockRandomCode = "?LockRandomCode";
        protected const string ParamCreateTime = "?CreateTime";
        protected const string ParamCreator = "?Creator";
        protected const string ParamClientType = "?ClientType";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkLockDb</returns>
        public static List<ParkLockDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parklock">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkLockDb parklock)
        {
            var param= GetInsertParams(parklock);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="lockId">车位锁信息编号</param> 
        /// <returns>ParkLockDb</returns>
        public static ParkLockDb  GetByPriKey(int lockId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamLockId,lockId)
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
        /// <param name="parklock">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkLockDb parklock)
        {
            var param= GetUpdateParams(parklock);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="lockId">车位锁信息编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int lockId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamLockId,lockId)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ParkLockDb parklock)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamLockId,parklock.LockId),
                    new MySqlParameter(ParamLockCode,parklock.LockCode),
                    new MySqlParameter(ParamBindNo,parklock.BindNo),
                    new MySqlParameter(ParamLockRandomCode,parklock.LockRandomCode),
                    new MySqlParameter(ParamCreateTime,parklock.CreateTime),
                    new MySqlParameter(ParamCreator,parklock.Creator),
                    new MySqlParameter(ParamClientType,parklock.ClientType)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkLockDb parklock)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamLockCode,parklock.LockCode),
                    new MySqlParameter(ParamBindNo,parklock.BindNo),
                    new MySqlParameter(ParamLockRandomCode,parklock.LockRandomCode),
                    new MySqlParameter(ParamCreateTime,parklock.CreateTime),
                    new MySqlParameter(ParamCreator,parklock.Creator),
                    new MySqlParameter(ParamClientType,parklock.ClientType)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkLockDb</returns>
        public static ParkLockDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkLockDb
                {
                    LockId = DbChange.ToInt(dr["LockId"],0),
                    LockCode = DbChange.ToString(dr["LockCode"]),
                    BindNo = DbChange.ToString(dr["BindNo"]),
                    LockRandomCode = DbChange.ToString(dr["LockRandomCode"]),
                    CreateTime = DbChange.ToDateTime(dr["CreateTime"],DateTime.MinValue),
                    Creator = DbChange.ToInt(dr["Creator"],0),
                    ClientType = DbChange.ToInt(dr["ClientType"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkLockDb</returns>
        public static List<ParkLockDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkLockDb>(); 
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

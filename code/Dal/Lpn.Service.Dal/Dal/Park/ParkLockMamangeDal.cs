using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_lock_mamange]车位锁管理 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_lock_mamange]车位锁管理 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkLockMamangeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parklockmamange;";
        //新增插入语句
        protected const string SqlInsert = "insert into parklockmamange(`ParkCode`,`ParkLocation`,`LockName`,`LockId`,`BindUserId`,`CreateTime`,`Status`,`ConfirmUser`,`ClientType`) values(?ParkCode,?ParkLocation,?LockName,?LockId,?BindUserId,?CreateTime,?Status,?ConfirmUser,?ClientType);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parklockmamange where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parklockmamange set `ParkCode`=?ParkCode,`ParkLocation`=?ParkLocation,`LockName`=?LockName,`LockId`=?LockId,`BindUserId`=?BindUserId,`CreateTime`=?CreateTime,`Status`=?Status,`ConfirmUser`=?ConfirmUser,`ClientType`=?ClientType where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parklockmamange  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamParkLocation = "?ParkLocation";
        protected const string ParamLockName = "?LockName";
        protected const string ParamLockId = "?LockId";
        protected const string ParamBindUserId = "?BindUserId";
        protected const string ParamCreateTime = "?CreateTime";
        protected const string ParamStatus = "?Status";
        protected const string ParamConfirmUser = "?ConfirmUser";
        protected const string ParamClientType = "?ClientType";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkLockMamangeDb</returns>
        public static List<ParkLockMamangeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parklockmamange">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkLockMamangeDb parklockmamange)
        {
            var param= GetInsertParams(parklockmamange);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">车位锁管理编号</param> 
        /// <returns>ParkLockMamangeDb</returns>
        public static ParkLockMamangeDb  GetByPriKey(int id)
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
        /// <param name="parklockmamange">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkLockMamangeDb parklockmamange)
        {
            var param= GetUpdateParams(parklockmamange);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">车位锁管理编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkLockMamangeDb parklockmamange)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parklockmamange.ID),
                    new MySqlParameter(ParamParkCode,parklockmamange.ParkCode),
                    new MySqlParameter(ParamParkLocation,parklockmamange.ParkLocation),
                    new MySqlParameter(ParamLockName,parklockmamange.LockName),
                    new MySqlParameter(ParamLockId,parklockmamange.LockId),
                    new MySqlParameter(ParamBindUserId,parklockmamange.BindUserId),
                    new MySqlParameter(ParamCreateTime,parklockmamange.CreateTime),
                    new MySqlParameter(ParamStatus,parklockmamange.Status),
                    new MySqlParameter(ParamConfirmUser,parklockmamange.ConfirmUser),
                    new MySqlParameter(ParamClientType,parklockmamange.ClientType)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkLockMamangeDb parklockmamange)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parklockmamange.ParkCode),
                    new MySqlParameter(ParamParkLocation,parklockmamange.ParkLocation),
                    new MySqlParameter(ParamLockName,parklockmamange.LockName),
                    new MySqlParameter(ParamLockId,parklockmamange.LockId),
                    new MySqlParameter(ParamBindUserId,parklockmamange.BindUserId),
                    new MySqlParameter(ParamCreateTime,parklockmamange.CreateTime),
                    new MySqlParameter(ParamStatus,parklockmamange.Status),
                    new MySqlParameter(ParamConfirmUser,parklockmamange.ConfirmUser),
                    new MySqlParameter(ParamClientType,parklockmamange.ClientType)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkLockMamangeDb</returns>
        public static ParkLockMamangeDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkLockMamangeDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    ParkLocation = DbChange.ToString(dr["ParkLocation"]),
                    LockName = DbChange.ToString(dr["LockName"]),
                    LockId = DbChange.ToInt(dr["LockId"],0),
                    BindUserId = DbChange.ToInt(dr["BindUserId"],0),
                    CreateTime = DbChange.ToDateTime(dr["CreateTime"],DateTime.MinValue),
                    Status = DbChange.ToInt(dr["Status"],0),
                    ConfirmUser = DbChange.ToInt(dr["ConfirmUser"],0),
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
        /// <returns>List of ParkLockMamangeDb</returns>
        public static List<ParkLockMamangeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkLockMamangeDb>(); 
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

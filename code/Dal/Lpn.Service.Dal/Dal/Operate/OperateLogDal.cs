using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Operate;

/*
* 由自动生成工具完成
* 描述:[operate_log]操作日志 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Operate
{
    /// <summary>
    /// [operate_log]操作日志 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OperateLogDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from operatelog;";
        //新增插入语句
        protected const string SqlInsert = "insert into operatelog(`LogType`,`LogTime`,`LogInfo`,`UserID`) values(?LogType,?LogTime,?LogInfo,?UserID);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from operatelog where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update operatelog set `LogType`=?LogType,`LogTime`=?LogTime,`LogInfo`=?LogInfo,`UserID`=?UserID where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from operatelog  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamLogType = "?LogType";
        protected const string ParamLogTime = "?LogTime";
        protected const string ParamLogInfo = "?LogInfo";
        protected const string ParamUserID = "?UserID";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OperateLogDb</returns>
        public static List<OperateLogDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="operatelog">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OperateLogDb operatelog)
        {
            var param= GetInsertParams(operatelog);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">日志编号</param> 
        /// <returns>OperateLogDb</returns>
        public static OperateLogDb  GetByPriKey(int id)
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
        /// <param name="operatelog">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OperateLogDb operatelog)
        {
            var param= GetUpdateParams(operatelog);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">日志编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(OperateLogDb operatelog)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,operatelog.ID),
                    new MySqlParameter(ParamLogType,operatelog.LogType),
                    new MySqlParameter(ParamLogTime,operatelog.LogTime),
                    new MySqlParameter(ParamLogInfo,operatelog.LogInfo),
                    new MySqlParameter(ParamUserID,operatelog.UserID)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OperateLogDb operatelog)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamLogType,operatelog.LogType),
                    new MySqlParameter(ParamLogTime,operatelog.LogTime),
                    new MySqlParameter(ParamLogInfo,operatelog.LogInfo),
                    new MySqlParameter(ParamUserID,operatelog.UserID)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OperateLogDb</returns>
        public static OperateLogDb  ConvertToObject(DataRow dr)
        {
            var data = new OperateLogDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    LogType = DbChange.ToString(dr["LogType"]),
                    LogTime = DbChange.ToDateTime(dr["LogTime"],DateTime.MinValue),
                    LogInfo = DbChange.ToString(dr["LogInfo"]),
                    UserID = DbChange.ToInt(dr["UserID"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OperateLogDb</returns>
        public static List<OperateLogDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OperateLogDb>(); 
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

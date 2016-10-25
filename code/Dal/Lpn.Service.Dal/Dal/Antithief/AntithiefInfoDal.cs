using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Antithief;

/*
* 由自动生成工具完成
* 描述:[Antithief_info]防盗信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Antithief
{
    /// <summary>
    /// [Antithief_info]防盗信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class AntithiefInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from antithiefinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into antithiefinfo(`UserName`,`BindCarNo`,`VerifyingCode`,`ParkCode`,`EntranceTime`,`AntiThiefStatus`,`OperationTime`) values(?UserName,?BindCarNo,?VerifyingCode,?ParkCode,?EntranceTime,?AntiThiefStatus,?OperationTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from antithiefinfo where `BindCarNo`=?BindCarNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update antithiefinfo set `UserName`=?UserName,`VerifyingCode`=?VerifyingCode,`ParkCode`=?ParkCode,`EntranceTime`=?EntranceTime,`AntiThiefStatus`=?AntiThiefStatus,`OperationTime`=?OperationTime where `BindCarNo`=?BindCarNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from antithiefinfo  where `BindCarNo`=?BindCarNo;";
        #endregion

        #region 参数
        protected const string ParamUserName = "?UserName";
        protected const string ParamBindCarNo = "?BindCarNo";
        protected const string ParamVerifyingCode = "?VerifyingCode";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamEntranceTime = "?EntranceTime";
        protected const string ParamAntiThiefStatus = "?AntiThiefStatus";
        protected const string ParamOperationTime = "?OperationTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of AntithiefInfoDb</returns>
        public static List<AntithiefInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="antithiefinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(AntithiefInfoDb antithiefinfo)
        {
            var param= GetInsertParams(antithiefinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="bindCarNo">绑定车牌号</param> 
        /// <returns>AntithiefInfoDb</returns>
        public static AntithiefInfoDb  GetByPriKey(string bindCarNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamBindCarNo,bindCarNo)
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
        /// <param name="antithiefinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(AntithiefInfoDb antithiefinfo)
        {
            var param= GetUpdateParams(antithiefinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="bindCarNo">绑定车牌号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string bindCarNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamBindCarNo,bindCarNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(AntithiefInfoDb antithiefinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserName,antithiefinfo.UserName),
                    new MySqlParameter(ParamBindCarNo,antithiefinfo.BindCarNo),
                    new MySqlParameter(ParamVerifyingCode,antithiefinfo.VerifyingCode),
                    new MySqlParameter(ParamParkCode,antithiefinfo.ParkCode),
                    new MySqlParameter(ParamEntranceTime,antithiefinfo.EntranceTime),
                    new MySqlParameter(ParamAntiThiefStatus,antithiefinfo.AntiThiefStatus),
                    new MySqlParameter(ParamOperationTime,antithiefinfo.OperationTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(AntithiefInfoDb antithiefinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserName,antithiefinfo.UserName),
                    new MySqlParameter(ParamBindCarNo,antithiefinfo.BindCarNo),
                    new MySqlParameter(ParamVerifyingCode,antithiefinfo.VerifyingCode),
                    new MySqlParameter(ParamParkCode,antithiefinfo.ParkCode),
                    new MySqlParameter(ParamEntranceTime,antithiefinfo.EntranceTime),
                    new MySqlParameter(ParamAntiThiefStatus,antithiefinfo.AntiThiefStatus),
                    new MySqlParameter(ParamOperationTime,antithiefinfo.OperationTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>AntithiefInfoDb</returns>
        public static AntithiefInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new AntithiefInfoDb
                {
                    UserName = DbChange.ToString(dr["UserName"]),
                    BindCarNo = DbChange.ToString(dr["BindCarNo"]),
                    VerifyingCode = DbChange.ToString(dr["VerifyingCode"]),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    EntranceTime = DbChange.ToDateTime(dr["EntranceTime"],DateTime.MinValue),
                    AntiThiefStatus = DbChange.ToInt(dr["AntiThiefStatus"],-1),
                    OperationTime = DbChange.ToDateTime(dr["OperationTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of AntithiefInfoDb</returns>
        public static List<AntithiefInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<AntithiefInfoDb>(); 
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

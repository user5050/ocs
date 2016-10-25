using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Antithief;

/*
* 由自动生成工具完成
* 描述:[Antithief_info_history]布撤防历史 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Antithief
{
    /// <summary>
    /// [Antithief_info_history]布撤防历史 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class AntithiefInfoHistoryDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from antithiefinfohistory;";
        //新增插入语句
        protected const string SqlInsert = "insert into antithiefinfohistory(`UserName`,`BindCarNo`,`VerifyingCode`,`ParkCode`,`EntranceTime`,`AntiThiefStatus`,`OperationTime`) values(?UserName,?BindCarNo,?VerifyingCode,?ParkCode,?EntranceTime,?AntiThiefStatus,?OperationTime);";
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
        /// <returns>List of AntithiefInfoHistoryDb</returns>
        public static List<AntithiefInfoHistoryDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="antithiefinfohistory">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(AntithiefInfoHistoryDb antithiefinfohistory)
        {
            var param= GetInsertParams(antithiefinfohistory);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(AntithiefInfoHistoryDb antithiefinfohistory)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserName,antithiefinfohistory.UserName),
                    new MySqlParameter(ParamBindCarNo,antithiefinfohistory.BindCarNo),
                    new MySqlParameter(ParamVerifyingCode,antithiefinfohistory.VerifyingCode),
                    new MySqlParameter(ParamParkCode,antithiefinfohistory.ParkCode),
                    new MySqlParameter(ParamEntranceTime,antithiefinfohistory.EntranceTime),
                    new MySqlParameter(ParamAntiThiefStatus,antithiefinfohistory.AntiThiefStatus),
                    new MySqlParameter(ParamOperationTime,antithiefinfohistory.OperationTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>AntithiefInfoHistoryDb</returns>
        public static AntithiefInfoHistoryDb  ConvertToObject(DataRow dr)
        {
            var data = new AntithiefInfoHistoryDb
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
        /// <returns>List of AntithiefInfoHistoryDb</returns>
        public static List<AntithiefInfoHistoryDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<AntithiefInfoHistoryDb>(); 
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

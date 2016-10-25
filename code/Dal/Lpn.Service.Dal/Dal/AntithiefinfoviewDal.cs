using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db;

/*
* 由自动生成工具完成
* 描述:VIEW Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal
{
    /// <summary>
    /// VIEW Dal帮助类
    /// </summary>
    [Serializable]
    public partial class AntithiefinfoviewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from antithiefinfoview;";
        //新增插入语句
        protected const string SqlInsert = "insert into antithiefinfoview(`UserName`,`BindCarNo`,`VerifyingCode`,`ParkCode`,`EntranceTime`,`AntiThiefStatus`,`OperationTime`,`parkname`) values(?UserName,?BindCarNo,?VerifyingCode,?ParkCode,?EntranceTime,?AntiThiefStatus,?OperationTime,?parkname);";
        #endregion

        #region 参数
        protected const string ParamUserName = "?UserName";
        protected const string ParamBindCarNo = "?BindCarNo";
        protected const string ParamVerifyingCode = "?VerifyingCode";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamEntranceTime = "?EntranceTime";
        protected const string ParamAntiThiefStatus = "?AntiThiefStatus";
        protected const string ParamOperationTime = "?OperationTime";
        protected const string Paramparkname = "?parkname";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of AntithiefinfoviewDb</returns>
        public static List<AntithiefinfoviewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="antithiefinfoview">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(AntithiefinfoviewDb antithiefinfoview)
        {
            var param= GetInsertParams(antithiefinfoview);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(AntithiefinfoviewDb antithiefinfoview)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserName,antithiefinfoview.UserName),
                    new MySqlParameter(ParamBindCarNo,antithiefinfoview.BindCarNo),
                    new MySqlParameter(ParamVerifyingCode,antithiefinfoview.VerifyingCode),
                    new MySqlParameter(ParamParkCode,antithiefinfoview.ParkCode),
                    new MySqlParameter(ParamEntranceTime,antithiefinfoview.EntranceTime),
                    new MySqlParameter(ParamAntiThiefStatus,antithiefinfoview.AntiThiefStatus),
                    new MySqlParameter(ParamOperationTime,antithiefinfoview.OperationTime),
                    new MySqlParameter(Paramparkname,antithiefinfoview.Parkname)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>AntithiefinfoviewDb</returns>
        public static AntithiefinfoviewDb  ConvertToObject(DataRow dr)
        {
            var data = new AntithiefinfoviewDb
                {
                    UserName = DbChange.ToString(dr["UserName"]),
                    BindCarNo = DbChange.ToString(dr["BindCarNo"]),
                    VerifyingCode = DbChange.ToString(dr["VerifyingCode"]),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    EntranceTime = DbChange.ToDateTime(dr["EntranceTime"],DateTime.MinValue),
                    AntiThiefStatus = DbChange.ToInt(dr["AntiThiefStatus"],-1),
                    OperationTime = DbChange.ToDateTime(dr["OperationTime"],DateTime.MinValue),
                    Parkname = DbChange.ToString(dr["parkname"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of AntithiefinfoviewDb</returns>
        public static List<AntithiefinfoviewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<AntithiefinfoviewDb>(); 
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

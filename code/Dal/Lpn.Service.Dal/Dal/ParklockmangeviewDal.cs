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
    public partial class ParklockmangeviewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parklockmangeview;";
        //新增插入语句
        protected const string SqlInsert = "insert into parklockmangeview(`parkLocation`,`lockName`,`createTime`,`status`,`confirmUser`,`lockCode`,`lockRandomCode`,`username`,`id`,`parkname`,`parkCode`) values(?parkLocation,?lockName,?createTime,?status,?confirmUser,?lockCode,?lockRandomCode,?username,?id,?parkname,?parkCode);";
        #endregion

        #region 参数
        protected const string ParamparkLocation = "?parkLocation";
        protected const string ParamlockName = "?lockName";
        protected const string ParamcreateTime = "?createTime";
        protected const string Paramstatus = "?status";
        protected const string ParamconfirmUser = "?confirmUser";
        protected const string ParamlockCode = "?lockCode";
        protected const string ParamlockRandomCode = "?lockRandomCode";
        protected const string Paramusername = "?username";
        protected const string Paramid = "?id";
        protected const string Paramparkname = "?parkname";
        protected const string ParamparkCode = "?parkCode";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParklockmangeviewDb</returns>
        public static List<ParklockmangeviewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parklockmangeview">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParklockmangeviewDb parklockmangeview)
        {
            var param= GetInsertParams(parklockmangeview);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParklockmangeviewDb parklockmangeview)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamparkLocation,parklockmangeview.ParkLocation),
                    new MySqlParameter(ParamlockName,parklockmangeview.LockName),
                    new MySqlParameter(ParamcreateTime,parklockmangeview.CreateTime),
                    new MySqlParameter(Paramstatus,parklockmangeview.Status),
                    new MySqlParameter(ParamconfirmUser,parklockmangeview.ConfirmUser),
                    new MySqlParameter(ParamlockCode,parklockmangeview.LockCode),
                    new MySqlParameter(ParamlockRandomCode,parklockmangeview.LockRandomCode),
                    new MySqlParameter(Paramusername,parklockmangeview.Username),
                    new MySqlParameter(Paramid,parklockmangeview.Id),
                    new MySqlParameter(Paramparkname,parklockmangeview.Parkname),
                    new MySqlParameter(ParamparkCode,parklockmangeview.ParkCode)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParklockmangeviewDb</returns>
        public static ParklockmangeviewDb  ConvertToObject(DataRow dr)
        {
            var data = new ParklockmangeviewDb
                {
                    ParkLocation = DbChange.ToString(dr["parkLocation"]),
                    LockName = DbChange.ToString(dr["lockName"]),
                    CreateTime = DbChange.ToDateTime(dr["createTime"],DateTime.MinValue),
                    Status = DbChange.ToInt(dr["status"],0),
                    ConfirmUser = DbChange.ToInt(dr["confirmUser"],0),
                    LockCode = DbChange.ToString(dr["lockCode"]),
                    LockRandomCode = DbChange.ToString(dr["lockRandomCode"]),
                    Username = DbChange.ToString(dr["username"]),
                    Id = DbChange.ToInt(dr["id"],0),
                    Parkname = DbChange.ToString(dr["parkname"]),
                    ParkCode = DbChange.ToString(dr["parkCode"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParklockmangeviewDb</returns>
        public static List<ParklockmangeviewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParklockmangeviewDb>(); 
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

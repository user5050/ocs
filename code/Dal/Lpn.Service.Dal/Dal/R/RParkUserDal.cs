using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.R;

/*
* 由自动生成工具完成
* 描述:停车场管理员 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.R
{
    /// <summary>
    /// 停车场管理员 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class RParkUserDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from r_park_user;";
        //新增插入语句
        protected const string SqlInsert = "insert into r_park_user(`ParkID`,`UserID`) values(?ParkID,?UserID);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from r_park_user where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update r_park_user set `ParkID`=?ParkID,`UserID`=?UserID where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from r_park_user  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkID = "?ParkID";
        protected const string ParamUserID = "?UserID";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of RParkUserDb</returns>
        public static List<RParkUserDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="rparkuser">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(RParkUserDb rparkuser)
        {
            var param= GetInsertParams(rparkuser);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">停车场管理员编号</param> 
        /// <returns>RParkUserDb</returns>
        public static RParkUserDb  GetByPriKey(int id)
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
        /// <param name="rparkuser">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(RParkUserDb rparkuser)
        {
            var param= GetUpdateParams(rparkuser);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">停车场管理员编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(RParkUserDb rparkuser)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,rparkuser.ID),
                    new MySqlParameter(ParamParkID,rparkuser.ParkID),
                    new MySqlParameter(ParamUserID,rparkuser.UserID)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(RParkUserDb rparkuser)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,rparkuser.ParkID),
                    new MySqlParameter(ParamUserID,rparkuser.UserID)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>RParkUserDb</returns>
        public static RParkUserDb  ConvertToObject(DataRow dr)
        {
            var data = new RParkUserDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkID = DbChange.ToString(dr["ParkID"]),
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
        /// <returns>List of RParkUserDb</returns>
        public static List<RParkUserDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<RParkUserDb>(); 
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

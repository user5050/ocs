using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.User;

/*
* 由自动生成工具完成
* 描述:[user_authorize]用户模版权限 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.User
{
    /// <summary>
    /// [user_authorize]用户模版权限 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class UserAuthorizeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from userauthorize;";
        //新增插入语句
        protected const string SqlInsert = "insert into userauthorize(`UserID`,`UserAuthor`,`UserPost`) values(?UserID,?UserAuthor,?UserPost);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from userauthorize where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update userauthorize set `UserID`=?UserID,`UserAuthor`=?UserAuthor,`UserPost`=?UserPost where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from userauthorize  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamUserID = "?UserID";
        protected const string ParamUserAuthor = "?UserAuthor";
        protected const string ParamUserPost = "?UserPost";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of UserAuthorizeDb</returns>
        public static List<UserAuthorizeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="userauthorize">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(UserAuthorizeDb userauthorize)
        {
            var param= GetInsertParams(userauthorize);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">自增ID</param> 
        /// <returns>UserAuthorizeDb</returns>
        public static UserAuthorizeDb  GetByPriKey(int id)
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
        /// <param name="userauthorize">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(UserAuthorizeDb userauthorize)
        {
            var param= GetUpdateParams(userauthorize);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">自增ID</param> 
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
        public static MySqlParameter[]  GetUpdateParams(UserAuthorizeDb userauthorize)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,userauthorize.ID),
                    new MySqlParameter(ParamUserID,userauthorize.UserID),
                    new MySqlParameter(ParamUserAuthor,userauthorize.UserAuthor),
                    new MySqlParameter(ParamUserPost,userauthorize.UserPost)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(UserAuthorizeDb userauthorize)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserID,userauthorize.UserID),
                    new MySqlParameter(ParamUserAuthor,userauthorize.UserAuthor),
                    new MySqlParameter(ParamUserPost,userauthorize.UserPost)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>UserAuthorizeDb</returns>
        public static UserAuthorizeDb  ConvertToObject(DataRow dr)
        {
            var data = new UserAuthorizeDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    UserAuthor = DbChange.ToString(dr["UserAuthor"]),
                    UserPost = DbChange.ToString(dr["UserPost"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of UserAuthorizeDb</returns>
        public static List<UserAuthorizeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<UserAuthorizeDb>(); 
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

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.User;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.User
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class UserDiamondDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from user_diamond;";
        //新增插入语句
        protected const string SqlInsert = "insert into user_diamond(`Uid`,`Amount`,`RowTime`,`LastUpdateTime`) values(?Uid,?Amount,?RowTime,?LastUpdateTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from user_diamond where `Uid`=?Uid;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update user_diamond set `Amount`=?Amount,`RowTime`=?RowTime,`LastUpdateTime`=?LastUpdateTime where `Uid`=?Uid;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from user_diamond  where `Uid`=?Uid;";
        #endregion

        #region 参数
        protected const string ParamUid = "?Uid";
        protected const string ParamAmount = "?Amount";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamLastUpdateTime = "?LastUpdateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of UserDiamondDb</returns>
        public static List<UserDiamondDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="userdiamond">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(UserDiamondDb userdiamond)
        {
            var param= GetInsertParams(userdiamond);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="uid">用户id</param> 
        /// <returns>UserDiamondDb</returns>
        public static UserDiamondDb  GetByPriKey(string uid)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,uid)
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
        /// <param name="userdiamond">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(UserDiamondDb userdiamond)
        {
            var param= GetUpdateParams(userdiamond);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="uid">用户id</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string uid)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,uid)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(UserDiamondDb userdiamond)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,userdiamond.Uid),
                    new MySqlParameter(ParamAmount,userdiamond.Amount),
                    new MySqlParameter(ParamRowTime,userdiamond.RowTime),
                    new MySqlParameter(ParamLastUpdateTime,userdiamond.LastUpdateTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(UserDiamondDb userdiamond)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,userdiamond.Uid),
                    new MySqlParameter(ParamAmount,userdiamond.Amount),
                    new MySqlParameter(ParamRowTime,userdiamond.RowTime),
                    new MySqlParameter(ParamLastUpdateTime,userdiamond.LastUpdateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>UserDiamondDb</returns>
        public static UserDiamondDb  ConvertToObject(DataRow dr)
        {
            var data = new UserDiamondDb
                {
                    Uid = DbChange.ToString(dr["Uid"]),
                    Amount = DbChange.ToInt(dr["Amount"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    LastUpdateTime = DbChange.ToDateTime(dr["LastUpdateTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of UserDiamondDb</returns>
        public static List<UserDiamondDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<UserDiamondDb>(); 
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

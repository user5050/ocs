using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Recommend;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Recommend
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class RecommendTokenDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from recommend_token;";
        //新增插入语句
        protected const string SqlInsert = "insert into recommend_token(`TokenId`,`UserId`,`Nick`) values(?TokenId,?UserId,?Nick);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from recommend_token where `TokenId`=?TokenId;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update recommend_token set `UserId`=?UserId,`Nick`=?Nick where `TokenId`=?TokenId;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from recommend_token  where `TokenId`=?TokenId;";
        #endregion

        #region 参数
        protected const string ParamTokenId = "?TokenId";
        protected const string ParamUserId = "?UserId";
        protected const string ParamNick = "?Nick";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of RecommendTokenDb</returns>
        public static List<RecommendTokenDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="recommendtoken">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(RecommendTokenDb recommendtoken)
        {
            var param= GetInsertParams(recommendtoken);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="tokenId">推荐Token</param> 
        /// <returns>RecommendTokenDb</returns>
        public static RecommendTokenDb  GetByPriKey(string tokenId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTokenId,tokenId)
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
        /// <param name="recommendtoken">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(RecommendTokenDb recommendtoken)
        {
            var param= GetUpdateParams(recommendtoken);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="tokenId">推荐Token</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string tokenId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTokenId,tokenId)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(RecommendTokenDb recommendtoken)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTokenId,recommendtoken.TokenId),
                    new MySqlParameter(ParamUserId,recommendtoken.UserId),
                    new MySqlParameter(ParamNick,recommendtoken.Nick)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(RecommendTokenDb recommendtoken)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTokenId,recommendtoken.TokenId),
                    new MySqlParameter(ParamUserId,recommendtoken.UserId),
                    new MySqlParameter(ParamNick,recommendtoken.Nick)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>RecommendTokenDb</returns>
        public static RecommendTokenDb  ConvertToObject(DataRow dr)
        {
            var data = new RecommendTokenDb
                {
                    TokenId = DbChange.ToString(dr["TokenId"]),
                    UserId = DbChange.ToInt(dr["UserId"],0),
                    Nick = DbChange.ToString(dr["Nick"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of RecommendTokenDb</returns>
        public static List<RecommendTokenDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<RecommendTokenDb>(); 
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

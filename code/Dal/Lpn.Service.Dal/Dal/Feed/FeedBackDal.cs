using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Feed;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Feed
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class FeedBackDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from feed_back;";
        //新增插入语句
        protected const string SqlInsert = "insert into feed_back(`Uid`,`content`,`RowTime`) values(?Uid,?content,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from feed_back where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update feed_back set `Uid`=?Uid,`content`=?content,`RowTime`=?RowTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from feed_back  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamUid = "?Uid";
        protected const string Paramcontent = "?content";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of FeedBackDb</returns>
        public static List<FeedBackDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="feedback">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(FeedBackDb feedback)
        {
            var param= GetInsertParams(feedback);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>FeedBackDb</returns>
        public static FeedBackDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id)
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
        /// <param name="feedback">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(FeedBackDb feedback)
        {
            var param= GetUpdateParams(feedback);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(FeedBackDb feedback)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,feedback.Id),
                    new MySqlParameter(ParamUid,feedback.Uid),
                    new MySqlParameter(Paramcontent,feedback.Content),
                    new MySqlParameter(ParamRowTime,feedback.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(FeedBackDb feedback)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,feedback.Uid),
                    new MySqlParameter(Paramcontent,feedback.Content),
                    new MySqlParameter(ParamRowTime,feedback.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>FeedBackDb</returns>
        public static FeedBackDb  ConvertToObject(DataRow dr)
        {
            var data = new FeedBackDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    Uid = DbChange.ToString(dr["Uid"]),
                    Content = DbChange.ToString(dr["content"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of FeedBackDb</returns>
        public static List<FeedBackDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<FeedBackDb>(); 
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

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
    public partial class RecommendRelationshipDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from recommend_relationship;";
        //新增插入语句
        protected const string SqlInsert = "insert into recommend_relationship(`UserId`,`ReceiveMobile`,`IsReceive`,`RowTime`,`ReceiveTime`) values(?UserId,?ReceiveMobile,?IsReceive,?RowTime,?ReceiveTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from recommend_relationship where `ReceiveMobile`=?ReceiveMobile;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update recommend_relationship set `UserId`=?UserId,`IsReceive`=?IsReceive,`RowTime`=?RowTime,`ReceiveTime`=?ReceiveTime where `ReceiveMobile`=?ReceiveMobile;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from recommend_relationship  where `ReceiveMobile`=?ReceiveMobile;";
        #endregion

        #region 参数
        protected const string ParamUserId = "?UserId";
        protected const string ParamReceiveMobile = "?ReceiveMobile";
        protected const string ParamIsReceive = "?IsReceive";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamReceiveTime = "?ReceiveTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of RecommendRelationshipDb</returns>
        public static List<RecommendRelationshipDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="recommendrelationship">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(RecommendRelationshipDb recommendrelationship)
        {
            var param= GetInsertParams(recommendrelationship);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="receiveMobile">领用者手机号</param> 
        /// <returns>RecommendRelationshipDb</returns>
        public static RecommendRelationshipDb  GetByPriKey(string receiveMobile)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamReceiveMobile,receiveMobile)
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
        /// <param name="recommendrelationship">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(RecommendRelationshipDb recommendrelationship)
        {
            var param= GetUpdateParams(recommendrelationship);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="receiveMobile">领用者手机号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string receiveMobile)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamReceiveMobile,receiveMobile)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(RecommendRelationshipDb recommendrelationship)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserId,recommendrelationship.UserId),
                    new MySqlParameter(ParamReceiveMobile,recommendrelationship.ReceiveMobile),
                    new MySqlParameter(ParamIsReceive,recommendrelationship.IsReceive),
                    new MySqlParameter(ParamRowTime,recommendrelationship.RowTime),
                    new MySqlParameter(ParamReceiveTime,recommendrelationship.ReceiveTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(RecommendRelationshipDb recommendrelationship)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserId,recommendrelationship.UserId),
                    new MySqlParameter(ParamReceiveMobile,recommendrelationship.ReceiveMobile),
                    new MySqlParameter(ParamIsReceive,recommendrelationship.IsReceive),
                    new MySqlParameter(ParamRowTime,recommendrelationship.RowTime),
                    new MySqlParameter(ParamReceiveTime,recommendrelationship.ReceiveTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>RecommendRelationshipDb</returns>
        public static RecommendRelationshipDb  ConvertToObject(DataRow dr)
        {
            var data = new RecommendRelationshipDb
                {
                    UserId = DbChange.ToInt(dr["UserId"],0),
                    ReceiveMobile = DbChange.ToString(dr["ReceiveMobile"]),
                    IsReceive = DbChange.ToInt(dr["IsReceive"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    ReceiveTime = DbChange.ToDateTime(dr["ReceiveTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of RecommendRelationshipDb</returns>
        public static List<RecommendRelationshipDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<RecommendRelationshipDb>(); 
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

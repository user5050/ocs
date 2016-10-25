using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Feedback;

/*
* 由自动生成工具完成
* 描述:[feedback_info]回馈信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Feedback
{
    /// <summary>
    /// [feedback_info]回馈信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class FeedbackInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from feedback_info;";
        //新增插入语句
        protected const string SqlInsert = "insert into feedback_info(`UserName`,`Contact`,`FeedBack`) values(?UserName,?Contact,?FeedBack);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from feedback_info where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update feedback_info set `UserName`=?UserName,`Contact`=?Contact,`FeedBack`=?FeedBack where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from feedback_info  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamUserName = "?UserName";
        protected const string ParamContact = "?Contact";
        protected const string ParamFeedBack = "?FeedBack";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of FeedbackInfoDb</returns>
        public static List<FeedbackInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="feedbackinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(FeedbackInfoDb feedbackinfo)
        {
            var param= GetInsertParams(feedbackinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">回馈信息编号</param> 
        /// <returns>FeedbackInfoDb</returns>
        public static FeedbackInfoDb  GetByPriKey(int id)
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
        /// <param name="feedbackinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(FeedbackInfoDb feedbackinfo)
        {
            var param= GetUpdateParams(feedbackinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">回馈信息编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(FeedbackInfoDb feedbackinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,feedbackinfo.ID),
                    new MySqlParameter(ParamUserName,feedbackinfo.UserName),
                    new MySqlParameter(ParamContact,feedbackinfo.Contact),
                    new MySqlParameter(ParamFeedBack,feedbackinfo.FeedBack)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(FeedbackInfoDb feedbackinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserName,feedbackinfo.UserName),
                    new MySqlParameter(ParamContact,feedbackinfo.Contact),
                    new MySqlParameter(ParamFeedBack,feedbackinfo.FeedBack)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>FeedbackInfoDb</returns>
        public static FeedbackInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new FeedbackInfoDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    UserName = DbChange.ToString(dr["UserName"]),
                    Contact = DbChange.ToString(dr["Contact"]),
                    FeedBack = DbChange.ToString(dr["FeedBack"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of FeedbackInfoDb</returns>
        public static List<FeedbackInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<FeedbackInfoDb>(); 
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

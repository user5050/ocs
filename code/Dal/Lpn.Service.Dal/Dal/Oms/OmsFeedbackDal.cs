using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Oms;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Oms
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OmsFeedbackDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from oms_feedback;";
        //新增插入语句
        protected const string SqlInsert = "insert into oms_feedback(`type`,`source`,`mobile`,`feedback_time`,`version_name`,`device_type`,`network_type`,`content`,`status`,`last_modify_time`) values(?type,?source,?mobile,?feedback_time,?version_name,?device_type,?network_type,?content,?status,?last_modify_time);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from oms_feedback where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update oms_feedback set `type`=?type,`source`=?source,`mobile`=?mobile,`feedback_time`=?feedback_time,`version_name`=?version_name,`device_type`=?device_type,`network_type`=?network_type,`content`=?content,`status`=?status,`last_modify_time`=?last_modify_time where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from oms_feedback  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramtype = "?type";
        protected const string Paramid = "?id";
        protected const string Paramsource = "?source";
        protected const string Parammobile = "?mobile";
        protected const string Paramfeedback_time = "?feedback_time";
        protected const string Paramversion_name = "?version_name";
        protected const string Paramdevice_type = "?device_type";
        protected const string Paramnetwork_type = "?network_type";
        protected const string Paramcontent = "?content";
        protected const string Paramstatus = "?status";
        protected const string Paramlast_modify_time = "?last_modify_time";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OmsFeedbackDb</returns>
        public static List<OmsFeedbackDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="omsfeedback">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OmsFeedbackDb omsfeedback)
        {
            var param= GetInsertParams(omsfeedback);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>OmsFeedbackDb</returns>
        public static OmsFeedbackDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,id)
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
        /// <param name="omsfeedback">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OmsFeedbackDb omsfeedback)
        {
            var param= GetUpdateParams(omsfeedback);
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
                    new MySqlParameter(Paramid,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(OmsFeedbackDb omsfeedback)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramtype,omsfeedback.Type),
                    new MySqlParameter(Paramid,omsfeedback.Id),
                    new MySqlParameter(Paramsource,omsfeedback.Source),
                    new MySqlParameter(Parammobile,omsfeedback.Mobile),
                    new MySqlParameter(Paramfeedback_time,omsfeedback.Feedback_time),
                    new MySqlParameter(Paramversion_name,omsfeedback.Version_name),
                    new MySqlParameter(Paramdevice_type,omsfeedback.Device_type),
                    new MySqlParameter(Paramnetwork_type,omsfeedback.Network_type),
                    new MySqlParameter(Paramcontent,omsfeedback.Content),
                    new MySqlParameter(Paramstatus,omsfeedback.Status),
                    new MySqlParameter(Paramlast_modify_time,omsfeedback.Last_modify_time)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OmsFeedbackDb omsfeedback)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramtype,omsfeedback.Type),
                    new MySqlParameter(Paramsource,omsfeedback.Source),
                    new MySqlParameter(Parammobile,omsfeedback.Mobile),
                    new MySqlParameter(Paramfeedback_time,omsfeedback.Feedback_time),
                    new MySqlParameter(Paramversion_name,omsfeedback.Version_name),
                    new MySqlParameter(Paramdevice_type,omsfeedback.Device_type),
                    new MySqlParameter(Paramnetwork_type,omsfeedback.Network_type),
                    new MySqlParameter(Paramcontent,omsfeedback.Content),
                    new MySqlParameter(Paramstatus,omsfeedback.Status),
                    new MySqlParameter(Paramlast_modify_time,omsfeedback.Last_modify_time)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OmsFeedbackDb</returns>
        public static OmsFeedbackDb  ConvertToObject(DataRow dr)
        {
            var data = new OmsFeedbackDb
                {
                    Type = DbChange.ToInt(dr["type"],0),
                    Id = DbChange.ToInt(dr["id"],0),
                    Source = DbChange.ToInt(dr["source"],0),
                    Mobile = DbChange.ToString(dr["mobile"]),
                    Feedback_time = DbChange.ToDateTime(dr["feedback_time"],DateTime.MinValue),
                    Version_name = DbChange.ToString(dr["version_name"]),
                    Device_type = DbChange.ToString(dr["device_type"]),
                    Network_type = DbChange.ToString(dr["network_type"]),
                    Content = DbChange.ToString(dr["content"]),
                    Status = DbChange.ToInt(dr["status"],0),
                    Last_modify_time = DbChange.ToDateTime(dr["last_modify_time"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OmsFeedbackDb</returns>
        public static List<OmsFeedbackDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OmsFeedbackDb>(); 
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

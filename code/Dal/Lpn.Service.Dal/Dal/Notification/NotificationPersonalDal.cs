using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Notification;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Notification
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class NotificationPersonalDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from notification_personal;";
        //新增插入语句
        protected const string SqlInsert = "insert into notification_personal(`Userid`,`Type`,`Title`,`Content`,`Url`,`Viewed`,`Time`) values(?Userid,?Type,?Title,?Content,?Url,?Viewed,?Time);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from notification_personal where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update notification_personal set `Userid`=?Userid,`Type`=?Type,`Title`=?Title,`Content`=?Content,`Url`=?Url,`Viewed`=?Viewed,`Time`=?Time where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from notification_personal  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamUserid = "?Userid";
        protected const string ParamType = "?Type";
        protected const string ParamTitle = "?Title";
        protected const string ParamContent = "?Content";
        protected const string ParamUrl = "?Url";
        protected const string ParamViewed = "?Viewed";
        protected const string ParamTime = "?Time";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of NotificationPersonalDb</returns>
        public static List<NotificationPersonalDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="notificationpersonal">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(NotificationPersonalDb notificationpersonal)
        {
            var param= GetInsertParams(notificationpersonal);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">编号</param> 
        /// <returns>NotificationPersonalDb</returns>
        public static NotificationPersonalDb  GetByPriKey(int id)
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
        /// <param name="notificationpersonal">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(NotificationPersonalDb notificationpersonal)
        {
            var param= GetUpdateParams(notificationpersonal);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(NotificationPersonalDb notificationpersonal)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,notificationpersonal.Id),
                    new MySqlParameter(ParamUserid,notificationpersonal.Userid),
                    new MySqlParameter(ParamType,notificationpersonal.Type),
                    new MySqlParameter(ParamTitle,notificationpersonal.Title),
                    new MySqlParameter(ParamContent,notificationpersonal.Content),
                    new MySqlParameter(ParamUrl,notificationpersonal.Url),
                    new MySqlParameter(ParamViewed,notificationpersonal.Viewed),
                    new MySqlParameter(ParamTime,notificationpersonal.Time)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(NotificationPersonalDb notificationpersonal)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserid,notificationpersonal.Userid),
                    new MySqlParameter(ParamType,notificationpersonal.Type),
                    new MySqlParameter(ParamTitle,notificationpersonal.Title),
                    new MySqlParameter(ParamContent,notificationpersonal.Content),
                    new MySqlParameter(ParamUrl,notificationpersonal.Url),
                    new MySqlParameter(ParamViewed,notificationpersonal.Viewed),
                    new MySqlParameter(ParamTime,notificationpersonal.Time)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>NotificationPersonalDb</returns>
        public static NotificationPersonalDb  ConvertToObject(DataRow dr)
        {
            var data = new NotificationPersonalDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    Userid = DbChange.ToInt(dr["Userid"],0),
                    Type = DbChange.ToInt(dr["Type"],0),
                    Title = DbChange.ToString(dr["Title"]),
                    Content = DbChange.ToString(dr["Content"]),
                    Url = DbChange.ToString(dr["Url"]),
                    Viewed = DbChange.ToInt(dr["Viewed"],0),
                    Time = DbChange.ToDateTime(dr["Time"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of NotificationPersonalDb</returns>
        public static List<NotificationPersonalDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<NotificationPersonalDb>(); 
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

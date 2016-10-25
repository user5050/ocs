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
    public partial class NotificationSystemDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from notification_system;";
        //新增插入语句
        protected const string SqlInsert = "insert into notification_system(`Sn`,`Title`,`Content`,`Url`,`Time`) values(?Sn,?Title,?Content,?Url,?Time);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from notification_system where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update notification_system set `Sn`=?Sn,`Title`=?Title,`Content`=?Content,`Url`=?Url,`Time`=?Time where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from notification_system  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamSn = "?Sn";
        protected const string ParamTitle = "?Title";
        protected const string ParamContent = "?Content";
        protected const string ParamUrl = "?Url";
        protected const string ParamTime = "?Time";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of NotificationSystemDb</returns>
        public static List<NotificationSystemDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="notificationsystem">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(NotificationSystemDb notificationsystem)
        {
            var param= GetInsertParams(notificationsystem);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">编号</param> 
        /// <returns>NotificationSystemDb</returns>
        public static NotificationSystemDb  GetByPriKey(int id)
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
        /// <param name="notificationsystem">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(NotificationSystemDb notificationsystem)
        {
            var param= GetUpdateParams(notificationsystem);
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
        public static MySqlParameter[]  GetUpdateParams(NotificationSystemDb notificationsystem)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,notificationsystem.Id),
                    new MySqlParameter(ParamSn,notificationsystem.Sn),
                    new MySqlParameter(ParamTitle,notificationsystem.Title),
                    new MySqlParameter(ParamContent,notificationsystem.Content),
                    new MySqlParameter(ParamUrl,notificationsystem.Url),
                    new MySqlParameter(ParamTime,notificationsystem.Time)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(NotificationSystemDb notificationsystem)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSn,notificationsystem.Sn),
                    new MySqlParameter(ParamTitle,notificationsystem.Title),
                    new MySqlParameter(ParamContent,notificationsystem.Content),
                    new MySqlParameter(ParamUrl,notificationsystem.Url),
                    new MySqlParameter(ParamTime,notificationsystem.Time)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>NotificationSystemDb</returns>
        public static NotificationSystemDb  ConvertToObject(DataRow dr)
        {
            var data = new NotificationSystemDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    Sn = DbChange.ToLong(dr["Sn"],0),
                    Title = DbChange.ToString(dr["Title"]),
                    Content = DbChange.ToString(dr["Content"]),
                    Url = DbChange.ToString(dr["Url"]),
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
        /// <returns>List of NotificationSystemDb</returns>
        public static List<NotificationSystemDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<NotificationSystemDb>(); 
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

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Msg;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Msg
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class MsgUserLogDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from msg_user_log;";
        //新增插入语句
        protected const string SqlInsert = "insert into msg_user_log(`UserId`,`MsgId`,`MsgType`,`SendTime`,`SendCnt`,`LastSendDate`) values(?UserId,?MsgId,?MsgType,?SendTime,?SendCnt,?LastSendDate);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from msg_user_log where `UserId`=?UserId and `MsgId`=?MsgId and `MsgType`=?MsgType;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update msg_user_log set `SendTime`=?SendTime,`SendCnt`=?SendCnt,`LastSendDate`=?LastSendDate where `UserId`=?UserId and `MsgId`=?MsgId and `MsgType`=?MsgType;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from msg_user_log  where `UserId`=?UserId and `MsgId`=?MsgId and `MsgType`=?MsgType;";
        #endregion

        #region 参数
        protected const string ParamUserId = "?UserId";
        protected const string ParamMsgId = "?MsgId";
        protected const string ParamMsgType = "?MsgType";
        protected const string ParamSendTime = "?SendTime";
        protected const string ParamSendCnt = "?SendCnt";
        protected const string ParamLastSendDate = "?LastSendDate";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MsgUserLogDb</returns>
        public static List<MsgUserLogDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="msguserlog">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MsgUserLogDb msguserlog)
        {
            var param= GetInsertParams(msguserlog);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="userId">用户id</param> 
        /// <param name="msgId">消息模板id</param> 
        /// <param name="msgType">消息模板类型</param> 
        /// <returns>MsgUserLogDb</returns>
        public static MsgUserLogDb  GetByPriKey(int userId,int msgId,int msgType)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserId,userId),
                    new MySqlParameter(ParamMsgId,msgId),
                    new MySqlParameter(ParamMsgType,msgType)
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
        /// <param name="msguserlog">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MsgUserLogDb msguserlog)
        {
            var param= GetUpdateParams(msguserlog);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="userId">用户id</param> 
        /// <param name="msgId">消息模板id</param> 
        /// <param name="msgType">消息模板类型</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int userId,int msgId,int msgType)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserId,userId),
                    new MySqlParameter(ParamMsgId,msgId),
                    new MySqlParameter(ParamMsgType,msgType)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(MsgUserLogDb msguserlog)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserId,msguserlog.UserId),
                    new MySqlParameter(ParamMsgId,msguserlog.MsgId),
                    new MySqlParameter(ParamMsgType,msguserlog.MsgType),
                    new MySqlParameter(ParamSendTime,msguserlog.SendTime),
                    new MySqlParameter(ParamSendCnt,msguserlog.SendCnt),
                    new MySqlParameter(ParamLastSendDate,msguserlog.LastSendDate)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MsgUserLogDb msguserlog)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserId,msguserlog.UserId),
                    new MySqlParameter(ParamMsgId,msguserlog.MsgId),
                    new MySqlParameter(ParamMsgType,msguserlog.MsgType),
                    new MySqlParameter(ParamSendTime,msguserlog.SendTime),
                    new MySqlParameter(ParamSendCnt,msguserlog.SendCnt),
                    new MySqlParameter(ParamLastSendDate,msguserlog.LastSendDate)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MsgUserLogDb</returns>
        public static MsgUserLogDb  ConvertToObject(DataRow dr)
        {
            var data = new MsgUserLogDb
                {
                    UserId = DbChange.ToInt(dr["UserId"],0),
                    MsgId = DbChange.ToInt(dr["MsgId"],0),
                    MsgType = DbChange.ToInt(dr["MsgType"],0),
                    SendTime = DbChange.ToDateTime(dr["SendTime"],DateTime.MinValue),
                    SendCnt = DbChange.ToInt(dr["SendCnt"],0),
                    LastSendDate = DbChange.ToDateTime(dr["LastSendDate"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of MsgUserLogDb</returns>
        public static List<MsgUserLogDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MsgUserLogDb>(); 
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

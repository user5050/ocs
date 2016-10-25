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
    public partial class MsgStatSendDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from msg_stat_send;";
        //新增插入语句
        protected const string SqlInsert = "insert into msg_stat_send(`MsgId`,`MsgType`,`Cnt`,`RowTime`,`LastTime`) values(?MsgId,?MsgType,?Cnt,?RowTime,?LastTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from msg_stat_send where `MsgId`=?MsgId and `MsgType`=?MsgType;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update msg_stat_send set `Cnt`=?Cnt,`RowTime`=?RowTime,`LastTime`=?LastTime where `MsgId`=?MsgId and `MsgType`=?MsgType;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from msg_stat_send  where `MsgId`=?MsgId and `MsgType`=?MsgType;";
        #endregion

        #region 参数
        protected const string ParamMsgId = "?MsgId";
        protected const string ParamMsgType = "?MsgType";
        protected const string ParamCnt = "?Cnt";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamLastTime = "?LastTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MsgStatSendDb</returns>
        public static List<MsgStatSendDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="msgstatsend">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MsgStatSendDb msgstatsend)
        {
            var param= GetInsertParams(msgstatsend);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="msgId">消息Id</param> 
        /// <param name="msgType">消息类型</param> 
        /// <returns>MsgStatSendDb</returns>
        public static MsgStatSendDb  GetByPriKey(int msgId,int msgType)
        {
            var param = new[]
                { 
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
        /// <param name="msgstatsend">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MsgStatSendDb msgstatsend)
        {
            var param= GetUpdateParams(msgstatsend);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="msgId">消息Id</param> 
        /// <param name="msgType">消息类型</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int msgId,int msgType)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamMsgId,msgId),
                    new MySqlParameter(ParamMsgType,msgType)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(MsgStatSendDb msgstatsend)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamMsgId,msgstatsend.MsgId),
                    new MySqlParameter(ParamMsgType,msgstatsend.MsgType),
                    new MySqlParameter(ParamCnt,msgstatsend.Cnt),
                    new MySqlParameter(ParamRowTime,msgstatsend.RowTime),
                    new MySqlParameter(ParamLastTime,msgstatsend.LastTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MsgStatSendDb msgstatsend)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamMsgId,msgstatsend.MsgId),
                    new MySqlParameter(ParamMsgType,msgstatsend.MsgType),
                    new MySqlParameter(ParamCnt,msgstatsend.Cnt),
                    new MySqlParameter(ParamRowTime,msgstatsend.RowTime),
                    new MySqlParameter(ParamLastTime,msgstatsend.LastTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MsgStatSendDb</returns>
        public static MsgStatSendDb  ConvertToObject(DataRow dr)
        {
            var data = new MsgStatSendDb
                {
                    MsgId = DbChange.ToInt(dr["MsgId"],0),
                    MsgType = DbChange.ToInt(dr["MsgType"],0),
                    Cnt = DbChange.ToInt(dr["Cnt"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    LastTime = DbChange.ToDateTime(dr["LastTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of MsgStatSendDb</returns>
        public static List<MsgStatSendDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MsgStatSendDb>(); 
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

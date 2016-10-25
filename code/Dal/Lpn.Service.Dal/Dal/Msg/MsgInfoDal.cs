using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Msg;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Msg
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class MsgInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from msg_info;";
        //新增插入语句
        protected const string SqlInsert = "insert into msg_info(`Uid`,`Title`,`Content`,`SendTime`,`EndTime`,`IsView`,`RowTime`) values(?Uid,?Title,?Content,?SendTime,?EndTime,?IsView,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from msg_info where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update msg_info set `Uid`=?Uid,`Title`=?Title,`Content`=?Content,`SendTime`=?SendTime,`EndTime`=?EndTime,`IsView`=?IsView,`RowTime`=?RowTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from msg_info  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamUid = "?Uid";
        protected const string ParamTitle = "?Title";
        protected const string ParamContent = "?Content";
        protected const string ParamSendTime = "?SendTime";
        protected const string ParamEndTime = "?EndTime";
        protected const string ParamIsView = "?IsView";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MsgInfoDb</returns>
        public static List<MsgInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="msginfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MsgInfoDb msginfo)
        {
            var param= GetInsertParams(msginfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>MsgInfoDb</returns>
        public static MsgInfoDb  GetByPriKey(long id)
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
        /// <param name="msginfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MsgInfoDb msginfo)
        {
            var param= GetUpdateParams(msginfo);
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
        public static bool  DeleteByPriKey(long id)
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
        public static MySqlParameter[]  GetUpdateParams(MsgInfoDb msginfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,msginfo.Id),
                    new MySqlParameter(ParamUid,msginfo.Uid),
                    new MySqlParameter(ParamTitle,msginfo.Title),
                    new MySqlParameter(ParamContent,msginfo.Content),
                    new MySqlParameter(ParamSendTime,msginfo.SendTime),
                    new MySqlParameter(ParamEndTime,msginfo.EndTime),
                    new MySqlParameter(ParamIsView,msginfo.IsView),
                    new MySqlParameter(ParamRowTime,msginfo.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MsgInfoDb msginfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,msginfo.Uid),
                    new MySqlParameter(ParamTitle,msginfo.Title),
                    new MySqlParameter(ParamContent,msginfo.Content),
                    new MySqlParameter(ParamSendTime,msginfo.SendTime),
                    new MySqlParameter(ParamEndTime,msginfo.EndTime),
                    new MySqlParameter(ParamIsView,msginfo.IsView),
                    new MySqlParameter(ParamRowTime,msginfo.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MsgInfoDb</returns>
        public static MsgInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new MsgInfoDb
                {
                    Id = DbChange.ToLong(dr["Id"],0),
                    Uid = DbChange.ToString(dr["Uid"]),
                    Title = DbChange.ToString(dr["Title"]),
                    Content = DbChange.ToString(dr["Content"]),
                    SendTime = DbChange.ToDateTime(dr["SendTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["EndTime"],DateTime.MinValue),
                    IsView = DbChange.ToInt(dr["IsView"],0),
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
        /// <returns>List of MsgInfoDb</returns>
        public static List<MsgInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MsgInfoDb>(); 
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

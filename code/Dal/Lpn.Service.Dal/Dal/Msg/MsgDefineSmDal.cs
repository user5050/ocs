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
    public partial class MsgDefineSmDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from msg_define_sms;";
        //新增插入语句
        protected const string SqlInsert = "insert into msg_define_sms(`Title`,`TriggerType`,`Content`,`RowTime`,`Operator`,`OperateTime`) values(?Title,?TriggerType,?Content,?RowTime,?Operator,?OperateTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from msg_define_sms where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update msg_define_sms set `Title`=?Title,`TriggerType`=?TriggerType,`Content`=?Content,`RowTime`=?RowTime,`Operator`=?Operator,`OperateTime`=?OperateTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from msg_define_sms  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamTitle = "?Title";
        protected const string ParamTriggerType = "?TriggerType";
        protected const string ParamContent = "?Content";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamOperator = "?Operator";
        protected const string ParamOperateTime = "?OperateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MsgDefineSmDb</returns>
        public static List<MsgDefineSmDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="msgdefinesm">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MsgDefineSmDb msgdefinesm)
        {
            var param= GetInsertParams(msgdefinesm);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">id</param> 
        /// <returns>MsgDefineSmDb</returns>
        public static MsgDefineSmDb  GetByPriKey(int id)
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
        /// <param name="msgdefinesm">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MsgDefineSmDb msgdefinesm)
        {
            var param= GetUpdateParams(msgdefinesm);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">id</param> 
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
        public static MySqlParameter[]  GetUpdateParams(MsgDefineSmDb msgdefinesm)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,msgdefinesm.Id),
                    new MySqlParameter(ParamTitle,msgdefinesm.Title),
                    new MySqlParameter(ParamTriggerType,msgdefinesm.TriggerType),
                    new MySqlParameter(ParamContent,msgdefinesm.Content),
                    new MySqlParameter(ParamRowTime,msgdefinesm.RowTime),
                    new MySqlParameter(ParamOperator,msgdefinesm.Operator),
                    new MySqlParameter(ParamOperateTime,msgdefinesm.OperateTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MsgDefineSmDb msgdefinesm)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTitle,msgdefinesm.Title),
                    new MySqlParameter(ParamTriggerType,msgdefinesm.TriggerType),
                    new MySqlParameter(ParamContent,msgdefinesm.Content),
                    new MySqlParameter(ParamRowTime,msgdefinesm.RowTime),
                    new MySqlParameter(ParamOperator,msgdefinesm.Operator),
                    new MySqlParameter(ParamOperateTime,msgdefinesm.OperateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MsgDefineSmDb</returns>
        public static MsgDefineSmDb  ConvertToObject(DataRow dr)
        {
            var data = new MsgDefineSmDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    Title = DbChange.ToString(dr["Title"]),
                    TriggerType = DbChange.ToInt(dr["TriggerType"],0),
                    Content = DbChange.ToString(dr["Content"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    Operator = DbChange.ToString(dr["Operator"]),
                    OperateTime = DbChange.ToDateTime(dr["OperateTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of MsgDefineSmDb</returns>
        public static List<MsgDefineSmDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MsgDefineSmDb>(); 
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

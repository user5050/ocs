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
    public partial class MsgDefinePersonalDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from msg_define_personal;";
        //新增插入语句
        protected const string SqlInsert = "insert into msg_define_personal(`TriggerType`,`Title`,`Content`,`JumpType`,`JumpConfig`,`RowTime`,`Operator`,`OperateTime`) values(?TriggerType,?Title,?Content,?JumpType,?JumpConfig,?RowTime,?Operator,?OperateTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from msg_define_personal where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update msg_define_personal set `TriggerType`=?TriggerType,`Title`=?Title,`Content`=?Content,`JumpType`=?JumpType,`JumpConfig`=?JumpConfig,`RowTime`=?RowTime,`Operator`=?Operator,`OperateTime`=?OperateTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from msg_define_personal  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamTriggerType = "?TriggerType";
        protected const string ParamTitle = "?Title";
        protected const string ParamContent = "?Content";
        protected const string ParamJumpType = "?JumpType";
        protected const string ParamJumpConfig = "?JumpConfig";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamOperator = "?Operator";
        protected const string ParamOperateTime = "?OperateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MsgDefinePersonalDb</returns>
        public static List<MsgDefinePersonalDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="msgdefinepersonal">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MsgDefinePersonalDb msgdefinepersonal)
        {
            var param= GetInsertParams(msgdefinepersonal);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">id</param> 
        /// <returns>MsgDefinePersonalDb</returns>
        public static MsgDefinePersonalDb  GetByPriKey(int id)
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
        /// <param name="msgdefinepersonal">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MsgDefinePersonalDb msgdefinepersonal)
        {
            var param= GetUpdateParams(msgdefinepersonal);
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
        public static MySqlParameter[]  GetUpdateParams(MsgDefinePersonalDb msgdefinepersonal)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,msgdefinepersonal.Id),
                    new MySqlParameter(ParamTriggerType,msgdefinepersonal.TriggerType),
                    new MySqlParameter(ParamTitle,msgdefinepersonal.Title),
                    new MySqlParameter(ParamContent,msgdefinepersonal.Content),
                    new MySqlParameter(ParamJumpType,msgdefinepersonal.JumpType),
                    new MySqlParameter(ParamJumpConfig,msgdefinepersonal.JumpConfig),
                    new MySqlParameter(ParamRowTime,msgdefinepersonal.RowTime),
                    new MySqlParameter(ParamOperator,msgdefinepersonal.Operator),
                    new MySqlParameter(ParamOperateTime,msgdefinepersonal.OperateTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MsgDefinePersonalDb msgdefinepersonal)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTriggerType,msgdefinepersonal.TriggerType),
                    new MySqlParameter(ParamTitle,msgdefinepersonal.Title),
                    new MySqlParameter(ParamContent,msgdefinepersonal.Content),
                    new MySqlParameter(ParamJumpType,msgdefinepersonal.JumpType),
                    new MySqlParameter(ParamJumpConfig,msgdefinepersonal.JumpConfig),
                    new MySqlParameter(ParamRowTime,msgdefinepersonal.RowTime),
                    new MySqlParameter(ParamOperator,msgdefinepersonal.Operator),
                    new MySqlParameter(ParamOperateTime,msgdefinepersonal.OperateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MsgDefinePersonalDb</returns>
        public static MsgDefinePersonalDb  ConvertToObject(DataRow dr)
        {
            var data = new MsgDefinePersonalDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    TriggerType = DbChange.ToInt(dr["TriggerType"],0),
                    Title = DbChange.ToString(dr["Title"]),
                    Content = DbChange.ToString(dr["Content"]),
                    JumpType = DbChange.ToInt(dr["JumpType"],0),
                    JumpConfig = DbChange.ToString(dr["JumpConfig"]),
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
        /// <returns>List of MsgDefinePersonalDb</returns>
        public static List<MsgDefinePersonalDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MsgDefinePersonalDb>(); 
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

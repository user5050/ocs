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
    public partial class MsgDefineSystemDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from msg_define_system;";
        //新增插入语句
        protected const string SqlInsert = "insert into msg_define_system(`TriggerType`,`Title`,`Content`,`ImgUrl`,`JumpType`,`JumpConfig`,`LimitCity`,`LimitPark`,`LimitMobile`,`StartTime`,`EndTime`,`TimingSendTime`,`IntervalPreTime`,`RowTime`,`Operator`,`OperateTime`) values(?TriggerType,?Title,?Content,?ImgUrl,?JumpType,?JumpConfig,?LimitCity,?LimitPark,?LimitMobile,?StartTime,?EndTime,?TimingSendTime,?IntervalPreTime,?RowTime,?Operator,?OperateTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from msg_define_system where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update msg_define_system set `TriggerType`=?TriggerType,`Title`=?Title,`Content`=?Content,`ImgUrl`=?ImgUrl,`JumpType`=?JumpType,`JumpConfig`=?JumpConfig,`LimitCity`=?LimitCity,`LimitPark`=?LimitPark,`LimitMobile`=?LimitMobile,`StartTime`=?StartTime,`EndTime`=?EndTime,`TimingSendTime`=?TimingSendTime,`IntervalPreTime`=?IntervalPreTime,`RowTime`=?RowTime,`Operator`=?Operator,`OperateTime`=?OperateTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from msg_define_system  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamTriggerType = "?TriggerType";
        protected const string ParamTitle = "?Title";
        protected const string ParamContent = "?Content";
        protected const string ParamImgUrl = "?ImgUrl";
        protected const string ParamJumpType = "?JumpType";
        protected const string ParamJumpConfig = "?JumpConfig";
        protected const string ParamLimitCity = "?LimitCity";
        protected const string ParamLimitPark = "?LimitPark";
        protected const string ParamLimitMobile = "?LimitMobile";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamEndTime = "?EndTime";
        protected const string ParamTimingSendTime = "?TimingSendTime";
        protected const string ParamIntervalPreTime = "?IntervalPreTime";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamOperator = "?Operator";
        protected const string ParamOperateTime = "?OperateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MsgDefineSystemDb</returns>
        public static List<MsgDefineSystemDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="msgdefinesystem">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MsgDefineSystemDb msgdefinesystem)
        {
            var param= GetInsertParams(msgdefinesystem);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">id</param> 
        /// <returns>MsgDefineSystemDb</returns>
        public static MsgDefineSystemDb  GetByPriKey(int id)
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
        /// <param name="msgdefinesystem">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MsgDefineSystemDb msgdefinesystem)
        {
            var param= GetUpdateParams(msgdefinesystem);
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
        public static MySqlParameter[]  GetUpdateParams(MsgDefineSystemDb msgdefinesystem)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,msgdefinesystem.Id),
                    new MySqlParameter(ParamTriggerType,msgdefinesystem.TriggerType),
                    new MySqlParameter(ParamTitle,msgdefinesystem.Title),
                    new MySqlParameter(ParamContent,msgdefinesystem.Content),
                    new MySqlParameter(ParamImgUrl,msgdefinesystem.ImgUrl),
                    new MySqlParameter(ParamJumpType,msgdefinesystem.JumpType),
                    new MySqlParameter(ParamJumpConfig,msgdefinesystem.JumpConfig),
                    new MySqlParameter(ParamLimitCity,msgdefinesystem.LimitCity),
                    new MySqlParameter(ParamLimitPark,msgdefinesystem.LimitPark),
                    new MySqlParameter(ParamLimitMobile,msgdefinesystem.LimitMobile),
                    new MySqlParameter(ParamStartTime,msgdefinesystem.StartTime),
                    new MySqlParameter(ParamEndTime,msgdefinesystem.EndTime),
                    new MySqlParameter(ParamTimingSendTime,msgdefinesystem.TimingSendTime),
                    new MySqlParameter(ParamIntervalPreTime,msgdefinesystem.IntervalPreTime),
                    new MySqlParameter(ParamRowTime,msgdefinesystem.RowTime),
                    new MySqlParameter(ParamOperator,msgdefinesystem.Operator),
                    new MySqlParameter(ParamOperateTime,msgdefinesystem.OperateTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MsgDefineSystemDb msgdefinesystem)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTriggerType,msgdefinesystem.TriggerType),
                    new MySqlParameter(ParamTitle,msgdefinesystem.Title),
                    new MySqlParameter(ParamContent,msgdefinesystem.Content),
                    new MySqlParameter(ParamImgUrl,msgdefinesystem.ImgUrl),
                    new MySqlParameter(ParamJumpType,msgdefinesystem.JumpType),
                    new MySqlParameter(ParamJumpConfig,msgdefinesystem.JumpConfig),
                    new MySqlParameter(ParamLimitCity,msgdefinesystem.LimitCity),
                    new MySqlParameter(ParamLimitPark,msgdefinesystem.LimitPark),
                    new MySqlParameter(ParamLimitMobile,msgdefinesystem.LimitMobile),
                    new MySqlParameter(ParamStartTime,msgdefinesystem.StartTime),
                    new MySqlParameter(ParamEndTime,msgdefinesystem.EndTime),
                    new MySqlParameter(ParamTimingSendTime,msgdefinesystem.TimingSendTime),
                    new MySqlParameter(ParamIntervalPreTime,msgdefinesystem.IntervalPreTime),
                    new MySqlParameter(ParamRowTime,msgdefinesystem.RowTime),
                    new MySqlParameter(ParamOperator,msgdefinesystem.Operator),
                    new MySqlParameter(ParamOperateTime,msgdefinesystem.OperateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MsgDefineSystemDb</returns>
        public static MsgDefineSystemDb  ConvertToObject(DataRow dr)
        {
            var data = new MsgDefineSystemDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    TriggerType = DbChange.ToInt(dr["TriggerType"],0),
                    Title = DbChange.ToString(dr["Title"]),
                    Content = DbChange.ToString(dr["Content"]),
                    ImgUrl = DbChange.ToString(dr["ImgUrl"]),
                    JumpType = DbChange.ToInt(dr["JumpType"],0),
                    JumpConfig = DbChange.ToString(dr["JumpConfig"]),
                    LimitCity = DbChange.ToString(dr["LimitCity"]),
                    LimitPark = DbChange.ToString(dr["LimitPark"]),
                    LimitMobile = DbChange.ToString(dr["LimitMobile"]),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["EndTime"],DateTime.MinValue),
                    TimingSendTime = DbChange.ToDateTime(dr["TimingSendTime"],DateTime.MinValue),
                    IntervalPreTime = DbChange.ToInt(dr["IntervalPreTime"],0),
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
        /// <returns>List of MsgDefineSystemDb</returns>
        public static List<MsgDefineSystemDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MsgDefineSystemDb>(); 
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

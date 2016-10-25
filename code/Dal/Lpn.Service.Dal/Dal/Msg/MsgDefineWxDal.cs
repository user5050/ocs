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
    public partial class MsgDefineWxDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from msg_define_wx;";
        //新增插入语句
        protected const string SqlInsert = "insert into msg_define_wx(`TriggerType`,`Head`,`Tail`,`Remark`,`JumpType`,`JumpConfig`,`LimitCity`,`LimitPark`,`LimitMobile`,`StartTime`,`EndTime`,`IntervalPreTime`,`RowTime`,`Order`,`Operator`,`OperateTime`) values(?TriggerType,?Head,?Tail,?Remark,?JumpType,?JumpConfig,?LimitCity,?LimitPark,?LimitMobile,?StartTime,?EndTime,?IntervalPreTime,?RowTime,?Order,?Operator,?OperateTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from msg_define_wx where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update msg_define_wx set `TriggerType`=?TriggerType,`Head`=?Head,`Tail`=?Tail,`Remark`=?Remark,`JumpType`=?JumpType,`JumpConfig`=?JumpConfig,`LimitCity`=?LimitCity,`LimitPark`=?LimitPark,`LimitMobile`=?LimitMobile,`StartTime`=?StartTime,`EndTime`=?EndTime,`IntervalPreTime`=?IntervalPreTime,`RowTime`=?RowTime,`Order`=?Order,`Operator`=?Operator,`OperateTime`=?OperateTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from msg_define_wx  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamTriggerType = "?TriggerType";
        protected const string ParamHead = "?Head";
        protected const string ParamTail = "?Tail";
        protected const string ParamRemark = "?Remark";
        protected const string ParamJumpType = "?JumpType";
        protected const string ParamJumpConfig = "?JumpConfig";
        protected const string ParamLimitCity = "?LimitCity";
        protected const string ParamLimitPark = "?LimitPark";
        protected const string ParamLimitMobile = "?LimitMobile";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamEndTime = "?EndTime";
        protected const string ParamIntervalPreTime = "?IntervalPreTime";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamOrder = "?Order";
        protected const string ParamOperator = "?Operator";
        protected const string ParamOperateTime = "?OperateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MsgDefineWxDb</returns>
        public static List<MsgDefineWxDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="msgdefinewx">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MsgDefineWxDb msgdefinewx)
        {
            var param= GetInsertParams(msgdefinewx);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">id</param> 
        /// <returns>MsgDefineWxDb</returns>
        public static MsgDefineWxDb  GetByPriKey(int id)
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
        /// <param name="msgdefinewx">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(MsgDefineWxDb msgdefinewx)
        {
            var param= GetUpdateParams(msgdefinewx);
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
        public static MySqlParameter[]  GetUpdateParams(MsgDefineWxDb msgdefinewx)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,msgdefinewx.Id),
                    new MySqlParameter(ParamTriggerType,msgdefinewx.TriggerType),
                    new MySqlParameter(ParamHead,msgdefinewx.Head),
                    new MySqlParameter(ParamTail,msgdefinewx.Tail),
                    new MySqlParameter(ParamRemark,msgdefinewx.Remark),
                    new MySqlParameter(ParamJumpType,msgdefinewx.JumpType),
                    new MySqlParameter(ParamJumpConfig,msgdefinewx.JumpConfig),
                    new MySqlParameter(ParamLimitCity,msgdefinewx.LimitCity),
                    new MySqlParameter(ParamLimitPark,msgdefinewx.LimitPark),
                    new MySqlParameter(ParamLimitMobile,msgdefinewx.LimitMobile),
                    new MySqlParameter(ParamStartTime,msgdefinewx.StartTime),
                    new MySqlParameter(ParamEndTime,msgdefinewx.EndTime),
                    new MySqlParameter(ParamIntervalPreTime,msgdefinewx.IntervalPreTime),
                    new MySqlParameter(ParamRowTime,msgdefinewx.RowTime),
                    new MySqlParameter(ParamOrder,msgdefinewx.Order),
                    new MySqlParameter(ParamOperator,msgdefinewx.Operator),
                    new MySqlParameter(ParamOperateTime,msgdefinewx.OperateTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MsgDefineWxDb msgdefinewx)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTriggerType,msgdefinewx.TriggerType),
                    new MySqlParameter(ParamHead,msgdefinewx.Head),
                    new MySqlParameter(ParamTail,msgdefinewx.Tail),
                    new MySqlParameter(ParamRemark,msgdefinewx.Remark),
                    new MySqlParameter(ParamJumpType,msgdefinewx.JumpType),
                    new MySqlParameter(ParamJumpConfig,msgdefinewx.JumpConfig),
                    new MySqlParameter(ParamLimitCity,msgdefinewx.LimitCity),
                    new MySqlParameter(ParamLimitPark,msgdefinewx.LimitPark),
                    new MySqlParameter(ParamLimitMobile,msgdefinewx.LimitMobile),
                    new MySqlParameter(ParamStartTime,msgdefinewx.StartTime),
                    new MySqlParameter(ParamEndTime,msgdefinewx.EndTime),
                    new MySqlParameter(ParamIntervalPreTime,msgdefinewx.IntervalPreTime),
                    new MySqlParameter(ParamRowTime,msgdefinewx.RowTime),
                    new MySqlParameter(ParamOrder,msgdefinewx.Order),
                    new MySqlParameter(ParamOperator,msgdefinewx.Operator),
                    new MySqlParameter(ParamOperateTime,msgdefinewx.OperateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MsgDefineWxDb</returns>
        public static MsgDefineWxDb  ConvertToObject(DataRow dr)
        {
            var data = new MsgDefineWxDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    TriggerType = DbChange.ToInt(dr["TriggerType"],0),
                    Head = DbChange.ToString(dr["Head"]),
                    Tail = DbChange.ToString(dr["Tail"]),
                    Remark = DbChange.ToString(dr["Remark"]),
                    JumpType = DbChange.ToInt(dr["JumpType"],0),
                    JumpConfig = DbChange.ToString(dr["JumpConfig"]),
                    LimitCity = DbChange.ToString(dr["LimitCity"]),
                    LimitPark = DbChange.ToString(dr["LimitPark"]),
                    LimitMobile = DbChange.ToString(dr["LimitMobile"]),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["EndTime"],DateTime.MinValue),
                    IntervalPreTime = DbChange.ToInt(dr["IntervalPreTime"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    Order = DbChange.ToInt(dr["Order"],0),
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
        /// <returns>List of MsgDefineWxDb</returns>
        public static List<MsgDefineWxDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MsgDefineWxDb>(); 
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

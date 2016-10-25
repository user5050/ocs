using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Pre;

/*
* 由自动生成工具完成
* 描述:[pre_account_info]预修改停车场结算信息表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Pre
{
    /// <summary>
    /// [pre_account_info]预修改停车场结算信息表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class PreAccountInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from preaccountinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into preaccountinfo(`ParkID`,`SettlementRate1`,`SettlementRate2`,`SettlementRate3`,`SettlementRate4`,`SettlementInterval`,`EffectTime`) values(?ParkID,?SettlementRate1,?SettlementRate2,?SettlementRate3,?SettlementRate4,?SettlementInterval,?EffectTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from preaccountinfo where `ParkID`=?ParkID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update preaccountinfo set `SettlementRate1`=?SettlementRate1,`SettlementRate2`=?SettlementRate2,`SettlementRate3`=?SettlementRate3,`SettlementRate4`=?SettlementRate4,`SettlementInterval`=?SettlementInterval,`EffectTime`=?EffectTime where `ParkID`=?ParkID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from preaccountinfo  where `ParkID`=?ParkID;";
        #endregion

        #region 参数
        protected const string ParamParkID = "?ParkID";
        protected const string ParamSettlementRate1 = "?SettlementRate1";
        protected const string ParamSettlementRate2 = "?SettlementRate2";
        protected const string ParamSettlementRate3 = "?SettlementRate3";
        protected const string ParamSettlementRate4 = "?SettlementRate4";
        protected const string ParamSettlementInterval = "?SettlementInterval";
        protected const string ParamEffectTime = "?EffectTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of PreAccountInfoDb</returns>
        public static List<PreAccountInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="preaccountinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(PreAccountInfoDb preaccountinfo)
        {
            var param= GetInsertParams(preaccountinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="parkID">停车场编号</param> 
        /// <returns>PreAccountInfoDb</returns>
        public static PreAccountInfoDb  GetByPriKey(int parkID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parkID)
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
        /// <param name="preaccountinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(PreAccountInfoDb preaccountinfo)
        {
            var param= GetUpdateParams(preaccountinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="parkID">停车场编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int parkID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parkID)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(PreAccountInfoDb preaccountinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,preaccountinfo.ParkID),
                    new MySqlParameter(ParamSettlementRate1,preaccountinfo.SettlementRate1),
                    new MySqlParameter(ParamSettlementRate2,preaccountinfo.SettlementRate2),
                    new MySqlParameter(ParamSettlementRate3,preaccountinfo.SettlementRate3),
                    new MySqlParameter(ParamSettlementRate4,preaccountinfo.SettlementRate4),
                    new MySqlParameter(ParamSettlementInterval,preaccountinfo.SettlementInterval),
                    new MySqlParameter(ParamEffectTime,preaccountinfo.EffectTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(PreAccountInfoDb preaccountinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,preaccountinfo.ParkID),
                    new MySqlParameter(ParamSettlementRate1,preaccountinfo.SettlementRate1),
                    new MySqlParameter(ParamSettlementRate2,preaccountinfo.SettlementRate2),
                    new MySqlParameter(ParamSettlementRate3,preaccountinfo.SettlementRate3),
                    new MySqlParameter(ParamSettlementRate4,preaccountinfo.SettlementRate4),
                    new MySqlParameter(ParamSettlementInterval,preaccountinfo.SettlementInterval),
                    new MySqlParameter(ParamEffectTime,preaccountinfo.EffectTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>PreAccountInfoDb</returns>
        public static PreAccountInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new PreAccountInfoDb
                {
                    ParkID = DbChange.ToInt(dr["ParkID"],0),
                    SettlementRate1 = DbChange.ToDecimal(dr["SettlementRate1"],0),
                    SettlementRate2 = DbChange.ToDecimal(dr["SettlementRate2"],0),
                    SettlementRate3 = DbChange.ToDecimal(dr["SettlementRate3"],0),
                    SettlementRate4 = DbChange.ToDecimal(dr["SettlementRate4"],0),
                    SettlementInterval = DbChange.ToInt(dr["SettlementInterval"],0),
                    EffectTime = DbChange.ToDateTime(dr["EffectTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of PreAccountInfoDb</returns>
        public static List<PreAccountInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<PreAccountInfoDb>(); 
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

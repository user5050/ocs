using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Rep;

/*
* 由自动生成工具完成
* 描述:泊位效率 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Rep
{
    /// <summary>
    /// 泊位效率 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class RepParkefficDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from rep_parkeffic;";
        //新增插入语句
        protected const string SqlInsert = "insert into rep_parkeffic(`ParkCode`,`Lot_All`,`Lot_Use`,`Lot_Free`,`Lot_Effic`,`Lot_Vip`,`Lot_Vipuse`,`Lot_Vipfree`,`Lot_Vipeffic`,`EventTime`) values(?ParkCode,?Lot_All,?Lot_Use,?Lot_Free,?Lot_Effic,?Lot_Vip,?Lot_Vipuse,?Lot_Vipfree,?Lot_Vipeffic,?EventTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from rep_parkeffic where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update rep_parkeffic set `ParkCode`=?ParkCode,`Lot_All`=?Lot_All,`Lot_Use`=?Lot_Use,`Lot_Free`=?Lot_Free,`Lot_Effic`=?Lot_Effic,`Lot_Vip`=?Lot_Vip,`Lot_Vipuse`=?Lot_Vipuse,`Lot_Vipfree`=?Lot_Vipfree,`Lot_Vipeffic`=?Lot_Vipeffic,`EventTime`=?EventTime where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from rep_parkeffic  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamLot_All = "?Lot_All";
        protected const string ParamLot_Use = "?Lot_Use";
        protected const string ParamLot_Free = "?Lot_Free";
        protected const string ParamLot_Effic = "?Lot_Effic";
        protected const string ParamLot_Vip = "?Lot_Vip";
        protected const string ParamLot_Vipuse = "?Lot_Vipuse";
        protected const string ParamLot_Vipfree = "?Lot_Vipfree";
        protected const string ParamLot_Vipeffic = "?Lot_Vipeffic";
        protected const string ParamEventTime = "?EventTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of RepParkefficDb</returns>
        public static List<RepParkefficDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="repparkeffic">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(RepParkefficDb repparkeffic)
        {
            var param= GetInsertParams(repparkeffic);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">泊位效率编号</param> 
        /// <returns>RepParkefficDb</returns>
        public static RepParkefficDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
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
        /// <param name="repparkeffic">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(RepParkefficDb repparkeffic)
        {
            var param= GetUpdateParams(repparkeffic);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">泊位效率编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(RepParkefficDb repparkeffic)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,repparkeffic.ID),
                    new MySqlParameter(ParamParkCode,repparkeffic.ParkCode),
                    new MySqlParameter(ParamLot_All,repparkeffic.Lot_All),
                    new MySqlParameter(ParamLot_Use,repparkeffic.Lot_Use),
                    new MySqlParameter(ParamLot_Free,repparkeffic.Lot_Free),
                    new MySqlParameter(ParamLot_Effic,repparkeffic.Lot_Effic),
                    new MySqlParameter(ParamLot_Vip,repparkeffic.Lot_Vip),
                    new MySqlParameter(ParamLot_Vipuse,repparkeffic.Lot_Vipuse),
                    new MySqlParameter(ParamLot_Vipfree,repparkeffic.Lot_Vipfree),
                    new MySqlParameter(ParamLot_Vipeffic,repparkeffic.Lot_Vipeffic),
                    new MySqlParameter(ParamEventTime,repparkeffic.EventTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(RepParkefficDb repparkeffic)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,repparkeffic.ParkCode),
                    new MySqlParameter(ParamLot_All,repparkeffic.Lot_All),
                    new MySqlParameter(ParamLot_Use,repparkeffic.Lot_Use),
                    new MySqlParameter(ParamLot_Free,repparkeffic.Lot_Free),
                    new MySqlParameter(ParamLot_Effic,repparkeffic.Lot_Effic),
                    new MySqlParameter(ParamLot_Vip,repparkeffic.Lot_Vip),
                    new MySqlParameter(ParamLot_Vipuse,repparkeffic.Lot_Vipuse),
                    new MySqlParameter(ParamLot_Vipfree,repparkeffic.Lot_Vipfree),
                    new MySqlParameter(ParamLot_Vipeffic,repparkeffic.Lot_Vipeffic),
                    new MySqlParameter(ParamEventTime,repparkeffic.EventTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>RepParkefficDb</returns>
        public static RepParkefficDb  ConvertToObject(DataRow dr)
        {
            var data = new RepParkefficDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    Lot_All = DbChange.ToInt(dr["Lot_All"],0),
                    Lot_Use = DbChange.ToInt(dr["Lot_Use"],0),
                    Lot_Free = DbChange.ToInt(dr["Lot_Free"],0),
                    Lot_Effic = DbChange.ToDouble(dr["Lot_Effic"],0D),
                    Lot_Vip = DbChange.ToInt(dr["Lot_Vip"],0),
                    Lot_Vipuse = DbChange.ToInt(dr["Lot_Vipuse"],0),
                    Lot_Vipfree = DbChange.ToInt(dr["Lot_Vipfree"],0),
                    Lot_Vipeffic = DbChange.ToDouble(dr["Lot_Vipeffic"],0D),
                    EventTime = DbChange.ToDateTime(dr["EventTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of RepParkefficDb</returns>
        public static List<RepParkefficDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<RepParkefficDb>(); 
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

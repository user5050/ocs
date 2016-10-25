using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_fee]停车场费率 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_fee]停车场费率 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkFeeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkfee;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkfee(`ParkCode`,`FreeTime`,`UnitPrice`,`Detail`,`IsChecked`,`FirstPrice`,`FirstTime`,`FreeExitTime`) values(?ParkCode,?FreeTime,?UnitPrice,?Detail,?IsChecked,?FirstPrice,?FirstTime,?FreeExitTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkfee where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkfee set `ParkCode`=?ParkCode,`FreeTime`=?FreeTime,`UnitPrice`=?UnitPrice,`Detail`=?Detail,`IsChecked`=?IsChecked,`FirstPrice`=?FirstPrice,`FirstTime`=?FirstTime,`FreeExitTime`=?FreeExitTime where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkfee  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamFreeTime = "?FreeTime";
        protected const string ParamUnitPrice = "?UnitPrice";
        protected const string ParamDetail = "?Detail";
        protected const string ParamIsChecked = "?IsChecked";
        protected const string ParamFirstPrice = "?FirstPrice";
        protected const string ParamFirstTime = "?FirstTime";
        protected const string ParamFreeExitTime = "?FreeExitTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkFeeDb</returns>
        public static List<ParkFeeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkfee">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkFeeDb parkfee)
        {
            var param= GetInsertParams(parkfee);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">停车场费率编号</param> 
        /// <returns>ParkFeeDb</returns>
        public static ParkFeeDb  GetByPriKey(int id)
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
        /// <param name="parkfee">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkFeeDb parkfee)
        {
            var param= GetUpdateParams(parkfee);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">停车场费率编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkFeeDb parkfee)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkfee.ID),
                    new MySqlParameter(ParamParkCode,parkfee.ParkCode),
                    new MySqlParameter(ParamFreeTime,parkfee.FreeTime),
                    new MySqlParameter(ParamUnitPrice,parkfee.UnitPrice),
                    new MySqlParameter(ParamDetail,parkfee.Detail),
                    new MySqlParameter(ParamIsChecked,parkfee.IsChecked),
                    new MySqlParameter(ParamFirstPrice,parkfee.FirstPrice),
                    new MySqlParameter(ParamFirstTime,parkfee.FirstTime),
                    new MySqlParameter(ParamFreeExitTime,parkfee.FreeExitTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkFeeDb parkfee)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkfee.ParkCode),
                    new MySqlParameter(ParamFreeTime,parkfee.FreeTime),
                    new MySqlParameter(ParamUnitPrice,parkfee.UnitPrice),
                    new MySqlParameter(ParamDetail,parkfee.Detail),
                    new MySqlParameter(ParamIsChecked,parkfee.IsChecked),
                    new MySqlParameter(ParamFirstPrice,parkfee.FirstPrice),
                    new MySqlParameter(ParamFirstTime,parkfee.FirstTime),
                    new MySqlParameter(ParamFreeExitTime,parkfee.FreeExitTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkFeeDb</returns>
        public static ParkFeeDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkFeeDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    FreeTime = DbChange.ToInt(dr["FreeTime"],0),
                    UnitPrice = DbChange.ToInt(dr["UnitPrice"],0),
                    Detail = DbChange.ToString(dr["Detail"]),
                    IsChecked = DbChange.ToInt(dr["IsChecked"],-1),
                    FirstPrice = DbChange.ToInt(dr["FirstPrice"],0),
                    FirstTime = DbChange.ToInt(dr["FirstTime"],0),
                    FreeExitTime = DbChange.ToInt(dr["FreeExitTime"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkFeeDb</returns>
        public static List<ParkFeeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkFeeDb>(); 
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

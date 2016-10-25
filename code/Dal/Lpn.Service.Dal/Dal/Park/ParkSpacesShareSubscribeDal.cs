using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_spaces_share_subscribe] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_spaces_share_subscribe] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkSpacesShareSubscribeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkspacessharesubscribe;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkspacessharesubscribe(`ID`,`ParkSpaceType`,`ParkSpaceID`,`ParkSpaceOwner`,`SapceCode`,`Describe`,`Price`,`Minutes`,`TotalMoney`,`Owner`,`CardSerialNo`,`VehicleNo`,`BeginTime`,`LeaveTime`,`CreateTime`,`Status`,`OrderNo`,`Stamp`,`Lot`,`ParkCode`) values(?ID,?ParkSpaceType,?ParkSpaceID,?ParkSpaceOwner,?SapceCode,?Describe,?Price,?Minutes,?TotalMoney,?Owner,?CardSerialNo,?VehicleNo,?BeginTime,?LeaveTime,?CreateTime,?Status,?OrderNo,?Stamp,?Lot,?ParkCode);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkspacessharesubscribe where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkspacessharesubscribe set `ParkSpaceType`=?ParkSpaceType,`ParkSpaceID`=?ParkSpaceID,`ParkSpaceOwner`=?ParkSpaceOwner,`SapceCode`=?SapceCode,`Describe`=?Describe,`Price`=?Price,`Minutes`=?Minutes,`TotalMoney`=?TotalMoney,`Owner`=?Owner,`CardSerialNo`=?CardSerialNo,`VehicleNo`=?VehicleNo,`BeginTime`=?BeginTime,`LeaveTime`=?LeaveTime,`CreateTime`=?CreateTime,`Status`=?Status,`OrderNo`=?OrderNo,`Stamp`=?Stamp,`Lot`=?Lot,`ParkCode`=?ParkCode where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkspacessharesubscribe  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkSpaceType = "?ParkSpaceType";
        protected const string ParamParkSpaceID = "?ParkSpaceID";
        protected const string ParamParkSpaceOwner = "?ParkSpaceOwner";
        protected const string ParamSapceCode = "?SapceCode";
        protected const string ParamDescribe = "?Describe";
        protected const string ParamPrice = "?Price";
        protected const string ParamMinutes = "?Minutes";
        protected const string ParamTotalMoney = "?TotalMoney";
        protected const string ParamOwner = "?Owner";
        protected const string ParamCardSerialNo = "?CardSerialNo";
        protected const string ParamVehicleNo = "?VehicleNo";
        protected const string ParamBeginTime = "?BeginTime";
        protected const string ParamLeaveTime = "?LeaveTime";
        protected const string ParamCreateTime = "?CreateTime";
        protected const string ParamStatus = "?Status";
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamStamp = "?Stamp";
        protected const string ParamLot = "?Lot";
        protected const string ParamParkCode = "?ParkCode";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkSpacesShareSubscribeDb</returns>
        public static List<ParkSpacesShareSubscribeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkspacessharesubscribe">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkSpacesShareSubscribeDb parkspacessharesubscribe)
        {
            var param= GetInsertParams(parkspacessharesubscribe);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ParkSpacesShareSubscribeDb</returns>
        public static ParkSpacesShareSubscribeDb  GetByPriKey(string id)
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
        /// <param name="parkspacessharesubscribe">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkSpacesShareSubscribeDb parkspacessharesubscribe)
        {
            var param= GetUpdateParams(parkspacessharesubscribe);
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
        public static bool  DeleteByPriKey(string id)
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
        public static MySqlParameter[]  GetUpdateParams(ParkSpacesShareSubscribeDb parkspacessharesubscribe)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkspacessharesubscribe.ID),
                    new MySqlParameter(ParamParkSpaceType,parkspacessharesubscribe.ParkSpaceType),
                    new MySqlParameter(ParamParkSpaceID,parkspacessharesubscribe.ParkSpaceID),
                    new MySqlParameter(ParamParkSpaceOwner,parkspacessharesubscribe.ParkSpaceOwner),
                    new MySqlParameter(ParamSapceCode,parkspacessharesubscribe.SapceCode),
                    new MySqlParameter(ParamDescribe,parkspacessharesubscribe.Describe),
                    new MySqlParameter(ParamPrice,parkspacessharesubscribe.Price),
                    new MySqlParameter(ParamMinutes,parkspacessharesubscribe.Minutes),
                    new MySqlParameter(ParamTotalMoney,parkspacessharesubscribe.TotalMoney),
                    new MySqlParameter(ParamOwner,parkspacessharesubscribe.Owner),
                    new MySqlParameter(ParamCardSerialNo,parkspacessharesubscribe.CardSerialNo),
                    new MySqlParameter(ParamVehicleNo,parkspacessharesubscribe.VehicleNo),
                    new MySqlParameter(ParamBeginTime,parkspacessharesubscribe.BeginTime),
                    new MySqlParameter(ParamLeaveTime,parkspacessharesubscribe.LeaveTime),
                    new MySqlParameter(ParamCreateTime,parkspacessharesubscribe.CreateTime),
                    new MySqlParameter(ParamStatus,parkspacessharesubscribe.Status),
                    new MySqlParameter(ParamOrderNo,parkspacessharesubscribe.OrderNo),
                    new MySqlParameter(ParamStamp,parkspacessharesubscribe.Stamp),
                    new MySqlParameter(ParamLot,parkspacessharesubscribe.Lot),
                    new MySqlParameter(ParamParkCode,parkspacessharesubscribe.ParkCode)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkSpacesShareSubscribeDb parkspacessharesubscribe)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkspacessharesubscribe.ID),
                    new MySqlParameter(ParamParkSpaceType,parkspacessharesubscribe.ParkSpaceType),
                    new MySqlParameter(ParamParkSpaceID,parkspacessharesubscribe.ParkSpaceID),
                    new MySqlParameter(ParamParkSpaceOwner,parkspacessharesubscribe.ParkSpaceOwner),
                    new MySqlParameter(ParamSapceCode,parkspacessharesubscribe.SapceCode),
                    new MySqlParameter(ParamDescribe,parkspacessharesubscribe.Describe),
                    new MySqlParameter(ParamPrice,parkspacessharesubscribe.Price),
                    new MySqlParameter(ParamMinutes,parkspacessharesubscribe.Minutes),
                    new MySqlParameter(ParamTotalMoney,parkspacessharesubscribe.TotalMoney),
                    new MySqlParameter(ParamOwner,parkspacessharesubscribe.Owner),
                    new MySqlParameter(ParamCardSerialNo,parkspacessharesubscribe.CardSerialNo),
                    new MySqlParameter(ParamVehicleNo,parkspacessharesubscribe.VehicleNo),
                    new MySqlParameter(ParamBeginTime,parkspacessharesubscribe.BeginTime),
                    new MySqlParameter(ParamLeaveTime,parkspacessharesubscribe.LeaveTime),
                    new MySqlParameter(ParamCreateTime,parkspacessharesubscribe.CreateTime),
                    new MySqlParameter(ParamStatus,parkspacessharesubscribe.Status),
                    new MySqlParameter(ParamOrderNo,parkspacessharesubscribe.OrderNo),
                    new MySqlParameter(ParamStamp,parkspacessharesubscribe.Stamp),
                    new MySqlParameter(ParamLot,parkspacessharesubscribe.Lot),
                    new MySqlParameter(ParamParkCode,parkspacessharesubscribe.ParkCode)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkSpacesShareSubscribeDb</returns>
        public static ParkSpacesShareSubscribeDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkSpacesShareSubscribeDb
                {
                    ID = DbChange.ToString(dr["ID"]),
                    ParkSpaceType = DbChange.ToInt(dr["ParkSpaceType"],0),
                    ParkSpaceID = DbChange.ToString(dr["ParkSpaceID"]),
                    ParkSpaceOwner = DbChange.ToInt(dr["ParkSpaceOwner"],0),
                    SapceCode = DbChange.ToString(dr["SapceCode"]),
                    Describe = DbChange.ToString(dr["Describe"]),
                    Price = DbChange.ToDecimal(dr["Price"],0),
                    Minutes = DbChange.ToInt(dr["Minutes"],0),
                    TotalMoney = DbChange.ToDecimal(dr["TotalMoney"],0),
                    Owner = DbChange.ToInt(dr["Owner"],0),
                    CardSerialNo = DbChange.ToString(dr["CardSerialNo"]),
                    VehicleNo = DbChange.ToString(dr["VehicleNo"]),
                    BeginTime = DbChange.ToDateTime(dr["BeginTime"],DateTime.MinValue),
                    LeaveTime = DbChange.ToDateTime(dr["LeaveTime"],DateTime.MinValue),
                    CreateTime = DbChange.ToDateTime(dr["CreateTime"],DateTime.MinValue),
                    Status = DbChange.ToInt(dr["Status"],0),
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    Stamp = DbChange.ToString(dr["Stamp"]),
                    Lot = DbChange.ToString(dr["Lot"]),
                    ParkCode = DbChange.ToString(dr["ParkCode"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkSpacesShareSubscribeDb</returns>
        public static List<ParkSpacesShareSubscribeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkSpacesShareSubscribeDb>(); 
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

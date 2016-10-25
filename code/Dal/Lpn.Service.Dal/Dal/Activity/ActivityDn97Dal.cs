using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Activity;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Activity
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ActivityDn97Dal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from activity_dn97;";
        //新增插入语句
        protected const string SqlInsert = "insert into activity_dn97(`OrderNo`,`ActivityId`,`ActivityName`,`ServiceAddr`,`Name`,`Contract`,`CarType`,`CarNo`,`CarColor`,`ParkingLot`,`PayDesc`,`Remark`,`RowTime`,`Amount`,`IsPay`,`IsUsed`,`ActivityDate`,`UsedTime`,`SpId`,`SpPrice`) values(?OrderNo,?ActivityId,?ActivityName,?ServiceAddr,?Name,?Contract,?CarType,?CarNo,?CarColor,?ParkingLot,?PayDesc,?Remark,?RowTime,?Amount,?IsPay,?IsUsed,?ActivityDate,?UsedTime,?SpId,?SpPrice);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from activity_dn97 where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update activity_dn97 set `ActivityId`=?ActivityId,`ActivityName`=?ActivityName,`ServiceAddr`=?ServiceAddr,`Name`=?Name,`Contract`=?Contract,`CarType`=?CarType,`CarNo`=?CarNo,`CarColor`=?CarColor,`ParkingLot`=?ParkingLot,`PayDesc`=?PayDesc,`Remark`=?Remark,`RowTime`=?RowTime,`Amount`=?Amount,`IsPay`=?IsPay,`IsUsed`=?IsUsed,`ActivityDate`=?ActivityDate,`UsedTime`=?UsedTime,`SpId`=?SpId,`SpPrice`=?SpPrice where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from activity_dn97  where `OrderNo`=?OrderNo;";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamActivityId = "?ActivityId";
        protected const string ParamActivityName = "?ActivityName";
        protected const string ParamServiceAddr = "?ServiceAddr";
        protected const string ParamName = "?Name";
        protected const string ParamContract = "?Contract";
        protected const string ParamCarType = "?CarType";
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamCarColor = "?CarColor";
        protected const string ParamParkingLot = "?ParkingLot";
        protected const string ParamPayDesc = "?PayDesc";
        protected const string ParamRemark = "?Remark";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamAmount = "?Amount";
        protected const string ParamIsPay = "?IsPay";
        protected const string ParamIsUsed = "?IsUsed";
        protected const string ParamActivityDate = "?ActivityDate";
        protected const string ParamUsedTime = "?UsedTime";
        protected const string ParamSpId = "?SpId";
        protected const string ParamSpPrice = "?SpPrice";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ActivityDn97Db</returns>
        public static List<ActivityDn97Db>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="activitydn97">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ActivityDn97Db activitydn97)
        {
            var param= GetInsertParams(activitydn97);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单号</param> 
        /// <returns>ActivityDn97Db</returns>
        public static ActivityDn97Db  GetByPriKey(string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
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
        /// <param name="activitydn97">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ActivityDn97Db activitydn97)
        {
            var param= GetUpdateParams(activitydn97);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="orderNo">订单号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ActivityDn97Db activitydn97)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,activitydn97.OrderNo),
                    new MySqlParameter(ParamActivityId,activitydn97.ActivityId),
                    new MySqlParameter(ParamActivityName,activitydn97.ActivityName),
                    new MySqlParameter(ParamServiceAddr,activitydn97.ServiceAddr),
                    new MySqlParameter(ParamName,activitydn97.Name),
                    new MySqlParameter(ParamContract,activitydn97.Contract),
                    new MySqlParameter(ParamCarType,activitydn97.CarType),
                    new MySqlParameter(ParamCarNo,activitydn97.CarNo),
                    new MySqlParameter(ParamCarColor,activitydn97.CarColor),
                    new MySqlParameter(ParamParkingLot,activitydn97.ParkingLot),
                    new MySqlParameter(ParamPayDesc,activitydn97.PayDesc),
                    new MySqlParameter(ParamRemark,activitydn97.Remark),
                    new MySqlParameter(ParamRowTime,activitydn97.RowTime),
                    new MySqlParameter(ParamAmount,activitydn97.Amount),
                    new MySqlParameter(ParamIsPay,activitydn97.IsPay),
                    new MySqlParameter(ParamIsUsed,activitydn97.IsUsed),
                    new MySqlParameter(ParamActivityDate,activitydn97.ActivityDate),
                    new MySqlParameter(ParamUsedTime,activitydn97.UsedTime),
                    new MySqlParameter(ParamSpId,activitydn97.SpId),
                    new MySqlParameter(ParamSpPrice,activitydn97.SpPrice)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ActivityDn97Db activitydn97)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,activitydn97.OrderNo),
                    new MySqlParameter(ParamActivityId,activitydn97.ActivityId),
                    new MySqlParameter(ParamActivityName,activitydn97.ActivityName),
                    new MySqlParameter(ParamServiceAddr,activitydn97.ServiceAddr),
                    new MySqlParameter(ParamName,activitydn97.Name),
                    new MySqlParameter(ParamContract,activitydn97.Contract),
                    new MySqlParameter(ParamCarType,activitydn97.CarType),
                    new MySqlParameter(ParamCarNo,activitydn97.CarNo),
                    new MySqlParameter(ParamCarColor,activitydn97.CarColor),
                    new MySqlParameter(ParamParkingLot,activitydn97.ParkingLot),
                    new MySqlParameter(ParamPayDesc,activitydn97.PayDesc),
                    new MySqlParameter(ParamRemark,activitydn97.Remark),
                    new MySqlParameter(ParamRowTime,activitydn97.RowTime),
                    new MySqlParameter(ParamAmount,activitydn97.Amount),
                    new MySqlParameter(ParamIsPay,activitydn97.IsPay),
                    new MySqlParameter(ParamIsUsed,activitydn97.IsUsed),
                    new MySqlParameter(ParamActivityDate,activitydn97.ActivityDate),
                    new MySqlParameter(ParamUsedTime,activitydn97.UsedTime),
                    new MySqlParameter(ParamSpId,activitydn97.SpId),
                    new MySqlParameter(ParamSpPrice,activitydn97.SpPrice)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ActivityDn97Db</returns>
        public static ActivityDn97Db  ConvertToObject(DataRow dr)
        {
            var data = new ActivityDn97Db
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    ActivityId = DbChange.ToString(dr["ActivityId"]),
                    ActivityName = DbChange.ToString(dr["ActivityName"]),
                    ServiceAddr = DbChange.ToString(dr["ServiceAddr"]),
                    Name = DbChange.ToString(dr["Name"]),
                    Contract = DbChange.ToString(dr["Contract"]),
                    CarType = DbChange.ToString(dr["CarType"]),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    CarColor = DbChange.ToString(dr["CarColor"]),
                    ParkingLot = DbChange.ToString(dr["ParkingLot"]),
                    PayDesc = DbChange.ToString(dr["PayDesc"]),
                    Remark = DbChange.ToString(dr["Remark"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    Amount = DbChange.ToInt(dr["Amount"],0),
                    IsPay = DbChange.ToInt(dr["IsPay"],0),
                    IsUsed = DbChange.ToInt(dr["IsUsed"],0),
                    ActivityDate = DbChange.ToDateTime(dr["ActivityDate"],DateTime.MinValue),
                    UsedTime = DbChange.ToDateTime(dr["UsedTime"],DateTime.MinValue),
                    SpId = DbChange.ToString(dr["SpId"]),
                    SpPrice = DbChange.ToDouble(dr["SpPrice"],0D)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ActivityDn97Db</returns>
        public static List<ActivityDn97Db>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ActivityDn97Db>(); 
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

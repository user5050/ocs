using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_spaces_share] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_spaces_share] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkSpacesShareDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkspacesshare;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkspacesshare(`ID`,`ParkCode`,`ParkName`,`Library`,`Lot`,`SapceCode`,`Describe`,`Comment`,`LotOwner`,`AuditStatus`,`LockStatus`,`CreateTime`,`AuditTime`,`AuditDescribe`,`Publishstatus`,`Stamp`) values(?ID,?ParkCode,?ParkName,?Library,?Lot,?SapceCode,?Describe,?Comment,?LotOwner,?AuditStatus,?LockStatus,?CreateTime,?AuditTime,?AuditDescribe,?Publishstatus,?Stamp);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkspacesshare where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkspacesshare set `ParkCode`=?ParkCode,`ParkName`=?ParkName,`Library`=?Library,`Lot`=?Lot,`SapceCode`=?SapceCode,`Describe`=?Describe,`Comment`=?Comment,`LotOwner`=?LotOwner,`AuditStatus`=?AuditStatus,`LockStatus`=?LockStatus,`CreateTime`=?CreateTime,`AuditTime`=?AuditTime,`AuditDescribe`=?AuditDescribe,`Publishstatus`=?Publishstatus,`Stamp`=?Stamp where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkspacesshare  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamParkName = "?ParkName";
        protected const string ParamLibrary = "?Library";
        protected const string ParamLot = "?Lot";
        protected const string ParamSapceCode = "?SapceCode";
        protected const string ParamDescribe = "?Describe";
        protected const string ParamComment = "?Comment";
        protected const string ParamLotOwner = "?LotOwner";
        protected const string ParamAuditStatus = "?AuditStatus";
        protected const string ParamLockStatus = "?LockStatus";
        protected const string ParamCreateTime = "?CreateTime";
        protected const string ParamAuditTime = "?AuditTime";
        protected const string ParamAuditDescribe = "?AuditDescribe";
        protected const string ParamPublishstatus = "?Publishstatus";
        protected const string ParamStamp = "?Stamp";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkSpacesShareDb</returns>
        public static List<ParkSpacesShareDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkspacesshare">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkSpacesShareDb parkspacesshare)
        {
            var param= GetInsertParams(parkspacesshare);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ParkSpacesShareDb</returns>
        public static ParkSpacesShareDb  GetByPriKey(string id)
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
        /// <param name="parkspacesshare">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkSpacesShareDb parkspacesshare)
        {
            var param= GetUpdateParams(parkspacesshare);
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
        public static MySqlParameter[]  GetUpdateParams(ParkSpacesShareDb parkspacesshare)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkspacesshare.ID),
                    new MySqlParameter(ParamParkCode,parkspacesshare.ParkCode),
                    new MySqlParameter(ParamParkName,parkspacesshare.ParkName),
                    new MySqlParameter(ParamLibrary,parkspacesshare.Library),
                    new MySqlParameter(ParamLot,parkspacesshare.Lot),
                    new MySqlParameter(ParamSapceCode,parkspacesshare.SapceCode),
                    new MySqlParameter(ParamDescribe,parkspacesshare.Describe),
                    new MySqlParameter(ParamComment,parkspacesshare.Comment),
                    new MySqlParameter(ParamLotOwner,parkspacesshare.LotOwner),
                    new MySqlParameter(ParamAuditStatus,parkspacesshare.AuditStatus),
                    new MySqlParameter(ParamLockStatus,parkspacesshare.LockStatus),
                    new MySqlParameter(ParamCreateTime,parkspacesshare.CreateTime),
                    new MySqlParameter(ParamAuditTime,parkspacesshare.AuditTime),
                    new MySqlParameter(ParamAuditDescribe,parkspacesshare.AuditDescribe),
                    new MySqlParameter(ParamPublishstatus,parkspacesshare.Publishstatus),
                    new MySqlParameter(ParamStamp,parkspacesshare.Stamp)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkSpacesShareDb parkspacesshare)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkspacesshare.ID),
                    new MySqlParameter(ParamParkCode,parkspacesshare.ParkCode),
                    new MySqlParameter(ParamParkName,parkspacesshare.ParkName),
                    new MySqlParameter(ParamLibrary,parkspacesshare.Library),
                    new MySqlParameter(ParamLot,parkspacesshare.Lot),
                    new MySqlParameter(ParamSapceCode,parkspacesshare.SapceCode),
                    new MySqlParameter(ParamDescribe,parkspacesshare.Describe),
                    new MySqlParameter(ParamComment,parkspacesshare.Comment),
                    new MySqlParameter(ParamLotOwner,parkspacesshare.LotOwner),
                    new MySqlParameter(ParamAuditStatus,parkspacesshare.AuditStatus),
                    new MySqlParameter(ParamLockStatus,parkspacesshare.LockStatus),
                    new MySqlParameter(ParamCreateTime,parkspacesshare.CreateTime),
                    new MySqlParameter(ParamAuditTime,parkspacesshare.AuditTime),
                    new MySqlParameter(ParamAuditDescribe,parkspacesshare.AuditDescribe),
                    new MySqlParameter(ParamPublishstatus,parkspacesshare.Publishstatus),
                    new MySqlParameter(ParamStamp,parkspacesshare.Stamp)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkSpacesShareDb</returns>
        public static ParkSpacesShareDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkSpacesShareDb
                {
                    ID = DbChange.ToString(dr["ID"]),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    ParkName = DbChange.ToString(dr["ParkName"]),
                    Library = DbChange.ToString(dr["Library"]),
                    Lot = DbChange.ToString(dr["Lot"]),
                    SapceCode = DbChange.ToString(dr["SapceCode"]),
                    Describe = DbChange.ToString(dr["Describe"]),
                    Comment = DbChange.ToString(dr["Comment"]),
                    LotOwner = DbChange.ToInt(dr["LotOwner"],0),
                    AuditStatus = DbChange.ToInt(dr["AuditStatus"],0),
                    LockStatus = DbChange.ToInt(dr["LockStatus"],-1),
                    CreateTime = DbChange.ToDateTime(dr["CreateTime"],DateTime.MinValue),
                    AuditTime = DbChange.ToDateTime(dr["AuditTime"],DateTime.MinValue),
                    AuditDescribe = DbChange.ToString(dr["AuditDescribe"]),
                    Publishstatus = DbChange.ToInt(dr["Publishstatus"],-1),
                    Stamp = DbChange.ToDateTime(dr["Stamp"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkSpacesShareDb</returns>
        public static List<ParkSpacesShareDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkSpacesShareDb>(); 
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

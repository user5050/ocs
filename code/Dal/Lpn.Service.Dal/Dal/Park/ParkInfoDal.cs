using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_info]停车场信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_info]停车场信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkinfo(`AreaCode`,`ParkName`,`ImgUrl`,`ParkTel`,`ParkAddr`,`ParkCompany`,`ParkOperator`,`ParkIssued`,`ParkLotPlan`,`ParkLotAll`,`ParkLotNomechanical`,`ParkLotMechanical`,`ParkLotOperate`,`ParkLotVip`,`IfConnect`,`IP`,`Port`,`RecordType`,`ParkCode`,`ParkType`,`ParkSort`,`ParkIn`,`ParkOut`,`StartTime`,`EndTime`,`Enabled`,`AccessTime`,`EncryptPwd`,`CADUrl`,`ParkStatus`,`UpdateTime`,`freeexittime`,`parkfeesummary`,`markdesc`,`tmppayconfirm`,`timefix`,`City`,`FixLimtTime`,`paperdedu`,`fixaccred`,`ismember`) values(?AreaCode,?ParkName,?ImgUrl,?ParkTel,?ParkAddr,?ParkCompany,?ParkOperator,?ParkIssued,?ParkLotPlan,?ParkLotAll,?ParkLotNomechanical,?ParkLotMechanical,?ParkLotOperate,?ParkLotVip,?IfConnect,?IP,?Port,?RecordType,?ParkCode,?ParkType,?ParkSort,?ParkIn,?ParkOut,?StartTime,?EndTime,?Enabled,?AccessTime,?EncryptPwd,?CADUrl,?ParkStatus,?UpdateTime,?freeexittime,?parkfeesummary,?markdesc,?tmppayconfirm,?timefix,?City,?FixLimtTime,?paperdedu,?fixaccred,?ismember);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkinfo where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkinfo set `AreaCode`=?AreaCode,`ParkName`=?ParkName,`ImgUrl`=?ImgUrl,`ParkTel`=?ParkTel,`ParkAddr`=?ParkAddr,`ParkCompany`=?ParkCompany,`ParkOperator`=?ParkOperator,`ParkIssued`=?ParkIssued,`ParkLotPlan`=?ParkLotPlan,`ParkLotAll`=?ParkLotAll,`ParkLotNomechanical`=?ParkLotNomechanical,`ParkLotMechanical`=?ParkLotMechanical,`ParkLotOperate`=?ParkLotOperate,`ParkLotVip`=?ParkLotVip,`IfConnect`=?IfConnect,`IP`=?IP,`Port`=?Port,`RecordType`=?RecordType,`ParkCode`=?ParkCode,`ParkType`=?ParkType,`ParkSort`=?ParkSort,`ParkIn`=?ParkIn,`ParkOut`=?ParkOut,`StartTime`=?StartTime,`EndTime`=?EndTime,`Enabled`=?Enabled,`AccessTime`=?AccessTime,`EncryptPwd`=?EncryptPwd,`CADUrl`=?CADUrl,`ParkStatus`=?ParkStatus,`UpdateTime`=?UpdateTime,`freeexittime`=?freeexittime,`parkfeesummary`=?parkfeesummary,`markdesc`=?markdesc,`tmppayconfirm`=?tmppayconfirm,`timefix`=?timefix,`City`=?City,`FixLimtTime`=?FixLimtTime,`paperdedu`=?paperdedu,`fixaccred`=?fixaccred,`ismember`=?ismember where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkinfo  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamAreaCode = "?AreaCode";
        protected const string ParamParkName = "?ParkName";
        protected const string ParamImgUrl = "?ImgUrl";
        protected const string ParamParkTel = "?ParkTel";
        protected const string ParamParkAddr = "?ParkAddr";
        protected const string ParamParkCompany = "?ParkCompany";
        protected const string ParamParkOperator = "?ParkOperator";
        protected const string ParamParkIssued = "?ParkIssued";
        protected const string ParamParkLotPlan = "?ParkLotPlan";
        protected const string ParamParkLotAll = "?ParkLotAll";
        protected const string ParamParkLotNomechanical = "?ParkLotNomechanical";
        protected const string ParamParkLotMechanical = "?ParkLotMechanical";
        protected const string ParamParkLotOperate = "?ParkLotOperate";
        protected const string ParamParkLotVip = "?ParkLotVip";
        protected const string ParamIfConnect = "?IfConnect";
        protected const string ParamIP = "?IP";
        protected const string ParamPort = "?Port";
        protected const string ParamRecordType = "?RecordType";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamParkType = "?ParkType";
        protected const string ParamParkSort = "?ParkSort";
        protected const string ParamParkIn = "?ParkIn";
        protected const string ParamParkOut = "?ParkOut";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamEndTime = "?EndTime";
        protected const string ParamEnabled = "?Enabled";
        protected const string ParamAccessTime = "?AccessTime";
        protected const string ParamEncryptPwd = "?EncryptPwd";
        protected const string ParamCADUrl = "?CADUrl";
        protected const string ParamParkStatus = "?ParkStatus";
        protected const string ParamUpdateTime = "?UpdateTime";
        protected const string Paramfreeexittime = "?freeexittime";
        protected const string Paramparkfeesummary = "?parkfeesummary";
        protected const string Parammarkdesc = "?markdesc";
        protected const string Paramtmppayconfirm = "?tmppayconfirm";
        protected const string Paramtimefix = "?timefix";
        protected const string ParamCity = "?City";
        protected const string ParamFixLimtTime = "?FixLimtTime";
        protected const string Parampaperdedu = "?paperdedu";
        protected const string Paramfixaccred = "?fixaccred";
        protected const string Paramismember = "?ismember";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkInfoDb</returns>
        public static List<ParkInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkInfoDb parkinfo)
        {
            var param= GetInsertParams(parkinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">停车场编号</param> 
        /// <returns>ParkInfoDb</returns>
        public static ParkInfoDb  GetByPriKey(int id)
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
        /// <param name="parkinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkInfoDb parkinfo)
        {
            var param= GetUpdateParams(parkinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">停车场编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkInfoDb parkinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkinfo.ID),
                    new MySqlParameter(ParamAreaCode,parkinfo.AreaCode),
                    new MySqlParameter(ParamParkName,parkinfo.ParkName),
                    new MySqlParameter(ParamImgUrl,parkinfo.ImgUrl),
                    new MySqlParameter(ParamParkTel,parkinfo.ParkTel),
                    new MySqlParameter(ParamParkAddr,parkinfo.ParkAddr),
                    new MySqlParameter(ParamParkCompany,parkinfo.ParkCompany),
                    new MySqlParameter(ParamParkOperator,parkinfo.ParkOperator),
                    new MySqlParameter(ParamParkIssued,parkinfo.ParkIssued),
                    new MySqlParameter(ParamParkLotPlan,parkinfo.ParkLotPlan),
                    new MySqlParameter(ParamParkLotAll,parkinfo.ParkLotAll),
                    new MySqlParameter(ParamParkLotNomechanical,parkinfo.ParkLotNomechanical),
                    new MySqlParameter(ParamParkLotMechanical,parkinfo.ParkLotMechanical),
                    new MySqlParameter(ParamParkLotOperate,parkinfo.ParkLotOperate),
                    new MySqlParameter(ParamParkLotVip,parkinfo.ParkLotVip),
                    new MySqlParameter(ParamIfConnect,parkinfo.IfConnect),
                    new MySqlParameter(ParamIP,parkinfo.IP),
                    new MySqlParameter(ParamPort,parkinfo.Port),
                    new MySqlParameter(ParamRecordType,parkinfo.RecordType),
                    new MySqlParameter(ParamParkCode,parkinfo.ParkCode),
                    new MySqlParameter(ParamParkType,parkinfo.ParkType),
                    new MySqlParameter(ParamParkSort,parkinfo.ParkSort),
                    new MySqlParameter(ParamParkIn,parkinfo.ParkIn),
                    new MySqlParameter(ParamParkOut,parkinfo.ParkOut),
                    new MySqlParameter(ParamStartTime,parkinfo.StartTime),
                    new MySqlParameter(ParamEndTime,parkinfo.EndTime),
                    new MySqlParameter(ParamEnabled,parkinfo.Enabled),
                    new MySqlParameter(ParamAccessTime,parkinfo.AccessTime),
                    new MySqlParameter(ParamEncryptPwd,parkinfo.EncryptPwd),
                    new MySqlParameter(ParamCADUrl,parkinfo.CADUrl),
                    new MySqlParameter(ParamParkStatus,parkinfo.ParkStatus),
                    new MySqlParameter(ParamUpdateTime,parkinfo.UpdateTime),
                    new MySqlParameter(Paramfreeexittime,parkinfo.Freeexittime),
                    new MySqlParameter(Paramparkfeesummary,parkinfo.Parkfeesummary),
                    new MySqlParameter(Parammarkdesc,parkinfo.Markdesc),
                    new MySqlParameter(Paramtmppayconfirm,parkinfo.Tmppayconfirm),
                    new MySqlParameter(Paramtimefix,parkinfo.Timefix),
                    new MySqlParameter(ParamCity,parkinfo.City),
                    new MySqlParameter(ParamFixLimtTime,parkinfo.FixLimtTime),
                    new MySqlParameter(Parampaperdedu,parkinfo.Paperdedu),
                    new MySqlParameter(Paramfixaccred,parkinfo.Fixaccred),
                    new MySqlParameter(Paramismember,parkinfo.Ismember)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkInfoDb parkinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamAreaCode,parkinfo.AreaCode),
                    new MySqlParameter(ParamParkName,parkinfo.ParkName),
                    new MySqlParameter(ParamImgUrl,parkinfo.ImgUrl),
                    new MySqlParameter(ParamParkTel,parkinfo.ParkTel),
                    new MySqlParameter(ParamParkAddr,parkinfo.ParkAddr),
                    new MySqlParameter(ParamParkCompany,parkinfo.ParkCompany),
                    new MySqlParameter(ParamParkOperator,parkinfo.ParkOperator),
                    new MySqlParameter(ParamParkIssued,parkinfo.ParkIssued),
                    new MySqlParameter(ParamParkLotPlan,parkinfo.ParkLotPlan),
                    new MySqlParameter(ParamParkLotAll,parkinfo.ParkLotAll),
                    new MySqlParameter(ParamParkLotNomechanical,parkinfo.ParkLotNomechanical),
                    new MySqlParameter(ParamParkLotMechanical,parkinfo.ParkLotMechanical),
                    new MySqlParameter(ParamParkLotOperate,parkinfo.ParkLotOperate),
                    new MySqlParameter(ParamParkLotVip,parkinfo.ParkLotVip),
                    new MySqlParameter(ParamIfConnect,parkinfo.IfConnect),
                    new MySqlParameter(ParamIP,parkinfo.IP),
                    new MySqlParameter(ParamPort,parkinfo.Port),
                    new MySqlParameter(ParamRecordType,parkinfo.RecordType),
                    new MySqlParameter(ParamParkCode,parkinfo.ParkCode),
                    new MySqlParameter(ParamParkType,parkinfo.ParkType),
                    new MySqlParameter(ParamParkSort,parkinfo.ParkSort),
                    new MySqlParameter(ParamParkIn,parkinfo.ParkIn),
                    new MySqlParameter(ParamParkOut,parkinfo.ParkOut),
                    new MySqlParameter(ParamStartTime,parkinfo.StartTime),
                    new MySqlParameter(ParamEndTime,parkinfo.EndTime),
                    new MySqlParameter(ParamEnabled,parkinfo.Enabled),
                    new MySqlParameter(ParamAccessTime,parkinfo.AccessTime),
                    new MySqlParameter(ParamEncryptPwd,parkinfo.EncryptPwd),
                    new MySqlParameter(ParamCADUrl,parkinfo.CADUrl),
                    new MySqlParameter(ParamParkStatus,parkinfo.ParkStatus),
                    new MySqlParameter(ParamUpdateTime,parkinfo.UpdateTime),
                    new MySqlParameter(Paramfreeexittime,parkinfo.Freeexittime),
                    new MySqlParameter(Paramparkfeesummary,parkinfo.Parkfeesummary),
                    new MySqlParameter(Parammarkdesc,parkinfo.Markdesc),
                    new MySqlParameter(Paramtmppayconfirm,parkinfo.Tmppayconfirm),
                    new MySqlParameter(Paramtimefix,parkinfo.Timefix),
                    new MySqlParameter(ParamCity,parkinfo.City),
                    new MySqlParameter(ParamFixLimtTime,parkinfo.FixLimtTime),
                    new MySqlParameter(Parampaperdedu,parkinfo.Paperdedu),
                    new MySqlParameter(Paramfixaccred,parkinfo.Fixaccred),
                    new MySqlParameter(Paramismember,parkinfo.Ismember)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkInfoDb</returns>
        public static ParkInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkInfoDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    AreaCode = DbChange.ToString(dr["AreaCode"]),
                    ParkName = DbChange.ToString(dr["ParkName"]),
                    ImgUrl = DbChange.ToString(dr["ImgUrl"]),
                    ParkTel = DbChange.ToString(dr["ParkTel"]),
                    ParkAddr = DbChange.ToString(dr["ParkAddr"]),
                    ParkCompany = DbChange.ToString(dr["ParkCompany"]),
                    ParkOperator = DbChange.ToString(dr["ParkOperator"]),
                    ParkIssued = DbChange.ToString(dr["ParkIssued"]),
                    ParkLotPlan = DbChange.ToInt(dr["ParkLotPlan"],0),
                    ParkLotAll = DbChange.ToInt(dr["ParkLotAll"],0),
                    ParkLotNomechanical = DbChange.ToInt(dr["ParkLotNomechanical"],0),
                    ParkLotMechanical = DbChange.ToInt(dr["ParkLotMechanical"],0),
                    ParkLotOperate = DbChange.ToInt(dr["ParkLotOperate"],0),
                    ParkLotVip = DbChange.ToInt(dr["ParkLotVip"],0),
                    IfConnect = DbChange.ToInt(dr["IfConnect"],0),
                    IP = DbChange.ToString(dr["IP"]),
                    Port = DbChange.ToInt(dr["Port"],0),
                    RecordType = DbChange.ToInt(dr["RecordType"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    ParkType = DbChange.ToString(dr["ParkType"]),
                    ParkSort = DbChange.ToString(dr["ParkSort"]),
                    ParkIn = DbChange.ToInt(dr["ParkIn"],0),
                    ParkOut = DbChange.ToInt(dr["ParkOut"],0),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["EndTime"],DateTime.MinValue),
                    Enabled = DbChange.ToInt(dr["Enabled"],-1),
                    AccessTime = DbChange.ToDateTime(dr["AccessTime"],DateTime.MinValue),
                    EncryptPwd = DbChange.ToString(dr["EncryptPwd"]),
                    CADUrl = DbChange.ToString(dr["CADUrl"]),
                    ParkStatus = DbChange.ToInt(dr["ParkStatus"],0),
                    UpdateTime = DbChange.ToString(dr["UpdateTime"]),
                    Freeexittime = DbChange.ToInt(dr["freeexittime"],0),
                    Parkfeesummary = DbChange.ToString(dr["parkfeesummary"]),
                    Markdesc = DbChange.ToString(dr["markdesc"]),
                    Tmppayconfirm = DbChange.ToString(dr["tmppayconfirm"]),
                    Timefix = DbChange.ToString(dr["timefix"]),
                    City = DbChange.ToString(dr["City"]),
                    FixLimtTime = DbChange.ToDateTime(dr["FixLimtTime"],DateTime.MinValue),
                    Paperdedu = DbChange.ToString(dr["paperdedu"]),
                    Fixaccred = DbChange.ToString(dr["fixaccred"]),
                    Ismember = DbChange.ToString(dr["ismember"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkInfoDb</returns>
        public static List<ParkInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkInfoDb>(); 
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

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_account_info]停车场结算信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_account_info]停车场结算信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkAccountInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkaccountinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkaccountinfo(`ParkID`,`AccountName`,`AccountNo`,`BankName`,`SettlementType`,`SettlementInterval`,`Contactor`,`ContactPhone`,`Opreator`) values(?ParkID,?AccountName,?AccountNo,?BankName,?SettlementType,?SettlementInterval,?Contactor,?ContactPhone,?Opreator);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkaccountinfo where `ParkID`=?ParkID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkaccountinfo set `AccountName`=?AccountName,`AccountNo`=?AccountNo,`BankName`=?BankName,`SettlementType`=?SettlementType,`SettlementInterval`=?SettlementInterval,`Contactor`=?Contactor,`ContactPhone`=?ContactPhone,`Opreator`=?Opreator where `ParkID`=?ParkID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkaccountinfo  where `ParkID`=?ParkID;";
        #endregion

        #region 参数
        protected const string ParamParkID = "?ParkID";
        protected const string ParamAccountName = "?AccountName";
        protected const string ParamAccountNo = "?AccountNo";
        protected const string ParamBankName = "?BankName";
        protected const string ParamSettlementType = "?SettlementType";
        protected const string ParamSettlementInterval = "?SettlementInterval";
        protected const string ParamContactor = "?Contactor";
        protected const string ParamContactPhone = "?ContactPhone";
        protected const string ParamOpreator = "?Opreator";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkAccountInfoDb</returns>
        public static List<ParkAccountInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkaccountinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkAccountInfoDb parkaccountinfo)
        {
            var param= GetInsertParams(parkaccountinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="parkID">停车场编号</param> 
        /// <returns>ParkAccountInfoDb</returns>
        public static ParkAccountInfoDb  GetByPriKey(int parkID)
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
        /// <param name="parkaccountinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkAccountInfoDb parkaccountinfo)
        {
            var param= GetUpdateParams(parkaccountinfo);
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
        public static MySqlParameter[]  GetUpdateParams(ParkAccountInfoDb parkaccountinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parkaccountinfo.ParkID),
                    new MySqlParameter(ParamAccountName,parkaccountinfo.AccountName),
                    new MySqlParameter(ParamAccountNo,parkaccountinfo.AccountNo),
                    new MySqlParameter(ParamBankName,parkaccountinfo.BankName),
                    new MySqlParameter(ParamSettlementType,parkaccountinfo.SettlementType),
                    new MySqlParameter(ParamSettlementInterval,parkaccountinfo.SettlementInterval),
                    new MySqlParameter(ParamContactor,parkaccountinfo.Contactor),
                    new MySqlParameter(ParamContactPhone,parkaccountinfo.ContactPhone),
                    new MySqlParameter(ParamOpreator,parkaccountinfo.Opreator)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkAccountInfoDb parkaccountinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parkaccountinfo.ParkID),
                    new MySqlParameter(ParamAccountName,parkaccountinfo.AccountName),
                    new MySqlParameter(ParamAccountNo,parkaccountinfo.AccountNo),
                    new MySqlParameter(ParamBankName,parkaccountinfo.BankName),
                    new MySqlParameter(ParamSettlementType,parkaccountinfo.SettlementType),
                    new MySqlParameter(ParamSettlementInterval,parkaccountinfo.SettlementInterval),
                    new MySqlParameter(ParamContactor,parkaccountinfo.Contactor),
                    new MySqlParameter(ParamContactPhone,parkaccountinfo.ContactPhone),
                    new MySqlParameter(ParamOpreator,parkaccountinfo.Opreator)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkAccountInfoDb</returns>
        public static ParkAccountInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkAccountInfoDb
                {
                    ParkID = DbChange.ToInt(dr["ParkID"],0),
                    AccountName = DbChange.ToString(dr["AccountName"]),
                    AccountNo = DbChange.ToString(dr["AccountNo"]),
                    BankName = DbChange.ToString(dr["BankName"]),
                    SettlementType = DbChange.ToInt(dr["SettlementType"],0),
                    SettlementInterval = DbChange.ToInt(dr["SettlementInterval"],0),
                    Contactor = DbChange.ToString(dr["Contactor"]),
                    ContactPhone = DbChange.ToString(dr["ContactPhone"]),
                    Opreator = DbChange.ToInt(dr["Opreator"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkAccountInfoDb</returns>
        public static List<ParkAccountInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkAccountInfoDb>(); 
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

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysBannerDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from sys_banner;";
        //新增插入语句
        protected const string SqlInsert = "insert into sys_banner(`Img`,`Desc`,`TimeOutType`,`TimeOutDesc`,`SendType`,`SendDesc`,`TransferType`,`Transfer`,`OperateTime`,`Operater`,`state`,`order`) values(?Img,?Desc,?TimeOutType,?TimeOutDesc,?SendType,?SendDesc,?TransferType,?Transfer,?OperateTime,?Operater,?state,?order);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from sys_banner where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update sys_banner set `Img`=?Img,`Desc`=?Desc,`TimeOutType`=?TimeOutType,`TimeOutDesc`=?TimeOutDesc,`SendType`=?SendType,`SendDesc`=?SendDesc,`TransferType`=?TransferType,`Transfer`=?Transfer,`OperateTime`=?OperateTime,`Operater`=?Operater,`state`=?state,`order`=?order where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from sys_banner  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamImg = "?Img";
        protected const string ParamDesc = "?Desc";
        protected const string ParamTimeOutType = "?TimeOutType";
        protected const string ParamTimeOutDesc = "?TimeOutDesc";
        protected const string ParamSendType = "?SendType";
        protected const string ParamSendDesc = "?SendDesc";
        protected const string ParamTransferType = "?TransferType";
        protected const string ParamTransfer = "?Transfer";
        protected const string ParamOperateTime = "?OperateTime";
        protected const string ParamOperater = "?Operater";
        protected const string Paramstate = "?state";
        protected const string Paramorder = "?order";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysBannerDb</returns>
        public static List<SysBannerDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sysbanner">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysBannerDb sysbanner)
        {
            var param= GetInsertParams(sysbanner);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">自增编号</param> 
        /// <returns>SysBannerDb</returns>
        public static SysBannerDb  GetByPriKey(int id)
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
        /// <param name="sysbanner">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SysBannerDb sysbanner)
        {
            var param= GetUpdateParams(sysbanner);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">自增编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(SysBannerDb sysbanner)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,sysbanner.ID),
                    new MySqlParameter(ParamImg,sysbanner.Img),
                    new MySqlParameter(ParamDesc,sysbanner.Desc),
                    new MySqlParameter(ParamTimeOutType,sysbanner.TimeOutType),
                    new MySqlParameter(ParamTimeOutDesc,sysbanner.TimeOutDesc),
                    new MySqlParameter(ParamSendType,sysbanner.SendType),
                    new MySqlParameter(ParamSendDesc,sysbanner.SendDesc),
                    new MySqlParameter(ParamTransferType,sysbanner.TransferType),
                    new MySqlParameter(ParamTransfer,sysbanner.Transfer),
                    new MySqlParameter(ParamOperateTime,sysbanner.OperateTime),
                    new MySqlParameter(ParamOperater,sysbanner.Operater),
                    new MySqlParameter(Paramstate,sysbanner.State),
                    new MySqlParameter(Paramorder,sysbanner.Order)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysBannerDb sysbanner)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamImg,sysbanner.Img),
                    new MySqlParameter(ParamDesc,sysbanner.Desc),
                    new MySqlParameter(ParamTimeOutType,sysbanner.TimeOutType),
                    new MySqlParameter(ParamTimeOutDesc,sysbanner.TimeOutDesc),
                    new MySqlParameter(ParamSendType,sysbanner.SendType),
                    new MySqlParameter(ParamSendDesc,sysbanner.SendDesc),
                    new MySqlParameter(ParamTransferType,sysbanner.TransferType),
                    new MySqlParameter(ParamTransfer,sysbanner.Transfer),
                    new MySqlParameter(ParamOperateTime,sysbanner.OperateTime),
                    new MySqlParameter(ParamOperater,sysbanner.Operater),
                    new MySqlParameter(Paramstate,sysbanner.State),
                    new MySqlParameter(Paramorder,sysbanner.Order)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysBannerDb</returns>
        public static SysBannerDb  ConvertToObject(DataRow dr)
        {
            var data = new SysBannerDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    Img = DbChange.ToString(dr["Img"]),
                    Desc = DbChange.ToString(dr["Desc"]),
                    TimeOutType = DbChange.ToInt(dr["TimeOutType"],0),
                    TimeOutDesc = DbChange.ToDateTime(dr["TimeOutDesc"],DateTime.MinValue),
                    SendType = DbChange.ToInt(dr["SendType"],0),
                    SendDesc = DbChange.ToString(dr["SendDesc"]),
                    TransferType = DbChange.ToInt(dr["TransferType"],0),
                    Transfer = DbChange.ToString(dr["Transfer"]),
                    OperateTime = DbChange.ToDateTime(dr["OperateTime"],DateTime.MinValue),
                    Operater = DbChange.ToInt(dr["Operater"],0),
                    State = DbChange.ToInt(dr["state"],0),
                    Order = DbChange.ToInt(dr["order"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysBannerDb</returns>
        public static List<SysBannerDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysBannerDb>(); 
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

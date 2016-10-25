using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_lock_share]车位锁分享 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_lock_share]车位锁分享 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkLockShareDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parklockshare;";
        //新增插入语句
        protected const string SqlInsert = "insert into parklockshare(`ShareID`,`UserID`) values(?ShareID,?UserID);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parklockshare where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parklockshare set `ShareID`=?ShareID,`UserID`=?UserID where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parklockshare  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamShareID = "?ShareID";
        protected const string ParamUserID = "?UserID";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkLockShareDb</returns>
        public static List<ParkLockShareDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parklockshare">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkLockShareDb parklockshare)
        {
            var param= GetInsertParams(parklockshare);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">车位锁分享编号</param> 
        /// <returns>ParkLockShareDb</returns>
        public static ParkLockShareDb  GetByPriKey(int id)
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
        /// <param name="parklockshare">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkLockShareDb parklockshare)
        {
            var param= GetUpdateParams(parklockshare);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">车位锁分享编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkLockShareDb parklockshare)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parklockshare.ID),
                    new MySqlParameter(ParamShareID,parklockshare.ShareID),
                    new MySqlParameter(ParamUserID,parklockshare.UserID)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkLockShareDb parklockshare)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamShareID,parklockshare.ShareID),
                    new MySqlParameter(ParamUserID,parklockshare.UserID)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkLockShareDb</returns>
        public static ParkLockShareDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkLockShareDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ShareID = DbChange.ToInt(dr["ShareID"],0),
                    UserID = DbChange.ToInt(dr["UserID"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkLockShareDb</returns>
        public static List<ParkLockShareDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkLockShareDb>(); 
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

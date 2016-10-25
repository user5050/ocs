using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_spaces_share_subscribe_detail] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_spaces_share_subscribe_detail] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkSpacesShareSubscribeDetailDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkspacessharesubscribedetail;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkspacessharesubscribedetail(`ID`,`subscribeTime`,`Minutes`) values(?ID,?subscribeTime,?Minutes);";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamsubscribeTime = "?subscribeTime";
        protected const string ParamMinutes = "?Minutes";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkSpacesShareSubscribeDetailDb</returns>
        public static List<ParkSpacesShareSubscribeDetailDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkspacessharesubscribedetail">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkSpacesShareSubscribeDetailDb parkspacessharesubscribedetail)
        {
            var param= GetInsertParams(parkspacessharesubscribedetail);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkSpacesShareSubscribeDetailDb parkspacessharesubscribedetail)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkspacessharesubscribedetail.ID),
                    new MySqlParameter(ParamsubscribeTime,parkspacessharesubscribedetail.SubscribeTime),
                    new MySqlParameter(ParamMinutes,parkspacessharesubscribedetail.Minutes)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkSpacesShareSubscribeDetailDb</returns>
        public static ParkSpacesShareSubscribeDetailDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkSpacesShareSubscribeDetailDb
                {
                    ID = DbChange.ToString(dr["ID"]),
                    SubscribeTime = DbChange.ToDateTime(dr["subscribeTime"],DateTime.MinValue),
                    Minutes = DbChange.ToInt(dr["Minutes"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkSpacesShareSubscribeDetailDb</returns>
        public static List<ParkSpacesShareSubscribeDetailDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkSpacesShareSubscribeDetailDb>(); 
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

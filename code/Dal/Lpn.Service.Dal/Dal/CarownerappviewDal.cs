using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db;

/*
* 由自动生成工具完成
* 描述:VIEW Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal
{
    /// <summary>
    /// VIEW Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CarownerappviewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from carownerappview;";
        //新增插入语句
        protected const string SqlInsert = "insert into carownerappview(`id`,`carno`,`userid`,`img`,`username`,`state`) values(?id,?carno,?userid,?img,?username,?state);";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramcarno = "?carno";
        protected const string Paramuserid = "?userid";
        protected const string Paramimg = "?img";
        protected const string Paramusername = "?username";
        protected const string Paramstate = "?state";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CarownerappviewDb</returns>
        public static List<CarownerappviewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="carownerappview">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CarownerappviewDb carownerappview)
        {
            var param= GetInsertParams(carownerappview);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CarownerappviewDb carownerappview)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,carownerappview.Id),
                    new MySqlParameter(Paramcarno,carownerappview.Carno),
                    new MySqlParameter(Paramuserid,carownerappview.Userid),
                    new MySqlParameter(Paramimg,carownerappview.Img),
                    new MySqlParameter(Paramusername,carownerappview.Username),
                    new MySqlParameter(Paramstate,carownerappview.State)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CarownerappviewDb</returns>
        public static CarownerappviewDb  ConvertToObject(DataRow dr)
        {
            var data = new CarownerappviewDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    Carno = DbChange.ToString(dr["carno"]),
                    Userid = DbChange.ToInt(dr["userid"],0),
                    Img = DbChange.ToString(dr["img"]),
                    Username = DbChange.ToString(dr["username"]),
                    State = DbChange.ToInt(dr["state"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CarownerappviewDb</returns>
        public static List<CarownerappviewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CarownerappviewDb>(); 
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

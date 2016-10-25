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
    public partial class CarownerviewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from carownerview;";
        //新增插入语句
        protected const string SqlInsert = "insert into carownerview(`id`,`carno`,`carbrand`,`color`,`username`,`isregdit`,`img`) values(?id,?carno,?carbrand,?color,?username,?isregdit,?img);";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramcarno = "?carno";
        protected const string Paramcarbrand = "?carbrand";
        protected const string Paramcolor = "?color";
        protected const string Paramusername = "?username";
        protected const string Paramisregdit = "?isregdit";
        protected const string Paramimg = "?img";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CarownerviewDb</returns>
        public static List<CarownerviewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="carownerview">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CarownerviewDb carownerview)
        {
            var param= GetInsertParams(carownerview);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CarownerviewDb carownerview)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,carownerview.Id),
                    new MySqlParameter(Paramcarno,carownerview.Carno),
                    new MySqlParameter(Paramcarbrand,carownerview.Carbrand),
                    new MySqlParameter(Paramcolor,carownerview.Color),
                    new MySqlParameter(Paramusername,carownerview.Username),
                    new MySqlParameter(Paramisregdit,carownerview.Isregdit),
                    new MySqlParameter(Paramimg,carownerview.Img)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CarownerviewDb</returns>
        public static CarownerviewDb  ConvertToObject(DataRow dr)
        {
            var data = new CarownerviewDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    Carno = DbChange.ToString(dr["carno"]),
                    Carbrand = DbChange.ToString(dr["carbrand"]),
                    Color = DbChange.ToString(dr["color"]),
                    Username = DbChange.ToString(dr["username"]),
                    Isregdit = DbChange.ToInt(dr["isregdit"],-1),
                    Img = DbChange.ToString(dr["img"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CarownerviewDb</returns>
        public static List<CarownerviewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CarownerviewDb>(); 
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

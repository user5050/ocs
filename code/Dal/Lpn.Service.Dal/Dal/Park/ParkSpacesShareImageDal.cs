using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_spaces_share_image] Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_spaces_share_image] Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkSpacesShareImageDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkspacesshareimage;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkspacesshareimage(`SpaceID`,`IDX`,`Picture`,`Stamp`) values(?SpaceID,?IDX,?Picture,?Stamp);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkspacesshareimage where `SpaceID`=?SpaceID and `IDX`=?IDX;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkspacesshareimage set `Picture`=?Picture,`Stamp`=?Stamp where `SpaceID`=?SpaceID and `IDX`=?IDX;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkspacesshareimage  where `SpaceID`=?SpaceID and `IDX`=?IDX;";
        #endregion

        #region 参数
        protected const string ParamSpaceID = "?SpaceID";
        protected const string ParamIDX = "?IDX";
        protected const string ParamPicture = "?Picture";
        protected const string ParamStamp = "?Stamp";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkSpacesShareImageDb</returns>
        public static List<ParkSpacesShareImageDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkspacesshareimage">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkSpacesShareImageDb parkspacesshareimage)
        {
            var param= GetInsertParams(parkspacesshareimage);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="spaceID"></param> 
        /// <param name="iDX"></param> 
        /// <returns>ParkSpacesShareImageDb</returns>
        public static ParkSpacesShareImageDb  GetByPriKey(string spaceID,int iDX)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSpaceID,spaceID),
                    new MySqlParameter(ParamIDX,iDX)
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
        /// <param name="parkspacesshareimage">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkSpacesShareImageDb parkspacesshareimage)
        {
            var param= GetUpdateParams(parkspacesshareimage);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="spaceID"></param> 
        /// <param name="iDX"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string spaceID,int iDX)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSpaceID,spaceID),
                    new MySqlParameter(ParamIDX,iDX)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ParkSpacesShareImageDb parkspacesshareimage)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSpaceID,parkspacesshareimage.SpaceID),
                    new MySqlParameter(ParamIDX,parkspacesshareimage.IDX),
                    new MySqlParameter(ParamPicture,parkspacesshareimage.Picture),
                    new MySqlParameter(ParamStamp,parkspacesshareimage.Stamp)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkSpacesShareImageDb parkspacesshareimage)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSpaceID,parkspacesshareimage.SpaceID),
                    new MySqlParameter(ParamIDX,parkspacesshareimage.IDX),
                    new MySqlParameter(ParamPicture,parkspacesshareimage.Picture),
                    new MySqlParameter(ParamStamp,parkspacesshareimage.Stamp)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkSpacesShareImageDb</returns>
        public static ParkSpacesShareImageDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkSpacesShareImageDb
                {
                    SpaceID = DbChange.ToString(dr["SpaceID"]),
                    IDX = DbChange.ToInt(dr["IDX"],0),
                    Picture = DbChange.ToString(dr["Picture"]),
                    Stamp = DbChange.ToString(dr["Stamp"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkSpacesShareImageDb</returns>
        public static List<ParkSpacesShareImageDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkSpacesShareImageDb>(); 
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

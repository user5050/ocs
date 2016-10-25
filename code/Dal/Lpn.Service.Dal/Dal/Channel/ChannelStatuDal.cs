using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Channel;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Channel
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ChannelStatuDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from channel_status;";
        //新增插入语句
        protected const string SqlInsert = "insert into channel_status(`ParkId`,`ChannelId`,`ChannelName`,`WSLastOnline`,`WSName`,`CameraStatus`,`ChannelStatus`,`VoiceStatus`,`ScreenStatus`,`FullScrennStatus`,`WSStatus`,`CameraLastOnline`) values(?ParkId,?ChannelId,?ChannelName,?WSLastOnline,?WSName,?CameraStatus,?ChannelStatus,?VoiceStatus,?ScreenStatus,?FullScrennStatus,?WSStatus,?CameraLastOnline);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from channel_status where `ParkId`=?ParkId and `ChannelId`=?ChannelId;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update channel_status set `ChannelName`=?ChannelName,`WSLastOnline`=?WSLastOnline,`WSName`=?WSName,`CameraStatus`=?CameraStatus,`ChannelStatus`=?ChannelStatus,`VoiceStatus`=?VoiceStatus,`ScreenStatus`=?ScreenStatus,`FullScrennStatus`=?FullScrennStatus,`WSStatus`=?WSStatus,`CameraLastOnline`=?CameraLastOnline where `ParkId`=?ParkId and `ChannelId`=?ChannelId;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from channel_status  where `ParkId`=?ParkId and `ChannelId`=?ChannelId;";
        #endregion

        #region 参数
        protected const string ParamParkId = "?ParkId";
        protected const string ParamChannelId = "?ChannelId";
        protected const string ParamChannelName = "?ChannelName";
        protected const string ParamWSLastOnline = "?WSLastOnline";
        protected const string ParamWSName = "?WSName";
        protected const string ParamCameraStatus = "?CameraStatus";
        protected const string ParamChannelStatus = "?ChannelStatus";
        protected const string ParamVoiceStatus = "?VoiceStatus";
        protected const string ParamScreenStatus = "?ScreenStatus";
        protected const string ParamFullScrennStatus = "?FullScrennStatus";
        protected const string ParamWSStatus = "?WSStatus";
        protected const string ParamCameraLastOnline = "?CameraLastOnline";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ChannelStatuDb</returns>
        public static List<ChannelStatuDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="channelstatu">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ChannelStatuDb channelstatu)
        {
            var param= GetInsertParams(channelstatu);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="parkId"></param> 
        /// <param name="channelId">通道ID</param> 
        /// <returns>ChannelStatuDb</returns>
        public static ChannelStatuDb  GetByPriKey(int parkId,int channelId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkId,parkId),
                    new MySqlParameter(ParamChannelId,channelId)
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
        /// <param name="channelstatu">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ChannelStatuDb channelstatu)
        {
            var param= GetUpdateParams(channelstatu);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="parkId"></param> 
        /// <param name="channelId">通道ID</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int parkId,int channelId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkId,parkId),
                    new MySqlParameter(ParamChannelId,channelId)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ChannelStatuDb channelstatu)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkId,channelstatu.ParkId),
                    new MySqlParameter(ParamChannelId,channelstatu.ChannelId),
                    new MySqlParameter(ParamChannelName,channelstatu.ChannelName),
                    new MySqlParameter(ParamWSLastOnline,channelstatu.WSLastOnline),
                    new MySqlParameter(ParamWSName,channelstatu.WSName),
                    new MySqlParameter(ParamCameraStatus,channelstatu.CameraStatus),
                    new MySqlParameter(ParamChannelStatus,channelstatu.ChannelStatus),
                    new MySqlParameter(ParamVoiceStatus,channelstatu.VoiceStatus),
                    new MySqlParameter(ParamScreenStatus,channelstatu.ScreenStatus),
                    new MySqlParameter(ParamFullScrennStatus,channelstatu.FullScrennStatus),
                    new MySqlParameter(ParamWSStatus,channelstatu.WSStatus),
                    new MySqlParameter(ParamCameraLastOnline,channelstatu.CameraLastOnline)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ChannelStatuDb channelstatu)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkId,channelstatu.ParkId),
                    new MySqlParameter(ParamChannelId,channelstatu.ChannelId),
                    new MySqlParameter(ParamChannelName,channelstatu.ChannelName),
                    new MySqlParameter(ParamWSLastOnline,channelstatu.WSLastOnline),
                    new MySqlParameter(ParamWSName,channelstatu.WSName),
                    new MySqlParameter(ParamCameraStatus,channelstatu.CameraStatus),
                    new MySqlParameter(ParamChannelStatus,channelstatu.ChannelStatus),
                    new MySqlParameter(ParamVoiceStatus,channelstatu.VoiceStatus),
                    new MySqlParameter(ParamScreenStatus,channelstatu.ScreenStatus),
                    new MySqlParameter(ParamFullScrennStatus,channelstatu.FullScrennStatus),
                    new MySqlParameter(ParamWSStatus,channelstatu.WSStatus),
                    new MySqlParameter(ParamCameraLastOnline,channelstatu.CameraLastOnline)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ChannelStatuDb</returns>
        public static ChannelStatuDb  ConvertToObject(DataRow dr)
        {
            var data = new ChannelStatuDb
                {
                    ParkId = DbChange.ToInt(dr["ParkId"],0),
                    ChannelId = DbChange.ToInt(dr["ChannelId"],0),
                    ChannelName = DbChange.ToString(dr["ChannelName"]),
                    WSLastOnline = DbChange.ToDateTime(dr["WSLastOnline"],DateTime.MinValue),
                    WSName = DbChange.ToString(dr["WSName"]),
                    CameraStatus = DbChange.ToInt(dr["CameraStatus"],0),
                    ChannelStatus = DbChange.ToInt(dr["ChannelStatus"],0),
                    VoiceStatus = DbChange.ToInt(dr["VoiceStatus"],0),
                    ScreenStatus = DbChange.ToInt(dr["ScreenStatus"],0),
                    FullScrennStatus = DbChange.ToInt(dr["FullScrennStatus"],0),
                    WSStatus = DbChange.ToInt(dr["WSStatus"],0),
                    CameraLastOnline = DbChange.ToDateTime(dr["CameraLastOnline"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ChannelStatuDb</returns>
        public static List<ChannelStatuDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ChannelStatuDb>(); 
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

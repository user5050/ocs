using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Partnerpay;

/*
* 由自动生成工具完成
* 描述:合作公司支付平台信息配置 Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Partnerpay
{
    /// <summary>
    /// 合作公司支付平台信息配置 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class PartnerpayPlatformconfigDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from partnerpay_platformconfig;";
        //新增插入语句
        protected const string SqlInsert = "insert into partnerpay_platformconfig(`MchId`,`Platfrom`,`AppId`,`PartnerId`,`SignCert`,`SignCertPwd`,`SignKey`,`EncryptCert`,`PlatfromPublicKey`,`Extre`,`SubMchId`) values(?MchId,?Platfrom,?AppId,?PartnerId,?SignCert,?SignCertPwd,?SignKey,?EncryptCert,?PlatfromPublicKey,?Extre,?SubMchId);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from partnerpay_platformconfig where `MchId`=?MchId and `Platfrom`=?Platfrom and `PartnerId`=?PartnerId;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update partnerpay_platformconfig set `AppId`=?AppId,`SignCert`=?SignCert,`SignCertPwd`=?SignCertPwd,`SignKey`=?SignKey,`EncryptCert`=?EncryptCert,`PlatfromPublicKey`=?PlatfromPublicKey,`Extre`=?Extre,`SubMchId`=?SubMchId where `MchId`=?MchId and `Platfrom`=?Platfrom and `PartnerId`=?PartnerId;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from partnerpay_platformconfig  where `MchId`=?MchId and `Platfrom`=?Platfrom and `PartnerId`=?PartnerId;";
        #endregion

        #region 参数
        protected const string ParamMchId = "?MchId";
        protected const string ParamPlatfrom = "?Platfrom";
        protected const string ParamAppId = "?AppId";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamSignCert = "?SignCert";
        protected const string ParamSignCertPwd = "?SignCertPwd";
        protected const string ParamSignKey = "?SignKey";
        protected const string ParamEncryptCert = "?EncryptCert";
        protected const string ParamPlatfromPublicKey = "?PlatfromPublicKey";
        protected const string ParamExtre = "?Extre";
        protected const string ParamSubMchId = "?SubMchId";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of PartnerpayPlatformconfigDb</returns>
        public static List<PartnerpayPlatformconfigDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="partnerpayplatformconfig">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(PartnerpayPlatformconfigDb partnerpayplatformconfig)
        {
            var param= GetInsertParams(partnerpayplatformconfig);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="mchId">商户ID</param> 
        /// <param name="platfrom">平台类型</param> 
        /// <param name="partnerId">合作商id</param> 
        /// <returns>PartnerpayPlatformconfigDb</returns>
        public static PartnerpayPlatformconfigDb  GetByPriKey(string mchId,int platfrom,string partnerId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamMchId,mchId),
                    new MySqlParameter(ParamPlatfrom,platfrom),
                    new MySqlParameter(ParamPartnerId,partnerId)
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
        /// <param name="partnerpayplatformconfig">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(PartnerpayPlatformconfigDb partnerpayplatformconfig)
        {
            var param= GetUpdateParams(partnerpayplatformconfig);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="mchId">商户ID</param> 
        /// <param name="platfrom">平台类型</param> 
        /// <param name="partnerId">合作商id</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string mchId,int platfrom,string partnerId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamMchId,mchId),
                    new MySqlParameter(ParamPlatfrom,platfrom),
                    new MySqlParameter(ParamPartnerId,partnerId)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(PartnerpayPlatformconfigDb partnerpayplatformconfig)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamMchId,partnerpayplatformconfig.MchId),
                    new MySqlParameter(ParamPlatfrom,partnerpayplatformconfig.Platfrom),
                    new MySqlParameter(ParamAppId,partnerpayplatformconfig.AppId),
                    new MySqlParameter(ParamPartnerId,partnerpayplatformconfig.PartnerId),
                    new MySqlParameter(ParamSignCert,partnerpayplatformconfig.SignCert),
                    new MySqlParameter(ParamSignCertPwd,partnerpayplatformconfig.SignCertPwd),
                    new MySqlParameter(ParamSignKey,partnerpayplatformconfig.SignKey),
                    new MySqlParameter(ParamEncryptCert,partnerpayplatformconfig.EncryptCert),
                    new MySqlParameter(ParamPlatfromPublicKey,partnerpayplatformconfig.PlatfromPublicKey),
                    new MySqlParameter(ParamExtre,partnerpayplatformconfig.Extre),
                    new MySqlParameter(ParamSubMchId,partnerpayplatformconfig.SubMchId)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(PartnerpayPlatformconfigDb partnerpayplatformconfig)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamMchId,partnerpayplatformconfig.MchId),
                    new MySqlParameter(ParamPlatfrom,partnerpayplatformconfig.Platfrom),
                    new MySqlParameter(ParamAppId,partnerpayplatformconfig.AppId),
                    new MySqlParameter(ParamPartnerId,partnerpayplatformconfig.PartnerId),
                    new MySqlParameter(ParamSignCert,partnerpayplatformconfig.SignCert),
                    new MySqlParameter(ParamSignCertPwd,partnerpayplatformconfig.SignCertPwd),
                    new MySqlParameter(ParamSignKey,partnerpayplatformconfig.SignKey),
                    new MySqlParameter(ParamEncryptCert,partnerpayplatformconfig.EncryptCert),
                    new MySqlParameter(ParamPlatfromPublicKey,partnerpayplatformconfig.PlatfromPublicKey),
                    new MySqlParameter(ParamExtre,partnerpayplatformconfig.Extre),
                    new MySqlParameter(ParamSubMchId,partnerpayplatformconfig.SubMchId)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>PartnerpayPlatformconfigDb</returns>
        public static PartnerpayPlatformconfigDb  ConvertToObject(DataRow dr)
        {
            var data = new PartnerpayPlatformconfigDb
                {
                    MchId = DbChange.ToString(dr["MchId"]),
                    Platfrom = DbChange.ToInt(dr["Platfrom"],0),
                    AppId = DbChange.ToString(dr["AppId"]),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    SignCert = DbChange.ToString(dr["SignCert"]),
                    SignCertPwd = DbChange.ToString(dr["SignCertPwd"]),
                    SignKey = DbChange.ToString(dr["SignKey"]),
                    EncryptCert = DbChange.ToString(dr["EncryptCert"]),
                    PlatfromPublicKey = DbChange.ToString(dr["PlatfromPublicKey"]),
                    Extre = DbChange.ToString(dr["Extre"]),
                    SubMchId = DbChange.ToString(dr["SubMchId"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of PartnerpayPlatformconfigDb</returns>
        public static List<PartnerpayPlatformconfigDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<PartnerpayPlatformconfigDb>(); 
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

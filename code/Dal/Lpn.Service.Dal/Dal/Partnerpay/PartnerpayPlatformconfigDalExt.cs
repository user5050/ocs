using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Model.Db.Partnerpay;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Dal.Dal.Partnerpay
{
    public partial class PartnerpayPlatformconfigDal
    {
        #region SQL
        //获取根据主键查询
        protected const string SqlPartnerConfigs = "select * from partnerpay_platformconfig where `PartnerId`=?PartnerId;";
        #endregion


        #region 获取指定合作商数据
        /// <summary>
        /// 获取指定合作商数据
        /// </summary>
        /// <returns>List of PartnerpayPlatformconfigDb</returns>
        public static List<PartnerpayPlatformconfigDb> GetPartnerConfigs(string partnerId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPartnerId,partnerId)
                };


            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlPartnerConfigs, param);

            return ConvertToObjects(dr);
        }
        #endregion
    }
}

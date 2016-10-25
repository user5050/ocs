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
    public partial class PartnerpayControlDal
    {
        #region SQL
        //获取根据主键查询
        protected const string SqlGetByPartnerId = "select * from partnerpay_control where `PartnerId`=?PartnerId;";
        #endregion


        #region 获取partnerId查询数据
        /// <summary>
        /// 获取partnerId查询数据
        /// </summary>
        /// <param name="partnerId">停车场编号</param> 
        /// <returns>PartnerpayControlDb</returns>
        public static PartnerpayControlDb GetByPartnerId(string partnerId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPartnerId,partnerId)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByPartnerId, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion
    }
}

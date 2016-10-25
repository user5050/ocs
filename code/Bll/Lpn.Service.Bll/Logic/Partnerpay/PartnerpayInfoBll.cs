using System;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Partnerpay;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Partnerpay;

/* 
* 描述:停车场合作公司配置信息 
* 作者:lee
* 创建时间:2015/12/14
*/
namespace OneCoin.Service.Bll.Logic.Partnerpay
{
    /// <summary>
    /// 停车场合作公司配置信息 
    /// </summary> 
    public class PartnerpayInfoBll : BllBase
    {
        public static PartnerpayInfoDb GetByPartnerId(string partnerId)
        {
            return PartnerpayInfoDal.GetByPriKey(partnerId);
        }
    }
}

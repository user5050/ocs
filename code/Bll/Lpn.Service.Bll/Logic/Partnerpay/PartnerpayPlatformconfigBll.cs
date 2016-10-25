using System.Collections.Generic;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Partnerpay;
using OneCoin.Service.Model.Db.Partnerpay;

/* 
* 描述:合作公司支付平台信息配置 
* 作者:lee
* 创建时间:2015/12/14
*/
namespace OneCoin.Service.Bll.Logic.Partnerpay
{
    /// <summary>
    /// 合作公司支付平台信息配置 
    /// </summary> 
    public class PartnerpayPlatformconfigBll : BllBase
    {
        public static List<PartnerpayPlatformconfigDb> GetByPartnerId(string partnerId)
        {
            return PartnerpayPlatformconfigDal.GetPartnerConfigs(partnerId);
        }
    }
}

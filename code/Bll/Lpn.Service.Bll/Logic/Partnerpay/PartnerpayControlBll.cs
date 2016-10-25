using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Partnerpay;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Db.Partnerpay;

/* 
* 描述:停车场支付功能控制开关  
* 作者:lee
* 创建时间:2015/12/14
*/
namespace OneCoin.Service.Bll.Logic.Partnerpay
{

    public class PartnerpayControlBll : BllBase
    { 
        public static PartnerpayControlDb GetByParkCode(string parkCode)
        {
            return PartnerpayControlDal.GetByPriKey(parkCode);
        }

        public static PartnerpayControlDb GetByPartnerId(string partnerId)
        {
            return PartnerpayControlDal.GetByPartnerId(partnerId);
        }

        /// <summary>
        /// 是否支持默认商户支付
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        public static bool IsCanUseDefaultPayment(string parkCode)
        {
            var data= PartnerpayControlDal.GetByPriKey(parkCode);
            if (data == null) return true;

            if (data.PartnerId == WebConfig.RechargePartner) return true;


            return false;
        }
    }
}

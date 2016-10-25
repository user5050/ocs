using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using OneCoin.Payment.Plugins.BestPay.Core;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Entity.Config;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Payment.Plugins
{
    public class PayBase
    {
        // 支付类型 
        private readonly PaymentType _type;
        internal static IPayConfig PayConfig = null;

        public PayBase(PaymentType type)
        {
            _type = type;
        }

        public PayConfig GetConfig(string parkCode,PaymentPurpose purpose,bool isWxOpen=false)
        { 
            if (PayConfig == null)
            {
                // 加载获取支付配置插件
                var appConfig = Spanner.SpliteStringsClearEmpty(ConfigurationManager.AppSettings["OneCoin.Payment.PayConfig"], ",");

                if (appConfig.Length == 2)
                {
                    PayConfig = Activator.CreateInstance(appConfig[1], appConfig[0]).Unwrap() as IPayConfig;
                }
            }


            return isWxOpen ? PayConfig.GetWxConfig(purpose) : PayConfig.GetConfig(parkCode, _type, purpose);
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="payCallBack"></param>
        /// <param name="payConfig"></param>
        /// <returns></returns>
        protected bool VerifyResult(PayCallBackDto payCallBack, PayConfig payConfig)
        {
            var signSource = payCallBack.GenricSource(payConfig.MchId, payConfig.Md5Key);

            return EncryptMgr.MD5(signSource).ToLower(CultureInfo.CurrentCulture) == payCallBack.SIGN.ToLower();
        }

        protected   string  Query(string url,string postString)
        {
            var http = new HttpClient(url) {PostString = postString};

            return http.GetString();
        }
    }
}

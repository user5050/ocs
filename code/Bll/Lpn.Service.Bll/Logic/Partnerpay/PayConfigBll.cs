using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Db.Partnerpay;
using OneCoin.Service.Model.Entity.Config;
using OneCoin.Service.Model.Entity.Partnerpay;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Bll.Logic.Partnerpay
{
    public class PayConfigBll : IPayConfig
    {
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="platform"></param>
        /// <param name="purpose"></param>
        /// <returns></returns>
        public  PayConfig GetConfig(string parkCode, PaymentType platform, PaymentPurpose purpose)
        { 
            var control = purpose == PaymentPurpose.账户充值 ? GetRechargeConfig() : GetParkConfig(parkCode);
            
            if (control == null) return null;

            if (control.Configs.ContainsKey(platform))
            {
                return control.Configs[platform];
            }

            return null;
        }


        public static string GetPartnerId(string parkCode, PaymentType platform, PaymentPurpose purpose, bool isWxApp)
        {
            // 微信公众号支付
            if (platform == PaymentType.WeixinPay && !isWxApp)
            {
                return WebConfig.WxPartner;
            }

            // 充值
            if (purpose == PaymentPurpose.账户充值)
            {
                return WebConfig.RechargePartner;
            }


            // 获取停车场与合作商的配置信息
            var clt = PartnerpayControlBll.GetByParkCode(parkCode);

            return clt == null ? WebConfig.RechargePartner : clt.PartnerId;
        }

        /// <summary>
        /// 微信公众
        /// </summary>
        /// <param name="purpose"></param>
        /// <returns></returns>
        public PayConfig GetWxConfig(PaymentPurpose purpose)
        { 
            var control = GetParkWxConfig();

            if (control == null) return null;

            if (control.Configs.ContainsKey(PaymentType.WeixinPay))
            {
                return control.Configs[PaymentType.WeixinPay];
            }

            return null;
        }

        /// <summary>
        /// 充值配置
        /// </summary> 
        /// <returns></returns>
        private PartnerpayControlDto GetRechargeConfig()
        {
           return GetParkRechargeConfig(); 
        }


        /// <summary>
        /// 获取指定停车场所支持的支付平台列表
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        public static List<int> SupportType(string parkCode)
        {
            var control = GetParkConfig(parkCode);
            if (control == null) return new List<int>();

            return control.SupportPlatform ?? new List<int>();
        }


        #region private
        private static PartnerpayControlDto GetParkConfig(string parkCode)
        { 
            var control = PartnerpayControlBll.GetByParkCode(parkCode);
            if (control == null)
            {
                //如果不存在配置，则使用宜泊账号(充值账号即为宜泊默认账号)
                control = PartnerpayControlBll.GetByPartnerId(WebConfig.RechargePartner);
            }

            var cfgs = PartnerpayPlatformconfigBll.GetByPartnerId(control.PartnerId);
             
            var config = new PartnerpayControlDto
                {
                    ParkCode = parkCode,
                    Configs = GetConfigs(cfgs),
                    SupportPlatform = Spanner.SpliteInts(control.EnablePlatforms,",").ToList()
                };

            return config;
        }


        private static PartnerpayControlDto GetParkRechargeConfig()
        {
            var cfgs = PartnerpayPlatformconfigBll.GetByPartnerId(WebConfig.RechargePartner);

            var config = new PartnerpayControlDto
            { 
                Configs = GetConfigs(cfgs),
                SupportPlatform = GetSupportType(cfgs)
            };

            return config;
        }

        private static PartnerpayControlDto GetParkWxConfig()
        { 
            var cfgs = PartnerpayPlatformconfigBll.GetByPartnerId(WebConfig.WxPartner);

            var config = new PartnerpayControlDto
            {
                Configs = GetConfigs(cfgs),
                SupportPlatform = GetSupportType(cfgs)
            };

            return config;
        }

        private static Dictionary<PaymentType, PayConfig> GetConfigs(IEnumerable<PartnerpayPlatformconfigDb> cfgs)
        {
            if (cfgs == null) return new Dictionary<PaymentType, PayConfig>();

            var datas = new Dictionary<PaymentType, PayConfig>();
            foreach (var cfg in cfgs)
            {
                datas[(PaymentType) cfg.Platfrom] = new PayConfig
                    {
                        MchId=cfg.MchId,
                        EncrypCer = cfg.EncryptCert,
                        Md5Key = cfg.SignKey,
                        Pfx = cfg.SignCert,
                        PfxPwd = cfg.SignCertPwd,
                        PlatformPublicCer = cfg.PlatfromPublicKey,
                        AppId = cfg.AppId,
                        SubMchId = cfg.SubMchId
                    };
            }

            return datas;
        }

        private static List<int> GetSupportType(IEnumerable<PartnerpayPlatformconfigDb> configs)
        {
            if (configs == null) return new List<int>();

            return configs.Select(x => x.Platfrom).ToList();
        } 
        #endregion 
         
    }
}

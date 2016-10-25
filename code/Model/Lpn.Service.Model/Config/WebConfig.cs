using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace OneCoin.Service.Model.Config
{
    public static class WebConfig
    {
        #region 变量

        private static readonly bool _enableEnableToken;
        #endregion

        #region 构造方法。
        /// <summary>
        /// 静态构造方法。LevelMax
        /// </summary>
        static WebConfig()
        {
            _enableEnableToken = String.Compare(ConfigurationManager.AppSettings["EnableToken"], "true", StringComparison.OrdinalIgnoreCase) == 0; 
        }
        #endregion

        /// <summary>
        /// 是否开启token检查
        /// </summary>
        public static bool EnableToken
        {
            get { return _enableEnableToken; }
        }


        #region redis
        /// <summary>
        /// redis缓存池大小
        /// </summary>
        private static int _poolSize;
        public static int PoolSize
        {
            get
            {
                if (_poolSize <= 0)
                {
                    int.TryParse(ConfigurationManager.AppSettings["PoolSize"], out _poolSize);
                    
                    if (_poolSize <= 0)
                    {
                        _poolSize = 20;
                    }
                }
                 
                return _poolSize;
            }
        }


        /// <summary>
        /// redis超时时间(单位：秒 )
        /// </summary>
        private static int _poolTimeOutSeconds;
        public static int PoolTimeOutSeconds
        {
            get
            {
                if (_poolTimeOutSeconds <= 0)
                {
                    int.TryParse(ConfigurationManager.AppSettings["PoolTimeOutSeconds"], out _poolTimeOutSeconds);

                    if (_poolTimeOutSeconds <= 0)
                    {
                        _poolTimeOutSeconds = 20;
                    }
                }

                return _poolTimeOutSeconds;
            }
        }

        /// <summary>
        /// Redis 读写host
        /// </summary>
        private static string _readWriteHosts;
        public static string ReadWriteHosts
        {
            get
            {
                if (string.IsNullOrEmpty(_readWriteHosts))
                {
                    _readWriteHosts = ConfigurationManager.AppSettings["ReadWriteHosts"];
                }

                return _readWriteHosts;
            }
        }

        /// <summary>
        /// 默认库ID(0~15)
        /// </summary>
        public static long DefaultRedisDb
        {
            get
            {
                if (ConfigurationManager.AppSettings.AllKeys.Any(x => x == "DefaultRedisDb"))
                {
                    return int.Parse(ConfigurationManager.AppSettings["DefaultRedisDb"]);
                }

                return 0;
            }
        }

        #endregion

        #region 消息服务地址
        private static string _messageUrl;
        public static string MessageUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_messageUrl))
                {
                    _messageUrl = ConfigurationManager.AppSettings["MessageUrl"];
                }

                return _messageUrl;
            }
        }
        #endregion

        #region 短信发送配置
        /// <summary>
        /// 短信发送配置信息
        /// </summary>
        private static string _smsConfig;
        public static string SmsConfig
        {
            get
            {
                _smsConfig = ConfigurationManager.AppSettings["SmsConfig"];
                return _smsConfig;
            }
        }
        #endregion

        #region 固定验签KEy

        /// <summary>
        /// 固定验签KEy
        /// </summary>
        public static string CommSignKey 
        {
            get { return ConfigurationManager.AppSettings["CommSignKey"]; }
        }
        #endregion

        #region 资源空间
        /// <summary>
        /// 资源空间
        /// </summary>
        public static string ResourceBucket { get { return ConfigurationManager.AppSettings["ResourceBucket"]; } }
        #endregion

        #region 资源访问域名
        /// <summary>
        /// 资源访问域名
        /// </summary>
        public static string ResourceDomain { get { return ConfigurationManager.AppSettings["ResourceDomain"]; } }
        #endregion
       
        #region 车场图片地址
        public static string ParkUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["Parkurl"];
      
            }
        }
        #endregion

        #region 车场找图范围
        private static double _radii;
        public static double Radii
        {
            get
            {
                double.TryParse(ConfigurationManager.AppSettings["MapRadii"], out _radii);
                return _radii;
            }
        }
        #endregion 

        #region 充值合作商ID
        public static string RechargePartner
        {
            get
            {
                return ConfigurationManager.AppSettings["RechargePartner"];
            }
        }
        #endregion

        #region 微信公众号合作商ID
        public static string WxPartner
        {
            get
            {
                return ConfigurationManager.AppSettings["WxPartner"];
            }
        }
        #endregion


        #region 车场图片地址
        public static string ParkInUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ParkInUrl"];

            }
        }
        #endregion

        #region 车场图片地址
        public static string ParkOutUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ParkOutUrl"];

            }
        }
        #endregion

        #region 支付相关
        /// <summary>
        /// 微信支付活动标识
        /// </summary>
        public static string PayExtreGoodsTag
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["Pay_ExtreGoodsTag"];
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        #endregion


        #region 微信登录成功跳转地址
        /// <summary>
        /// 微信登录成功跳转地址
        /// </summary>
        public static string Wxlogin
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["Wxlogin"];
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        #endregion


        #region 支持的停车场所在城市

        /// <summary>
        /// 支持的停车场所在城市
        /// </summary>
        private static HashSet<string> _citys = null;
        public static HashSet<string> EnableCitys
        {
            get
            {
                if (_citys != null) return _citys;

                try
                {
                    var data = new HashSet<string>();

                    foreach (var ec in ConfigurationManager.AppSettings["EnableCitys"].Split(','))
                    {
                        data.Add(ec);
                    }

                    _citys = data;
                }
                catch (Exception)
                {
                }

                return _citys ?? new HashSet<string>();
            }
        }
        #endregion

        /// <summary>
        /// 我的优惠券列表地址
        /// </summary>
        public static string CouponUrl
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["CouponUrl"];
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }


        /// <summary>
        /// 车牌找回
        /// </summary>
        public static string WxFindCarNo
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["WxFindCarNo"];
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
    }
}


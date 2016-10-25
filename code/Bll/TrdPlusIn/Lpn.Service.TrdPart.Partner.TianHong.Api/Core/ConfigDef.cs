namespace Lpn.Service.TrdPart.Partner.TianHong.Api.Core
{
    public class ConfigDef
    {
#if DEBUG
        /// <summary>
        /// 测试地址
        /// </summary>
        public const string ApiServer = "http://hlj.dev.rainbowcn.net";
#else 
        //public const string ApiServer = "http://hlj.test.rainbowcn.net/v2.1";
        public const string ApiServer = "http://api.honglingjin.cn/v2.1";
        
#endif

        /// <summary>
        /// 合作商id
        /// </summary>
        public const string PartnerId = "tianhong";
        
    }
}

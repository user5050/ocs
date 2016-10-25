namespace Lpn.Service.TrdPart.Partner.Ykb.Core
{
    public class ConfigDef
    {
#if DEBUG
        // 测试
        public const string ApiHost = "http://118.123.249.87:8080";

        public static string Token = "E4E831EEBFCA3738E8F9E19CD18D0280";
#else
        // 生产
        public const string ApiHost = "http://118.123.249.69:8080";

        public static string Token = "9CC438AF55EED3735CB6442FCF1C4126";
#endif


        /// <summary>
        /// 合作商id
        /// </summary>
        public const string PartnerId = "ykb";
    }
}

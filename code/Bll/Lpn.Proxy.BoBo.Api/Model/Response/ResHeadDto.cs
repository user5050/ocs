namespace Lpn.Proxy.BoBo.Api.Model.Response
{
    public class ResHeadDto
    {
        /// <summary>
        /// 返回码，10000成功，其他值失败
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 返回码提示信息
        /// </summary>
        public string msg { get; set; }
    }
}

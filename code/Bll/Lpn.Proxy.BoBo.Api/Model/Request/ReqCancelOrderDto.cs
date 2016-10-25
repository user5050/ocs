namespace Lpn.Proxy.BoBo.Api.Model.Request
{
    public class ReqCancelOrderDto
    {

        /// <summary>
        /// 车牌号
        /// </summary>
        public string carNumber { get; set; }
         

        /// <summary>
        /// 退费金额（单位为分）
        /// </summary>
        public string reAmount { get; set; }
         
          
    }
}

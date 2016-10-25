using System.Collections.Generic;

namespace OneCoin.Service.Model.Dto.Request.ThirdParty
{
    public class ReqThirdPartyMonthlySyncDto
    {
        /// <summary>
        /// 出场编码
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string UserToken { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 本地用户即删除冲突车牌并重新添加。物管用户如果冲突就返回不修改。物管同一个用户同步当前车牌
        /// </summary>
        public List<string> CarNos { get; set; }


        /// <summary>
        /// 缴费时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public string TillTime { get; set; }


        /// <summary>
        /// 缴费金额
        /// </summary>
        public double Consume { get; set; }


        /// <summary>
        /// 车位数
        /// </summary>
        public int ParkingAmount { get; set; }

        /// <summary>
        /// 车位号
        /// </summary>
        public List<string> ParkingNos { get; set; }

        /// <summary>
        /// 月租费率
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// 续费算费类型
        /// 1 上次到期时间+1开始算费 
        /// 2 购买日+1开始算费
        /// </summary>
        public int RateType { get; set; } 
    }
}

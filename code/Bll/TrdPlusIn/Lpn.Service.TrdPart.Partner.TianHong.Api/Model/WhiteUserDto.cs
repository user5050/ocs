namespace Lpn.Service.TrdPart.Partner.TianHong.Api.Model
{
    public class WhiteUserDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 开通门店
        /// </summary>
        public string Store { get; set; }

        /// <summary>
        /// 更新时间 数据格式：2015-01-10 11:41:21
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 0:添加 1:删除。（修改－先删除再添加）
        /// </summary>
        public int Type { get; set; }
        
    }
}

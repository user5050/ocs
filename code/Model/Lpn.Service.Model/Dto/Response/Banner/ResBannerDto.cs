namespace OneCoin.Service.Model.Dto.Response.Banner
{
    public class ResBannerDto
    {
        public string img { get; set; }

        public string desc { get; set; }

        //转方式 (0商品，1普通页,2网页)
        public int type { get; set; }

        public string url { get; set; }
    }
}

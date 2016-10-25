namespace OneCoin.Payment.Entity
{
    public class WXRes
    {
        public string appId { set; get; }

        public string timeStamp { set; get; }

        public string nonceStr { set; get; }

        public string package { get; set; }

        public string signType { get; set; }

        public string paySign { get; set; }
    }


    public class WXAppRes : WXRes
    {
        public string appId { set; get; }

        public string timeStamp { set; get; }

        public string nonceStr { set; get; }

        public string prepayid { get; set; }

        public string signType { get; set; }

        public string paySign { get; set; }

        public string package { get; set; }

        public string partnerid { get; set; }

        
    }
}

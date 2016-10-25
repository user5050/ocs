using System.Linq;
using System.Xml.Linq;

namespace OneCoin.Payment.Entity
{
    public class WeixinRes
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public string Return_code { get; set; }

        /// <summary>
        ///  返回信息
        /// </summary>
        public string Return_msg { get; set; }

        public WeixinRes()
        {
            this.Return_code = "";
            this.Return_msg = "";
        }

        public string Serialize()
        {
            var xml = new XElement("xml",
                                   new XElement("return_code", "<![CDATA[" + Return_code + "]]"),
                                   new XElement("return_msg", "<![CDATA[" + Return_msg + "]]")
                );
            return xml.ToString();
        }

        public void DeSerialize(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            var ad = from item in doc.Descendants("xml")
                     select item;
            foreach (var item in ad)
            {
                Return_code = item.Element("return_code").Value;
                Return_msg = item.Element("return_msg").Value;
                break;
            }
        }
    }
}

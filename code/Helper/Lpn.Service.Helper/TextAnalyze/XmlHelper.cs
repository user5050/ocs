using System.Xml;

namespace OneCoin.Service.Helper.TextAnalyze
{
    public class XmlHelper
    {
        public static string GetValueWithSpecifyAttributeValue(XmlNode node, string atrributeName, string findAttributeValue)
        {
            if (node != null)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    var attibute = item.Attributes[atrributeName];
                    if (attibute != null)
                    {
                        if (string.Compare(attibute.Value, findAttributeValue, true) == 0)
                            return item.InnerText;
                    }
                }
            }

            return string.Empty;
        }
         
    }
}

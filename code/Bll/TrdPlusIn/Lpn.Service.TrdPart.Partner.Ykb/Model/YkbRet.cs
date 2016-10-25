namespace Lpn.Service.TrdPart.Partner.Ykb.Model
{
    public class YkbRet
    {
        public string State { get; set; }

        public string Msg { get; set; }

        public override string ToString()
        {
            return string.Format("{{\"msg\":\"{0}\",\"state\":\"{1}\"}}",Msg,State);
        }
    }
}

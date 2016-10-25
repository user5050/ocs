namespace Lpn.Service.TrdPart.Partner.Ykb.Model.Response
{
    public class ResWarpper<T>
    {
        public T data { get; set; }

        public string msg { get; set; }

        public int state { get; set; }
     }
}

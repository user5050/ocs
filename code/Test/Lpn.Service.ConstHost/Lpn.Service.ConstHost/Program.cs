using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Extension.Dto;
using StockTool;

namespace OneCoin.Service.ConstHost
{
    class Program
    {
        static void Main()
        {
            int precent = 0;
            var r = new StockHelper().Gets(new List<string> { "sh000001", "sz000001", "sz000002" }, out precent);



            Console.WriteLine("160601164404202710800006420".ToOrderSubPart(false));
            Console.WriteLine("160601164404202710800006420".ToOrderSubPart(true));

            string.Format("sdfs{0}{0}", "df");

            //var ret = new TianHongApi().CarStart(new CarStartDto
            //{
            //    ImageID = 0,
            //    ParkCode = "66666666",
            //    StartTime = DateTime.Now.ToString(),

            //    VehicleNo = "川A58586 "
            //});
            var date = DateTime.Parse("2000-01-1");
           
            


            Console.WriteLine(Spanner.GetLocalIp());

            //OrdersTaskBll.Start();
            //PaymentTaskBll.Start();
            //Console.WriteLine(MapGeocoder.RenderReverse("31", "104"));
            //Console.WriteLine(MapGeocoder.GetCity("31", "104"));

           


            Console.WriteLine(Spanner.Join("12345678901234567890123456789012".ToCharArray(0,32).OrderBy(x=>Guid.NewGuid().GetHashCode()).ToList(),""));

            long total = 0;
            Parallel.ForEach(Enumerable.Range(1, 10000).ToList(), () => 0, (j, loop, stotal) =>
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

                    stotal += j;
                    return stotal;

                }
                             , final => { Console.WriteLine(total); Interlocked.Add(ref total, final); });

            Console.WriteLine("total：" + total);

            Console.ReadLine();
            Console.WriteLine("Exit");
        } 
    }
}

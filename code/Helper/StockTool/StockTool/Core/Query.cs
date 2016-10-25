using OneCoin.Service.Helper.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Helper.Log;

namespace StockTool.Core
{
    public class Query
    {
        public string Q_QQ(List<string> nos)
        {
            //r=0.8446343279145341q=sz399001,bkqt012023,pt012023_002252
            const string BaseUrl = "http://qt.gtimg.cn/";

            var client = new HttpClient();
            client.Url = string.Format("{0}?r={1}q={2}", BaseUrl,new Random().NextDouble(), Spanner.Join(nos, ","));

            var ret= client.GetString();

            LogHelper.Trace(string.Format("Q_QQ:\r\n{0}\r\n{1}", client.Url, ret));

            return ret;
        }


        /*http://hq.sinajs.cn/list=s_sh603859,s_sh000001,s_sz000001,s_sz002236,s_sz000935,s_sh601669
         * var hq_str_sh000001="上证指数,收盘价格,注意上证五入
var hq_str_s_sh603859="能科股份,11.950,1.090,10.04,123,15";
var hq_str_s_sh000001="上证指数,3128.2467,37.3055,1.21,2405223,25035439";
var hq_str_s_sz000001="平安银行,9.24,0.11,1.20,915677,84474";
var hq_str_s_sz002236="大华股份,14.47,0.00,0.00,322420,46641";
var hq_str_s_sz000935="四川双马,29.13,2.65,10.01,616527,175846";
var hq_str_s_sh601669="中国电建,7.320,0.270,3.83,3365810,245185";*/
        public string  Q_Sina(List<string> nos)
        {
            const string BaseUrl = "http://hq.sinajs.cn/list=";

            nos = nos.Select(x => string.Format("s_{0}", x)).ToList();

            var client = new HttpClient();
            client.Url = string.Format("{0}{1}", BaseUrl,Spanner.Join(nos, ","));

            var ret= client.GetString();

            LogHelper.Trace(string.Format("Q_Sina:\r\n{0}\r\n{1}", client.Url, ret));


            return ret;
        }



        /*
         * 163.com   前缀 1为深圳 0为上海
         * http://api.money.126.net/data/feed/1000001?callback=ne2d81fff72829f8
         * 
         * ne2d81fff72829f8({"1000001":{"code": "1000001", "percent": 0.012048, "high": 9.3, "askvol3": 778460, "askvol2": 1209757, "askvol5": 814659, "askvol4": 2768875, "price": 9.24, "open": 9.13, "bid5": 9.2, "bid4": 9.21, "bid3": 9.22, "bid2": 9.23, "bid1": 9.24, "low": 9.12, "updown": 0.11, "type": "SZ", "bidvol1": 300505, "status": 0, "bidvol3": 326100, "bidvol2": 404600, "symbol": "000001", "update": "2016/10/24 15:59:58", "bidvol5": 559600, "bidvol4": 300100, "volume": 91567704, "askvol1": 399060, "ask5": 9.29, "ask4": 9.28, "ask1": 9.25, "name": "\u5e73\u5b89\u94f6\u884c", "ask3": 9.27, "ask2": 9.26, "arrow": "\u2191", "time": "2016/10/24 15:59:56", "yestclose": 9.13, "turnover": 844746080.61} });
         */


        public string Q_163(string no)
        {
            const string BaseUrl = "http://api.money.126.net/data/feed/";

            no = no.Replace("sz","1").Replace("sh","0");

            var client = new HttpClient {Url = string.Format("{0}{1}?callback=ne2d81fff72829f8", BaseUrl, no)};

            var ret= client.GetString().Replace("ne2d81fff72829f8(", "").Replace(");","");

            LogHelper.Trace(string.Format("Q_163:\r\n{0}\r\n{1}", client.Url, ret));

            return ret;
        }
    }
}

using System.Linq;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Helper.Serialization;
using OneCoin.Service.Helper.TextAnalyze;
using StockTool.Core;
using StockTool.Dto;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StockTool
{
    public class StockHelper: Query
    {
        protected List<StockData> GetFromQq(List<string> nos)
        {
            var ret = Q_QQ(nos);

            /*
             * v_sh601919="1~中国远洋~601919~5.47~5.35~5.37~1032948~527439~505509~5.46~942~5.45~6480~5.44~3174~5.43~3676~5.42~4559~5.47~1073~5.48~6775~5.49~7956~5.50~9678~5.51~4070~15:00:03/5.47/97/B/52968/12954|14:59:58/5.47/67/B/36649/12948|14:59:58/5.47/21/B/11476/12944|14:59:53/5.47/168/B/91875/12939|14:59:48/5.47/607/B/331582/12933|14:59:43/5.46/707/S/386180/12930~20161024150924~0.12~2.24~5.54~5.31~5.47/1032851/563440373~1032948~56349~1.35~~~5.54~5.31~4.30~417.67~558.83~2.75~5.89~4.82~2.13";
v_sh601857="1~中国石油~601857~7.43~7.36~7.37~558895~258826~300068~7.42~1191~7.41~1863~7.40~5420~7.39~2159~7.38~2543~7.43~285~7.44~9737~7.45~11708~7.46~15670~7.47~10084~14:59:58/7.42/182/S/135046/12948|14:59:58/7.42/20/S/14840/12944|14:59:53/7.43/44/B/32654/12939|14:59:48/7.43/81/B/60152/12933|14:59:43/7.42/46/S/34132/12930|14:59:38/7.42/51/S/37888/12927~20161024150924~0.07~0.95~7.46~7.34~7.42/558895/414547122~558895~41455~0.03~126.18~~7.46~7.34~1.63~12030.80~13598.46~1.15~8.10~6.62~2.35";
v_sh000001="1~上证指数~000001~3128.25~3090.94~3092.05~240522349~120261176~120261176~0.00~0~0.00~0~0.00~0~0.00~0~0.00~0~0.00~0~0.00~0~0.00~0~0.00~0~0.00~0~15:00:08/3128.43/56010/M/61330812/12955|15:00:03/3128.90/130215/M/140472704/12949|14:59:58/3128.52/182820/M/183927168/12944|14:59:53/3128.28/110490/M/121652560/12939|14:59:48/3128.78/158231/M/178782848/12933|14:59:43/3127.91/176987/M/202754144/12930~20161024150924~37.31~1.21~3137.03~3090.79~3128.52/240336124/250152590051~240522349~25035439~~~~3137.03~3090.79~1.50~~~301.37~-1.00~-1.00~1.37";
*/

            var datas = new List<StockData>();
            var items = Spanner.SpliteStringsClearEmpty(ret, "\n");
            foreach (var item in items)
            {
                MatchCollection regex = RegexComm.GetMatches(item, "v_([a-zA-Z0-9]+)=\"[^~]+~([^~]+)~[\\d]+~([0-9\\.]+)~.*", RegexOptions.IgnoreCase);

                if(regex.Count > 0)
                {
                    datas.Add(new StockData {
                        StockNo = regex[0].Groups[1].Value,
                        StockName= regex[0].Groups[2].Value,
                        Value = double.Parse(regex[0].Groups[3].Value)
                    });
                } 
            }

            return datas;
        }


        protected List<StockData> GetFromSina(List<string> nos)
        {
            var ret = Q_Sina(nos);

            /*
var hq_str_s_sh000001="上证指数,3128.2467,37.3055,1.21,2405223,25035439";
var hq_str_s_sz000001="平安银行,9.24,0.11,1.20,915677,84474";
var hq_str_s_sz002236="大华股份,14.47,0.00,0.00,322420,46641";
var hq_str_s_sz000935="四川双马,29.13,2.65,10.01,616527,175846";
             */

            var datas = new List<StockData>();
            var items = Spanner.SpliteStringsClearEmpty(ret, "\n");
            foreach (var item in items)
            {
                MatchCollection regex = RegexComm.GetMatches(item, "var\\s*hq_str_s_([a-zA-Z0-9]{8})=\"([^,]+),([0-9\\.]+),.*", RegexOptions.IgnoreCase);

                if (regex.Count > 0)
                {
                    datas.Add(new StockData
                    {
                        StockNo = regex[0].Groups[1].Value,
                        StockName = regex[0].Groups[2].Value,
                        Value = Math.Round(double.Parse(regex[0].Groups[3].Value),2,MidpointRounding.AwayFromZero)
                    });
                }
            }

            return datas;
        }



        protected List<StockData> GetFrom163(List<string> nos)
        {
            var datas = new List<StockData>();

            foreach (var no in nos)
            {
                var ret = Q_163(no);

                var data = SimpleSerialization.JsonToObject<Dictionary<string, Stock163Dto>>(ret);
                if (data != null && data.Count > 0)
                {
                    var item = data.Values.FirstOrDefault();
                    var code = string.Format("{0}{1}", item.code.StartsWith("1") ? "sz" : "sh",
                                             item.code.Substring(1, item.code.Length - 1));

                    datas.Add(new StockData
                        {
                            StockName = item.name,
                            StockNo = code,
                            Value = item.price
                        });
                }
            }

            return datas;
        }



        public List<StockData> Gets(List<string> nos,out int precent)
        {
            var partqq = GetFromQq(nos);
            var partsina = GetFromSina(nos);
            var part163 = GetFrom163(nos);
            precent = 100;

            var datas = new List<StockData>();
            foreach (var no in nos)
            {
                var part1 = partqq.FirstOrDefault(x => x.StockNo == no);
                var part2 = partsina.FirstOrDefault(x => x.StockNo == no);
                var part3 = part163.FirstOrDefault(x => x.StockNo == no);

                var totalresult = 0;
 
                if (part1 != null) totalresult++;
                if (part2 != null) totalresult++;
                if (part3 != null) totalresult++;

                precent = Math.Min(precent,totalresult == 3 ? 100 : totalresult == 2 ? 60 : 0);

                if (totalresult >= 2)
                {
                    if (part1 != null && part2 != null)
                    {
                        if (Math.Abs(part1.Value - part2.Value) < 0.001)
                        {
                            datas.Add(new StockData
                                {
                                    StockNo = part1.StockNo,
                                    StockName = part1.StockName,
                                    Value = part1.Value
                                });

                            continue;
                        }
                    }

                    if (part1 != null && part3 != null)
                    {
                        if (Math.Abs(part1.Value - part3.Value) < 0.001)
                        {
                            datas.Add(new StockData
                            {
                                StockNo = part1.StockNo,
                                StockName = part1.StockName,
                                Value = part1.Value
                            });

                            continue;

                        }
                    }

                    if (part2 != null && part3 != null)
                    {
                        if (Math.Abs(part2.Value - part3.Value) < 0.001)
                        {
                            datas.Add(new StockData
                            {
                                StockNo = part2.StockNo,
                                StockName = part2.StockName,
                                Value = part2.Value
                            });
                             
                        }
                    }
                }
            }

            return datas;
        }
    }
}

using System.Text;
using Lpn.Service.Bll.Logic.Park;
using Lpn.Service.Bll.Logic.ThirdParty;
using Lpn.Service.Cache.Park;
using Lpn.Service.TrdPart.Partner.Task.Core;
using System.Linq;

namespace Lpn.Service.TrdPart.Partner.Task.Park
{
    public class ParkFeeTask : ITask
    {
        // 最近上线的停车场才上报
        public void Run()
        {
            var parks = ParkFeeBll.GetParkFeeInfos();
            var fees = ParkFeeBll.GetParkFees();

            foreach (var parkCode in parks.Select(x => x.Parkcode).Distinct())
            {
                var parkfeeExtras = parks.Where(x => x.Parkcode == parkCode).ToList();
                var fee = fees.FirstOrDefault(x => x.ParkCode == parkCode);

                if (fee != null)
                {
                    var sb = new StringBuilder();
                    if (parkfeeExtras.Count == 1)
                    {
                        sb.Append(parkfeeExtras[0].Parkfee);
                    }
                    else
                    {
                        foreach (var extra in parkfeeExtras)
                        {
                            sb.AppendFormat("{0},{1};", extra.Parktype, extra.Parkfee);
                        }

                        if (sb.Length > 0) sb.Length--;
                    }


                    //给合作商上报费率
                    PartnerServiceBll.UploadParkInfo(parkCode, ParkCacheMgr.GetName(parkCode), sb.ToString(),fee.FreeTime );
                }
            }
        }

        /// <summary>
        /// 单位：分钟
        /// </summary>
        /// <returns></returns>
        public int GetRunInterval()
        {
            return 60;
        }

        public string GetTaskId()
        {
            return "ParkFeeUpload";
        }
    }
}

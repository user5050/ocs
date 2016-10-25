using System;
using System.Collections.Generic;
using Lpn.Service.Cache.Partner;
using Lpn.Service.TrdPart.Partner.Core.Interface;
using Lpn.Service.TrdPart.Partner.Core.Interface.Model;
using Lpn.Service.TrdPart.Partner.Core.Model;
using Lpn.Service.TrdPart.Partner.TianHong.Api.Logic;
using Lpn.Service.TrdPart.Partner.XiChen;
using Lpn.Service.TrdPart.Partner.Ykb;

namespace Lpn.Service.TrdPart.Partner.Bll.Logic
{
    public class PartnerActionMgr
    {
        private static readonly List<IPartnerAction> Instance;
        private static readonly List<IPartnerActivityAction> InstanceActivity;

        static PartnerActionMgr()
        {
            Instance = new List<IPartnerAction> {new TianHongApi()};
            InstanceActivity = new List<IPartnerActivityAction> { new YkbApiMgr() ,new XiChenApiMgr()};
        }

        public static bool CarStart(CarStartDto carEnter)
        {
            Instance.ForEach(x => TryNotifyCarStart(x, carEnter));

            return true;
        }

        private static bool TryNotifyCarStart(IPartnerAction x, CarStartDto carEnter)
        {
            try
            {
                var partnerId = x.PartnerId;
                if (PartnerCacheMgr.IsAuthedParkCode(partnerId, carEnter.ParkCode))
                {
                    return x.CarStart(carEnter);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }

        public static bool CarEnd(CarEndDto carExit)
        {
            Instance.ForEach(x => TryNotifyCarEnd(x, carExit));

            return true;
        }

        private static object TryNotifyCarEnd(IPartnerAction x, CarEndDto carExit)
        {
            try
            {
                var partnerId = x.PartnerId;
                if (PartnerCacheMgr.IsAuthedParkCode(partnerId, carExit.ParkCode))
                {
                    return x.CarEnd(carExit);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }


        public static bool UploadParkInfo(ParkInfoDto parkInfo)
        { 
            Instance.ForEach(x => TryNotifyUploadParkInfo(x, parkInfo));

            return true;
        }

        private static bool TryNotifyUploadParkInfo(IPartnerAction x, ParkInfoDto parkInfo)
        {
            try
            {
                var partnerId = x.PartnerId;
                if (PartnerCacheMgr.IsAuthedParkCode(partnerId, parkInfo.ParkCode))
                {
                    return x.UploadParkInfo(parkInfo);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }


        public static bool SyncActivity(SyncActivityDto data,string parkCode)
        {
            var isSuccess = true;
            InstanceActivity.ForEach(x => isSuccess = isSuccess && TrySyncActivity(x, data, parkCode));

            return isSuccess;
        }

        private static bool TrySyncActivity(IPartnerActivityAction x, SyncActivityDto data, string parkCode)
        {
            try
            {
                var partnerId = x.PartnerId;
                if (PartnerCacheMgr.IsAuthedParkCode(partnerId, parkCode) || partnerId == data.PartnerId)
                {
                    string msg;
                    return x.SyncActivity(data, out msg);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }  
    }
}

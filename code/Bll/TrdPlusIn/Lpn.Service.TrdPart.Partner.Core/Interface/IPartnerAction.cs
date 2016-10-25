using Lpn.Service.TrdPart.Partner.Core.Interface.Model;
using Lpn.Service.TrdPart.Partner.Core.Model;

namespace Lpn.Service.TrdPart.Partner.Core.Interface
{
    public interface IPartnerAction
    {
        bool CarStart(CarStartDto carEnter);

        bool CarEnd(CarEndDto carExit);

        bool UploadParkInfo(ParkInfoDto parkInfo);

        string PartnerId { get; } 
    }


    public interface  IPartnerActivityAction
    {
        bool SyncActivity(SyncActivityDto parkInfo,out string msg);

        string PartnerId { get; } 
    }
}

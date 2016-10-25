using System.Collections.Generic;
using Lpn.Service.TrdPart.MonthlySync.Interface.Entity;

namespace Lpn.Service.TrdPart.MonthlySync.Interface.Core
{
    public interface IMonthlySyncUpload
    {
        bool Upload(List<MonthlySyncDto> datas);
    }
}

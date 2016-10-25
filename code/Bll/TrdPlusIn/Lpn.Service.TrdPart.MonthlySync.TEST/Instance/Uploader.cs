using System.Collections.Generic;
using Lpn.Service.Helper.Log;
using Lpn.Service.TrdPart.MonthlySync.Interface.Core;
using Lpn.Service.TrdPart.MonthlySync.Interface.Entity;

namespace Lpn.Service.TrdPart.MonthlySync.TEST.Instance
{
    public class Uploader : IMonthlySyncUpload
    {
        public bool Upload(List<MonthlySyncDto> datas)
        {
            LogHelper.Add("月租续费上传通知成功");
            return true;
        }
    }
}

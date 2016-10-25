using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCoin.Service.Model.Dto.Request.Banner
{
    public class ReqGetDto
    {
        /// <summary>
        /// 更新标识
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Lng { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneCoin.Service.Model.Dto.Response.Banner;

namespace OneCoin.Service.Model.Dto.Request.Banner
{
    public class ResGetDto
    {
        /// <summary>
        /// 更新标识
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// Banner列表
        /// </summary>
        public List<ResBannerDto> banners { get; set; }
    }
}

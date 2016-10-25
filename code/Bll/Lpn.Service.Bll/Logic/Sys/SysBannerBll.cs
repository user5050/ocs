using System;
using System.Linq;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Home;
using OneCoin.Service.Model.Dto.Response.Banner;
using OneCoin.Service.Model.Result;

namespace OneCoin.Service.Bll.Logic.Sys
{
    public class HomeBannerBll : BllBase
    {
        /// <summary>
        /// 获取Banner列表
        /// </summary>  
        /// <returns></returns>
        public static ResultDto Get()
        {
            var banners = HomeBannerDal.GetAll();
            var datas = banners.Where(x=>x.StartTime <= DateTime.Now && x.ExpriedTime >= DateTime.Now)
                .OrderByDescending(x=>x.Order)
                .Select(banner => new ResBannerDto
                {
                    img = banner.Img, type = banner.Type, url = banner.Url
                }).ToList();


            return ResultDto.DefaultSuccess(datas);
        }
    }
}

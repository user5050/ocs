using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Model.Db.Home;
using OneCoin.Service.Model.Dto.Response.Msg;
using OneCoin.Service.Model.Extension.Dto;

namespace OneCoin.Service.Model.Extension
{
    public static class NewsExtension
    {
        #region 系统新闻

        public static List<ResNewsDto> ToDto(this List<HomeNewDb> datas)
        {
            return datas.Select(x => x.ToDto()).ToList();
        }


        public static ResNewsDto ToDto(this HomeNewDb data)
        {
            return new ResNewsDto
            {
                Title = data.Title,
                SendTime = data.StartTime.ToFormat(),
                IsView=true, 
            };
        }

        public static ResNewsDto ToDetailDto(this HomeNewDb data)
        {
            return new ResNewsDto
            {
                Title = data.Title,
                SendTime = data.StartTime.ToFormat(),
                IsView = true,
                Content = data.Content
            };
        } 
        
        #endregion
    }
}

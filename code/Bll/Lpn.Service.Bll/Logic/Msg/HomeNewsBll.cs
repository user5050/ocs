using OneCoin.Service.Dal.Dal.Home;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Extension;
using OneCoin.Service.Model.Result;

namespace OneCoin.Service.Bll.Logic.Msg
{
    public class HomeNewsBll
    {
        public static ResultDto Gets()
        {
            var news = HomeNewDal.Gets();

            return ResultDto.DefaultSuccess(news.ToDto());
        }

        public static ResultDto GetDetail(int newsId)
        {
            var news = HomeNewDal.GetByPriKey(newsId);

            if (news == null) return ResultDto.DefaultError(ResultState.GlobalParameterError);


            return ResultDto.DefaultSuccess(news.ToDetailDto());
        }
    }
}

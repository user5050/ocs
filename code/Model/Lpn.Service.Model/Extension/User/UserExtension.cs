using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Model.Db.Msg;
using OneCoin.Service.Model.Db.User;
using OneCoin.Service.Model.Dto.Response.Msg;
using OneCoin.Service.Model.Dto.Response.User;
using OneCoin.Service.Model.Extension.Dto;

namespace OneCoin.Service.Model.Extension.User
{
    public static class UserExtension
    {
        #region 用户登录信息

        public static ResLoginDto ToLoginDto(this UserBaseDb data, string token)
        {
            return new ResLoginDto
                {
                    Mobile = data.Mobile,
                    NickName = data.Name,
                    Tel = data.Mobile,
                    Token = token,
                    Img = data.Head.ToFullUrl()
                };
        }
        #endregion

        #region 消息

        public static List<ResMsgDto> ToSampleDto(this List<MsgInfoDb> datas)
        {
            return datas.Select(x => x.ToDto()).ToList();
        }

        public static ResMsgDto ToSampleDto(this MsgInfoDb data)
        {
            return new ResMsgDto
            {
                Title = data.Title, 
                IsView = data.IsView == 1,
                SendTime = data.RowTime.ToFormat()
            };
        }

        public static ResMsgDto ToDto(this MsgInfoDb data)
        {
            return new ResMsgDto
            {
                Title = data.Title,
                Content = data.Content,
                IsView = data.IsView ==1, 
                SendTime = data.RowTime.ToFormat()
            };
        }


        #endregion

        #region 收货地址

        public static List<ResContractDto> ToDto(this List<UserContractDb> datas)
        {
            return datas.Select(x => x.ToDto()).ToList();
        }


        public static ResContractDto ToDto(this UserContractDb data)
        {
            return new ResContractDto
                {
                    Address = data.Address,
                    Contract = data.Contract,
                    Id = data.Id,
                    IsDefault = data.IsDefault,
                    Name = data.Name
                };
        }
        #endregion
    }
}

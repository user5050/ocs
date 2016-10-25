using System;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.User;
using OneCoin.Service.Model.Db.User;
using OneCoin.Service.Model.Dto.Response.User;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Extension.User;
using OneCoin.Service.Model.Result;

namespace OneCoin.Service.Bll.Logic.SysUser
{
    public class UserContractBll : BllBase
    {
        public static ResultDto Gets(string userId)
        {
            var contracts = UserContractDal.GetByUserId(userId);

            return ResultDto.DefaultSuccess(contracts.ToDto());
        }


        public static ResultDto Del(string userId, int id)
        {
            var contract = UserContractDal.GetByPriKey(id);

            if (contract == null || contract.Uid != userId)
                return ResultDto.DefaultError(ResultState.GlobalParameterError);

            if (UserContractDal.DeleteByPriKey(id))
            {
                return ResultDto.DefaultSuccess();
            }

            return ResultDto.DefaultError(ResultState.GlobalSystemError);
        }


        public static ResultDto Save(string userId,ResContractDto data)
        {
            if (string.IsNullOrEmpty(data.Name)
                || string.IsNullOrEmpty(data.Address)
                || string.IsNullOrEmpty(data.Contract))
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }

            if (data.Id > 0)
            {
                var contract = UserContractDal.GetByPriKey(data.Id);

                if (contract == null || contract.Uid != userId)
                    return ResultDto.DefaultError(ResultState.GlobalParameterError);


                contract.Address = data.Address;
                contract.Name = data.Name;
                contract.IsDefault = data.IsDefault;
                contract.Contract = data.Contract;

                if (UserContractDal.UpdateByPriKey(contract))
                {

                    if (contract.IsDefault==1)
                    {
                        UserContractDal.UpdateDefault(userId, contract.Id);
                    }

                    return ResultDto.DefaultSuccess();
                }
            }
            else
            {
                //查询当前数量，最多不超过5个地址
                if (UserContractDal.GetCntByUserId(userId) >= 5)
                {
                    return ResultDto.DefaultError(ResultState.GlobalMuchData);
                }

                if (UserContractDal.InsertWithFillId(new UserContractDb
                    {
                        Address = data.Address,
                        Contract = data.Contract,
                        IsDefault = data.IsDefault,
                        Name = data.Name,
                        RowTime = DateTime.Now,
                        Uid = userId
                    }))
                {

                    if (data.IsDefault == 1)
                    {
                        UserContractDal.UpdateDefault(userId, data.Id);
                    }

                    return ResultDto.DefaultSuccess();
                }
            }

            return ResultDto.DefaultError(ResultState.GlobalSystemError);
        }


        public static ResultDto SetDefault(string userId, int id)
        {
            var contract = UserContractDal.GetByPriKey(id);

            if (contract == null || contract.Uid != userId)
                return ResultDto.DefaultError(ResultState.GlobalParameterError);


            if (UserContractDal.UpdateDefault(userId, id))
            {
                return ResultDto.DefaultSuccess();
            }

            return ResultDto.DefaultError(ResultState.GlobalSystemError);

        }
    }
}

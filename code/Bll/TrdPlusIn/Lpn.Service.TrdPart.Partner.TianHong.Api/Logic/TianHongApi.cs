using System;
using System.Collections.Generic;
using Lpn.Service.TrdPart.Partner.Core.Interface;
using Lpn.Service.TrdPart.Partner.Core.Model;
using Lpn.Service.TrdPart.Partner.TianHong.Api.Core;
using Lpn.Service.TrdPart.Partner.TianHong.Api.Model;

namespace Lpn.Service.TrdPart.Partner.TianHong.Api.Logic
{
    public class TianHongApi : ApiBase, IPartnerAction
    {
        #region 获取白名单
        /// <summary>
        /// 获取白名单
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="lastTime"></param>
        /// <returns></returns>
        public static RetObj<List<WhiteUserDto>> CarList(string parkCode, DateTime lastTime)
        {
            return RemoteQuery<RetObj<List<WhiteUserDto>>>("/parkmall/carList",
                                new
                                {
                                    ParkCode = parkCode,
                                    EventTime = lastTime.ToString("yyyy-MM-dd HH:mm:ss")
                                });
        }
        #endregion

        #region 车辆出场通知
        /// <summary>
        /// 车辆出场通知
        /// </summary>
        /// <param name="carExit"></param>
        /// <returns></returns>
        public   bool CarEnd(CarEndDto carExit)
        {
            var ret = RemoteQuery<RetObj>("/parkmall/carEnd",carExit);

            return ret.IsSuccess;
        }
         
        #endregion


        #region 上传停车场信息
        /// <summary>
        /// 上传停车场信息
        /// </summary>
        /// <param name="parkInfo"></param>
        /// <returns></returns>
        public bool UploadParkInfo(ParkInfoDto parkInfo)
        {
            var ret = RemoteQuery<RetObj>("/parkmall/parkInfoSync", parkInfo);

            return ret.IsSuccess;
        }
        #endregion

        #region 车辆入场通知
        /// <summary>
        /// 车辆入场通知
        /// </summary>
        /// <param name="carEnter"></param>
        /// <returns></returns>
        public   bool CarStart(CarStartDto carEnter)
        {
            var ret = RemoteQuery<RetObj>("/parkmall/carStart", carEnter);

            return ret.IsSuccess;
        }
        #endregion

         
        public string PartnerId
        {
            get { return ConfigDef.PartnerId; }
         }
    }
}

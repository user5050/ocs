//using System;
//using System.Globalization;
//using OneCoin.Library.Service.Park.Model.park.Request;
//using OneCoin.Service.Bll.Core;
//using OneCoin.Service.Bll.Logic.Park;
//using OneCoin.Service.Bll.Logic.Payment;
//using OneCoin.Service.Dal.Dal.Sys;
//using OneCoin.Service.Model.Result;
//using GetVersion = OneCoin.Library.Service.Park.Model.platform.Response.GetVersion;

//namespace OneCoin.Service.Bll.Logic.Sys
//{
//    public class SysVersionBll : BllBase
//    {
//        /// <summary>
//        /// 检测最新版本
//        /// </summary>
//        /// <param name="parkCode"></param>
//        /// <param name="version"></param>
//        /// <returns></returns>
//        public static ResultDto Check(string parkCode, string version)
//        {
//            var cfg = SysVersionDal.GetByParkCode(parkCode);

//            var parkId = ParkInfoBll.GetIdByParkCode(parkCode);

//            bool eboPay = PaymentRoleForParkBll.IsExistsParkRoleByParkId(parkId);

//            if (cfg != null)
//            {
//                // 是否配置了最新版本
//                if (!string.IsNullOrEmpty(cfg.NewVersion))
//                {
//                    // 比较当前版本与最新版本
//                    if (string.Compare(cfg.NewVersion, version, true, CultureInfo.CurrentCulture) != 0)
//                    {
//                        //查询最新版本资源信息
//                        var resource = SysVersionResourceDal.GetByPriKey(cfg.NewVersion);
//                        if (resource != null)
//                        {
//                            return ResultDto.DefaultSuccess(new GetVersion
//                                {
//                                    DownloadUrl = resource.Url,
//                                    Hash = resource.Hash,
//                                    TimeOut = cfg.ExpireDate,
//                                    Version = cfg.NewVersion,
//                                    SupportEboPay = (eboPay ? 1 : 0)
//                                });
//                        }
//                    }
//                }

//            }

//            // 返回有效期
//            return ResultDto.DefaultSuccess(new GetVersion
//            {
//                TimeOut = cfg != null ? cfg.ExpireDate : "",
//                SupportEboPay = (eboPay ? 1 : 0)
//            });

//        }


//        public static ResultDto UpdateLog(UploadVersion log)
//        {
//            if (log != null)
//            {
//                if (log.Success)
//                {
//                    SysVersionDal.UpdateVerionAndLog(log.ParkCode, log.UpdateLog, log.Version, DateTime.Now);
//                }
//                else
//                {
//                    SysVersionDal.UpdateLog(log.ParkCode, log.UpdateLog, DateTime.Now);
//                }
//            }

//            return ResultDto.DefaultSuccess();
//        }

//        /// <summary>
//        /// 获取时间
//        /// </summary>
//        /// <returns></returns>
//        public static ResultDto GetTime()
//        {
//            return ResultDto.DefaultSuccess(DateTime.Now.Ticks.ToString());
//        }
//    }
//}

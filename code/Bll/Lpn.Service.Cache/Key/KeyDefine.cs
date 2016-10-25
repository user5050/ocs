/*
* 描述: 缓存键定义
* 作者:lee
* 创建时间:2015/10/21
*/

namespace OneCoin.Service.Cache.Key
{
    public class KeyDefine
    {
        #region 登录相关

        #region  Token

        /// <summary>
        /// 用户登录token与userId的映射关系,参数：用户登录Token，值：用户id
        /// </summary>
        public const string TokenUserFormatter = "lpn:service:cache:token:{0}:userId";


        /// <summary>
        /// 用户登录userId与token的映射关系,参数：值：用户id,用户登录Token
        /// </summary>
        public const string TokenUserkeyFormatter = "lpn:service:cache:token:{0}:token";


        #endregion

        #region  IOS Token

        /// <summary>
        /// 用户userid与IOS Token的映射关系,参数：用户userid，值：IOS Token
        /// </summary>
        public const string TokenIosTokenFormatter = "lpn:service:cache:IosToken:{0}";

        #endregion

        #endregion

        #region 停车场相关

        #region  ParkMac

        /// <summary>
        /// 停车场设备编号与设备Mac地址的映射关系,参数：停车场设备编号，值：设备mac地址
        /// </summary>
        public const string ParkMacKeyFormatter = "lpn:service:cache:park:{0}:mac";

        #endregion

        #region  Park  SignKey

        /// <summary>
        /// 停车场设备编号与设备密码的映射关系,参数：停车场设备编号，值：设备验签密码
        /// </summary>
        public const string ParkSignKeyFormatter = "lpn:service:cache:park:{0}:signkey";

        #endregion

        #region  Park Id

        /// <summary>
        /// 停车场设备编号与Id的映射关系,参数：停车场设备编号，值：ParkId
        /// </summary>
        public const string ParkIdKeyFormatter = "lpn:service:cache:park:{0}:id";

        #endregion

        #region  Park Name

        /// <summary>
        /// 停车场设备编号与名称的映射关系,参数：停车场设备编号，值：名称
        /// </summary>
        public const string ParkCodeNameKeyFormatter = "lpn:service:cache:park:{0}:name";

        #endregion
        #endregion

        #region 账号相关

        #region  UserName UserId

        /// <summary>
        /// 用户名与用户Id的映射关系,参数：UserName，值：UserId
        /// </summary>
        public const string UserNameIdFormatter = "lpn:service:cache:user:name:{0}:id";

        #endregion

        #region  UserId  UserName

        /// <summary>
        /// 用户Id与用户名的映射关系,参数：UserId，值：UserName
        /// </summary>
        public const string UserIdNameFormatter = "lpn:service:cache:user:{0}:name";

        #endregion

        #endregion

        #region 验证码相关

        #region  mobile  vcode

        /// <summary>
        /// 手机号码，验证码的映射关系,参数：mobile，值：vcode
        /// </summary>
        public const string MobileVcodeFormatter = "lpn:service:cache:mobile:{0}:vcode";

        /// <summary>
        /// 手机验证码消息模板
        /// </summary>
        public const string MobileVcodeMsgTempFormatter = "lpn:service:cache:VcodeMsgTemp:Login";

        #endregion

        #endregion

        #region APP配置相关

        #region  userid+classname+key value

        /// <summary>
        /// APP配置键和值映射关系,参数：userid+classname+key，值：value
        /// </summary>
        public const string AppConfigFormatter = "lpn:service:cache:appconfig:{0}:{1}:{2}";

        #endregion

        #endregion

        #region 模块使用统计

        #region  moduleId+submoduleId+value+date

        /// <summary>
        /// APP配置键和值映射关系,参数：moduleId+submoduleId+value+date，值：int32
        /// </summary>
        public const string ModuleStat = "lpn:service:cache:modulestat:{0}:{1}:{2}:{3}";

        #endregion

        #endregion

        #region 快速出场相关

        /// <summary>
        /// 快速出场自动缴费，支付记录号 parkcode, carno,qn
        /// </summary>
        public const string TokenAutoPayFormatter = "lpn:service:cache:autopay:{0}:{1}:{2}";

        #endregion

        #region 天气相关

        #region  city  气候

        /// <summary>
        /// city，气候的映射关系,参数：city，值：气候
        /// </summary>
        public const string MobileWeatherFormatter = "lpn:service:cache:Weather:{0}";

        #endregion
        #endregion

        #region 白名单相关

        #region  手机号码

        /// <summary>
        /// 手机号码
        /// </summary>
        public const string WhiteMobileKey = "lpn:service:cache:WhiteMobile";

        #endregion
        #endregion

        #region Banner相关
         
        /// <summary>
        /// 定时发送时间
        /// </summary>
        public const string BannerSyncTimeKey = "lpn:service:cache:banner:syncTime";

        /// <summary>
        /// 白名单
        /// </summary>
        public const string BannerWhiteMobileKey = "lpn:service:cache:banner:WhiteMobileKey";

        #endregion

        #region 商户认证数据

        /// <summary>
        /// 泊泊预约(TODO需要下个版本替换)
        /// </summary>
        public const string SubscribeKeyFormatter = "lpn:service:cache:subscribe:partner:{0}:key";


        /// <summary>
        /// 商户key(手动配置)
        /// </summary>
        public const string PartnerKeyFormatter = "lpn:service:cache:partner:{0}:key";

        /// <summary>
        /// 商户被授权的停车场编号(手动配置)
        /// </summary>
        public const string PartnerAuthedParkCodeFormatter = "lpn:service:cache:partner:{0}:authedparkcode";


        /// <summary>
        /// 商户注册对应的用户ID
        /// </summary>
        public const string PartnerMapedUserIdFormatter = "lpn:service:cache:partner:{0}:mapeduserid";

        /// <summary>
        /// 商户名称
        /// </summary>
        public const string PartnerNameFormatter = "lpn:service:cache:partner:{0}:name";

        /// <summary>
        /// 商户被禁止标记
        /// </summary>
        public const string PartnerForbiddenFormatter = "lpn:service:cache:partner:{0}:forbidden";

        /// <summary>
        /// 操作统计
        /// </summary>
        public const string PartnerQueryStat = "lpn:service:cache:partner:{0}:{1}:querystat";

        #endregion

        #region 车辆信息相关

        /// <summary>
        /// 车辆信息相关(0:车牌号)
        /// </summary>
        public const string CarProStopKeyFormatter = "lpn:service:cache:car:{0}:ProStop";

        #endregion

        #region 活动信息相关

        /// <summary>
        /// 活动信息相关(剩余名额)
        /// </summary>
        public const string ActivityRestNumKeyFormatter = "lpn:service:cache:activity:{0}:restnum";

        /// <summary>
        /// 活动信息相关(短信通知内容模板)
        /// </summary>
        public const string ActivityMsgTplFormatter = "lpn:service:cache:activity:{0}:msgtpl";


        /// <summary>
        /// 活动报名成功后通知管理员名单(手机号码,手机号码)
        /// </summary>
        public const string ActivityNotifyManagerKeyFormatter = "lpn:service:cache:activity:{0}:notifymanager";


        /// <summary>
        /// 活动信息相关(活动方名称)
        /// </summary>
        public const string ActivitySpName = "lpn:service:cache:activity:{0}:SpName";

         
        #endregion

        #region 月租物管同步相关

        /// <summary>
        /// 商户被授权的停车场编号
        /// </summary>
        public const string PartnerMonthlySyncFormatter = "lpn:service:cache:partner:monthlysync:bindparkcode";

        /// <summary>
        /// 停车场编号对应的商户id
        /// </summary>
        public const string PartnerMonthlySyncPc2PIdFormatter = "lpn:service:cache:partner:monthlysync:{0}:partnerid";

        /// <summary>
        /// 停车场编号最新上报时间
        /// </summary>
        public const string PartnerMonthlySyncTimeFormatter = "lpn:service:cache:partner:monthlysync:{0}:uploadtime";

        /// <summary>
        /// 月租物管是否需要上报(手动配置)
        /// </summary>
        public const string PartnerMonthlySyncEnableUploadFormatter = "lpn:service:cache:partner:monthlysync:{0}:enbaleupload";

        #endregion

        #region 用户所属属性

        /// <summary>
        /// 用户所属属性
        /// </summary>
        public const string UserIsBelongToBkx = "lpn:service:cache:BelongTo:{0}:Bkx";

        #endregion

        #region 优惠券缓存

        /// <summary>
        /// 优惠券缓存
        /// </summary>
        public const string CouponPreViewCache = "lpn:service:cache:Coupon:{0}:PreView";

        #endregion

        #region 统计
         
        #endregion

        #region 短连接

        /// <summary>
        /// 短连接
        /// </summary>
        public const string ShortUrlCache = "lpn:service:cache:shorturl:{0}";

        #endregion

        #region 频率

        /// <summary>
        /// 频率控制
        /// </summary>
        public const string FrequencyCache = "lpn:service:cache:frequency:{0}:{1}";

        #endregion


        #region 商品

        /// <summary>
        /// 成员 gameno
        /// </summary>
        public const string ProductGameMemberCache = "OneCoin:service:cache:GameMember:{0}";


        /// <summary>
        /// 晒单数 pid
        /// </summary>
        public const string ProductShowCntCache = "OneCoin:service:cache:ShowCnt:{0}";


        /// <summary>
        /// 参与人数 pid
        /// </summary>
        public const string ProductJoinCntCache = "OneCoin:service:cache:JoinCnt:{0}";
        #endregion
    }
}

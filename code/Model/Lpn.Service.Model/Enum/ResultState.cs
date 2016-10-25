namespace OneCoin.Service.Model.Enum
{
    public enum ResultState
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        Unknow = -1,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,

        /// <summary>
        /// 特殊消息
        /// </summary>
        SpecialMessage = 99,

        //类型  
        //      10 底层错误
        //      11 逻辑错误
        //      12 信息
        //功能模块   
        //      01  系统全局
        //      02  账号相关
        //      03  角色相关
        //      04  版本控制
        //      05  充值相关
        //      06  战役相关
        //      07  副本相关
        //      08  资源相关
        //      09  邮件相关

        #region 分段[1X(状态类型)YY(功能模块)ZZZ(具体状态码)]

        #region 系统全局[1001XXX] 前缀Global

        /// <summary>
        /// 系统错误
        /// </summary>
        GlobalSystemError = -1001001,

        /// <summary>
        /// 数据库错误
        /// </summary>
        GlobalDbError = -1001002,

        /// <summary>
        /// 参数错误
        /// </summary>
        GlobalParameterError = -1001003,

        /// <summary>
        /// 非法字符
        /// </summary>
        GlobalBadWordError = -1001004,

        /// <summary>
        /// 系统维护中
        /// </summary>
        GlobalServerMaintain = -1001005,

        /// <summary>
        /// 数据库不存在该基础数据
        /// </summary>
        GlobalNotData = -1001006,

        /// <summary>
        /// 签名不正确
        /// </summary>
        GlobalSignInvalid = -1001007,

        /// <summary>
        /// 不支持此功能
        /// </summary>
        GlobalNotSupport = -1001008,

        /// <summary>
        /// 次数用完：使用次数
        /// </summary>
        GlobalNoTimes = -1001009,

        /// <summary>
        /// 配置错误
        /// </summary>
        GlobalConfigError = -1001010,

        /// <summary>
        /// 配置错误
        /// </summary>
        GlobalNoRight = -1001011,

        /// <summary>
        /// 字符串太长
        /// </summary>
        GlobalLengthTooLong = -1001012,

        /// <summary>
        /// 手机号码错误
        /// </summary>
        GlobalMobileError = -1001013,


        /// <summary>
        /// 超时查询
        /// </summary>
        GlobalTimeout = -1001014,


        /// <summary>
        /// 无响应
        /// </summary>
        GlobalNoAction = -1001015,

        /// <summary>
        /// 验证码错误
        /// </summary>
        GlobalVCodeError = -1001016,

        /// <summary>
        /// 太频繁
        /// </summary>
        GlobalTooFrequency = -1001017,

        /// <summary>
        /// 数量过多
        /// </summary>
        GlobalMuchData = -1001018,
        #endregion

        #region 预约相关[1X01XXX] 前缀Sub

        /// <summary>
        /// 车位预约失败
        /// </summary>
        SubFault = -1101601,

        /// <summary>
        /// 支付停车场费失败
        /// </summary>
        SubPayFault = -1101602,

        /// <summary>
        /// 查询停车费用失败
        /// </summary>
        SubQueryPayFault = -1101603,

        /// <summary>
        /// 非预约车
        /// </summary>
        SubNotSubCar = -1101604,


        #endregion

        #region 用户账号相关 [1X02XXX] 前缀Account
        /// <summary>
        /// 用户会话异常
        /// </summary>
        AccountSessionError = -1102001,

        /// <summary>
        /// 禁止登陆
        /// </summary>
        AccountIsFrobidden = -1102002,

        /// <summary>
        /// 账号系统异常
        /// </summary>
        AccountServerError = -1102003,


        /// <summary>
        /// 账号已注册
        /// </summary>
        AccountAccountIsRegisted = -1102004,


        /// <summary>
        /// 验证码错误
        /// </summary>
        AccountValidCodeError = -1102005,

        /// <summary>
        /// 验证码发送时间过短
        /// </summary>
        AccountValidCodeTooFrequent = -1102006,


        /// <summary>
        /// 账号不存在
        /// </summary>
        AccountNotExists = -1102007,

        /// <summary>
        /// 密码错误
        /// </summary>
        AccountPwdError = -1102008,

        /// <summary>
        /// 驾驶证错误
        /// </summary>
        AccountDriverLicenceError = -1102009,
        #endregion

        #region 停车场相关 [1X03XXX] 前缀Park

        /// <summary>
        /// 停车场注册失败
        /// </summary>
        ParkRegistError = -1103001,

        /// <summary>
        /// 停车场不存在
        /// </summary>
        ParkNotExists = -1103002,


        /// <summary>
        /// 停车场不支持支付请求
        /// </summary>
        ParkCanNotPay = -1103003,
        #endregion

        #region 车辆相关 [1X04XXX] 前缀Car

        /// <summary>
        /// 车辆未入场
        /// </summary>
        CarNotIn = -1104001,

        /// <summary>
        /// 车牌号已注册
        /// </summary>
        CarRegisted = -1104002,

        /// <summary>
        /// 车牌找回请求正在处理中
        /// </summary>
        CarFinding = -1104003,

        /// <summary>
        /// 用户没有登记或共享车牌
        /// </summary>
        CarUnRegisted = -1104004,

        /// <summary>
        /// 车牌已授权该用户
        /// </summary>
        CarAuthorizationed = -1104005,


        /// <summary>
        /// 绑定了过多的车牌
        /// </summary>
        CarBindedTooMuch = -1104006,
        #endregion

        #region 支付相关 [1X05XXX] 前缀Pay

        /// <summary>
        /// 余额不足
        /// </summary>
        PayMoneyNotEnough = -1105001,

        /// <summary>
        /// 重复订单,之前的订单还在处理中
        /// </summary>
        PayOrderDuplicate = -1105002,
        #endregion

        #region 优惠券相关 [1X06XXX] 前缀Coupon

        /// <summary>
        /// 优惠券已领取 
        /// </summary>
        CouponHaveGet = -1106001,

        /// <summary>
        /// 优惠券已领取完
        /// </summary>
        CouponComplated = -1106002,

        /// <summary>
        /// 优惠券已过期
        /// </summary>
        CouponExpired = -1106003,

        /// <summary>
        /// 无法使用优惠券
        /// </summary>
        CouponCanntUse = -1106004,
        #endregion

        #region 自定义用户配置  [1X07XXX]  前缀Appconfig


        #endregion

        #region 车位锁相关  [1X08XXX]  前缀ParkLock

        /// <summary>
        /// 未找到车位锁
        /// </summary>
        ParkLockNotFound = -1108001,

        /// <summary>
        /// 车位锁已绑定
        /// </summary>
        ParkLockHasLocked = -1108002,

        /// <summary>
        /// 未找到用户
        /// </summary>
        ParkLockUserNotFound = -1108003,

        /// <summary>
        /// 未找到绑定关系
        /// </summary>
        ParkLockRelationNotFound = -1108004,

        /// <summary>
        /// 车场离线
        /// </summary>
        ParkOffline = -1108005,

        #endregion

        #region 月租服务相关  [1X09XXX]  前缀Monthly

        /// <summary>
        /// 不能添加月租车
        /// </summary>
        MonthlyNotOperatedByLocal = -1109001,


        /// <summary>
        /// 已经购买了全月租
        /// </summary>
        MonthlyExistsFullMonthCar = -1109002,

        /// <summary>
        /// 暂不支持月租授权
        /// </summary>
        MonthlyCarAuthNotSupport = -1109003,

        #endregion

        #region 车辆防盗  [1X10XXX]  前缀Antithief

        /// <summary>
        /// 车牌授权不合法
        /// </summary>
        AntithiefUnAuthed = -1110001,

        /// <summary>
        /// 无入场记录
        /// </summary>
        AntithiefNotEnter = -1110002,

        /// <summary>
        /// 车辆已布防
        /// </summary>
        AntithiefEnabled = -1110003,

        /// <summary>
        /// 停车场布/撤防失败
        /// </summary>
        AntithiefLocalFailed = -1110004,

        /// <summary>
        /// 车辆未布防(撤防提示)
        /// </summary>
        AntithiefUnEnabled = -1110005,


        #endregion

        #region APP版本相关  [1X11XXX]  前缀App

        /// <summary>
        /// 未找到该类型的版本
        /// </summary>
        AppTypeNotFound = -1111001,

        /// <summary>
        /// 无需升级
        /// </summary>
        AppTypeNotNeed = -1111002,

        #endregion

        #region 手机短信  [1X12XXX]  前缀Sms

        /// <summary>
        /// 短信发送失败
        /// </summary>
        SmsSendFailed = -1112001,

        #endregion

        #region 天气信息相关  [1X12XXX]  前缀Weather

        /// <summary>
        /// 获取天气失败
        /// </summary>
        WeatherGetFailed = -1112002,

        #endregion

        #region Banner信息相关  [1X13XXX]  前缀Banner

        /// <summary>
        /// 无需更新
        /// </summary>
        BannerExitsted = -1113001,

        #endregion

        #region 时段月租服务相关  [1X14XXX]  前缀MonthlyTime

        /// <summary>
        /// 时段月租已售罄
        /// </summary>
        MonthlyTimeNotForSale = -1101401,

        #endregion

        #region 活动相关  [1X15XXX]  前缀Activity

        /// <summary>
        ///  已售罄
        /// </summary>
        ActivityRestNumNotEnough = -1115001,

        /// <summary>
        /// 已参加活动
        /// </summary>
        ActivityHaveJoined = -1115002,

        /// <summary>
        /// 不符合条件
        /// </summary>
        ActivityNotMatch = -1115003,

        #endregion

        #region 物业系统相关  [1X16XXX]  前缀Sync

        /// <summary>
        ///  车牌号冲突
        /// </summary>
        SyncCarNoConflict = -1116001,

        #endregion

        #region 推荐新人相关  [1X17XXX]  前缀Recommend

        /// <summary>
        ///  您不能领取自己发放的优惠劵
        /// </summary>
        RecommendNotMine = -1117001,

        /// <summary>
        /// 您已经领取新人优惠劵
        /// </summary>
        RecommendReceived = -1117002,

        /// <summary>
        /// 推荐活动已经结束或者礼包被领取完
        /// </summary>
        RecommendNotEffective = -1117003,

        #endregion


        #region 车主认证   [1X18XXX]  前缀CarVerify

        /// <summary>
        /// 已认证通过
        /// </summary>
        CarVerifyHasPassed = -1118001,

       
        #endregion

        #endregion
    }
}

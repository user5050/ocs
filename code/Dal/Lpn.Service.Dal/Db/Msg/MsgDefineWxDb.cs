using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Msg
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class MsgDefineWxDb
    {
        #region id
        private int _fId;

        /// <summary>
        /// id
        /// </summary>
        public  int  Id
        {
            get
            {
                return  _fId;
            }
            set
            {
                  _fId = value;
            }
         }
        #endregion

        #region 触发类型(平台提供)
        private int _fTriggerType;

        /// <summary>
        /// 触发类型(平台提供)
        /// </summary>
        public  int  TriggerType
        {
            get
            {
                return  _fTriggerType;
            }
            set
            {
                  _fTriggerType = value;
            }
         }
        #endregion

        #region 内容头部
        private string _fHead;

        /// <summary>
        /// 内容头部
        /// </summary>
        public  string  Head
        {
            get
            {
                return  _fHead;
            }
            set
            {
                  _fHead = value;
            }
         }
        #endregion

        #region 内容尾部
        private string _fTail;

        /// <summary>
        /// 内容尾部
        /// </summary>
        public  string  Tail
        {
            get
            {
                return  _fTail;
            }
            set
            {
                  _fTail = value;
            }
         }
        #endregion

        #region 备注
        private string _fRemark;

        /// <summary>
        /// 备注
        /// </summary>
        public  string  Remark
        {
            get
            {
                return  _fRemark;
            }
            set
            {
                  _fRemark = value;
            }
         }
        #endregion

        #region 跳转动作类型(0:无1:打开链接2:系统页面)
        private int _fJumpType;

        /// <summary>
        /// 跳转动作类型(0:无1:打开链接2:系统页面)
        /// </summary>
        public  int  JumpType
        {
            get
            {
                return  _fJumpType;
            }
            set
            {
                  _fJumpType = value;
            }
         }
        #endregion

        #region 跳转配置
        private string _fJumpConfig;

        /// <summary>
        /// 跳转配置
        /// </summary>
        public  string  JumpConfig
        {
            get
            {
                return  _fJumpConfig;
            }
            set
            {
                  _fJumpConfig = value;
            }
         }
        #endregion

        #region 限制的城市,逗号分隔
        private string _fLimitCity;

        /// <summary>
        /// 限制的城市,逗号分隔
        /// </summary>
        public  string  LimitCity
        {
            get
            {
                return  _fLimitCity;
            }
            set
            {
                  _fLimitCity = value;
            }
         }
        #endregion

        #region 限制的停车场编号，逗号分隔
        private string _fLimitPark;

        /// <summary>
        /// 限制的停车场编号，逗号分隔
        /// </summary>
        public  string  LimitPark
        {
            get
            {
                return  _fLimitPark;
            }
            set
            {
                  _fLimitPark = value;
            }
         }
        #endregion

        #region 限制的手机号码，逗号分隔
        private string _fLimitMobile;

        /// <summary>
        /// 限制的手机号码，逗号分隔
        /// </summary>
        public  string  LimitMobile
        {
            get
            {
                return  _fLimitMobile;
            }
            set
            {
                  _fLimitMobile = value;
            }
         }
        #endregion

        #region 生效时间
        private DateTime _fStartTime;

        /// <summary>
        /// 生效时间
        /// </summary>
        public  DateTime  StartTime
        {
            get
            {
                return  _fStartTime;
            }
            set
            {
                  _fStartTime = value;
            }
         }
        #endregion

        #region 失效时间
        private DateTime _fEndTime;

        /// <summary>
        /// 失效时间
        /// </summary>
        public  DateTime  EndTime
        {
            get
            {
                return  _fEndTime;
            }
            set
            {
                  _fEndTime = value;
            }
         }
        #endregion

        #region 每次推送的时间间隔(天)(TriggerType 为定时发送时有效)
        private int _fIntervalPreTime;

        /// <summary>
        /// 每次推送的时间间隔(天)(TriggerType 为定时发送时有效)
        /// </summary>
        public  int  IntervalPreTime
        {
            get
            {
                return  _fIntervalPreTime;
            }
            set
            {
                  _fIntervalPreTime = value;
            }
         }
        #endregion

        #region 创建时间
        private DateTime _fRowTime;

        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime  RowTime
        {
            get
            {
                return  _fRowTime;
            }
            set
            {
                  _fRowTime = value;
            }
         }
        #endregion

        #region 优先级(倒叙)
        private int _fOrder;

        /// <summary>
        /// 优先级(倒叙)
        /// </summary>
        public  int  Order
        {
            get
            {
                return  _fOrder;
            }
            set
            {
                  _fOrder = value;
            }
         }
        #endregion

        #region 最近操作人
        private string _fOperator;

        /// <summary>
        /// 最近操作人
        /// </summary>
        public  string  Operator
        {
            get
            {
                return  _fOperator;
            }
            set
            {
                  _fOperator = value;
            }
         }
        #endregion

        #region 最近操作时间
        private DateTime _fOperateTime;

        /// <summary>
        /// 最近操作时间
        /// </summary>
        public  DateTime  OperateTime
        {
            get
            {
                return  _fOperateTime;
            }
            set
            {
                  _fOperateTime = value;
            }
         }
        #endregion

     }
}


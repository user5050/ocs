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
    public partial class MsgUserLogDb
    {
        #region 用户id
        private int _fUserId;

        /// <summary>
        /// 用户id
        /// </summary>
        public  int  UserId
        {
            get
            {
                return  _fUserId;
            }
            set
            {
                  _fUserId = value;
            }
         }
        #endregion

        #region 消息模板id
        private int _fMsgId;

        /// <summary>
        /// 消息模板id
        /// </summary>
        public  int  MsgId
        {
            get
            {
                return  _fMsgId;
            }
            set
            {
                  _fMsgId = value;
            }
         }
        #endregion

        #region 消息模板类型
        private int _fMsgType;

        /// <summary>
        /// 消息模板类型
        /// </summary>
        public  int  MsgType
        {
            get
            {
                return  _fMsgType;
            }
            set
            {
                  _fMsgType = value;
            }
         }
        #endregion

        #region 发送时间
        private DateTime _fSendTime;

        /// <summary>
        /// 发送时间
        /// </summary>
        public  DateTime  SendTime
        {
            get
            {
                return  _fSendTime;
            }
            set
            {
                  _fSendTime = value;
            }
         }
        #endregion

        #region 总计发送次数
        private int _fSendCnt;

        /// <summary>
        /// 总计发送次数
        /// </summary>
        public  int  SendCnt
        {
            get
            {
                return  _fSendCnt;
            }
            set
            {
                  _fSendCnt = value;
            }
         }
        #endregion

        #region 最近发送日期
        private DateTime _fLastSendDate;

        /// <summary>
        /// 最近发送日期
        /// </summary>
        public  DateTime  LastSendDate
        {
            get
            {
                return  _fLastSendDate;
            }
            set
            {
                  _fLastSendDate = value;
            }
         }
        #endregion

     }
}


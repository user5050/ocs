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
    public partial class MsgStatSendDb
    {
        #region 消息Id
        private int _fMsgId;

        /// <summary>
        /// 消息Id
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

        #region 消息类型
        private int _fMsgType;

        /// <summary>
        /// 消息类型
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

        #region 发送次数
        private int _fCnt;

        /// <summary>
        /// 发送次数
        /// </summary>
        public  int  Cnt
        {
            get
            {
                return  _fCnt;
            }
            set
            {
                  _fCnt = value;
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

        #region 最近更新时间
        private DateTime _fLastTime;

        /// <summary>
        /// 最近更新时间
        /// </summary>
        public  DateTime  LastTime
        {
            get
            {
                return  _fLastTime;
            }
            set
            {
                  _fLastTime = value;
            }
         }
        #endregion

     }
}


using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Msg
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class MsgInfoDb
    {
        #region Id
        private long _fId;

        /// <summary>
        /// Id
        /// </summary>
        public  long  Id
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

        #region 用户id
        private string _fUid;

        /// <summary>
        /// 用户id
        /// </summary>
        public  string  Uid
        {
            get
            {
                return  _fUid;
            }
            set
            {
                  _fUid = value;
            }
         }
        #endregion

        #region 标题
        private string _fTitle;

        /// <summary>
        /// 标题
        /// </summary>
        public  string  Title
        {
            get
            {
                return  _fTitle;
            }
            set
            {
                  _fTitle = value;
            }
         }
        #endregion

        #region 内容
        private string _fContent;

        /// <summary>
        /// 内容
        /// </summary>
        public  string  Content
        {
            get
            {
                return  _fContent;
            }
            set
            {
                  _fContent = value;
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

        #region 结束时间
        private DateTime _fEndTime;

        /// <summary>
        /// 结束时间
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

        #region 是否已查看
        private int _fIsView;

        /// <summary>
        /// 是否已查看
        /// </summary>
        public  int  IsView
        {
            get
            {
                return  _fIsView;
            }
            set
            {
                  _fIsView = value;
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

     }
}


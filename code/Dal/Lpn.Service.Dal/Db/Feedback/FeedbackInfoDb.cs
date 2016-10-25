using System;

/*
* 由自动生成工具完成
* 描述:[feedback_info]回馈信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Feedback
{
    /// <summary>
    /// [feedback_info]回馈信息
    /// </summary>
    [Serializable]
    public partial class FeedbackInfoDb
    {
        #region 回馈信息编号
        private int _fID;

        /// <summary>
        /// 回馈信息编号
        /// </summary>
        public  int  ID
        {
            get
            {
                return  _fID;
            }
            set
            {
                  _fID = value;
            }
         }
        #endregion

        #region 用户名
        private string _fUserName;

        /// <summary>
        /// 用户名
        /// </summary>
        public  string  UserName
        {
            get
            {
                return  _fUserName;
            }
            set
            {
                  _fUserName = value;
            }
         }
        #endregion

        #region 联系方式
        private string _fContact;

        /// <summary>
        /// 联系方式
        /// </summary>
        public  string  Contact
        {
            get
            {
                return  _fContact;
            }
            set
            {
                  _fContact = value;
            }
         }
        #endregion

        #region 回馈内容
        private string _fFeedBack;

        /// <summary>
        /// 回馈内容
        /// </summary>
        public  string  FeedBack
        {
            get
            {
                return  _fFeedBack;
            }
            set
            {
                  _fFeedBack = value;
            }
         }
        #endregion

     }
}


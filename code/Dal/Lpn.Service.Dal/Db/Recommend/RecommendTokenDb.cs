using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Recommend
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class RecommendTokenDb
    {
        #region 推荐Token
        private string _fTokenId;

        /// <summary>
        /// 推荐Token
        /// </summary>
        public  string  TokenId
        {
            get
            {
                return  _fTokenId;
            }
            set
            {
                  _fTokenId = value;
            }
         }
        #endregion

        #region 推荐者ID
        private int _fUserId;

        /// <summary>
        /// 推荐者ID
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

        #region 推荐者微信昵称
        private string _fNick;

        /// <summary>
        /// 推荐者微信昵称
        /// </summary>
        public  string  Nick
        {
            get
            {
                return  _fNick;
            }
            set
            {
                  _fNick = value;
            }
         }
        #endregion

     }
}


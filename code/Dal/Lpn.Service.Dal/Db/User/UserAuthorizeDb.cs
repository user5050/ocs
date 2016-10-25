using System;

/*
* 由自动生成工具完成
* 描述:[user_authorize]用户模版权限
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.User
{
    /// <summary>
    /// [user_authorize]用户模版权限
    /// </summary>
    [Serializable]
    public partial class UserAuthorizeDb
    {
        #region 自增ID
        private int _fID;

        /// <summary>
        /// 自增ID
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

        #region 用户编号
        private int _fUserID;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  UserID
        {
            get
            {
                return  _fUserID;
            }
            set
            {
                  _fUserID = value;
            }
         }
        #endregion

        #region 用户模板权限
        private string _fUserAuthor;

        /// <summary>
        /// 用户模板权限
        /// </summary>
        public  string  UserAuthor
        {
            get
            {
                return  _fUserAuthor;
            }
            set
            {
                  _fUserAuthor = value;
            }
         }
        #endregion

        #region 用户职务
        private string _fUserPost;

        /// <summary>
        /// 用户职务
        /// </summary>
        public  string  UserPost
        {
            get
            {
                return  _fUserPost;
            }
            set
            {
                  _fUserPost = value;
            }
         }
        #endregion

     }
}


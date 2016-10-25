using System;

/*
* 由自动生成工具完成
* 描述:[park_lock_share]车位锁分享
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_lock_share]车位锁分享
    /// </summary>
    [Serializable]
    public partial class ParkLockShareDb
    {
        #region 车位锁分享编号
        private int _fID;

        /// <summary>
        /// 车位锁分享编号
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

        #region 车位锁编号
        private int _fShareID;

        /// <summary>
        /// 车位锁编号
        /// </summary>
        public  int  ShareID
        {
            get
            {
                return  _fShareID;
            }
            set
            {
                  _fShareID = value;
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

     }
}


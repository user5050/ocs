using System;

/*
* 由自动生成工具完成
* 描述:[park_spaces_share_subscribe_detail]
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_spaces_share_subscribe_detail]
    /// </summary>
    [Serializable]
    public partial class ParkSpacesShareSubscribeDetailDb
    {
        #region ID
        private string _fID;

        /// <summary>
        /// ID
        /// </summary>
        public  string  ID
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

        #region SubscribeTime
        private DateTime _fSubscribeTime;

        /// <summary>
        /// SubscribeTime
        /// </summary>
        public  DateTime  SubscribeTime
        {
            get
            {
                return  _fSubscribeTime;
            }
            set
            {
                  _fSubscribeTime = value;
            }
         }
        #endregion

        #region Minutes
        private int _fMinutes;

        /// <summary>
        /// Minutes
        /// </summary>
        public  int  Minutes
        {
            get
            {
                return  _fMinutes;
            }
            set
            {
                  _fMinutes = value;
            }
         }
        #endregion

     }
}


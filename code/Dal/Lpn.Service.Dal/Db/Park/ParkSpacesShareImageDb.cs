using System;

/*
* 由自动生成工具完成
* 描述:[park_spaces_share_image]
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_spaces_share_image]
    /// </summary>
    [Serializable]
    public partial class ParkSpacesShareImageDb
    {
        #region SpaceID
        private string _fSpaceID;

        /// <summary>
        /// SpaceID
        /// </summary>
        public  string  SpaceID
        {
            get
            {
                return  _fSpaceID;
            }
            set
            {
                  _fSpaceID = value;
            }
         }
        #endregion

        #region IDX
        private int _fIDX;

        /// <summary>
        /// IDX
        /// </summary>
        public  int  IDX
        {
            get
            {
                return  _fIDX;
            }
            set
            {
                  _fIDX = value;
            }
         }
        #endregion

        #region Picture
        private string _fPicture;

        /// <summary>
        /// Picture
        /// </summary>
        public  string  Picture
        {
            get
            {
                return  _fPicture;
            }
            set
            {
                  _fPicture = value;
            }
         }
        #endregion

        #region Stamp
        private string _fStamp;

        /// <summary>
        /// Stamp
        /// </summary>
        public  string  Stamp
        {
            get
            {
                return  _fStamp;
            }
            set
            {
                  _fStamp = value;
            }
         }
        #endregion

     }
}


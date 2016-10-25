using System;

/*
* 由自动生成工具完成
* 描述:停车场管理员
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.R
{
    /// <summary>
    /// 停车场管理员
    /// </summary>
    [Serializable]
    public partial class RParkUserDb
    {
        #region 停车场管理员编号
        private int _fID;

        /// <summary>
        /// 停车场管理员编号
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

        #region 停车场编号
        private string _fParkID;

        /// <summary>
        /// 停车场编号
        /// </summary>
        public  string  ParkID
        {
            get
            {
                return  _fParkID;
            }
            set
            {
                  _fParkID = value;
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


using System;

/*
* 由自动生成工具完成
* 描述:VIEW
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db
{
    /// <summary>
    /// VIEW
    /// </summary>
    [Serializable]
    public partial class CarownerappviewDb
    {
        #region 车辆找回信息编号
        private int _fId;

        /// <summary>
        /// 车辆找回信息编号
        /// </summary>
        public  int  Id
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

        #region 车牌号
        private string _fCarno;

        /// <summary>
        /// 车牌号
        /// </summary>
        public  string  Carno
        {
            get
            {
                return  _fCarno;
            }
            set
            {
                  _fCarno = value;
            }
         }
        #endregion

        #region 提交者编号
        private int _fUserid;

        /// <summary>
        /// 提交者编号
        /// </summary>
        public  int  Userid
        {
            get
            {
                return  _fUserid;
            }
            set
            {
                  _fUserid = value;
            }
         }
        #endregion

        #region 车辆图片
        private string _fImg;

        /// <summary>
        /// 车辆图片
        /// </summary>
        public  string  Img
        {
            get
            {
                return  _fImg;
            }
            set
            {
                  _fImg = value;
            }
         }
        #endregion

        #region 用户名
        private string _fUsername;

        /// <summary>
        /// 用户名
        /// </summary>
        public  string  Username
        {
            get
            {
                return  _fUsername;
            }
            set
            {
                  _fUsername = value;
            }
         }
        #endregion

        #region 状态
        private int _fState;

        /// <summary>
        /// 状态
        /// </summary>
        public  int  State
        {
            get
            {
                return  _fState;
            }
            set
            {
                  _fState = value;
            }
         }
        #endregion

     }
}


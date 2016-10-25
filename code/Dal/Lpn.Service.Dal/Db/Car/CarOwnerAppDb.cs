using System;

/*
* 由自动生成工具完成
* 描述:[car_owner_app]车辆找回信息表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Car
{
    /// <summary>
    /// [car_owner_app]车辆找回信息表
    /// </summary>
    [Serializable]
    public partial class CarOwnerAppDb
    {
        #region 车辆找回信息编号
        private int _fID;

        /// <summary>
        /// 车辆找回信息编号
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
        private int _fUserID;

        /// <summary>
        /// 提交者编号
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

     }
}


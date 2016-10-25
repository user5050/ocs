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
    public partial class CarownerviewDb
    {
        #region 车牌分享编号
        private int _fId;

        /// <summary>
        /// 车牌分享编号
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

        #region 车辆品牌
        private string _fCarbrand;

        /// <summary>
        /// 车辆品牌
        /// </summary>
        public  string  Carbrand
        {
            get
            {
                return  _fCarbrand;
            }
            set
            {
                  _fCarbrand = value;
            }
         }
        #endregion

        #region 车辆颜色
        private string _fColor;

        /// <summary>
        /// 车辆颜色
        /// </summary>
        public  string  Color
        {
            get
            {
                return  _fColor;
            }
            set
            {
                  _fColor = value;
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

        #region 是否注册
        private int _fIsregdit;

        /// <summary>
        /// 是否注册
        /// </summary>
        public  int  Isregdit
        {
            get
            {
                return  _fIsregdit;
            }
            set
            {
                  _fIsregdit = value;
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


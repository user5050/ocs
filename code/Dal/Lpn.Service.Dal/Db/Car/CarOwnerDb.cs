using System;

/*
* 由自动生成工具完成
* 描述:[car_owner]车辆注册表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Car
{
    /// <summary>
    /// [car_owner]车辆注册表
    /// </summary>
    [Serializable]
    public partial class CarOwnerDb
    {
        #region 车辆注册编号
        private int _fID;

        /// <summary>
        /// 车辆注册编号
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

        #region 归属者编号
        private int _fUserID;

        /// <summary>
        /// 归属者编号
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

        #region 车辆品牌
        private string _fCarBrand;

        /// <summary>
        /// 车辆品牌
        /// </summary>
        public  string  CarBrand
        {
            get
            {
                return  _fCarBrand;
            }
            set
            {
                  _fCarBrand = value;
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

        #region 绑定时间
        private DateTime _fRowTime;

        /// <summary>
        /// 绑定时间
        /// </summary>
        public  DateTime  RowTime
        {
            get
            {
                return  _fRowTime;
            }
            set
            {
                  _fRowTime = value;
            }
         }
        #endregion

        #region 设备类型(1 IOS 2 安卓 3 IOS微信  4  安卓微信
        private int _fClientType;

        /// <summary>
        /// 设备类型(1 IOS 2 安卓 3 IOS微信  4  安卓微信
        /// </summary>
        public  int  ClientType
        {
            get
            {
                return  _fClientType;
            }
            set
            {
                  _fClientType = value;
            }
         }
        #endregion

     }
}


using System;

/*
* 由自动生成工具完成
* 描述:[car_ment]车牌分享列表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Car
{
    /// <summary>
    /// [car_ment]车牌分享列表
    /// </summary>
    [Serializable]
    public partial class CarMentDb
    {
        #region 车牌分享编号
        private int _fID;

        /// <summary>
        /// 车牌分享编号
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

        #region 使用者编号
        private int _fUserID;

        /// <summary>
        /// 使用者编号
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

        #region 是否注册
        private int _fIsRegdit;

        /// <summary>
        /// 是否注册
        /// </summary>
        public  int  IsRegdit
        {
            get
            {
                return  _fIsRegdit;
            }
            set
            {
                  _fIsRegdit = value;
            }
         }
        #endregion

        #region 车辆类型
        private int _fCarType;

        /// <summary>
        /// 车辆类型
        /// </summary>
        public  int  CarType
        {
            get
            {
                return  _fCarType;
            }
            set
            {
                  _fCarType = value;
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

        #region 车辆型号
        private string _fCarModel;

        /// <summary>
        /// 车辆型号
        /// </summary>
        public  string  CarModel
        {
            get
            {
                return  _fCarModel;
            }
            set
            {
                  _fCarModel = value;
            }
         }
        #endregion

        #region 归属者编号
        private int _fOwnerID;

        /// <summary>
        /// 归属者编号
        /// </summary>
        public  int  OwnerID
        {
            get
            {
                return  _fOwnerID;
            }
            set
            {
                  _fOwnerID = value;
            }
         }
        #endregion

     }
}


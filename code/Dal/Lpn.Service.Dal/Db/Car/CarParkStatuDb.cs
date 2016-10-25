using System;

/*
* 由自动生成工具完成
* 描述:车辆进出场状态信息表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Car
{
    /// <summary>
    /// 车辆进出场状态信息表
    /// </summary>
    [Serializable]
    public partial class CarParkStatuDb
    {
        #region 车牌号
        private string _fCarNo;

        /// <summary>
        /// 车牌号
        /// </summary>
        public  string  CarNo
        {
            get
            {
                return  _fCarNo;
            }
            set
            {
                  _fCarNo = value;
            }
         }
        #endregion

        #region 出入场状态(1入场  2 出场)
        private int _fInOrOut;

        /// <summary>
        /// 出入场状态(1入场  2 出场)
        /// </summary>
        public  int  InOrOut
        {
            get
            {
                return  _fInOrOut;
            }
            set
            {
                  _fInOrOut = value;
            }
         }
        #endregion

        #region 最近更新时间
        private DateTime _fTime;

        /// <summary>
        /// 最近更新时间
        /// </summary>
        public  DateTime  Time
        {
            get
            {
                return  _fTime;
            }
            set
            {
                  _fTime = value;
            }
         }
        #endregion

        #region 停车场编号
        private string _fParkCode;

        /// <summary>
        /// 停车场编号
        /// </summary>
        public  string  ParkCode
        {
            get
            {
                return  _fParkCode;
            }
            set
            {
                  _fParkCode = value;
            }
         }
        #endregion

     }
}


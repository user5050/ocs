using System;

/*
* 由自动生成工具完成
* 描述:[park_points]停车场地图标记信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_points]停车场地图标记信息
    /// </summary>
    [Serializable]
    public partial class ParkPointDb
    {
        #region 停车场地图标记信息编
        private int _fID;

        /// <summary>
        /// 停车场地图标记信息编
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
        private int _fParkID;

        /// <summary>
        /// 停车场编号
        /// </summary>
        public  int  ParkID
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

        #region 纬度
        private double _fLng;

        /// <summary>
        /// 纬度
        /// </summary>
        public  double  Lng
        {
            get
            {
                return  _fLng;
            }
            set
            {
                  _fLng = value;
            }
         }
        #endregion

        #region 经度
        private double _fLat;

        /// <summary>
        /// 经度
        /// </summary>
        public  double  Lat
        {
            get
            {
                return  _fLat;
            }
            set
            {
                  _fLat = value;
            }
         }
        #endregion

        #region 进出口标志
        private int _fPointType;

        /// <summary>
        /// 进出口标志
        /// </summary>
        public  int  PointType
        {
            get
            {
                return  _fPointType;
            }
            set
            {
                  _fPointType = value;
            }
         }
        #endregion

        #region 进出口名称
        private string _fPointName;

        /// <summary>
        /// 进出口名称
        /// </summary>
        public  string  PointName
        {
            get
            {
                return  _fPointName;
            }
            set
            {
                  _fPointName = value;
            }
         }
        #endregion

     }
}


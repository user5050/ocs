using System;

/*
* 由自动生成工具完成
* 描述:[park_infoextra]非e泊停车场信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_infoextra]非e泊停车场信息
    /// </summary>
    [Serializable]
    public partial class ParkInfoextraDb
    {
        #region 标识
        private int _fId;

        /// <summary>
        /// 标识
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

        #region 停车场名称
        private string _fParkname;

        /// <summary>
        /// 停车场名称
        /// </summary>
        public  string  Parkname
        {
            get
            {
                return  _fParkname;
            }
            set
            {
                  _fParkname = value;
            }
         }
        #endregion

        #region 图片地址
        private string _fImgurl;

        /// <summary>
        /// 图片地址
        /// </summary>
        public  string  Imgurl
        {
            get
            {
                return  _fImgurl;
            }
            set
            {
                  _fImgurl = value;
            }
         }
        #endregion

        #region 停车场编码
        private string _fParkcode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  Parkcode
        {
            get
            {
                return  _fParkcode;
            }
            set
            {
                  _fParkcode = value;
            }
         }
        #endregion

        #region 停车场地址
        private string _fParkaddr;

        /// <summary>
        /// 停车场地址
        /// </summary>
        public  string  Parkaddr
        {
            get
            {
                return  _fParkaddr;
            }
            set
            {
                  _fParkaddr = value;
            }
         }
        #endregion

        #region 经度
        private double _fLng;

        /// <summary>
        /// 经度
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

        #region 纬度
        private double _fLat;

        /// <summary>
        /// 纬度
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

        #region 总车位
        private int _fLotcount;

        /// <summary>
        /// 总车位
        /// </summary>
        public  int  Lotcount
        {
            get
            {
                return  _fLotcount;
            }
            set
            {
                  _fLotcount = value;
            }
         }
        #endregion

        #region 可用车位
        private int _fIdlelotcount;

        /// <summary>
        /// 可用车位
        /// </summary>
        public  int  Idlelotcount
        {
            get
            {
                return  _fIdlelotcount;
            }
            set
            {
                  _fIdlelotcount = value;
            }
         }
        #endregion

        #region 车库类型
        private string _fParktype;

        /// <summary>
        /// 车库类型
        /// </summary>
        public  string  Parktype
        {
            get
            {
                return  _fParktype;
            }
            set
            {
                  _fParktype = value;
            }
         }
        #endregion

        #region 免费出场时间
        private int _fFreeexittime;

        /// <summary>
        /// 免费出场时间
        /// </summary>
        public  int  Freeexittime
        {
            get
            {
                return  _fFreeexittime;
            }
            set
            {
                  _fFreeexittime = value;
            }
         }
        #endregion

        #region 费率摘要
        private string _fParkfeesummary;

        /// <summary>
        /// 费率摘要
        /// </summary>
        public  string  Parkfeesummary
        {
            get
            {
                return  _fParkfeesummary;
            }
            set
            {
                  _fParkfeesummary = value;
            }
         }
        #endregion

        #region 标签说明
        private string _fMarkdesc;

        /// <summary>
        /// 标签说明
        /// </summary>
        public  string  Markdesc
        {
            get
            {
                return  _fMarkdesc;
            }
            set
            {
                  _fMarkdesc = value;
            }
         }
        #endregion

     }
}


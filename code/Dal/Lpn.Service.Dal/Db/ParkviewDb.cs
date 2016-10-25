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
    public partial class ParkviewDb
    {
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

        #region 企业名称
        private string _fParkcompany;

        /// <summary>
        /// 企业名称
        /// </summary>
        public  string  Parkcompany
        {
            get
            {
                return  _fParkcompany;
            }
            set
            {
                  _fParkcompany = value;
            }
         }
        #endregion

        #region 总车位数
        private int _fParklotall;

        /// <summary>
        /// 总车位数
        /// </summary>
        public  int  Parklotall
        {
            get
            {
                return  _fParklotall;
            }
            set
            {
                  _fParklotall = value;
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

        #region 停车场地图标记信息编
        private int _fPid;

        /// <summary>
        /// 停车场地图标记信息编
        /// </summary>
        public  int  Pid
        {
            get
            {
                return  _fPid;
            }
            set
            {
                  _fPid = value;
            }
         }
        #endregion

        #region 停车场运行状态
        private int _fStatus;

        /// <summary>
        /// 停车场运行状态
        /// </summary>
        public  int  Status
        {
            get
            {
                return  _fStatus;
            }
            set
            {
                  _fStatus = value;
            }
         }
        #endregion

        #region VIP泊位空闲数
        private int _fVipcount;

        /// <summary>
        /// VIP泊位空闲数
        /// </summary>
        public  int  Vipcount
        {
            get
            {
                return  _fVipcount;
            }
            set
            {
                  _fVipcount = value;
            }
         }
        #endregion

        #region 对外经营泊位空闲数
        private int _fOperatecount;

        /// <summary>
        /// 对外经营泊位空闲数
        /// </summary>
        public  int  Operatecount
        {
            get
            {
                return  _fOperatecount;
            }
            set
            {
                  _fOperatecount = value;
            }
         }
        #endregion

        #region 停车场电话
        private string _fParktel;

        /// <summary>
        /// 停车场电话
        /// </summary>
        public  string  Parktel
        {
            get
            {
                return  _fParktel;
            }
            set
            {
                  _fParktel = value;
            }
         }
        #endregion

        #region 停车场编号
        private int _fId;

        /// <summary>
        /// 停车场编号
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

        #region 停车场图片
        private string _fImgurl;

        /// <summary>
        /// 停车场图片
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

        #region 地域编号
        private string _fAreacode;

        /// <summary>
        /// 地域编号
        /// </summary>
        public  string  Areacode
        {
            get
            {
                return  _fAreacode;
            }
            set
            {
                  _fAreacode = value;
            }
         }
        #endregion

        #region 经营者
        private string _fParkoperator;

        /// <summary>
        /// 经营者
        /// </summary>
        public  string  Parkoperator
        {
            get
            {
                return  _fParkoperator;
            }
            set
            {
                  _fParkoperator = value;
            }
         }
        #endregion

        #region 是否在用
        private string _fParkissued;

        /// <summary>
        /// 是否在用
        /// </summary>
        public  string  Parkissued
        {
            get
            {
                return  _fParkissued;
            }
            set
            {
                  _fParkissued = value;
            }
         }
        #endregion

        #region 泊车位
        private int _fParklotplan;

        /// <summary>
        /// 泊车位
        /// </summary>
        public  int  Parklotplan
        {
            get
            {
                return  _fParklotplan;
            }
            set
            {
                  _fParklotplan = value;
            }
         }
        #endregion

        #region Parklotnomechanical
        private int _fParklotnomechanical;

        /// <summary>
        /// Parklotnomechanical
        /// </summary>
        public  int  Parklotnomechanical
        {
            get
            {
                return  _fParklotnomechanical;
            }
            set
            {
                  _fParklotnomechanical = value;
            }
         }
        #endregion

        #region Parklotmechanical
        private int _fParklotmechanical;

        /// <summary>
        /// Parklotmechanical
        /// </summary>
        public  int  Parklotmechanical
        {
            get
            {
                return  _fParklotmechanical;
            }
            set
            {
                  _fParklotmechanical = value;
            }
         }
        #endregion

        #region 对外经营车位数
        private int _fParklotoperate;

        /// <summary>
        /// 对外经营车位数
        /// </summary>
        public  int  Parklotoperate
        {
            get
            {
                return  _fParklotoperate;
            }
            set
            {
                  _fParklotoperate = value;
            }
         }
        #endregion

        #region VIP车位数
        private int _fParklotvip;

        /// <summary>
        /// VIP车位数
        /// </summary>
        public  int  Parklotvip
        {
            get
            {
                return  _fParklotvip;
            }
            set
            {
                  _fParklotvip = value;
            }
         }
        #endregion

        #region 是否连接
        private int _fIfconnect;

        /// <summary>
        /// 是否连接
        /// </summary>
        public  int  Ifconnect
        {
            get
            {
                return  _fIfconnect;
            }
            set
            {
                  _fIfconnect = value;
            }
         }
        #endregion

        #region IP地址
        private string _fIp;

        /// <summary>
        /// IP地址
        /// </summary>
        public  string  Ip
        {
            get
            {
                return  _fIp;
            }
            set
            {
                  _fIp = value;
            }
         }
        #endregion

        #region 连接端口
        private int _fPort;

        /// <summary>
        /// 连接端口
        /// </summary>
        public  int  Port
        {
            get
            {
                return  _fPort;
            }
            set
            {
                  _fPort = value;
            }
         }
        #endregion

        #region 记录类型
        private int _fRecordtype;

        /// <summary>
        /// 记录类型
        /// </summary>
        public  int  Recordtype
        {
            get
            {
                return  _fRecordtype;
            }
            set
            {
                  _fRecordtype = value;
            }
         }
        #endregion

        #region 停车场类型
        private string _fParktype;

        /// <summary>
        /// 停车场类型
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

        #region 停车场类别
        private string _fParksort;

        /// <summary>
        /// 停车场类别
        /// </summary>
        public  string  Parksort
        {
            get
            {
                return  _fParksort;
            }
            set
            {
                  _fParksort = value;
            }
         }
        #endregion

        #region 进口数量
        private int _fParkin;

        /// <summary>
        /// 进口数量
        /// </summary>
        public  int  Parkin
        {
            get
            {
                return  _fParkin;
            }
            set
            {
                  _fParkin = value;
            }
         }
        #endregion

        #region 出口数量
        private int _fParkout;

        /// <summary>
        /// 出口数量
        /// </summary>
        public  int  Parkout
        {
            get
            {
                return  _fParkout;
            }
            set
            {
                  _fParkout = value;
            }
         }
        #endregion

        #region 启用时间
        private DateTime _fStarttime;

        /// <summary>
        /// 启用时间
        /// </summary>
        public  DateTime  Starttime
        {
            get
            {
                return  _fStarttime;
            }
            set
            {
                  _fStarttime = value;
            }
         }
        #endregion

        #region 结束时间
        private DateTime _fEndtime;

        /// <summary>
        /// 结束时间
        /// </summary>
        public  DateTime  Endtime
        {
            get
            {
                return  _fEndtime;
            }
            set
            {
                  _fEndtime = value;
            }
         }
        #endregion

        #region 是否启用
        private int _fEnabled;

        /// <summary>
        /// 是否启用
        /// </summary>
        public  int  Enabled
        {
            get
            {
                return  _fEnabled;
            }
            set
            {
                  _fEnabled = value;
            }
         }
        #endregion

        #region 免费时间
        private int _fFreetime;

        /// <summary>
        /// 免费时间
        /// </summary>
        public  int  Freetime
        {
            get
            {
                return  _fFreetime;
            }
            set
            {
                  _fFreetime = value;
            }
         }
        #endregion

        #region 每小时的价格
        private int _fUnitprice;

        /// <summary>
        /// 每小时的价格
        /// </summary>
        public  int  Unitprice
        {
            get
            {
                return  _fUnitprice;
            }
            set
            {
                  _fUnitprice = value;
            }
         }
        #endregion

        #region 第一阶段价格
        private int _fFirstprice;

        /// <summary>
        /// 第一阶段价格
        /// </summary>
        public  int  Firstprice
        {
            get
            {
                return  _fFirstprice;
            }
            set
            {
                  _fFirstprice = value;
            }
         }
        #endregion

        #region 第一阶段时间
        private int _fFirsttime;

        /// <summary>
        /// 第一阶段时间
        /// </summary>
        public  int  Firsttime
        {
            get
            {
                return  _fFirsttime;
            }
            set
            {
                  _fFirsttime = value;
            }
         }
        #endregion

        #region 停车场状态
        private int _fParkstatus;

        /// <summary>
        /// 停车场状态
        /// </summary>
        public  int  Parkstatus
        {
            get
            {
                return  _fParkstatus;
            }
            set
            {
                  _fParkstatus = value;
            }
         }
        #endregion

     }
}


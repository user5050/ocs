using System;

/*
* 由自动生成工具完成
* 描述:[park_info]停车场信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_info]停车场信息
    /// </summary>
    [Serializable]
    public partial class ParkInfoDb
    {
        #region 停车场编号
        private int _fID;

        /// <summary>
        /// 停车场编号
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

        #region 地域编号
        private string _fAreaCode;

        /// <summary>
        /// 地域编号
        /// </summary>
        public  string  AreaCode
        {
            get
            {
                return  _fAreaCode;
            }
            set
            {
                  _fAreaCode = value;
            }
         }
        #endregion

        #region 停车场名称
        private string _fParkName;

        /// <summary>
        /// 停车场名称
        /// </summary>
        public  string  ParkName
        {
            get
            {
                return  _fParkName;
            }
            set
            {
                  _fParkName = value;
            }
         }
        #endregion

        #region 停车场图片
        private string _fImgUrl;

        /// <summary>
        /// 停车场图片
        /// </summary>
        public  string  ImgUrl
        {
            get
            {
                return  _fImgUrl;
            }
            set
            {
                  _fImgUrl = value;
            }
         }
        #endregion

        #region 停车场电话
        private string _fParkTel;

        /// <summary>
        /// 停车场电话
        /// </summary>
        public  string  ParkTel
        {
            get
            {
                return  _fParkTel;
            }
            set
            {
                  _fParkTel = value;
            }
         }
        #endregion

        #region 停车场地址
        private string _fParkAddr;

        /// <summary>
        /// 停车场地址
        /// </summary>
        public  string  ParkAddr
        {
            get
            {
                return  _fParkAddr;
            }
            set
            {
                  _fParkAddr = value;
            }
         }
        #endregion

        #region 企业名称
        private string _fParkCompany;

        /// <summary>
        /// 企业名称
        /// </summary>
        public  string  ParkCompany
        {
            get
            {
                return  _fParkCompany;
            }
            set
            {
                  _fParkCompany = value;
            }
         }
        #endregion

        #region 经营者
        private string _fParkOperator;

        /// <summary>
        /// 经营者
        /// </summary>
        public  string  ParkOperator
        {
            get
            {
                return  _fParkOperator;
            }
            set
            {
                  _fParkOperator = value;
            }
         }
        #endregion

        #region 是否在用
        private string _fParkIssued;

        /// <summary>
        /// 是否在用
        /// </summary>
        public  string  ParkIssued
        {
            get
            {
                return  _fParkIssued;
            }
            set
            {
                  _fParkIssued = value;
            }
         }
        #endregion

        #region 泊车位
        private int _fParkLotPlan;

        /// <summary>
        /// 泊车位
        /// </summary>
        public  int  ParkLotPlan
        {
            get
            {
                return  _fParkLotPlan;
            }
            set
            {
                  _fParkLotPlan = value;
            }
         }
        #endregion

        #region 总车位数
        private int _fParkLotAll;

        /// <summary>
        /// 总车位数
        /// </summary>
        public  int  ParkLotAll
        {
            get
            {
                return  _fParkLotAll;
            }
            set
            {
                  _fParkLotAll = value;
            }
         }
        #endregion

        #region ParkLotNomechanical
        private int _fParkLotNomechanical;

        /// <summary>
        /// ParkLotNomechanical
        /// </summary>
        public  int  ParkLotNomechanical
        {
            get
            {
                return  _fParkLotNomechanical;
            }
            set
            {
                  _fParkLotNomechanical = value;
            }
         }
        #endregion

        #region ParkLotMechanical
        private int _fParkLotMechanical;

        /// <summary>
        /// ParkLotMechanical
        /// </summary>
        public  int  ParkLotMechanical
        {
            get
            {
                return  _fParkLotMechanical;
            }
            set
            {
                  _fParkLotMechanical = value;
            }
         }
        #endregion

        #region 对外经营车位数
        private int _fParkLotOperate;

        /// <summary>
        /// 对外经营车位数
        /// </summary>
        public  int  ParkLotOperate
        {
            get
            {
                return  _fParkLotOperate;
            }
            set
            {
                  _fParkLotOperate = value;
            }
         }
        #endregion

        #region VIP车位数
        private int _fParkLotVip;

        /// <summary>
        /// VIP车位数
        /// </summary>
        public  int  ParkLotVip
        {
            get
            {
                return  _fParkLotVip;
            }
            set
            {
                  _fParkLotVip = value;
            }
         }
        #endregion

        #region 是否连接
        private int _fIfConnect;

        /// <summary>
        /// 是否连接
        /// </summary>
        public  int  IfConnect
        {
            get
            {
                return  _fIfConnect;
            }
            set
            {
                  _fIfConnect = value;
            }
         }
        #endregion

        #region IP地址
        private string _fIP;

        /// <summary>
        /// IP地址
        /// </summary>
        public  string  IP
        {
            get
            {
                return  _fIP;
            }
            set
            {
                  _fIP = value;
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
        private int _fRecordType;

        /// <summary>
        /// 记录类型
        /// </summary>
        public  int  RecordType
        {
            get
            {
                return  _fRecordType;
            }
            set
            {
                  _fRecordType = value;
            }
         }
        #endregion

        #region 停车场编码
        private string _fParkCode;

        /// <summary>
        /// 停车场编码
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

        #region 停车场类型
        private string _fParkType;

        /// <summary>
        /// 停车场类型
        /// </summary>
        public  string  ParkType
        {
            get
            {
                return  _fParkType;
            }
            set
            {
                  _fParkType = value;
            }
         }
        #endregion

        #region 停车场类别
        private string _fParkSort;

        /// <summary>
        /// 停车场类别
        /// </summary>
        public  string  ParkSort
        {
            get
            {
                return  _fParkSort;
            }
            set
            {
                  _fParkSort = value;
            }
         }
        #endregion

        #region 进口数量
        private int _fParkIn;

        /// <summary>
        /// 进口数量
        /// </summary>
        public  int  ParkIn
        {
            get
            {
                return  _fParkIn;
            }
            set
            {
                  _fParkIn = value;
            }
         }
        #endregion

        #region 出口数量
        private int _fParkOut;

        /// <summary>
        /// 出口数量
        /// </summary>
        public  int  ParkOut
        {
            get
            {
                return  _fParkOut;
            }
            set
            {
                  _fParkOut = value;
            }
         }
        #endregion

        #region 启用时间
        private DateTime _fStartTime;

        /// <summary>
        /// 启用时间
        /// </summary>
        public  DateTime  StartTime
        {
            get
            {
                return  _fStartTime;
            }
            set
            {
                  _fStartTime = value;
            }
         }
        #endregion

        #region 结束时间
        private DateTime _fEndTime;

        /// <summary>
        /// 结束时间
        /// </summary>
        public  DateTime  EndTime
        {
            get
            {
                return  _fEndTime;
            }
            set
            {
                  _fEndTime = value;
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

        #region 创建时间
        private DateTime _fAccessTime;

        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime  AccessTime
        {
            get
            {
                return  _fAccessTime;
            }
            set
            {
                  _fAccessTime = value;
            }
         }
        #endregion

        #region 校验码
        private string _fEncryptPwd;

        /// <summary>
        /// 校验码
        /// </summary>
        public  string  EncryptPwd
        {
            get
            {
                return  _fEncryptPwd;
            }
            set
            {
                  _fEncryptPwd = value;
            }
         }
        #endregion

        #region 停车场CAD文件地址
        private string _fCADUrl;

        /// <summary>
        /// 停车场CAD文件地址
        /// </summary>
        public  string  CADUrl
        {
            get
            {
                return  _fCADUrl;
            }
            set
            {
                  _fCADUrl = value;
            }
         }
        #endregion

        #region 停车场状态
        private int _fParkStatus;

        /// <summary>
        /// 停车场状态
        /// </summary>
        public  int  ParkStatus
        {
            get
            {
                return  _fParkStatus;
            }
            set
            {
                  _fParkStatus = value;
            }
         }
        #endregion

        #region 修改时间
        private string _fUpdateTime;

        /// <summary>
        /// 修改时间
        /// </summary>
        public  string  UpdateTime
        {
            get
            {
                return  _fUpdateTime;
            }
            set
            {
                  _fUpdateTime = value;
            }
         }
        #endregion

        #region 免费离场时间(分钟)
        private int _fFreeexittime;

        /// <summary>
        /// 免费离场时间(分钟)
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

        #region 0元弹窗
        private string _fTmppayconfirm;

        /// <summary>
        /// 0元弹窗
        /// </summary>
        public  string  Tmppayconfirm
        {
            get
            {
                return  _fTmppayconfirm;
            }
            set
            {
                  _fTmppayconfirm = value;
            }
         }
        #endregion

        #region 时段月租
        private string _fTimefix;

        /// <summary>
        /// 时段月租
        /// </summary>
        public  string  Timefix
        {
            get
            {
                return  _fTimefix;
            }
            set
            {
                  _fTimefix = value;
            }
         }
        #endregion

        #region 所在城市
        private string _fCity;

        /// <summary>
        /// 所在城市
        /// </summary>
        public  string  City
        {
            get
            {
                return  _fCity;
            }
            set
            {
                  _fCity = value;
            }
         }
        #endregion

        #region 时段月租限制时间
        private DateTime _fFixLimtTime;

        /// <summary>
        /// 时段月租限制时间
        /// </summary>
        public  DateTime  FixLimtTime
        {
            get
            {
                return  _fFixLimtTime;
            }
            set
            {
                  _fFixLimtTime = value;
            }
         }
        #endregion

        #region 是否支持纸质抵扣
        private string _fPaperdedu;

        /// <summary>
        /// 是否支持纸质抵扣
        /// </summary>
        public  string  Paperdedu
        {
            get
            {
                return  _fPaperdedu;
            }
            set
            {
                  _fPaperdedu = value;
            }
         }
        #endregion

        #region 月租认证
        private string _fFixaccred;

        /// <summary>
        /// 月租认证
        /// </summary>
        public  string  Fixaccred
        {
            get
            {
                return  _fFixaccred;
            }
            set
            {
                  _fFixaccred = value;
            }
         }
        #endregion

        #region Ismember
        private string _fIsmember;

        /// <summary>
        /// Ismember
        /// </summary>
        public  string  Ismember
        {
            get
            {
                return  _fIsmember;
            }
            set
            {
                  _fIsmember = value;
            }
         }
        #endregion

     }
}


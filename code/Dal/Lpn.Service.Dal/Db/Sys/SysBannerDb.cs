using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class SysBannerDb
    {
        #region 自增编号
        private int _fID;

        /// <summary>
        /// 自增编号
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

        #region 图片地址
        private string _fImg;

        /// <summary>
        /// 图片地址
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

        #region 描述
        private string _fDesc;

        /// <summary>
        /// 描述
        /// </summary>
        public  string  Desc
        {
            get
            {
                return  _fDesc;
            }
            set
            {
                  _fDesc = value;
            }
         }
        #endregion

        #region 过期方式 0:永不过期 1：指定时间过期(TimeOutDesc指定)
        private int _fTimeOutType;

        /// <summary>
        /// 过期方式 0:永不过期 1：指定时间过期(TimeOutDesc指定)
        /// </summary>
        public  int  TimeOutType
        {
            get
            {
                return  _fTimeOutType;
            }
            set
            {
                  _fTimeOutType = value;
            }
         }
        #endregion

        #region 过期时间
        private DateTime _fTimeOutDesc;

        /// <summary>
        /// 过期时间
        /// </summary>
        public  DateTime  TimeOutDesc
        {
            get
            {
                return  _fTimeOutDesc;
            }
            set
            {
                  _fTimeOutDesc = value;
            }
         }
        #endregion

        #region 灰度类型 0：全量  1：指定手机号
        private int _fSendType;

        /// <summary>
        /// 灰度类型 0：全量  1：指定手机号
        /// </summary>
        public  int  SendType
        {
            get
            {
                return  _fSendType;
            }
            set
            {
                  _fSendType = value;
            }
         }
        #endregion

        #region 手机号列表
        private string _fSendDesc;

        /// <summary>
        /// 手机号列表
        /// </summary>
        public  string  SendDesc
        {
            get
            {
                return  _fSendDesc;
            }
            set
            {
                  _fSendDesc = value;
            }
         }
        #endregion

        #region 跳转方式 0:h5 1:页面
        private int _fTransferType;

        /// <summary>
        /// 跳转方式 0:h5 1:页面
        /// </summary>
        public  int  TransferType
        {
            get
            {
                return  _fTransferType;
            }
            set
            {
                  _fTransferType = value;
            }
         }
        #endregion

        #region 跳转编码
        private string _fTransfer;

        /// <summary>
        /// 跳转编码
        /// </summary>
        public  string  Transfer
        {
            get
            {
                return  _fTransfer;
            }
            set
            {
                  _fTransfer = value;
            }
         }
        #endregion

        #region 操作时间
        private DateTime _fOperateTime;

        /// <summary>
        /// 操作时间
        /// </summary>
        public  DateTime  OperateTime
        {
            get
            {
                return  _fOperateTime;
            }
            set
            {
                  _fOperateTime = value;
            }
         }
        #endregion

        #region 操作员
        private int _fOperater;

        /// <summary>
        /// 操作员
        /// </summary>
        public  int  Operater
        {
            get
            {
                return  _fOperater;
            }
            set
            {
                  _fOperater = value;
            }
         }
        #endregion

        #region 0:待发布 1:已发布 2:已过期
        private int _fState;

        /// <summary>
        /// 0:待发布 1:已发布 2:已过期
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

        #region 顺序
        private int _fOrder;

        /// <summary>
        /// 顺序
        /// </summary>
        public  int  Order
        {
            get
            {
                return  _fOrder;
            }
            set
            {
                  _fOrder = value;
            }
         }
        #endregion

     }
}


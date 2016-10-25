using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.App
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class AppVersionDb
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

        #region 版本号
        private int _fCode;

        /// <summary>
        /// 版本号
        /// </summary>
        public  int  Code
        {
            get
            {
                return  _fCode;
            }
            set
            {
                  _fCode = value;
            }
         }
        #endregion

        #region 版本描述
        private string _fDes;

        /// <summary>
        /// 版本描述
        /// </summary>
        public  string  Des
        {
            get
            {
                return  _fDes;
            }
            set
            {
                  _fDes = value;
            }
         }
        #endregion

        #region 机型(android:1 ios:2)
        private int _fType;

        /// <summary>
        /// 机型(android:1 ios:2)
        /// </summary>
        public  int  Type
        {
            get
            {
                return  _fType;
            }
            set
            {
                  _fType = value;
            }
         }
        #endregion

        #region 下载地址
        private string _fDownloadUrl;

        /// <summary>
        /// 下载地址
        /// </summary>
        public  string  DownloadUrl
        {
            get
            {
                return  _fDownloadUrl;
            }
            set
            {
                  _fDownloadUrl = value;
            }
         }
        #endregion

        #region 操作时间
        private DateTime _fLastOperateTime;

        /// <summary>
        /// 操作时间
        /// </summary>
        public  DateTime  LastOperateTime
        {
            get
            {
                return  _fLastOperateTime;
            }
            set
            {
                  _fLastOperateTime = value;
            }
         }
        #endregion

     }
}


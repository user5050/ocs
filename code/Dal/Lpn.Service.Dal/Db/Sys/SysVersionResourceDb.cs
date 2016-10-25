using System;

/*
* 由自动生成工具完成
* 描述:[sys_version_resource]
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_version_resource]
    /// </summary>
    [Serializable]
    public partial class SysVersionResourceDb
    {
        #region 版本号
        private string _fId;

        /// <summary>
        /// 版本号
        /// </summary>
        public  string  Id
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

        #region 资源地址
        private string _fUrl;

        /// <summary>
        /// 资源地址
        /// </summary>
        public  string  Url
        {
            get
            {
                return  _fUrl;
            }
            set
            {
                  _fUrl = value;
            }
         }
        #endregion

        #region Hash值
        private string _fHash;

        /// <summary>
        /// Hash值
        /// </summary>
        public  string  Hash
        {
            get
            {
                return  _fHash;
            }
            set
            {
                  _fHash = value;
            }
         }
        #endregion

        #region 上传时间
        private DateTime _fRowTime;

        /// <summary>
        /// 上传时间
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

        #region 操作人员
        private string _fOperatorName;

        /// <summary>
        /// 操作人员
        /// </summary>
        public  string  OperatorName
        {
            get
            {
                return  _fOperatorName;
            }
            set
            {
                  _fOperatorName = value;
            }
         }
        #endregion

        #region 备注
        private string _fRemark;

        /// <summary>
        /// 备注
        /// </summary>
        public  string  Remark
        {
            get
            {
                return  _fRemark;
            }
            set
            {
                  _fRemark = value;
            }
         }
        #endregion

     }
}


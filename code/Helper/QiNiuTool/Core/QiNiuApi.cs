using Qiniu.IO;
using Qiniu.RS;
using System.IO;

/*
 * 7牛 接口文档  http://developer.qiniu.com/docs/v6/sdk/csharp-sdk.html
 * 7牛 状态码　　http://developer.qiniu.com/docs/v6/api/reference/codes.html
 */
namespace QiNiuTool.Core
{
    public class QiNiuApi
    {
        static QiNiuApi()
        {
            Qiniu.Conf.Config.Init();
        }

        #region  普通上传(替换旧文件,谨慎使用，替换旧文件可能无法及时更新，建议每次修改变更文件名称,上传新文件，删除就文件)
        /// <summary>
        /// 普通上传(替换旧文件)
        /// </summary>
        /// <param name="bucket">空间名称</param>
        /// <param name="key">图片key(注意： key必须采用utf8编码，如使用非utf8编码访问七牛云存储将反馈错误)</param>
        /// <param name="data">数据</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static string AddOrUpdate(string bucket,string key, byte[]  data,out string error)
        { 
            Delete(bucket, key, out error);
            var upKey = Put(bucket, key, data, out error);

            return upKey; 
        }
        #endregion

        #region 5.2.1.普通上传

        /// <summary>
        /// 5.2.1.普通上传
        /// </summary>
        /// <param name="bucket">空间名称</param>
        /// <param name="key">图片key(注意： key必须采用utf8编码，如使用非utf8编码访问七牛云存储将反馈错误)</param>
        /// <param name="data">数据</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static string Put(string bucket,string key, byte[]  data,out string error)
        {
            var policy = new PutPolicy(bucket,3600*10);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();
            error = string.Empty;

            using(var io= new MemoryStream(data))
            {
               
                var ret = client.Put(upToken, key, io, extra);

                if (ret.OK)
                {
                    return ret.key;
                }
                else
                {
                    if (ret.Exception != null)
                    {
                        error = ret.Exception.Message;
                    }
                    else
                    {
                        error = ret.Response;
                    }
                }
            }

            return string.Empty;
        }
        #endregion 

        #region  3.4.删除单个文件

        /// <summary>
        /// 3.4.删除单个文件
        /// </summary>
        /// <param name="bucket">空间名称</param>
        /// <param name="key">图片key</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static bool Delete(string bucket, string key, out string error)
        { 
            error = string.Empty;
            RSClient client = new RSClient();
             var ret = client.Delete(new EntryPath(bucket, key));
            if (ret.OK)
            {
                return true;
            }
            else
            {
                if (ret.Exception != null)
                {
                    error = ret.Exception.Message;
                }
                else
                {
                    error = ret.Response;
                }
            }

            return false;
        }

        public static bool Test()
        {

            Qiniu.Conf.Config.ACCESS_KEY = "A_FFD7yO69LVqJIyfpDFL_FHl8MykfUIdEdDs5C-";
            Qiniu.Conf.Config.SECRET_KEY = "zAvXEfOebTnLWSl_8OMG0JI7oH8kghncA0JiYTrD";

             
            var client = new RSClient();
            var ret = client.Delete(new EntryPath("camealreadtest", "isbn_9787010110486"));
            if (ret.OK)
            {
                return true;
            }
            else
            {
                
            }

            return false;
        }
        #endregion

        #region 获取上传token(可提供给APP使用)

        /// <summary>
        /// 上传token
        /// </summary>
        /// <param name="bucket">空间名</param>
        /// <param name="expires">失效时间(单位：秒)</param>
        /// <returns></returns>
        public static string Token(string bucket,int expires=3600)
        {
            var policy = new PutPolicy(bucket, (uint)expires);
            return policy.Token();
        }
        #endregion
    }
}

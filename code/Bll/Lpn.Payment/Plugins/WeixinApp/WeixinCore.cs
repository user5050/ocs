using System;
using System.Text;
using System.IO;
using System.Net;

namespace Lpn.Payment.Plugins.WeixinApp
{
    public class WeixinCore
    {

        /// <summary>
        /// http的基本post方法
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postData">post的数据内容</param>
        /// <returns>服务器返回的数据</returns>
        public static string Post(string url, string param)
        {
            #region 打印发送的串
            //LogControl.Instance.Debug("提交数据:\r\nURL:{0}\r\n{1}\r\n",url,postData);
            #endregion
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 15000;
                request.Method = "POST";
                request.Accept = "*/*";
                request.AllowAutoRedirect = false;

                StreamWriter requestStream = null;
                WebResponse response = null;
                string responseStr = null;

                using (requestStream = new StreamWriter(request.GetRequestStream()))
                {
                    requestStream.Write(param);
                };// requestStream.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseStr = reader.ReadToEnd();
                        //File.WriteAllText(Server.MapPath("~/") + @"\test.txt", responseStr);
                    };
                    //reader.Close();
                }


                #region 打印接收的串
                //LogControl.Instance.Debug("反馈数据:\r\n{0}\r\n", sResult);
                #endregion

                return responseStr;
            }
            catch (Exception ex)
            {
                return "<error>" + ex.Message + "</error>";
            }

        }
    }
}

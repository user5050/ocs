using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;

namespace OneCoin.Sms
{
    class SMSservice : ISMS
    {

        // http://localhost:2859/WS/LinkWS.asmx
        string urlx = "http://mb345.com:999/";
        //string CorpID = "";
        //string Pwd = "";
        //string modeo = "";
        //string neirong = "";

        LinkWS WSS = new LinkWS();

        private static string HttpPostMMS(string url, string postData, string sEncoding)
        {
            try
            {

                HttpWebRequest Rst = (HttpWebRequest)WebRequest.Create(url);
                Rst.Method = "POST";
                Rst.ContentType = "application/x-www-form-urlencoded";



                byte[] data = System.Text.Encoding.GetEncoding(sEncoding).GetBytes(postData);
                // Send the data.
                Stream newStream = Rst.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                HttpWebResponse Rsp = (HttpWebResponse)Rst.GetResponse();
                StreamReader reader = new StreamReader(Rsp.GetResponseStream(), Encoding.GetEncoding(sEncoding));
                string ct = reader.ReadToEnd();
                return ct.Trim();
            }
            catch (Exception Ex)
            {
                return Ex.Message;

            }
        }

        private static string GetHttpPostX(string url, string[] param, string[] values)
        {
            try
            {
                WebClient WC = new WebClient();
                WC.Encoding = System.Text.Encoding.GetEncoding("GB2312");
                // WC.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                System.Collections.Specialized.NameValueCollection Col = new System.Collections.Specialized.NameValueCollection();
                for (int i = 0; i < param.Length; i++)
                {
                    Col.Add(param[i], values[i]);
                }


                byte[] responseArray = WC.UploadValues(url, "POST", Col);
                string response = Encoding.Default.GetString(responseArray);
                return response;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }

        public string Url
        {
            set { WSS.Url = value; }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="CorpID">帐号</param>
        /// <param name="Pwd">密码</param>
        /// <param name="Mbno">电话号码</param>
        /// <param name="Msg">内容</param>
        /// <returns></returns>
        public bool SendMessage(string CorpID, string Pwd, string Mbno, string Msg, ref string result)
        {
            try
            {
                // Msg = Msg + "【千帆科技】";
                int R = WSS.Send(CorpID, Pwd, Mbno, Msg, "", "");
                if (R == 0)
                {
                    result = "发送成功！";
                }
                else if (R == -1)
                {
                    result = "帐号未注册！";
                }
                else if (R == -2)
                {
                    result = "其他错误！";

                }
                else if (R == -3)
                {
                    result = "密码错误！";
                }
                else if (R == -4)
                {
                    result = "手机号码格式不对！";
                }
                else if (R == -5)
                {
                    result = "余额不足！";
                }
                else if (R == -6)
                {
                    result = "定时发送时间不是有效时间格式！";
                }
                return (R == 0);
            }
            catch (System.Net.WebException WebExcp)
            {
                result = "网络错误，无法连接到服务器！";
                return false;
            }
        }


        /// <summary>
        /// 接收短信
        /// </summary>
        /// <param name="CorpID">帐号</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        public string ReceiveMessage(string CorpID, string Pwd)
        {
            string result = "";
            try
            {
                string R = WSS.Get(CorpID, Pwd);
                if (R == "")
                {
                    result = "没有上行信息";
                }
                else if (R == "-1")
                {
                    result = "帐号未注册！";
                }
                else if (R == "-2")
                {
                    result = "其他错误！";
                }
                else if (R == "-3")
                {
                    result = "帐号密码不匹配！";
                }
                else
                {
                    string ReGet = "";
                    R = R.Replace("||", "|");
                    string[] temp = R.Split("|".ToCharArray());
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].Trim() != "")
                        {
                            string[] temp1 = temp[i].Split("#".ToCharArray());
                            if (temp1.Length > 2)
                            {
                                ReGet += "第" + i.ToString() + "条回复，手机号：" + temp1[0] + "，内容：" + temp1[1] + "，回复时间：" + temp1[2] + "，回复号码：" + temp1[3] + "\n";
                            }
                        }
                    }
                    result = ReGet.ToString().Trim();
                }
            }
            catch (System.Net.WebException WebExcp)
            {
                result = "网络错误，无法连接到服务器！";
            }
            return result;

        }

        /// <summary>
        /// 接收短信
        /// </summary>
        /// <param name="CorpID">帐号</param>
        /// <param name="Pwd">密码</param>
        /// <param name="wcfPort">端口号</param>
        /// <returns></returns>
        private bool Getnew(string CorpID, string Pwd, int wcfPort)
        {
            bool fu = false;
            string R = "";
            try
            {
                R = WSS.Get(CorpID, Pwd);
            }
            catch (Exception ex)
            {
                
            }
            //try
            //{
            //    if (R != "" && R != "-1" && R != "-2" && R != "-3")
            //    {
            //        InBox sen = new InBox();
            //        string ReGet = "";
            //        R = R.Replace("||", "|");
            //        string[] temp = R.Split("|".ToCharArray());
            //        for (int i = 0; i < temp.Length; i++)
            //        {
            //            if (temp[i].Trim() != "")
            //            {
            //                string[] temp1 = temp[i].Split("#".ToCharArray());
            //                if (temp1.Length > 2)
            //                {
            //                    ReGet += "第" + i.ToString() + "条回复，手机号：" + temp1[0] + "，内容：" + temp1[1] + "，回复时间：" + temp1[2] + "，回复号码：" + temp1[3] + "\n";
            //                    sen.Mbno = temp1[0];
            //                    sen.Msg = temp1[1];
            //                    sen.ArriveTim = Convert.ToDateTime(temp1[2]);
            //                    try
            //                    {
            //                        var fg = InterBussiness.Gett<tIMM_Emp>("Mobile=@Mobile", new Param("Mobile", temp1[0]));
            //                        if (fg.Count > 0)
            //                        {
            //                            foreach (var de in fg)
            //                            {
            //                                sen.UserrID = de.EmpID;
            //                                sen.UserName = de.EmpName;
            //                            }
            //                        }
            //                        else
            //                        {
            //                            sen.UserrID = 0;
            //                            sen.UserName = "";

            //                        }
            //                    }
            //                    catch (Exception)
            //                    {
            //                        sen.UserrID = 0;
            //                        sen.UserName = "";
            //                    }
            //                    sen.Comport = wcfPort;
            //                    int cont = InternalBusiness.InterBussiness.Insert<InBox>(sen);
            //                    fu = true;
            //                }

            //            }
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
               
            //}
            return fu;
        }
        
        /// <summary>
        /// 错误报告
        /// </summary>
        /// <param name="CorpID">帐号</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        private string Report(string CorpID, string Pwd)
        {
            string result = "";
            try
            {
                string R = WSS.GetReportFail(CorpID, Pwd, "");
                if (R == "-3")
                {
                    result = "密码错误！";
                }
                else if (R == "-2")
                {
                    result = "其他错误";
                }
                else if (R == "-1")
                {
                    result = "帐号尚未注册！";
                }
                else if (R == "" || R == "全部正确提交,无错误返回报告")
                {
                    result = "成功！";

                }
                else
                {
                    string ReGet = "";
                    R = R.Replace("||", "|");
                    string[] temp = R.Split("|".ToCharArray());
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].Trim() != "")
                        {
                            string[] temp1 = temp[i].Split("#".ToCharArray());
                            if (temp1.Length > 2)
                            {
                                ReGet += "第" + i.ToString() + "条回复，手机号：" + temp1[0] + "，内容：" + temp1[1] + "，回复时间：" + temp1[2] + "，回复号码：" + temp1[3] + "\n";
                            }
                        }
                    }
                    result = ReGet.ToString().Trim();
                }
            }
            catch (System.Net.WebException WebExcp) { result = "网络错误，无法连接到服务器！"; }
            return result;
        }
    }
}

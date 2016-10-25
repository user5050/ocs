using System;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace OneCoin.Service.PostTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var postUrl = TbUrl.Text.Trim();
            var data = TbData.Text.Trim();

            if (!string.IsNullOrEmpty(postUrl))
            {
                try
                {
                    using (var client = new XWebClient())
                    {
                        client.Encoding = Encoding.UTF8;
                        client.Headers.Remove("content-type");
                        client.Headers.Add("content-type", LbType.SelectedItem.ToString());


                        var ret = client.UploadString(postUrl, "POST", data);

                        AppendLog(ret);
                    }

                     
                }
                catch (Exception ex)
                {
                    AppendLog(ex.Message);
                }
            } 
        }

        private void AppendLog(string log)
        {
            TbResult.Text += "\r\n";
            TbResult.Text += log;
        }
    }

    public class XWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request != null)
            {
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                return request;
            }

            return null;
        }
    } 
}

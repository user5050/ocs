using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using OneCoin.Service.Helper.Encrypt;

namespace PfxTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BTCompute_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TBPath.Text))
            {
                var cer = new X509Certificate2(TBPath.Text, TBPassword.Text , X509KeyStorageFlags.Exportable);


                var data = cer.Export(X509ContentType.Pfx, TBPassword.Text);
                  
                //var cer1 = new X509Certificate2(data, TBPassword.Text); 有私钥 
                //var cer2 = new X509Certificate2(cer.RawData, TBPassword.Text); 无私钥
                  
                if (cer.HasPrivateKey)
                {
                    RTBMsg.Text = Convert.ToBase64String(data) ;
                     
                }
                else
                {
                    RTBMsg.Text = Convert.ToBase64String(data);
                }
                

            }
        }

        private void TBPath_Click(object sender, EventArgs e)
        {
            var ret = openFileDialog1.ShowDialog(this);

            if (ret == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                TBPath.Text = path;
            }
        }

        private void BtMd5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TBPath.Text))
            {
                byte[] buffer;
                using (var io= File.OpenRead(TBPath.Text))
                {
                    buffer = new byte[io.Length];
                    io.Read(buffer, 0, buffer.Length);
                }

                RTBMsg.Text = EncryptMgr.MD5(buffer);
            }
        }
    }
}

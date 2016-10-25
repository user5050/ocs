namespace PfxTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RTBMsg = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TBPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.BTCompute = new System.Windows.Forms.Button();
            this.BtMd5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RTBMsg
            // 
            this.RTBMsg.Location = new System.Drawing.Point(91, 113);
            this.RTBMsg.Name = "RTBMsg";
            this.RTBMsg.Size = new System.Drawing.Size(704, 434);
            this.RTBMsg.TabIndex = 0;
            this.RTBMsg.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TBPath
            // 
            this.TBPath.Location = new System.Drawing.Point(91, 35);
            this.TBPath.Name = "TBPath";
            this.TBPath.Size = new System.Drawing.Size(704, 28);
            this.TBPath.TabIndex = 1;
            this.TBPath.Click += new System.EventHandler(this.TBPath_Click);
            this.TBPath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "秘钥文件:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base64:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "文件密码:";
            // 
            // TBPassword
            // 
            this.TBPassword.Location = new System.Drawing.Point(91, 67);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.Size = new System.Drawing.Size(545, 28);
            this.TBPassword.TabIndex = 1;
            // 
            // BTCompute
            // 
            this.BTCompute.Location = new System.Drawing.Point(642, 69);
            this.BTCompute.Name = "BTCompute";
            this.BTCompute.Size = new System.Drawing.Size(75, 37);
            this.BTCompute.TabIndex = 3;
            this.BTCompute.Text = "计算";
            this.BTCompute.UseVisualStyleBackColor = true;
            this.BTCompute.Click += new System.EventHandler(this.BTCompute_Click);
            // 
            // BtMd5
            // 
            this.BtMd5.Location = new System.Drawing.Point(723, 69);
            this.BtMd5.Name = "BtMd5";
            this.BtMd5.Size = new System.Drawing.Size(75, 37);
            this.BtMd5.TabIndex = 3;
            this.BtMd5.Text = "MD5";
            this.BtMd5.UseVisualStyleBackColor = true;
            this.BtMd5.Click += new System.EventHandler(this.BtMd5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 559);
            this.Controls.Add(this.BtMd5);
            this.Controls.Add(this.BTCompute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.TBPath);
            this.Controls.Add(this.RTBMsg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTBMsg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox TBPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.Button BTCompute;
        private System.Windows.Forms.Button BtMd5;
    }
}


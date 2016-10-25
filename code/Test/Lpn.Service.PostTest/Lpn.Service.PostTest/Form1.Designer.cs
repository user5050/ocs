namespace OneCoin.Service.PostTest
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
            this.TbUrl = new System.Windows.Forms.TextBox();
            this.TbData = new System.Windows.Forms.TextBox();
            this.TbResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LbType = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // TbUrl
            // 
            this.TbUrl.Location = new System.Drawing.Point(62, 27);
            this.TbUrl.Name = "TbUrl";
            this.TbUrl.Size = new System.Drawing.Size(790, 28);
            this.TbUrl.TabIndex = 0;
            // 
            // TbData
            // 
            this.TbData.Location = new System.Drawing.Point(62, 116);
            this.TbData.Multiline = true;
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(880, 113);
            this.TbData.TabIndex = 0;
            // 
            // TbResult
            // 
            this.TbResult.Location = new System.Drawing.Point(15, 292);
            this.TbResult.Multiline = true;
            this.TbResult.Name = "TbResult";
            this.TbResult.Size = new System.Drawing.Size(927, 365);
            this.TbResult.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "返回结果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "POST";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(867, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Content-Type";
            // 
            // LbType
            // 
            this.LbType.AllowDrop = true;
            this.LbType.FormattingEnabled = true;
            this.LbType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LbType.ItemHeight = 18;
            this.LbType.Items.AddRange(new object[] {
            "application/json",
            "multipart/form-data",
            "application/x-www-form-urlencoded",
            "text/xml"});
            this.LbType.Location = new System.Drawing.Point(134, 75);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(718, 22);
            this.LbType.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 669);
            this.Controls.Add(this.LbType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbResult);
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.TbUrl);
            this.Name = "Form1";
            this.Text = "POST 测试";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbUrl;
        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.TextBox TbResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LbType;
    }
}


namespace cn.bmob.example
{
    partial class BmobFileUploadForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.fileText = new System.Windows.Forms.TextBox();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.enterDba = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.resultText = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.formstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "本案例是Bmob后端云服务平台提供的文件服务的演示。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "选择文件：";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(369, 58);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 21;
            this.browseBtn.Text = "浏览...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // fileText
            // 
            this.fileText.Enabled = false;
            this.fileText.Location = new System.Drawing.Point(96, 58);
            this.fileText.Name = "fileText";
            this.fileText.Size = new System.Drawing.Size(265, 21);
            this.fileText.TabIndex = 22;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Enabled = false;
            this.uploadBtn.Location = new System.Drawing.Point(28, 97);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(418, 23);
            this.uploadBtn.TabIndex = 23;
            this.uploadBtn.Text = "上传文件";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // enterDba
            // 
            this.enterDba.Enabled = false;
            this.enterDba.Location = new System.Drawing.Point(26, 133);
            this.enterDba.Name = "enterDba";
            this.enterDba.Size = new System.Drawing.Size(418, 23);
            this.enterDba.TabIndex = 24;
            this.enterDba.Text = "保存入库";
            this.enterDba.UseVisualStyleBackColor = true;
            this.enterDba.Click += new System.EventHandler(this.enterDba_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "返回结果：";
            // 
            // resultText
            // 
            this.resultText.Location = new System.Drawing.Point(26, 196);
            this.resultText.Multiline = true;
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(416, 106);
            this.resultText.TabIndex = 26;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.formstatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 318);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(480, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "状态";
            // 
            // formstatus
            // 
            this.formstatus.Name = "formstatus";
            this.formstatus.Size = new System.Drawing.Size(0, 17);
            // 
            // BmobFileUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 340);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.enterDba);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.fileText);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BmobFileUploadForm";
            this.Text = "Bmob后端云服务平台（www.bmob.cn）";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox fileText;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Button enterDba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resultText;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel formstatus;
    }
}


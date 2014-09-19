namespace cn.bmob.example
{
    partial class BmobForm
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
            this.FormStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.deleteData = new System.Windows.Forms.Button();
            this.findAllData = new System.Windows.Forms.Button();
            this.updateData = new System.Windows.Forms.Button();
            this.createData = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.findOneData = new System.Windows.Forms.Button();
            this.FormStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormStatus
            // 
            this.FormStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.FormStatusLabel});
            this.FormStatus.Location = new System.Drawing.Point(0, 218);
            this.FormStatus.Name = "FormStatus";
            this.FormStatus.Size = new System.Drawing.Size(414, 22);
            this.FormStatus.TabIndex = 8;
            this.FormStatus.Text = "状态";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "状态";
            // 
            // FormStatusLabel
            // 
            this.FormStatusLabel.Name = "FormStatusLabel";
            this.FormStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // deleteData
            // 
            this.deleteData.Enabled = false;
            this.deleteData.Location = new System.Drawing.Point(150, 83);
            this.deleteData.Name = "deleteData";
            this.deleteData.Size = new System.Drawing.Size(95, 23);
            this.deleteData.TabIndex = 15;
            this.deleteData.Text = "删除数据";
            this.deleteData.UseVisualStyleBackColor = true;
            this.deleteData.Click += new System.EventHandler(this.deleteData_Click);
            // 
            // findAllData
            // 
            this.findAllData.Location = new System.Drawing.Point(277, 44);
            this.findAllData.Name = "findAllData";
            this.findAllData.Size = new System.Drawing.Size(95, 23);
            this.findAllData.TabIndex = 14;
            this.findAllData.Text = "查找全部数据";
            this.findAllData.UseVisualStyleBackColor = true;
            this.findAllData.Click += new System.EventHandler(this.findAllData_Click);
            // 
            // updateData
            // 
            this.updateData.Enabled = false;
            this.updateData.Location = new System.Drawing.Point(24, 83);
            this.updateData.Name = "updateData";
            this.updateData.Size = new System.Drawing.Size(95, 23);
            this.updateData.TabIndex = 13;
            this.updateData.Text = "修改数据";
            this.updateData.UseVisualStyleBackColor = true;
            this.updateData.Click += new System.EventHandler(this.updateData_Click);
            // 
            // createData
            // 
            this.createData.Location = new System.Drawing.Point(24, 44);
            this.createData.Name = "createData";
            this.createData.Size = new System.Drawing.Size(95, 23);
            this.createData.TabIndex = 12;
            this.createData.Text = "创建数据";
            this.createData.UseVisualStyleBackColor = true;
            this.createData.Click += new System.EventHandler(this.createData_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(22, 121);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 12);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "返回结果：";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(24, 145);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(378, 64);
            this.Result.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "本案例是Bmob后端云服务平台提供的数据服务的演示。";
            // 
            // findOneData
            // 
            this.findOneData.Enabled = false;
            this.findOneData.Location = new System.Drawing.Point(150, 44);
            this.findOneData.Name = "findOneData";
            this.findOneData.Size = new System.Drawing.Size(95, 23);
            this.findOneData.TabIndex = 19;
            this.findOneData.Text = "查找一条数据";
            this.findOneData.UseVisualStyleBackColor = true;
            this.findOneData.Click += new System.EventHandler(this.findOneData_Click);
            // 
            // BmobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 240);
            this.Controls.Add(this.findOneData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.deleteData);
            this.Controls.Add(this.findAllData);
            this.Controls.Add(this.updateData);
            this.Controls.Add(this.createData);
            this.Controls.Add(this.FormStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BmobForm";
            this.Text = "Bmob后端云服务平台（www.bmob.cn）";
            this.FormStatus.ResumeLayout(false);
            this.FormStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip FormStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel FormStatusLabel;
        private System.Windows.Forms.Button deleteData;
        private System.Windows.Forms.Button findAllData;
        private System.Windows.Forms.Button updateData;
        private System.Windows.Forms.Button createData;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button findOneData;
    }
}


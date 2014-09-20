namespace cn.bmob.example
{
    partial class BmobCloudCode
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
            this.components = new System.ComponentModel.Container();
            this.resultText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cloudCodeBtn = new System.Windows.Forms.Button();
            this.valBEdt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.parmBEdt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.valAEdt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.parmAEdt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.function = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // resultText
            // 
            this.resultText.Location = new System.Drawing.Point(16, 251);
            this.resultText.Multiline = true;
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(406, 89);
            this.resultText.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 33;
            this.label8.Text = "返回结果：";
            // 
            // cloudCodeBtn
            // 
            this.cloudCodeBtn.Location = new System.Drawing.Point(21, 197);
            this.cloudCodeBtn.Name = "cloudCodeBtn";
            this.cloudCodeBtn.Size = new System.Drawing.Size(398, 23);
            this.cloudCodeBtn.TabIndex = 32;
            this.cloudCodeBtn.Text = "执行云端代码";
            this.cloudCodeBtn.UseVisualStyleBackColor = true;
            this.cloudCodeBtn.Click += new System.EventHandler(this.cloudCodeBtn_Click);
            // 
            // valBEdt
            // 
            this.valBEdt.Location = new System.Drawing.Point(288, 160);
            this.valBEdt.Name = "valBEdt";
            this.valBEdt.Size = new System.Drawing.Size(130, 21);
            this.valBEdt.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "参数B的值：";
            // 
            // parmBEdt
            // 
            this.parmBEdt.Location = new System.Drawing.Point(81, 160);
            this.parmBEdt.Name = "parmBEdt";
            this.parmBEdt.Size = new System.Drawing.Size(130, 21);
            this.parmBEdt.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "参数名B：";
            // 
            // valAEdt
            // 
            this.valAEdt.Location = new System.Drawing.Point(288, 119);
            this.valAEdt.Name = "valAEdt";
            this.valAEdt.Size = new System.Drawing.Size(130, 21);
            this.valAEdt.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "参数A的值：";
            // 
            // parmAEdt
            // 
            this.parmAEdt.Location = new System.Drawing.Point(81, 119);
            this.parmAEdt.Name = "parmAEdt";
            this.parmAEdt.Size = new System.Drawing.Size(130, 21);
            this.parmAEdt.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "参数名A：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "云端参数列表：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "云端方法名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "本案例是Bmob后端云服务平台提供的云端代码服务的演示。";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // function
            // 
            this.function.FormattingEnabled = true;
            this.function.Items.AddRange(new object[] {
            "first",
            "second",
            "third"});
            this.function.Location = new System.Drawing.Point(23, 66);
            this.function.Name = "function";
            this.function.Size = new System.Drawing.Size(395, 20);
            this.function.TabIndex = 35;
            this.function.SelectedIndexChanged += new System.EventHandler(this.function_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(96, 46);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 12);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "查看云端代码的内容";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // BmobCloudCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 354);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.function);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cloudCodeBtn);
            this.Controls.Add(this.valBEdt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.parmBEdt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.valAEdt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.parmAEdt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "BmobCloudCode";
            this.Text = "Bmob后端云服务平台（www.bmob.cn）";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox parmAEdt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox valAEdt;
        private System.Windows.Forms.TextBox valBEdt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox parmBEdt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cloudCodeBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox resultText;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox function;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
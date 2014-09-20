using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.bmob.example
{
    public partial class BmobCloudCode : BmobBaseForm
    {
        public BmobCloudCode():
            base()
        {
            InitializeComponent();
        }

        private void cloudCodeBtn_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(function, "");
            if (function.Text== "")
            {
                errorProvider1.SetError(function, "请选择云端代码名称");
                return;
            }

            //设置云端代码参数
            var p = new Dictionary<String, Object>();
            if (parmAEdt.Text.Trim() != "" && valAEdt.Text.Trim() != "")
            {
                p.Add(parmAEdt.Text, valAEdt.Text);
            }
            if (parmBEdt.Text.Trim() != "" && valBEdt.Text.Trim() != "")
            {
                p.Add(parmBEdt.Text, valBEdt.Text);
            }

            //调用云端代码
            var future = Bmob.EndpointTaskAsync<Dictionary<String, Object>>(function.Text, p);
            FinishedCallback(future.Result, resultText);
            
        }

        private void function_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置云端代码参数
            if (function.SelectedIndex == 2)
            {
                parmAEdt.Text = "userid";
                valAEdt.Text = "y6qBDvXj";
            }
            else
            {
                parmAEdt.Text = "";
                valAEdt.Text = "";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("notepad.exe", "cloudcode.txt");
        }

    }
}

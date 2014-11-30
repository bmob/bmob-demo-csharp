using BmobCSharpFileDemo.Model;
using cn.bmob.exception;
using cn.bmob.io;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.bmob.example
{
    public partial class BmobUserForm : BmobBaseForm
    {
        public BmobUserForm() :
            base()
        {
            InitializeComponent();
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            //登录用户
            var future = Bmob.LoginTaskAsync<BmobUser>(username.Text, password.Text);
            try
            {
                FinishedCallback(future.Result, result);
            }
            catch
            {
                MessageBox.Show("登录失败，原因：" + future.Exception.InnerException.ToString());
            }
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            //注册用户
            MyUserObject user = new MyUserObject();
            user.username = username.Text;
            user.password = password.Text;
            user.sex = new BmobBoolean(false);
            user.age = 50;
            var future = Bmob.CreateTaskAsync<MyUserObject>(user);
            try
            {
                FinishedCallback(future.Result, result);
            }
            catch
            {
                MessageBox.Show("注册失败，原因：" + future.Exception.InnerException.ToString());
            }
            
        }
    }
}

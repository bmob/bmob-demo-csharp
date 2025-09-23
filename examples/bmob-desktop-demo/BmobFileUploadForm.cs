using BmobCSharpFileDemo.Model;
using cn.bmob.api;
using cn.bmob.example.Model;
using cn.bmob.exception;
using cn.bmob.Extensions;
using cn.bmob.io;
using cn.bmob.json;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.bmob.example
{
    public partial class BmobFileUploadForm : BmobBaseForm
    {

        private BmobFile bmobFile;

        public BmobFileUploadForm()
            : base()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileText.Text = openFileDialog1.FileName;
                uploadBtn.Enabled = true;
            }

        }

        // async方式异步请求处理，非阻塞访问
        private async void uploadBtn_Click(object sender, EventArgs e)
        {
            formstatus.Text = "正在上传...";

            Byte[] data = null;
            using (var stream = File.OpenRead(fileText.Text))
            {
                data = stream.ReadAsBytes();
            }

            var Result = await Bmob.FileUploadTaskAsync(new BmobLocalFile(data,"hello.png"));
            FinishedCallback(Result, resultText);

            bmobFile = Result;

            enterDba.Enabled = true;
            formstatus.Text = "上传成功！";
        }

        // callback方式异步请求处理，非阻塞访问
        private void enterDba_Click(object sender, EventArgs e)
        {
            MyfilesObject myfileObject = new MyfilesObject();
            myfileObject.user = "Bmob后端云";
            myfileObject.url = bmobFile;

            Bmob.Create<MyfilesObject>(myfileObject, (resp, ex) =>
            {
                // http://msdn.microsoft.com/en-us/library/vstudio/zyzhdc6b(v=vs.100).aspx
                Invoke(new doUiThread(
                    () =>
                    {
                        FinishedCallback(resp, resultText);

                        formstatus.Text = "保存成功！";
                    }
                    ));
            });

        }

        delegate void doUiThread();

        private void BmobFileUploadForm_Load(object sender, EventArgs e)
        {

        }
    }
}

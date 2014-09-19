using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cn.bmob.api;
using HelloWindowsForm.Model;
using cn.bmob.io;
using cn.bmob.tools;
using System.Diagnostics;
using cn.bmob.json;

namespace HelloWindowsForm
{
    public partial class BmobForm : Form
    {
        //创建Bmob实例
        private BmobWindows Bmob =new BmobWindows();
        //对应要操作的数据表
        public const String TABLE_NAME = "Game";
        //接下来要操作的数据的数据
        private GameObject gameObject = new GameObject(TABLE_NAME);


        public BmobForm()
        {
            InitializeComponent();
            //初始化ApplicationId，这个ApplicationId需要更改为你自己的ApplicationId（ http://www.bmob.cn 上注册登录之后，创建应用可获取到ApplicationId）
            Bmob.initialize("69015a79796397f7701454336b84e0c4");

            //注册调试工具
            BmobDebug.Register(msg => { Debug.WriteLine(msg); });
        }

        private void createData_Click(object sender, EventArgs e)
        {
            //设置值    
            System.Random rnd = new System.Random();
            gameObject.score = rnd.Next(-50, 170);
            gameObject.playerName = "123";
            gameObject.cheatMode = false;

            //保存数据
            var future = Bmob.CreateTaskAsync(gameObject);

            //获取创建记录的objectId
            gameObject.objectId = future.Result.objectId;

            FinishedCallback(future.Result);

            //设置控件的可用性
            findAllData.Enabled = true;
            findOneData.Enabled = true;
            deleteData.Enabled = true;
            updateData.Enabled = true;
            FormStatusLabel.Text = "创建成功";
        }

        private void findAllData_Click(object sender, EventArgs e)
        {
            //查找表中的全部数据（默认最多返回10条数据）
            var future = Bmob.FindTaskAsync<GameObject>(TABLE_NAME, new BmobQuery());
            FinishedCallback(future.Result);

            FormStatusLabel.Text = "查找全部数据成功";
        }

        
        private void findOneData_Click(object sender, EventArgs e)
        {
            //查找一条记录
            var future = Bmob.GetTaskAsync<GameObject>(TABLE_NAME, gameObject.objectId);
            FinishedCallback(future.Result);

            FormStatusLabel.Text = "查找一条数据成功";
        }

        private void deleteData_Click(object sender, EventArgs e)
        {
            //删除一条记录
            var future = Bmob.DeleteTaskAsync(TABLE_NAME, gameObject.objectId);
            FinishedCallback(future.Result);

            //设置控件的可用性
            findAllData.Enabled = true;
            findOneData.Enabled = false;
            deleteData.Enabled = false;
            updateData.Enabled = false;

            FormStatusLabel.Text = "删除一条数据成功";
        }

        private void updateData_Click(object sender, EventArgs e)
        {
            //修改playerName的值    
            gameObject.playerName = "bmob后端云";

            //更新记录
            var future = Bmob.UpdateTaskAsync<GameObject>(gameObject);
            FinishedCallback(future.Result);

            FormStatusLabel.Text = "更新一条数据成功";
        }

        //对返回结果进行显示处理
        private void FinishedCallback<T>(T data)
        {
            if (data is IBmobWritable)
            {
                Result.Text = JsonAdapter.JSON.ToJson((IBmobWritable)data);
            }
            else
            {
                Result.Text = JsonAdapter.JSON.ToString(data);
            }

        }

    }
}

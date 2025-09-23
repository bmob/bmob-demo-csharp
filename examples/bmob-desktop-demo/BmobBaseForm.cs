using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.json;
using cn.bmob.tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace cn.bmob.example
{
    public partial class BmobBaseForm : Form
    {

        //创建Bmob实例
        private BmobWindows bmob;

        public BmobBaseForm()
            : base()
        {
            bmob = new BmobWindows();

            //初始化ApplicationId，这个ApplicationId需要更改为你自己的ApplicationId（ http://www.bmobapp.com 上注册登录之后，创建应用可获取到ApplicationId）
            Bmob.initialize("66c17717bbe9d423df02da5d199de77e", "82b7aece49ad172d8c141f5321d20b30");
            
            //注册调试工具
            BmobDebug.Register(msg => { Debug.WriteLine(msg); });
        }

        public BmobWindows Bmob
        {
            get { return bmob; }
        }

        //对返回结果进行显示处理
        public void FinishedCallback<T>(T data, TextBox text)
        {
            text.Text = JsonAdapter.JSON.ToDebugJsonString(data);
        }

    }
}

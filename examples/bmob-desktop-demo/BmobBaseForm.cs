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

            //初始化ApplicationId，这个ApplicationId需要更改为你自己的ApplicationId（ http://www.bmob.cn 上注册登录之后，创建应用可获取到ApplicationId）
            Bmob.initialize("4414150cb439afdf684d37dc184e0f9f", "e1deb317442129c125b228ddf78e5f22");
            
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

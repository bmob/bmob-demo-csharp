using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using HelloPhone.Resources;

using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;
using System.Diagnostics;
using cn.bmob.json;

using cn.bmob.Extensions;
using cn.bmob.config;

namespace HelloPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        private String TABLE_NAME = "T_BMOB_API_456";
        private BmobWindowsPhone Bmob = new BmobWindowsPhone();

        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // onroad
            Bmob.initialize(//"71cbfc2602aa830a117f7b15f20cc3ec");
               "4414150cb439afdf684d37dc184e0f9f");
            BmobDebug.Register(msg => { Debug.WriteLine(msg); });

            BmobConfiguration.PushChannel = "your_app_name_en";

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        private void updateStatus(Button button, String status)
        {
            button.BorderBrush = status == "OK" ? new SolidColorBrush(Colors.Green) : (Brush)Application.Current.Resources["PhoneAccentBrush"];
        }

        private class SignUser : BmobUser
        {
            public string friendNames { get; set; }

            public override void write(BmobOutput output, bool all)
            {
                base.write(output, all);
                output.Put("friends", friendNames);
            }

            public override void readFields(BmobInput input)
            {
                base.readFields(input);
                friendNames = input.getString("friends");
            }
        }

        // 注册用户
        private void signup_Click(object sender, RoutedEventArgs e)
        {
            SignUser user = new SignUser();
            user.username = "user_2014_11_30";
            user.password = "123456";
            user.friendNames = "a ,b ,c ";

            Bmob.Signup<SignUser>(user, (resp, ex) =>
            {
                string status = "OK";
                if (ex != null)
                {
                    status = "ERROR";
                }
                BmobDebug.Log(JsonAdapter.JSON.ToJson(resp));

                Dispatcher.BeginInvoke(() =>
                {
                    updateStatus(signup, status);
                });
            });
        }

        private class BmobApi : BmobTable
        {
            public string name { get; set; }

            public override void write(BmobOutput output, bool all)
            {
                base.write(output, all);
                output.Put("name", name);
            }

            public override void readFields(BmobInput input)
            {
                base.readFields(input);
                name = input.getString("name");
            }
        }

        // 添加表记录
        private void create_Click(object sender, RoutedEventArgs e)
        {
            BmobApi record = new BmobApi();
            record.name = "hello bmob windowsphone";

            Bmob.Create(TABLE_NAME, record, (resp, ex) =>
            {
                string status = "OK";
                if (ex != null)
                {
                    status = "ERROR";
                }

                Dispatcher.BeginInvoke(() =>
                               {
                                   updateStatus(create, status);
                               });
            });
        }

        // 云端代码调用
        private void cloud_Click(object sender, RoutedEventArgs e)
        {
            // 具体的云端代码使用参考
            Bmob.Endpoint<Dictionary<object, object>>("test", (resp, ex) =>
            {
                string status = "OK";
                if (ex != null)
                {
                    status = "ERROR";
                }

                Dispatcher.BeginInvoke(() =>
                {
                    updateStatus(cloud, status);
                });
            });
        }

        // JSON解析测试
        private void json_Click(object sender, RoutedEventArgs e)
        {
            var data = new BmobApi();
            data.name = "winse";
            BmobDebug.Log(JsonAdapter.JSON.ToJson(data));
        }

        // 调用内部方法请求url网页的内容
        private void url_Click(object sender, RoutedEventArgs e)
        {
            new BmobWindows().Request("http://www.baidu.com", "", new byte[0], new Dictionary<string, string>(), (resp, ex) =>
            {
                BmobDebug.Log(resp);
            });
        }

        // 请求b获取mob服务器时间
        private void time_Click(object sender, RoutedEventArgs e)
        {
            Bmob.Timestamp((resp, ex) =>
            {
                string status = "OK";
                if (ex != null)
                {
                    status = "ERROR";
                }

                Dispatcher.BeginInvoke(() =>
                {
                    updateStatus(time, status);
                });
            });
        }


        private void file_Click(object sender, RoutedEventArgs e)
        {
            byte[] a = "hello windowsphone file upload.".GetBytes();

            Bmob.FileUpload(new BmobLocalFile(a), (resp, ex) =>
            {
                string status = "OK";
                if (ex != null)
                {
                    status = "ERROR";
                }

                Dispatcher.BeginInvoke(() =>
                {
                    updateStatus(file, status);
                });
            });

            ////读取属性Build Action为content的txt文件
            ////用stream获取文件的二进制流
            //Stream st = Application.GetResourceStream(new Uri("files/firle1.txt", UriKind.Relative)).Stream;
            //string str = new StreamReader(st).ReadToEnd();
            //MessageBox.Show(str);


            ////读取属性Build Action为Resource的txt文件
            //Stream st1 = Application.GetResourceStream(new Uri("/demo（项目名称）;component/files/firle2.txt", UriKind.Relative)).Stream;
            //string str1 = new StreamReader(st1).ReadToEnd();
            //MessageBox.Show(str); 
        }

        private void createTask_Click(object sender, RoutedEventArgs e)
        {
            BmobApi table = new BmobApi();
            table.name = "hello wp";

            Bmob.CreateTaskAsync(TABLE_NAME, table).ContinueWith(f =>
            {

                string status = "OK";
                if (f.Result == null)
                {
                    status = "ERROR";
                }

                Dispatcher.BeginInvoke(() =>
                {
                    updateStatus(createTask, status);
                });
            });


        }
        
        // start push
        private void installation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bmob.StartPush();
            }
            catch(Exception ex)
            {
                BmobDebug.Log(ex);
            }
        }

        // stop push 
        private void stoppush_Click(object sender, RoutedEventArgs e)
        {
            Bmob.StopPush();
        }

        private void push_Click(object sender, RoutedEventArgs e)
        {
            Bmob.Push(new PushParamter().toast("wp push ok?", "good!!"), (resp, ex) =>
            {
                string status = "OK";
                if (ex != null)
                {
                    status = "ERROR";
                }

                Dispatcher.BeginInvoke(() =>
                {
                    updateStatus(push, status);
                });
            });
        }

        private void tilepush_Click(object sender, RoutedEventArgs e)
        {
            Bmob.Push(new PushParamter().token("hello bmob", 100, "hello bmob", "do our best!!"), (resp, ex) =>
            {
                string status = "OK";
                if (ex != null)
                {
                    status = "ERROR";
                }

                Dispatcher.BeginInvoke(() =>
                {
                    updateStatus(tilepush, status);
                });
            });
        }

        private void rawpush_Click(object sender, RoutedEventArgs e)
        {
            Bmob.Push(new PushParamter().raw("raw 123123"), (resp, ex) =>
            {
                string status = "OK";
                if (ex != null)
                {
                    status = "ERROR";
                }

                Dispatcher.BeginInvoke(() =>
                {
                    updateStatus(rawpush, status);
                });
            });
        }

        // restclient examples
        private void rest_Click(object sender, RoutedEventArgs e)
        { }



        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}
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

            /**
             * 
             * ## 演示案例中，云端代码first的内容如下：

function onRequest(request, response, modules) {
  response.end('{"bmob":"Hello,world"}');
}      

功能：返回key-value形式的json数据。


## 云端代码second的内容如下：
function onRequest(request, response, modules) {
  
  //获取数据库对象
  
  var db = modules.oData;
  
  //获取Posts表中的所有值
  
  db.find({

    "table":"_User"
  },function(err,data){
    
    response.end(data);
  
  });

}         

功能：获取_User表中的全部数据（默认返回10条）。


## 云端代码third的内容如下：
function onRequest(request, response, modules) {
  
  var db = modules.oData;
  
  db.findOne({

    "table":"_User",
   "objectId":request.body.userid
  
  },function(err,data){
   
    response.end(data);
  
});

}  

功能：返回_User表中指定objectId（从调用方传输）的一条数据。
             */

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

    }
}

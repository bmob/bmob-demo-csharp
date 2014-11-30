using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmobCSharpFileDemo.Model
{
    class MyfilesObject: BmobTable
    {

        private String fTable;
        //以下对应云端字段名称
        public BmobFile url { get; set; }
        public String user { get; set; }

        //构造函数
        public MyfilesObject() { }

        //构造函数
        public MyfilesObject(String tableName)
        {
            this.fTable = tableName;
        }

        public override string table
        {
            get
            {
                if (fTable != null)
                {
                    return fTable;
                }
                return base.table;
            }
        }

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            this.url = input.getFile("url");
            this.user = input.getString("user");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("url", this.url);
            output.Put("user", this.user);
        }
    }
}


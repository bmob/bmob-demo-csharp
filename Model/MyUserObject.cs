using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmobCSharpFileDemo.Model
{
    class MyUserObject: BmobUser
    {
        //以下对应云端字段名称
        public BmobBoolean sex { get; set; }
        public BmobInt age { get; set; }

        //构造函数
        public MyUserObject() { }

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            this.sex = input.getBoolean("sex");
            this.age = input.getInt("age");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("sex", this.sex);
            output.Put("age", this.age);
        }
    }
}


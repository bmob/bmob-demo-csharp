using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.bmob.example.Model
{
    class AdminUserObject : BmobTable
    {
        private String fTable;
        //以下对应云端字段名称
        public String UserName { get; set; }
        public String UserPhone { get; set; }
        public String UserRole { get; set; }
        public String PassWord { get; set; }
        public String IsActive { get; set; }
        //构造函数
        public AdminUserObject() { }

        //构造函数
        public AdminUserObject(String tableName)
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

            this.UserName = input.getString("UserName");
            this.UserPhone = input.getString("UserPhone");
            this.UserRole = input.getString("UserRole");
            this.PassWord = input.getString("PassWord");
            this.IsActive = input.getString("IsActive");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("UserName", this.UserName);
            output.Put("UserPhone", this.UserPhone);
            output.Put("UserRole", this.UserRole);
            output.Put("PassWord", this.PassWord);
            output.Put("IsActive", this.IsActive);
        }
    }
}

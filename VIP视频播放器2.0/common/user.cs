using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP视频播放器2._0.common
{
    public class user: BmobUser
    {
        public BmobInt u_id { get; set; }
        public string nickname { get; set; }
        public BmobDate EndDate { get; set; }
        public BmobBoolean LoginState { get; set; }
        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            this.u_id = input.getInt("u_id");
            this.username = input.getString("username");
            this.password = input.getString("password");
            this.nickname = input.getString("nickname");
            this.EndDate = input.getDate("EndDate");
            this.LoginState = input.getBoolean("LoginState");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("u_id", this.u_id);
            output.Put("username", this.username);
            output.Put("password", this.password);
            output.Put("nickname", this.nickname);
            output.Put("EndDate", this.EndDate);
            output.Put("LoginState", this.LoginState);
        }

    }
}

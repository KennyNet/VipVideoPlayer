using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP视频播放器2._0.common
{
    class authentics:BmobTable
    {
        public string Ques { get; set; }
        public string Ans { get; set; }
        public string haha { get; set; }

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            this.Ques = input.getString("Ques");
            this.Ans = input.getString("Ans");
            this.haha = input.getString("haha");

        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("Ques", this.Ques);
            output.Put("Ans", this.Ans);
            output.Put("haha", this.haha);
        }
    }
}

using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP视频播放器2._0.common
{
    class Messages:BmobTable
    {
        public string msg { get; set; }
        public string Announcement { get; set; }

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            this.Announcement = input.getString("Announcement");
            this.msg = input.getString("msg");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("msg", this.msg);
            output.Put("Announcement", this.Announcement);
        }
    }
}

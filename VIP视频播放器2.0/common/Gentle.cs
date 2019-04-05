using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP视频播放器2._0.common
{
    public class Gentle:BmobTable
    {
        public string urls { get; set; }
        public string driver{ get; set; }
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            this.urls = input.getString("urls");
            this.driver = input.getString("driver");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("urls", this.urls);
            output.Put("driver", this.driver);
        }
    }
}

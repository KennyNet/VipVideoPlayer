using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP视频播放器2._0.common
{
    class Regioncs: BmobTable
    {
        public BmobInt r_id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            this.r_id = input.getInt("r_id");
            this.url = input.getString("url");
            this.name = input.getString("name");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("r_id", this.r_id);
            output.Put("url", this.url);
            output.Put("name", this.name);
        }
    }
}

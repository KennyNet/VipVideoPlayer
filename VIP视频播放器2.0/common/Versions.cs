using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP视频播放器2._0.common
{
    class Versions:BmobTable
    {
        public string Ver { get; set; }
        public string Download { get; set; }
        public string Introduce { get; set; }
        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            this.Ver = input.getString("Ver");
            this.Download = input.getString("Download");
            this.Introduce = input.getString("Introduce");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("Ver", this.Ver);
            output.Put("Download", this.Download);
            output.Put("Introduce", this.Introduce);
        }
    }
}


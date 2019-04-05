using CCWin;
using cn.bmob.api;
using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIP视频播放器2._0.common;

namespace VIP视频播放器2._0
{
    public partial class authenticFrm : Skin_DevExpress
    {
        private BmobWindows GentleBmob;
        public static string Ques = "";
        public static string Ans = "";
        public static string haha = "";
        List<Gentle> list = new List<Gentle>();
        public authenticFrm()
        {
            GentleBmob = new BmobWindows();
            Bmob.initialize("e5cb6b64079660df7b3a2e367210e2f5", "4c2a77d6724e02dcf7982bcc0c62b113");
            getGentle();
            InitializeComponent();
        }
        public BmobWindows Bmob
        {
            get { return GentleBmob; }
        }
        public void getGentle()
        {
            GentleBmob.Get<authentics>("authentics", "3cqg777t", (resp, exception) =>
            {
                authentics auth = resp;
                Ques = auth.Ques;
                Ans = auth.Ans;
                haha = auth.haha;
            });
        }
        private void authentic_Load(object sender, EventArgs e)
        {
            GetGentle();
            PassWordYellow.Text = "";
            MessageBoxEx.Show("点击题目，按要求回答", "绅士提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "9";
        }

        private void btnQues_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show(Ques, "记住问题了吗?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (PassWordYellow.Text==Ans)
            {
                MessageBoxEx.Show("绅士你好~");
                
                gentleFrm gentFrm = new gentleFrm(list);
                this.Hide();
                gentFrm.ShowDialog();
                return;
            }
            if (PassWordYellow.Text==haha)
            {
                MessageBoxEx.Show("这是一个彩蛋~嘿嘿嘿~被骗了吧~绿色上网健康生活");
                return;
            }
            else
            {
                MessageBoxEx.Show("孩子你在长大些再来吧~");
            }
        }
        public void GetGentle()
        {
            BmobQuery query = new BmobQuery();
            query.Select("driver", "urls");
            GentleBmob.Find<Gentle>("Gentle", query, (resp, exception) =>
            {
                if (exception != null)
                {
                    MessageBoxEx.Show("绅士获取失败,请检查网络连接或联系开发者" + exception, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               list = resp.results;
            });
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            PassWordYellow.Text += "9";
        }
    }
}

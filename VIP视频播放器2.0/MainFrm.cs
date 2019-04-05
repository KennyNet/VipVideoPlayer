using CCWin;
using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIP视频播放器2._0.common;

namespace VIP视频播放器2._0
{
    public partial class MainFrm : Skin_DevExpress
    {
        //版本号
        private string ver = "V2.0";
        //bmob对象
        private BmobWindows PlayBmob;
        //绅士变量
        private static int i = 0;
        //登陆
        public bool islogin = false;
        /// <summary>
        /// 用户变量
        /// </summary>
        public static user buser = new user();
        /// <summary>
        /// dic存储播放源
        /// </summary>
        Dictionary<string, string> dic = new Dictionary<string, string>();

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public MainFrm() : base()
        {
            //this.bu = buser;
            PlayBmob = new BmobWindows();
            this.Visible = false;
            //初始化，这个ApplicationId/RestKey需要更改为你自己的ApplicationId/RestKey（ http://www.bmob.cn 上注册登录之后，创建应用可获取到ApplicationId/RestKey）
            Bmob.initialize("e5cb6b64079660df7b3a2e367210e2f5", "4c2a77d6724e02dcf7982bcc0c62b113");
            StopSleep.PreventSleep();
            InitializeComponent();
        }
        /// <summary>
        /// bmob构造函数
        /// </summary>
        public BmobWindows Bmob
        {
            get { return PlayBmob; }
        }

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mianfrm_Load(object sender, EventArgs e)
        {
            PlayBmob.Get<Versions>("Version", "GjFtBBBN", (resp, exception) =>
            {
                Versions v = resp;
                if (v.Ver != ver)
                {
                    DialogResult dr = MessageBoxEx.Show(this, "检测到新版本\r\n" + v.Introduce + "\r\n是否下载？", "更新提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        //用户选择确认的操作
                        System.Diagnostics.Process.Start(v.Download);
                        this.Close();
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        //用户选择取消的操作
                        Environment.Exit(0);
                    }
                }
            });
            this.Text += ver;
            
            CheckForIllegalCrossThreadCalls = false;
            GetRegion();
            PlayBmob.Get<Messages>("Message", "7sS9KKKl", (resp, exception) =>
            {
                Messages messages = resp;
                lblAnnouncement.Text = messages.Announcement;
                MessageBoxEx.Show(messages.msg, "欢迎使用", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        /// <summary>
        /// 菜单隐藏弹出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenuShow_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = !panelMenu.Visible;
        }

        /// <summary>
        /// 获取播放源
        /// </summary>
        public void GetRegion()
        {
            BmobQuery query = new BmobQuery();
            query.Select("name", "url");
            PlayBmob.Find<Regioncs>("Region", query, (resp, exception) =>
            {
                if (exception != null)
                {
                    MessageBoxEx.Show("播放源获取失败,请检查网络连接或联系开发者", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Regioncs> listItems = resp.results;
                foreach (var item in listItems)
                {
                    cBoxRegion.Items.Add(item.name);
                    cBoxRegion.SelectedIndex = 0;
                    dic.Add(item.name, item.url);
                }
            });
        }

        /// <summary>
        /// 播放按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            string url = dic[cBoxRegion.SelectedItem.ToString()] + txtUrl.Text;
            Uri uri = new Uri(url);
            WebPlayer.Url = uri;
        }
        /// <summary>
        /// 登陆方法
        /// </summary>
        private void login()
        {
            btnLogin.Text = "验证账号";
            BmobWindows bmobWindows = new BmobWindows();
            DateTime now = new DateTime();
            bmobWindows.Timestamp((resp, exception) =>
            {
                now = Convert.ToDateTime(resp.datetime);
            }
            );
            PlayBmob.Login<user>(txtUsername.Text, txtPwd.Text, (resp, exception) =>
            {
                if (exception != null)
                {
                    MessageBoxEx.Show("失败原因为： " + exception.Message, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                buser = BmobUser.CurrentUser as user;
                DateTime endtime = Convert.ToDateTime(buser.EndDate.iso);
                if (buser.emailVerified.Get() == false)
                {
                    MessageBoxEx.Show("您的邮箱未验证", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    buser = null;
                    return;
                }
                if (DateTime.Compare(endtime, now) < 0)
                {
                    MessageBoxEx.Show("您的会员已到期,请充值!", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    buser = null;
                    return;
                }
                if (buser.LoginState.Get() == true)
                {
                    MessageBoxEx.Show("您的账号已经登陆!", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    buser = null;
                    return;
                }
                buser = resp;
                
                //MessageBox.Show("登录成功, @" + resp.username + "(" + resp.nickname + ")$[" + resp.sessionToken + "]");
                //MessageBox.Show("登录成功, 当前用户对象Session： " + BmobUser.CurrentUser.sessionToken);
            });
            
            if (buser.sessionToken!=null)
            {
                Thread.Sleep(500);
                user u = new user();
                u.LoginState = true;
                PlayBmob.Update("_User", buser.objectId, u, (resp, exception) =>
                {
                    if (exception != null)
                    {
                        MessageBox.Show("失败");
                    }
                });
                btnLogin.Text = "登陆成功";
                lblNicknames.Text = buser.nickname;
                lblCreateTimes.Text = buser.createdAt;
                lblUpdateTimes.Text = buser.updatedAt;
                lblEndTimes.Text = buser.EndDate.iso;
                gifBox1.BringToFront();
            }
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBoxEx.Show(this, "是否退出系统", "退出提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                if (buser.sessionToken != null)
                {
                    Thread.Sleep(500);
                    user u = new user();
                    u.LoginState = false;
                    PlayBmob.Update("_User", buser.objectId, u, (resp, exception) =>
                    {
                        if (exception != null)
                        {
                            MessageBox.Show("失败");
                        }
                    });
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            else
            {
                e.Cancel=true;
            }
        }

        /// <summary>
        /// 从登陆panel到注册panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToSignUp_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = false;
            PanelSignUp.Visible = true;
            this.Text += "-注册用户";
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Text = "验证成功";
            Thread th = new Thread(login) { IsBackground = true };
            th.Start();
        }

        /// <summary>
        /// 从注册panel到登陆panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            PanelSignUp.Visible = false;
            PanelLogin.Visible = true;
            MainFrm.ActiveForm.Text = "大头VIP播放器" + ver;
        }

        /// <summary>
        /// 注册按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUpp_Click(object sender, EventArgs e)
        {
            if (!new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$").IsMatch(txtMail.Text))
            {
                MessageBoxEx.Show("邮箱格式不正确!", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //判断密码输入
            if (txtPwd_r.Text == "")
            {
                MessageBoxEx.Show("请输入密码!", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //判断密码长度
            if (txtPwd_r.Text.Length <= 8)
            {
                MessageBoxEx.Show("密码长度不正确!", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //确认密码
            if (txtPwd_r.Text.Length > 8)
            {
                if (txtPwd_r.Text != txtRepwd_r.Text)
                {
                    MessageBoxEx.Show("两次输入的密码不同!", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //判断昵称
            if (txtNickname.Text == "")
            {
                MessageBoxEx.Show("请输入昵称!", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //注册
            #region 新建用户对象
            var users = new user();
            users.username = txtMail.Text;
            users.password = txtRepwd_r.Text;
            users.nickname = txtNickname.Text;
            users.email = txtMail.Text;
            users.LoginState = false;
            users.EndDate = new DateTime(DateTime.Now.Year+1, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            #endregion
            //注册
            PlayBmob.Signup<user>(users, (resp, exception) =>
            {
                if (exception != null)
                {
                    MessageBoxEx.Show("注册失败, 失败原因为： " + exception.Message, "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBoxEx.Show("注册成功!!请验证您的邮箱后登录软件", "恭喜你", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Text = txtMail.Text;
                txtPwd.Text = txtRepwd_r.Text;
                txtMail.Text = "";
                txtNickname.Text = "";
                txtPwd_r.Text = "";
                txtRepwd_r.Text = "";
            });
        }

        /// <summary>
        /// 注册-密码输入框重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPwd_r_Paint(object sender, PaintEventArgs e)
        {
            if (txtPwd_r.Text.Length <= 8)
            {
                lbltips.Text = "密码必须大于8位";
                txtRepwd_r.Text = "";
                txtRepwd_r.ReadOnly = true;
                return;
            }
            txtRepwd_r.ReadOnly = false;
            lbltips.Text = "";
        }

        /// <summary>
        /// 注册-确认密码框重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRepwd_r_Paint(object sender, PaintEventArgs e)
        {
            if (txtRepwd_r.Text != txtPwd_r.Text)
            {
                lbltips.Text = "两次输入的密码不同";
                return;
            }
            lbltips.Text = "";
        }

        /// <summary>
        /// 菜单-播放按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanelPlay_Click(object sender, EventArgs e)
        {
            if (buser.sessionToken==null)
            {
                MessageBoxEx.Show("您尚未登陆账号!", "登陆提醒",MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                panelMine.BringToFront();
                return;
            }
            panelPlay.BringToFront();
        }

        /// <summary>
        /// 菜单-个人中心按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanelMine_Click(object sender, EventArgs e)
        {
            panelMine.BringToFront();
        }

        /// <summary>
        /// 菜单-反馈按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanelFeedBack_Click(object sender, EventArgs e)
        {
            if (buser.sessionToken == null)
            {
                MessageBoxEx.Show("您尚未登陆账号!", "登陆提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                panelMine.BringToFront();
                return;
            }
        }

        /// <summary>
        /// 公告文字颜色timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int a = rd.Next(256);
            int r = rd.Next(256);
            int g = rd.Next(256);
            int b = rd.Next(256);
            Color cr = Color.FromArgb(a,r,g,b);
            lblAnnouncement.ForeColor = cr;
        }

        /// <summary>
        /// 绅士入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAnnouncement_Click(object sender, EventArgs e)
        {
            i++;
            if (i==12)
            {
                MessageBoxEx.Show("绅士你好!Are you ready to driver?","你打开了一个预料之外的窗口",MessageBoxButtons.OK,MessageBoxIcon.Question);

                i=0;
                authenticFrm authen = new authenticFrm();
                authen.ShowDialog();
            }
        }
    }
}

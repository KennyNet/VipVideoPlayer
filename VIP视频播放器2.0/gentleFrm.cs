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
    public partial class gentleFrm : Skin_DevExpress
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        List<Gentle> lists = new List<Gentle>();
        private BmobWindows gentlBmob;
        public gentleFrm(List<Gentle> list)
        {
            this.lists = list;
            gentlBmob = new BmobWindows();
            Bmob.initialize("e5cb6b64079660df7b3a2e367210e2f5", "4c2a77d6724e02dcf7982bcc0c62b113");
            
            InitializeComponent();
        }
        public BmobWindows Bmob
        {
            get { return gentlBmob; }
        }
        
        private void btnDrive_Click(object sender, EventArgs e)
        {

            string url = dic[cmbDriver.SelectedItem.ToString()] + txtCarNum.Text;
            //Uri uri = new Uri(url);
            //GentlePlayer.Url = uri;
            System.Diagnostics.Process.Start("iexplore.exe",url);
        }

        private void gentleFrm_Load(object sender, EventArgs e)
        {
            foreach (var item in lists)
            {
                cmbDriver.Items.Add(item.driver);
                cmbDriver.SelectedIndex = 0;
                dic.Add(item.driver, item.urls);
            }
        }
    }
}

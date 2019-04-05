namespace VIP视频播放器2._0
{
    partial class gentleFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GentlePlayer = new System.Windows.Forms.WebBrowser();
            this.txtCarNum = new CCWin.SkinControl.SkinTextBox();
            this.btnDrive = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.cmbDriver = new CCWin.SkinControl.SkinComboBox();
            this.SuspendLayout();
            // 
            // GentlePlayer
            // 
            this.GentlePlayer.Location = new System.Drawing.Point(7, 78);
            this.GentlePlayer.MinimumSize = new System.Drawing.Size(20, 20);
            this.GentlePlayer.Name = "GentlePlayer";
            this.GentlePlayer.ScriptErrorsSuppressed = true;
            this.GentlePlayer.ScrollBarsEnabled = false;
            this.GentlePlayer.Size = new System.Drawing.Size(689, 376);
            this.GentlePlayer.TabIndex = 0;
            // 
            // txtCarNum
            // 
            this.txtCarNum.BackColor = System.Drawing.Color.Transparent;
            this.txtCarNum.DownBack = null;
            this.txtCarNum.Icon = null;
            this.txtCarNum.IconIsButton = false;
            this.txtCarNum.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCarNum.IsPasswordChat = '\0';
            this.txtCarNum.IsSystemPasswordChar = false;
            this.txtCarNum.Lines = new string[0];
            this.txtCarNum.Location = new System.Drawing.Point(7, 34);
            this.txtCarNum.Margin = new System.Windows.Forms.Padding(0);
            this.txtCarNum.MaxLength = 32767;
            this.txtCarNum.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtCarNum.MouseBack = null;
            this.txtCarNum.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCarNum.Multiline = false;
            this.txtCarNum.Name = "txtCarNum";
            this.txtCarNum.NormlBack = null;
            this.txtCarNum.Padding = new System.Windows.Forms.Padding(5);
            this.txtCarNum.ReadOnly = false;
            this.txtCarNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCarNum.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.txtCarNum.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCarNum.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCarNum.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtCarNum.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtCarNum.SkinTxt.Name = "BaseText";
            this.txtCarNum.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.txtCarNum.SkinTxt.TabIndex = 0;
            this.txtCarNum.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCarNum.SkinTxt.WaterText = "输入车牌号（1-9999）";
            this.txtCarNum.TabIndex = 1;
            this.txtCarNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCarNum.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCarNum.WaterText = "输入车牌号（1-9999）";
            this.txtCarNum.WordWrap = true;
            // 
            // btnDrive
            // 
            this.btnDrive.BackColor = System.Drawing.Color.Transparent;
            this.btnDrive.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDrive.DownBack = null;
            this.btnDrive.Location = new System.Drawing.Point(335, 37);
            this.btnDrive.MouseBack = null;
            this.btnDrive.Name = "btnDrive";
            this.btnDrive.NormlBack = null;
            this.btnDrive.Size = new System.Drawing.Size(75, 23);
            this.btnDrive.TabIndex = 2;
            this.btnDrive.Text = "开车！";
            this.btnDrive.UseVisualStyleBackColor = false;
            this.btnDrive.Click += new System.EventHandler(this.btnDrive_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Red;
            this.skinLabel1.Location = new System.Drawing.Point(158, 227);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(327, 17);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = "注意：XX播放源还未研究清楚,暂时只能使用自带浏览器开车";
            // 
            // cmbDriver
            // 
            this.cmbDriver.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDriver.FormattingEnabled = true;
            this.cmbDriver.Location = new System.Drawing.Point(208, 37);
            this.cmbDriver.Name = "cmbDriver";
            this.cmbDriver.Size = new System.Drawing.Size(121, 22);
            this.cmbDriver.TabIndex = 4;
            this.cmbDriver.WaterText = "";
            // 
            // gentleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 461);
            this.Controls.Add(this.cmbDriver);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.btnDrive);
            this.Controls.Add(this.txtCarNum);
            this.Controls.Add(this.GentlePlayer);
            this.Name = "gentleFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gentle";
            this.Load += new System.EventHandler(this.gentleFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser GentlePlayer;
        private CCWin.SkinControl.SkinTextBox txtCarNum;
        private CCWin.SkinControl.SkinButton btnDrive;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinComboBox cmbDriver;
    }
}
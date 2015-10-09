namespace Reboot
{
    partial class Reboot
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reboot));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rebootshoudaong = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.RebootTimes = new System.Windows.Forms.Label();
            this.SETT = new System.Windows.Forms.GroupBox();
            this.RebootTime = new System.Windows.Forms.MaskedTextBox();
            this.set = new System.Windows.Forms.Button();
            this.ScreenKey = new System.Windows.Forms.Button();
            this.SETT.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 55000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rebootshoudaong
            // 
            this.rebootshoudaong.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rebootshoudaong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rebootshoudaong.BackgroundImage")));
            this.rebootshoudaong.FlatAppearance.BorderSize = 0;
            this.rebootshoudaong.Location = new System.Drawing.Point(421, 292);
            this.rebootshoudaong.Name = "rebootshoudaong";
            this.rebootshoudaong.Size = new System.Drawing.Size(117, 38);
            this.rebootshoudaong.TabIndex = 0;
            this.rebootshoudaong.UseVisualStyleBackColor = false;
            this.rebootshoudaong.Click += new System.EventHandler(this.rebootshoudaong_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // RebootTimes
            // 
            this.RebootTimes.AutoSize = true;
            this.RebootTimes.BackColor = System.Drawing.Color.Transparent;
            this.RebootTimes.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.RebootTimes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RebootTimes.Location = new System.Drawing.Point(42, 39);
            this.RebootTimes.Name = "RebootTimes";
            this.RebootTimes.Size = new System.Drawing.Size(89, 25);
            this.RebootTimes.TabIndex = 2;
            this.RebootTimes.Text = "重启时间:";
            // 
            // SETT
            // 
            this.SETT.BackColor = System.Drawing.Color.Transparent;
            this.SETT.Controls.Add(this.RebootTime);
            this.SETT.Controls.Add(this.set);
            this.SETT.Controls.Add(this.RebootTimes);
            this.SETT.ForeColor = System.Drawing.SystemColors.MenuText;
            this.SETT.Location = new System.Drawing.Point(48, 102);
            this.SETT.Name = "SETT";
            this.SETT.Size = new System.Drawing.Size(490, 107);
            this.SETT.TabIndex = 4;
            this.SETT.TabStop = false;
            this.SETT.Text = "设置";
            // 
            // RebootTime
            // 
            this.RebootTime.Location = new System.Drawing.Point(170, 42);
            this.RebootTime.Mask = "90:00";
            this.RebootTime.Name = "RebootTime";
            this.RebootTime.PromptChar = ' ';
            this.RebootTime.Size = new System.Drawing.Size(137, 21);
            this.RebootTime.TabIndex = 4;
            this.RebootTime.ValidatingType = typeof(System.DateTime);
            // 
            // set
            // 
            this.set.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("set.BackgroundImage")));
            this.set.Location = new System.Drawing.Point(374, 36);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(87, 32);
            this.set.TabIndex = 3;
            this.set.UseVisualStyleBackColor = true;
            this.set.Click += new System.EventHandler(this.set_Click);
            // 
            // ScreenKey
            // 
            this.ScreenKey.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScreenKey.BackgroundImage")));
            this.ScreenKey.Location = new System.Drawing.Point(48, 294);
            this.ScreenKey.Name = "ScreenKey";
            this.ScreenKey.Size = new System.Drawing.Size(121, 36);
            this.ScreenKey.TabIndex = 5;
            this.ScreenKey.UseVisualStyleBackColor = true;
            this.ScreenKey.Click += new System.EventHandler(this.ScreenKey_Click);
            // 
            // Reboot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(598, 370);
            this.Controls.Add(this.ScreenKey);
            this.Controls.Add(this.SETT);
            this.Controls.Add(this.rebootshoudaong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reboot";
            this.Text = " ";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Reboot_Load);
            this.SETT.ResumeLayout(false);
            this.SETT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rebootshoudaong;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label RebootTimes;
        private System.Windows.Forms.GroupBox SETT;
        private System.Windows.Forms.MaskedTextBox RebootTime;
        private System.Windows.Forms.Button set;
        private System.Windows.Forms.Button ScreenKey;
    }
}


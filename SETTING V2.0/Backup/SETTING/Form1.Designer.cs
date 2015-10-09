namespace SETTING
{
    partial class SETTING
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
            this.txtIP = new System.Windows.Forms.Label();
            this.txtSubMark = new System.Windows.Forms.Label();
            this.TTITLE = new System.Windows.Forms.Label();
            this.gunark_sub = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gunark_gateway = new System.Windows.Forms.ComboBox();
            this.txtGateWay = new System.Windows.Forms.Label();
            this.MaskedIP = new System.Windows.Forms.MaskedTextBox();
            this.Alter = new System.Windows.Forms.Button();
            this.GetIP = new System.Windows.Forms.Button();
            this.ScreenKey = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.AutoSize = true;
            this.txtIP.Font = new System.Drawing.Font("宋体", 10F);
            this.txtIP.Location = new System.Drawing.Point(10, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(70, 14);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "IP 地址：";
            // 
            // txtSubMark
            // 
            this.txtSubMark.AutoSize = true;
            this.txtSubMark.Font = new System.Drawing.Font("宋体", 10F);
            this.txtSubMark.Location = new System.Drawing.Point(10, 58);
            this.txtSubMark.Name = "txtSubMark";
            this.txtSubMark.Size = new System.Drawing.Size(77, 14);
            this.txtSubMark.TabIndex = 2;
            this.txtSubMark.Text = "子网掩码：";
            // 
            // TTITLE
            // 
            this.TTITLE.AutoSize = true;
            this.TTITLE.Font = new System.Drawing.Font("华文细黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TTITLE.Location = new System.Drawing.Point(13, 13);
            this.TTITLE.Name = "TTITLE";
            this.TTITLE.Size = new System.Drawing.Size(177, 24);
            this.TTITLE.TabIndex = 10;
            this.TTITLE.Text = "internet协议配置";
            // 
            // gunark_sub
            // 
            this.gunark_sub.FormattingEnabled = true;
            this.gunark_sub.Location = new System.Drawing.Point(144, 56);
            this.gunark_sub.Name = "gunark_sub";
            this.gunark_sub.Size = new System.Drawing.Size(146, 20);
            this.gunark_sub.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gunark_gateway);
            this.groupBox3.Controls.Add(this.txtGateWay);
            this.groupBox3.Controls.Add(this.MaskedIP);
            this.groupBox3.Controls.Add(this.gunark_sub);
            this.groupBox3.Controls.Add(this.txtIP);
            this.groupBox3.Controls.Add(this.txtSubMark);
            this.groupBox3.Location = new System.Drawing.Point(47, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 148);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "配置";
            // 
            // gunark_gateway
            // 
            this.gunark_gateway.FormattingEnabled = true;
            this.gunark_gateway.Location = new System.Drawing.Point(144, 104);
            this.gunark_gateway.Name = "gunark_gateway";
            this.gunark_gateway.Size = new System.Drawing.Size(147, 20);
            this.gunark_gateway.TabIndex = 21;
            // 
            // txtGateWay
            // 
            this.txtGateWay.AutoSize = true;
            this.txtGateWay.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGateWay.Location = new System.Drawing.Point(10, 110);
            this.txtGateWay.Name = "txtGateWay";
            this.txtGateWay.Size = new System.Drawing.Size(63, 14);
            this.txtGateWay.TabIndex = 20;
            this.txtGateWay.Text = "默认网关";
            // 
            // MaskedIP
            // 
            this.MaskedIP.Location = new System.Drawing.Point(144, 12);
            this.MaskedIP.Name = "MaskedIP";
            this.MaskedIP.Size = new System.Drawing.Size(146, 21);
            this.MaskedIP.TabIndex = 19;
            // 
            // Alter
            // 
            this.Alter.Location = new System.Drawing.Point(45, 240);
            this.Alter.Name = "Alter";
            this.Alter.Size = new System.Drawing.Size(75, 23);
            this.Alter.TabIndex = 15;
            this.Alter.Text = "修改";
            this.Alter.UseVisualStyleBackColor = true;
            this.Alter.Click += new System.EventHandler(this.Alter_Click);
            // 
            // GetIP
            // 
            this.GetIP.Location = new System.Drawing.Point(45, 289);
            this.GetIP.Name = "GetIP";
            this.GetIP.Size = new System.Drawing.Size(75, 23);
            this.GetIP.TabIndex = 16;
            this.GetIP.Text = "获取";
            this.GetIP.UseVisualStyleBackColor = true;
            this.GetIP.Click += new System.EventHandler(this.GetIP_Click);
            // 
            // ScreenKey
            // 
            this.ScreenKey.Location = new System.Drawing.Point(282, 289);
            this.ScreenKey.Name = "ScreenKey";
            this.ScreenKey.Size = new System.Drawing.Size(75, 23);
            this.ScreenKey.TabIndex = 17;
            this.ScreenKey.Text = "键盘";
            this.ScreenKey.UseVisualStyleBackColor = true;
            this.ScreenKey.Click += new System.EventHandler(this.Restart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SETTING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(421, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ScreenKey);
            this.Controls.Add(this.GetIP);
            this.Controls.Add(this.Alter);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.TTITLE);
            this.MaximizeBox = false;
            this.Name = "SETTING";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SETTING";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtIP;
        private System.Windows.Forms.Label txtSubMark;
        public System.Windows.Forms.Label TTITLE;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Alter;
        private System.Windows.Forms.Button GetIP;
        private System.Windows.Forms.Button ScreenKey;
        private System.Windows.Forms.ComboBox gunark_sub;
        private System.Windows.Forms.MaskedTextBox MaskedIP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox gunark_gateway;
        private System.Windows.Forms.Label txtGateWay;
    }
}


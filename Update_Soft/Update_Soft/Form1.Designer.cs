namespace Update_Soft
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancel_BT = new System.Windows.Forms.Button();
            this.update_BT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.MaximumSize = new System.Drawing.Size(218, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "主程序会在更新以及还原操作时，强制关闭，操作完成后会自动启动！";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "注意";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancel_BT);
            this.groupBox2.Controls.Add(this.update_BT);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 86);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cancel_BT
            // 
            this.cancel_BT.Location = new System.Drawing.Point(153, 42);
            this.cancel_BT.Name = "cancel_BT";
            this.cancel_BT.Size = new System.Drawing.Size(75, 23);
            this.cancel_BT.TabIndex = 0;
            this.cancel_BT.Text = "一键还原";
            this.cancel_BT.UseVisualStyleBackColor = true;
            this.cancel_BT.Click += new System.EventHandler(this.cancel_BT_Click);
            // 
            // update_BT
            // 
            this.update_BT.Location = new System.Drawing.Point(21, 42);
            this.update_BT.Name = "update_BT";
            this.update_BT.Size = new System.Drawing.Size(75, 23);
            this.update_BT.TabIndex = 0;
            this.update_BT.Text = "一键更新";
            this.update_BT.UseVisualStyleBackColor = true;
            this.update_BT.Click += new System.EventHandler(this.update_BT_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 283);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "枪弹柜控制系统更新";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cancel_BT;
        private System.Windows.Forms.Button update_BT;
        private System.Windows.Forms.Button button1;

    }
}


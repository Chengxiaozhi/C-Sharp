using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;



namespace Update_Soft
{
    /// <summary>
    /// 载入窗口时先检查更新，没有更新就提示“暂时无更新”；有更新的话先进行备份，备份失败的话提示错误推出更新；
    /// </summary>
    public partial class UpdateForm : Form
    {

        //private delegate void PrintResultDelegate(string msg, int val);
        //private delegate void SetButtonDelegate();
        private bool isDelete = true; //判断是否删除升级配置
        private bool runningLock = false;//判断是否正在升级
        private Thread thread;//升级的线程

        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            
            BaseForm.CloseApp();

            if (CheckUpdate())
            {
                if (!Backup())
                {
                    MessageBox.Show("备份失败！");
                    btnStart.Enabled = false;
                    isDelete = true;
                    return;
                }

            }
            else
            {
                MessageBox.Show("暂时无更新");
                this.btnFinish.Enabled = true;
                this.btnStart.Enabled = false;
                isDelete = false;
                this.Close();
            }
        }
        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (runningLock)
            {
                if (MessageBox.Show("升级还在进行中，中断升级会导致程序不可用，是否中断",
                          "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    if (thread != null) thread.Abort();
                    isDelete = true;
                    AppParameter.IsRunning = false;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (isDelete) File.Delete(AppParameter.LocalUPdateConfig);

            BaseForm.StartApp();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            UpdateApp();
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void UpdateApp()
        {
           
            int successCount = 0;
            int failCount = 0;
            int itemIndex = 0;
            List<FileENT> list = ConfigHelper.GetUpdateList();
            if (list.Count == 0)
            {
                MessageBox.Show("版本已是最新", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnFinish.Enabled = true;
                this.btnStart.Enabled = false;
                isDelete = false;
                this.Close();
                return;
            }
           
            thread = new Thread(new ThreadStart(delegate
            {
                #region thread method

                FileENT ent = null;

                while (true)
                {
                    lock (this)
                    {
                        if (itemIndex >= list.Count)
                            break;
                        ent = list[itemIndex];


                        string msg = string.Empty;
                        if (ExecUpdateItem(ent))
                        {
                            msg = ent.FileFullName + "更新成功";
                            successCount++;
                        }
                        else
                        {
                            msg = ent.FileFullName + "更新失败";
                            failCount++;
                        }

                        if (this.InvokeRequired)
                        {
                            
                            this.Invoke((Action)delegate()
                            {
                                listBox1.Items.Add(msg);
                                int val = (int)Math.Ceiling(1f / list.Count * 100);
                                progressBar1.Value = progressBar1.Value + val > 100 ? 100 : progressBar1.Value + val;
                            });
                        }


                        itemIndex++;
                        if (successCount + failCount == list.Count && this.InvokeRequired)
                        {
                            string finishMessage = string.Empty;
                            
                            if (this.InvokeRequired)
                            {
                                this.Invoke((Action)delegate()
                                {
                                    btnFinish.Enabled = true;
                                });
                            }
                            isDelete = failCount != 0;
                            if (!isDelete)
                            {
                                AppParameter.Version = list.Last().Version;
                                ConfigHelper.UpdateAppConfig("version", AppParameter.Version);
                                finishMessage = "升级完成，程序已成功升级到" + AppParameter.Version;
                            }
                            else
                                finishMessage = "升级完成，但不成功";
                            MessageBox.Show(finishMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            runningLock = false;
                        }
                    }
                }
                #endregion
            }));
         
            runningLock = true;
            thread.Start();
           
        }

        /// <summary>
        /// 执行单个更新
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public bool ExecUpdateItem(FileENT ent)
        {
            bool result = true;

            try
            {

                if (ent.Option == UpdateOptionEnum.del)
                    File.Delete(ent.FileFullName);
                else
                    HttpHelper.DownLoadFile(ent.Src, Path.Combine(AppParameter.MainPath, ent.FileFullName));
            }
            catch { result = false; }
            return result;
        }

        /// <summary>
        /// 检查更新 有则提示用户 确认后下载新的更新配置
        /// </summary>
        /// <returns>用户确认信息</returns>
        public static bool CheckUpdate()
        {
            bool result = false;

            HttpHelper.DownLoadFile(AppParameter.ServerURL, AppParameter.LocalPath + "temp_config.xml");
            if (!File.Exists(AppParameter.LocalUPdateConfig))
                result = true;
            else
            {
                long localSize = new FileInfo(AppParameter.LocalUPdateConfig).Length;
                long tempSize = new FileInfo(AppParameter.LocalPath + "temp_config.xml").Length;

                if (localSize >= tempSize) result = false;

                else result = true;
            }

            if (result)
            {
                if (File.Exists(AppParameter.LocalUPdateConfig)) File.Delete(AppParameter.LocalUPdateConfig);
                File.Copy(AppParameter.LocalPath + "temp_config.xml", AppParameter.LocalUPdateConfig);
            }
            else
                result = false;

            File.Delete(AppParameter.LocalPath + "temp_config.xml");
            return result;
        }

        /// <summary>
        /// 备份
        /// </summary>
        public static bool Backup()
        {
            string sourcePath = Path.Combine(AppParameter.BackupPath, DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "_v_" + AppParameter.Version + ".rar");
            return ZipHelper.Zip(AppParameter.MainPath.Trim(), sourcePath);
        }

       
    }
}

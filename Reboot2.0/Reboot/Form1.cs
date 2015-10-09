using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;


namespace Reboot
{
    public partial class Reboot : Form
    {
        public Reboot()
        {
            InitializeComponent();
           
        }
        private string rebootTime = DateTime.Now.ToShortTimeString();
        private string time = "00:00"; 

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int flg, int rea);
        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const int EWX_LOGOFF = 0x00000000;
        internal const int EWX_SHUTDOWN = 0x00000001;
        internal const int EWX_REBOOT = 0x00000002;
        internal const int EWX_FORCE = 0x00000004;
        internal const int EWX_POWEROFF = 0x00000008;
        internal const int EWX_FORCEIFHUNG = 0x00000010;
        private void DoExitWin(int flg)
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx(flg, 0);
        }

        private void rebootshoudaong_Click(object sender, EventArgs e)
        {
             if (!IsTime(RebootTime.Text.Trim()))
                {
                    MessageBox.Show("时间格式不正确");
                        return;
                }
            
         
            try
                {
                    string[] proName = new string[1] {"Bullet"};
                    foreach (string pName in proName)
                    {
                        System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName(pName);
                        p[0].Kill();
                       // MessageBox.Show("进程关闭成功");
                    }
                    
                }
                catch
                {
                    MessageBox.Show("无法关闭该程序！");
                }
              try
                  {
                      DoExitWin(EWX_REBOOT);//重启电脑
                  }
              catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           rebootTime = DateTime.Now.ToShortTimeString();
           string str = "Server=localhost;User ID=root;Password=123456;Database=qdgl;CharSet=utf8;";
           MySqlConnection conn = new MySqlConnection(str);
           conn.Open();
           string sqlFinger = "select REBOOT_TIME from gunark_reboot";
           MySqlCommand cmd = new MySqlCommand(sqlFinger, conn);
           MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           ada.Fill(ds);

           DataTable dt = ds.Tables[0];
           int len1 = ds.Tables[0].Rows.Count ;
           time = ds.Tables[0].Rows[len1-1][0].ToString();
           conn.Close();
           //MessageBox.Show(time);
            if (rebootTime.Equals(time))
            {
                timer1.Enabled = false;
                try
                {
                    string[] proName = new string[1] { "Bullet" };
                    foreach (string pName in proName)
                    {
                        System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName(pName);
                        p[0].Kill(); 
                    }

                }
                catch
                {
                    MessageBox.Show("无法关闭该程序！");
                }
                    try
                    {
                        DoExitWin(EWX_REBOOT);//重启电脑
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
       
            }
            timer1.Enabled = true;
        }

        private void Form1_SizeChanged(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }

    
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
            
        }


        #region 判断是否是正确的ip地址
        /// <summary>
        /// 判断是否是正确的ip地址
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        protected bool IsTime(string istime)
        {
            string[] num = istime.Split(':');
            if (num.Length != 2) 
                return false;
          
            if (Convert.ToInt32(num[0]) < 0 || Convert.ToInt32(num[0]) > 24) 
                    return false;
            if (Convert.ToInt32(num[1]) < 0 || Convert.ToInt32(num[1]) > 60)
                    return false;
            return true;
        }
        #endregion

        private void set_Click(object sender, EventArgs e)
        {
            if (!IsTime(RebootTime.Text.Trim()))
            {
                MessageBox.Show("时间格式不正确");
                return;
            }

           time = RebootTime.Text.ToString();

      
           DateTime now = DateTime.Now;
           string str = "Server=localhost;User ID=root;Password=123456;Database=qdgl;CharSet=utf8;";
           MySqlConnection conn = new MySqlConnection(str);
           conn.Open();
           string sqlFinger = "insert into gunark_reboot (REBOOT_TIME)values('" + time +"')";
           MySqlCommand cmd = new MySqlCommand(sqlFinger, conn);
           MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           ada.Fill(ds);
           conn.Close();

           MessageBox.Show(time);
        }

        private void ScreenKey_Click(object sender, EventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start("ScreenKey");
            }
            catch
            {
                MessageBox.Show("无法打开键盘");

            }
        }

        private void    Reboot_Load(object sender, EventArgs e)
        {

        }

    
    }
}
        
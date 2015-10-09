using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation; 
using System.Management;      // 访问网络设置 
using System.IO;              // 读写文本文件 
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;

 

namespace SETTING
{
    public partial class SETTING : Form
    {
        [DllImport("user32.dll")]
        public static extern int MessageBoxTimeoutA(IntPtr hwnd, string txt, string caption, int wtype, int wlange, int dwtimeout);
       
        ConfigFile cf = ConfigFile.Instanse;
        SetDatebase db =  new SetDatebase();
        public SETTING()
        {
           
            InitializeComponent();
           
            gunark_ip_Selected();
            gunark_sub_Selected();
            gunark_gateway_Selected();
        }


        [StructLayout(LayoutKind.Sequential, Pack=1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }
        [DllImport("kernel32.dll", ExactSpelling=true) ]
        internal static extern IntPtr GetCurrentProcess();
        [DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
        internal static extern bool OpenProcessToken( IntPtr h, int acc, ref IntPtr phtok );
        [DllImport("advapi32.dll", SetLastError=true) ]
        internal static extern bool LookupPrivilegeValue( string host, string name, ref long pluid );
        [DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
        internal static extern bool AdjustTokenPrivileges( IntPtr htok, bool disall,ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen );
        [DllImport("user32.dll", ExactSpelling=true, SetLastError=true) ]
        internal static extern bool ExitWindowsEx( int flg, int rea );
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
        private void DoExitWin( int flg )
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken( hproc, TOKEN_ADJUST_PRIVILEGES|TOKEN_QUERY, ref htok );
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue( null, SE_SHUTDOWN_NAME, ref tp.Luid );
            ok = AdjustTokenPrivileges( htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx( flg, 0 );
        }


        /////
        private void Alter_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(" 确定要修改吗？", "修改IP", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);//这里为确定用户是否点击“确定”按钮
            try
            {
                if (!IsIpaddress(MaskedIP.Text.Trim()))
                {
                    MessageBox.Show("ip格式不正确！"); return;
                }
                if (!IsIpaddress(gunark_sub.Text.Trim()))
                {
                    MessageBox.Show("子网掩码格式不正确！"); return;
                }
                if (!IsIpaddress(gunark_gateway.Text.Trim()))
                {
                    MessageBox.Show("网关格式不正确！"); return;
                }

                string[] ip = new string[] { MaskedIP.Text.Trim() };
                string[] SubMark = new string[] { gunark_sub.Text.Trim() };
                string[] GateWay = new string[] { gunark_gateway.Text.Trim() };
                SetIPAddress(ip, SubMark, GateWay);
                MessageBox.Show("ip信息设置成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show("设置出错：" + er.Message, "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ////////
        private void SetIPAddress(string[] ip, string[] submask, string[] getway)
        {
             try
            {
                ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = wmi.GetInstances();
                ManagementBaseObject inPar = null;
                ManagementBaseObject outPar = null;
               
                foreach (ManagementObject mo in moc)
                {
                    //如果没有启用IP设置的网络设备则跳过
                    if (!(bool)mo["IPEnabled"])
                        continue;
                    //设置IP地址和掩码

                    inPar = mo.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = ip;
                    inPar["SubnetMask"] = submask;
                    outPar = mo.InvokeMethod("EnableStatic", inPar, null);

                    inPar = mo.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = getway;
                    outPar = mo.InvokeMethod("SetGateways", inPar, null);
                   
                    
                }
               // MessageBox.Show("设置成功！");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
                
         }
           

        private void GetIP_Click(object sender, EventArgs e)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                bool Pd1 = (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet); //判断是否是以太网连接  
                if (Pd1)
                {
                    IPInterfaceProperties ip = adapter.GetIPProperties();     //IP配置信息  
                    if (ip.UnicastAddresses.Count > 0)
                    {
                        MaskedIP.Text = ip.UnicastAddresses[0].Address.ToString();//IP地址  
                        gunark_sub.Text = ip.UnicastAddresses[0].IPv4Mask.ToString();//子网掩码  

                    }
                    if (ip.GatewayAddresses.Count > 0)
                    {
                        gunark_gateway.Text = ip.GatewayAddresses[0].Address.ToString();//默认网关  
                    }
             
             
                }
            }
        }

        #region 判断是否是正确的ip地址
        /// <summary>
        /// 判断是否是正确的ip地址
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        protected bool IsIpaddress(string ipaddress)
        {
            string[] nums = ipaddress.Split('.');
            if (nums.Length != 4) return false;
            foreach (string num in nums)
            {
                if (Convert.ToInt32(num) < 0 || Convert.ToInt32(num) > 255) return false;
            }
            return true;
        }
        #endregion

        //#region Form1_Load
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    loadConfig();
        //}
        //#endregion

        private void Restart_Click(object sender, EventArgs e)
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

       
        private void gunark_ip_Selected()
        {
            string IP = db.selectSetting("GUNARK_IP");
            
                MaskedIP.Text = IP;
                 
        }
        private void gunark_sub_Selected()
        {

            //string[] sub = { "255.255.255.0", "255.255.0.0", "255.0.0.0" };
            string[] sub = db.selectconfig("GUNARK_SUBNET");
            for (int i = 0; i < sub.Length; i++)
            {
                gunark_sub.Items.Add(sub[i]);

            }
            int n = sub.Length - 1;
             gunark_sub.Text = sub[n];
        }
        private void gunark_gateway_Selected()
        {
            string gateway = db.selectSetting("GUNARK_GATEWAY");

            gunark_gateway.Text = gateway;

        }
      

    }
}
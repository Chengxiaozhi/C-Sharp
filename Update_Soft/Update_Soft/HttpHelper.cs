using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Update_Soft
{
    class HttpHelper
    {
        /// <summary>
        /// 从服务器下载所需文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        public static void DownLoadFile(string url, string fileName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

           
            byte[] buffer = new byte[1024];
            Stream outStream = CreateFile(fileName);
            Stream inStream = response.GetResponseStream();

            int l;
            do
            {
                l = inStream.Read(buffer, 0, buffer.Length);
                if (l > 0)
                    outStream.Write(buffer, 0, l);
            }
            while (l > 0);

            outStream.Close();
            inStream.Close();

            string pattern = @"\b(\S+).(exe.txt)$"; 
            string pattern1 = @"\b(\S+).(pdb.txt)$"; 
            Match mc = null;

            mc = Regex.Match(url, pattern);
            if (mc.ToString() != "")
            {
                string dfileName = Path.ChangeExtension(fileName, ".config");
                if (File.Exists(dfileName))
                {
                    File.Delete(dfileName);
                }
                File.Move(fileName, dfileName);
            }

            Match mc1 = Regex.Match(url, pattern1);
            if (mc1.ToString() != "")
            {
                string dfileName = Path.ChangeExtension(fileName, "");
                if (File.Exists(dfileName))
                {
                    File.Delete(dfileName);
                }
                File.Move(fileName, dfileName);
            }
            //}

        }

        private static FileStream CreateFile(string fileName)
        {
            string filePath = Path.GetDirectoryName(fileName);//获取指定路径字符串的目录信息
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            return File.Create(fileName);
        }
    }
}

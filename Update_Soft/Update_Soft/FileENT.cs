using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update_Soft
{
    public class FileENT
    {
        public string FileFullName { get; set; }

        public string Src { get; set; }

        public string Version { get; set; }

        public int Size { get; set; }

        public UpdateOptionEnum Option { get; set; }
    }
}

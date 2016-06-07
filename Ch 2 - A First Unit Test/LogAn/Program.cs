using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    class Program
    {
        //ncrunch: no coverage start
        static void Main(string[] args)
        {
            LogAnalyzer logAn = new LogAnalyzer();
            logAn.IsValidLogFileName("ValidFileName.SLF");
        }
        //ncrunch: no coverage end
    }
}

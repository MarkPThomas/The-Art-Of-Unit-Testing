using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    // This class uses the LoggingFacility internally.
    public class LogAnalyzer
    {
        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                LoggingFacility.Log("Filename too short: " + fileName);
            }
            // rest of method here
        }
    }
}

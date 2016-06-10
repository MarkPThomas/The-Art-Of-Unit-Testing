using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }
        
        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            // Read through the configuration file.
            // Return 'true' if configuration says extension is supported.

            // Code extracted into another class to begin creating a seam
            if (IsValid(fileName))
            {
                WasLastFileNameValid = true;
                return true;
            }
            else
            {
                WasLastFileNameValid = false;
                return false;
            }
        }


        protected virtual bool IsValid(string fileName)
        {
            FileExtensionManager manager = new FileExtensionManager();
            return manager.IsValid(fileName);
        }
    }
}

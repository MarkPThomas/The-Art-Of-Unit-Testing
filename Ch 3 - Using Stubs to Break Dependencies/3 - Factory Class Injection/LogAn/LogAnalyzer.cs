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

        private IExtensionManager _manager;

        public LogAnalyzer()
        {
            _manager = ExtensionManagerFactory.Create();
        }

        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            // Read through the configuration file.
            // Return 'true' if configuration says extension is supported.

            if (_manager.IsValid(fileName))
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

    }
}

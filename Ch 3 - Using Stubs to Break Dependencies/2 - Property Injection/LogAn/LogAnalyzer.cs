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
               
        ////////////////
        // Using Property/Dependency Injection
        ////////////////
        public IExtensionManager Manager { get; set; }

        ////////////////
        // Using Property/Dependency Injection
        ////////////////
        // This implies that the dependencies are optional.
        // Use this technique when you want to signify that a dependency of a class under test us optional or if
        // the dependency has a default instance created that doesn't create any problems during the test.
        public LogAnalyzer()
        {
            Manager = new FakeExtensionManager();
        }

        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            // Read through the configuration file.
            // Return 'true' if configuration says extension is supported.

            //////////////////
            //// Separating the dependency into another class
            //////////////////
            //// Code extracted into another class to begin creating a seam
            //IExtensionManager mgr = new FileExtensionManager();
            //if (mgr.IsValid(fileName))
            //{
            //    WasLastFileNameValid = true;
            //    return true;
            //}
            //else
            //{
            //    WasLastFileNameValid = false;
            //    return false;
            //}

            ////////////////
            // Using Property/Dependency Injection
            ////////////////
            // Code extracted into another class to begin creating a seam
            if (Manager.IsValid(fileName))
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

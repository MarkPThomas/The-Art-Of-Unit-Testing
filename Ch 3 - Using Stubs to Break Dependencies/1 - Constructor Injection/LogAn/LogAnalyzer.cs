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
        // Using Constructor Injection
        ////////////////
        private IExtensionManager _manager;

        ////////////////
        // Using Constructor Injection
        ////////////////
        // This becomes a problem when many dependencies must be provided.
        //
        // 'Parameter object refactoring' can be used to lump all possible dependencies into one parameter object, but this can get out of hand pretty fast.
        // Another solution is to use inversion of control (IoC) containers, such as Ninject. 
        // These are like 'smart factories' for objects.
        //
        // Recommended way of handling dependencies, although it makes testing code more cumbersome unless using a helper framework such as IoC containers for object creation.
        public LogAnalyzer(IExtensionManager manager)
        {
            _manager = manager;
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
            // Using Constructor Injection
            ////////////////
            // Code extracted into another class to begin creating a seam
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

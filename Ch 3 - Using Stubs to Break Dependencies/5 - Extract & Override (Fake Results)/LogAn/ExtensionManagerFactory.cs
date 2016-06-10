using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class ExtensionManagerFactory
    {
        private static IExtensionManager _customManager;

        public static IExtensionManager Create()
        {
            if (_customManager != null)
            {
                return _customManager;
            }
            else
            {
                return new FileExtensionManager();
            }
        }

        public static void SetManager(IExtensionManager manager)
        {
            _customManager = manager;
        }
    }
}

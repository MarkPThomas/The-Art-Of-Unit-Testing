using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    // This class also uses the LoggingFacility internally.
    public class ConfigurationManager
    {
        public bool IsConfigured(string configName)
        {
            LoggingFacility.Log("checking " + configName);
            bool result = true;
            return result;
        }
    }
}

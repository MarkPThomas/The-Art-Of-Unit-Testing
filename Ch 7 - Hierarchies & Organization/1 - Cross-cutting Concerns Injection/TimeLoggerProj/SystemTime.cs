using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLoggerProj
{
    /// <summary>
    /// To be used by all production code instead of DateTime for easier testing.
    /// The simple trick is that there are special functions in the class that allow you to alter the current time throughout the system.
    /// That is, everyone who uses the class will see whatever date and time you choose.
    /// This gives you a perfect way to test that the current time is used in your production code through a simple test like the one in this solution.
    /// </summary>
    public class SystemTime
    {
        private static DateTime _date;

        public static void Set(DateTime custom)
        {
            _date = custom;
        }

        public static void Reset()
        {
            _date = DateTime.MinValue;
        }

        public static DateTime Now
        {
            get
            {
                if (_date != DateTime.MinValue)
                {
                    return _date;
                }
                return DateTime.Now;
            }
        }
    }
}

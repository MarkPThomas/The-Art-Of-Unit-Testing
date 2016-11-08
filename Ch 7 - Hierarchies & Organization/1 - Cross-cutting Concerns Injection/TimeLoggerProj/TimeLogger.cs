using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLoggerProj
{
    public static class TimeLogger
    {
        public static string CreateMessage(string info)
        {
            // Below is a standard implementation.
            // If you were to make it more testable by making an ITimeProvider interface, you'd then have to use this interface everywhere DateTime is used.
            // return DateTime.Now.ToShortDateString() + " " + info;

            // Below uses a custom class everywhere in production code where DateTime would normally be used.
            return SystemTime.Now.ToShortDateString() + " " + info;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    public class FakeWebService : IWebService
    {
        public string LastError;
        public Exception ToThrow;

        public void LogError(string message)
        {
            if (ToThrow != null) { throw ToThrow; }
        }
    }
}

using System;

namespace LogAn.UnitTests
{
    public class FakeLogger : ILogger
    {
        public string LastError;
        public Exception ToThrow;

        public void LogError(string message)
        {
            if (ToThrow != null) { throw ToThrow; }
            LastError = message;
        }
    }
}

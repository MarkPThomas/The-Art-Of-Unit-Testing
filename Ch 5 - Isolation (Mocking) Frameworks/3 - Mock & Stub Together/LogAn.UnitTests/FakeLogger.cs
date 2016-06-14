using System;

namespace LogAn.UnitTests
{
    /// <summary>
    /// Fake logger that is used as a stub.
    /// </summary>
    public class FakeLogger : ILogger
    {
        public string LoggerGotMessage = null;
        public Exception WillThrow = null;

        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if (WillThrow != null) { throw WillThrow; }
        }
    }
}

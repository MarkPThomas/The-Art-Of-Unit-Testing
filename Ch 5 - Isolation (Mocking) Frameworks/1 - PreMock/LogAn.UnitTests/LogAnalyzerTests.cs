using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            FakeLogger logger = new FakeLogger();

            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;
           
            string tooShortFileName = "a.ext";
            analyzer.Analyze(tooShortFileName);

            StringAssert.Contains("too short", logger.LastError);
        }
    }
}

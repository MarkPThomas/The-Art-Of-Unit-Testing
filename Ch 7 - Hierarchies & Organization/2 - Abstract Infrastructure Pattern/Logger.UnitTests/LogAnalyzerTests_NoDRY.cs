using System;
using NUnit.Framework;

namespace Logger.UnitTests
{
    /// <summary>
    /// An example not following the DRY principle in test classes.
    /// </summary>
    [TestFixture]
    public class LogAnalyzerTests_NoDRY
    {
        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            LogAnalyzer la = new LogAnalyzer();
            la.Analyze("myemptyfile.txt");
            // rest of test
        }

        [TearDown]
        public void teardown()
        {
            // need to reset a static resource between tests
            LoggingFacility.Logger = null;
        }
    }
}

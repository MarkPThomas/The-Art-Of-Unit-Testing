using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logger.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests : BaseTestsClass
    {
        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            // Call base class helper method.
            FakeTheLogger();

            LogAnalyzer la = new LogAnalyzer();
            la.Analyze("myemptyfile.txt");
            // rest of test
        }
    }
}

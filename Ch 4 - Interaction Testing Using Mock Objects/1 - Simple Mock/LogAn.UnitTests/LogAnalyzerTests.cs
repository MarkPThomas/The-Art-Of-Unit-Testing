using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    //======================
    // Notes:
    //======================
    // Name tests according to the following pattern:
    //  [UnitOfWork]_[Scenario]_[ExpectedBehavior]
    //
    // Common Scenarios:
    //  ByDefault - When there is an expected value with no prior action.
    //  WhenCalled (or Always) - Used in changed state or calling a third party, with no prior configurations.
    //
    // In general avoid Setup & TearDown if you can avoid them
    //
    // Use factory methods to reuse code in tests, such as creating and initializing objects that all tests use.

    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer logAn = new LogAnalyzer(mockService);
            string tooShortFileName = "abc.ext";

            logAn.Analyze(tooShortFileName);

            StringAssert.Contains("Filename too short: " + tooShortFileName, mockService.LastError);
        }

        [Test]
        public void Analyze_LongEnoughFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer logAn = new LogAnalyzer(mockService);
            string tooShortFileName = "abcdefgh.ext";

            logAn.Analyze(tooShortFileName);

            Assert.IsNull(mockService.LastError);
        }
    }
}

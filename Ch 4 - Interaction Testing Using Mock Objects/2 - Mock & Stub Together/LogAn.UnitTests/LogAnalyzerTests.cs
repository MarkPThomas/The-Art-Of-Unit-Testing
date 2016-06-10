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
    
    // For mocks, there should only be one mock per test.
    // Mocks are the fake objects that can fail a test. They are the fake that is asserted.
    // Stubs are fake objects that affect test context. No assertions are run against a stub although a stub can throw an exception.

    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");

            FakeEmailService mockEmail = new FakeEmailService();

            LogAnalyzer logAn = new LogAnalyzer(stubService, mockEmail);

            string tooShortFileName = "abc.ext";
            logAn.Analyze(tooShortFileName);

            StringAssert.Contains("someone@somewhere.com", mockEmail.To);
            StringAssert.Contains("fake exception", mockEmail.Body);
            StringAssert.Contains("can't log", mockEmail.Subject);

            // Note: As soon as an assert fails, the test stops. If you want the other asserts to run, the To, Body, and Subject should be placed within a parameter object
            // 'expectedEmail' of EmailInfo, which corresponds to a property in the mock, and the following assert is used:
            // Assert.AreEqual(expectedEmail, mockEmail.Email)
        }

        [Test]
        public void Analyze_LongEnoughFileName_ReturnsNothing()
        {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");

            FakeEmailService mockEmail = new FakeEmailService();

            LogAnalyzer logAn = new LogAnalyzer(stubService, mockEmail);

            string tooShortFileName = "abcdefgh.ext";
            logAn.Analyze(tooShortFileName);

            Assert.IsNull(mockEmail.To);
            Assert.IsNull(mockEmail.Body);
            Assert.IsNull(mockEmail.Subject);
        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService stubService = new FakeWebService();

            FakeEmailService mockEmail = new FakeEmailService();

            LogAnalyzer logAn = new LogAnalyzer(stubService, mockEmail);

            string tooShortFileName = "abc.ext";
            logAn.Analyze(tooShortFileName);

            Assert.IsNull(mockEmail.To);
            Assert.IsNull(mockEmail.Body);
            Assert.IsNull(mockEmail.Subject);
        }
    }
}

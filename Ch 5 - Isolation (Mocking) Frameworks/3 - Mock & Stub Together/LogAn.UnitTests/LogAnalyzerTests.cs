using System;
using NUnit.Framework;
using NSubstitute;

namespace LogAn.UnitTests
{

    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            // FakeWebService mockWebService = new FakeWebService();
            var mockWebService = Substitute.For<IWebService>();

            //FakeLogger stubLogger = new FakeLogger();
            //stubLogger.WillThrow = new Exception("fake exception");
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When( logger => logger.LogError(Arg.Any<string>()))
                      .Do(info => { throw new Exception("fake exception"); });

            var analyzer = new LogAnalyzer(stubLogger, mockWebService);
            analyzer.MinNameLength =10;
            string tooShortFileName = "abc.ext";
            analyzer.Analyze(tooShortFileName);

            //Assert.That(mockWebService.MessageToWebService, Does.Contain("fake exception"));
            mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject()
        {
            var mockWebService = Substitute.For<IWebService>();
            
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                      .Do(info => { throw new Exception("fake exception"); });

            var analyzer = new LogAnalyzer(stubLogger, mockWebService);
            analyzer.MinNameLength = 10;
            analyzer.UseInfoObject = true;
            string tooShortFileName = "abc.ext";
            analyzer.Analyze(tooShortFileName);

            // Compare contents of an object
            // Default: Readability may suffer ...
            //mockWebService.Received().Write(Arg.Is<ErrorInfo>(info => info.Severity == 1000
            //                                                  && info.Message.Contains("fake exception")));

            // Simpler:
            // Create object that you expect to receive
            var expected = new ErrorInfo(1000, "fake exception");

            // Assert that you got exactly the same object (essentially assert.equals())
            mockWebService.Received().Write(expected);

            // Note that since you can't use argument matchers to see if a string contains some value, tests are a little less robust for future changes.
            // For example, any change to the string, including white space, will fail the test unless the test is updated.
        }
    }
}

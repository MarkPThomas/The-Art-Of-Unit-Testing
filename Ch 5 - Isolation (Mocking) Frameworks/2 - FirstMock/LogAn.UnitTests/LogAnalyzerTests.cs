using System;
using NUnit.Framework;
using NSubstitute;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();

            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;
           
            string tooShortFileName = "a.ext";
            analyzer.Analyze(tooShortFileName);

            // 'Recieved() checks that the following method was called, with the provided input.
            logger.Received().LogError("Filename too short: " + tooShortFileName);
        }

        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            //string fileName = "strict.txt";

            // Forces method call to return a fake value
            //fakeRules.IsValidLogFileName(fileName).Returns(true);
            // Assert.IsTrue(fakeRules.IsValidLogFileName(fileName));

            // Ignores the argument variable by using an 'argument matcher'
            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);
            Assert.IsTrue(fakeRules.IsValidLogFileName("anything"));
        }

        [Test]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
                     .Do(context => { throw new Exception("fake exception"); });

            Assert.Throws<Exception>(() => fakeRules.IsValidLogFileName("anything"));
        }
    }
}

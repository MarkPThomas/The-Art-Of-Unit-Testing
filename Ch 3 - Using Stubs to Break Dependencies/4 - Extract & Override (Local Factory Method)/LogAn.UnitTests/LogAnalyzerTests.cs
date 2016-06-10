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
        private LogAnalyzer _analyzer;

        //======================
        // Set Up & Tear Down for All Tests
        //======================
        // Methods below can be used to set up and tear down states once, before and after all tests have run.
        // In general these are not used for unit tests, unless resetting a static variable or Singleton.
        // These are usually used for integration tests.
        [OneTimeSetUp]
        public void FixtureSetup()
        {

        }

        [OneTimeTearDown]
        public void FixtureTearDown()
        {

        }

        //======================
        // Set Up & Tear Down for Each Test
        //======================
        // The methods below can be used to avoid needing to set up tests in each method, e.g. initializing the LogAnalyzer class.
        // You can only have one set of these in each class.
        // These are called before and after every test.
        // Use these carefully as while they reduce code, they require test readers to look in more than one place.
        // Do not use this to initialize class instances in real life. Instead, use Factory methods to keep tests more readable.
        [SetUp]
        public void SetUp()
        {
            _analyzer = MakeAnalyzer();
        }

        [TearDown]
        public void TearDown()
        {
            // The line below is included to demonstrate the method, but is not really necessary.
            // It shows an antipattern and isn't really needed. Do no do this in real life!
            //_analyzer = null;
        }

        //======================
        // Old Tests Before Parametric Test Created
        //======================

        //[Test]
        //public void IsValidLogFileName_BadExtension_ReturnsFalse()
        //{
        //    LogAnalyzer analyzer = new LogAnalyzer();

        //    bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

        //    Assert.IsFalse(result);
        //}

        //[Test]
        //public void IsValidLogFileName_GoodExtensionLowerCase_ReturnsTrue()
        //{
        //    LogAnalyzer analyzer = new LogAnalyzer();

        //    bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");

        //    Assert.IsTrue(result);
        //}

        //[Test]
        //public void IsValidLogFileName_GoodExtensionUpperCase_ReturnsTrue()
        //{
        //    LogAnalyzer analyzer = new LogAnalyzer();

        //    bool result = analyzer.IsValidLogFileName("filewithgoodextension.SLF");

        //    Assert.IsTrue(result);
        //}

        //======================
        // Very Complete Parametric Test, but less readable, e.g. note the Method Name. Useful in mild doses
        //======================
        //[TestCase("filewithgoodextension.slf", true)]
        //[TestCase("filewithgoodextension.SLF", true)]
        //[TestCase("filewithbadextension.foo", false)]
        //public void IsValidLogFileName_VariousExtensions_ReturnsTrue(string fileName, bool expected)
        //{
        //    LogAnalyzer analyzer = new LogAnalyzer();

        //    bool result = analyzer.IsValidLogFileName(fileName);

        //    Assert.AreEqual(expected, result);
        //}

        //======================
        // Recommended Refactored Parametric set of tests
        //======================
        // These reduce the number of places in the test that need to be refactored if a method changes to take in a different # of parameters.
        // Makes for more compact tests as well.
        [TestCase("filewithgoodextension.slf")]
        [TestCase("filewithgoodextension.SLF")]
        // Note the category. These can be used to run tests by category.
        [Category("Fast Tests")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string fileName)
        {
            _analyzer = MakeAnalyzer(managerWillBevalid: true);
            bool result = _analyzer.IsValidLogFileName(fileName);

            Assert.IsTrue(result);
        }

        [TestCase("filewithbadextension.foo")]
        [TestCase("filewithbadextension.FOO")]
        public void IsValidLogFileName_InValidExtensions_ReturnsFalse(string fileName)
        {
            _analyzer = MakeAnalyzer(managerWillBevalid: false);
            bool result = _analyzer.IsValidLogFileName(fileName);

            Assert.IsFalse(result);
        }

        //======================
        // Try-Catch Test
        //======================
        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            string exMessage = "this is fake";
            // Throwing exception with fake
            
            LogAnalyzer la = MakeAnalyzer(managerThrows: new Exception(exMessage));
            
            var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(""));

            // Below is a better way to check the string value than a direct compare, since strings often change.

            // Original
            // StringAssert.Contains("filename has to be provided", ex.Message);   

            // Throwing exception with fake
            StringAssert.Contains(exMessage, ex.Message);
        }

        //======================
        // (Temporarily) Ignoring a Test
        //======================
        [Test]
        [Ignore ("There is a problem with this test")]
        public void IsValidLogFileName_ValidFile_ReturnsTrue()
        {
            // Nothing to see here!
        }

        //======================
        // State Tests
        //======================
        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string filename, bool expected)
        {
            LogAnalyzer la = MakeAnalyzer(managerWillBevalid: expected);

            la.IsValidLogFileName(filename);

            Assert.AreEqual(expected, la.WasLastFileNameValid);
        }

        private LogAnalyzer MakeAnalyzer(bool managerWillBevalid = true,
                                         Exception managerThrows = null)
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = managerWillBevalid;
            myFakeManager.WillThrow = managerThrows;
            
            return new TestableLogAnalyzer(myFakeManager);
        }
    }
}

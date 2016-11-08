using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace Logger.UnitTests
{
    [TestFixture]
    public class BaseTestsClass
    {
        /// <summary>
        /// Refactors into a common readable utility method to be used by derived classes.
        /// Use as few as possible base classes, typically no more than one.
        /// Never have more than one level of inheritance to avoid readability issues.
        /// </summary>
        /// <returns></returns>
        public ILogger FakeTheLogger()
        {
            LoggingFacility.Logger = Substitute.For<ILogger>();
            return LoggingFacility.Logger;
        }

        /// <summary>
        /// Automatic cleanup for derived classes.
        /// </summary>
        [TearDown]
        public void teardown()
        {
            // need to reset a static resource between tests
            LoggingFacility.Logger = null;
        }
    }
}

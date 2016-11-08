using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logger.UnitTests
{
    /// <summary>
    /// An example not following the DRY principle in test classes.
    /// </summary>
    [TestFixture]
    public class ConfigurationManagerTests_NoDRY
    {
        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            ConfigurationManager cm = new ConfigurationManager();
           // bool configured = cm.IsConfigured("something");
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

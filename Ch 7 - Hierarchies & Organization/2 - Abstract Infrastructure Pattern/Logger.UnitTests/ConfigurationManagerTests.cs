using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logger.UnitTests
{
    [TestFixture]
    public class ConfigurationManagerTests : BaseTestsClass
    {
        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            // Call base class helper method.
            FakeTheLogger();

            ConfigurationManager cm = new ConfigurationManager();
            bool configured = cm.IsConfigured("something");
            // rest of test
        }
    }
}

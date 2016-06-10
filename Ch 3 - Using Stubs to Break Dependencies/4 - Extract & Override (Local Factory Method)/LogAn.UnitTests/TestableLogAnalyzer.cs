using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    /// <summary>
    /// Great method to use for simulating inputs of the code under test.
    /// Not very good for checking interaction between objects.
    /// One downside to using classes rather than interfaces is that the base class from production code may
    ///     already have built in dependencies that you will have to know about and override.
    /// </summary>
    internal class TestableLogAnalyzer : LogAnalyzer
    {
        public IExtensionManager Manager;

        public TestableLogAnalyzer(IExtensionManager manager)
        {
            Manager = manager;
        }

        protected override IExtensionManager GetManager()
        {
            return Manager;
        }
    }
}

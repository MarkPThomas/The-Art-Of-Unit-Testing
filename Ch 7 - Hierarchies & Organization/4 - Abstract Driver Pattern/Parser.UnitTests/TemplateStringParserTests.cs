using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Parser.UnitTests
{
    /// <summary>
    /// The test template class.
    /// A template test pattern ensures that developers don't forget important tests.
    /// The base class contains abstract tests that derived classes must implement.
    /// </summary>
    [TestFixture]
    public abstract class TemplateStringParserTests
    {
        public abstract void TestGetStringVersionFromHeader_SingleDigit_Found();

        public abstract void TestGetStringVersionFromHeader_WithMinorVersion_Found();

        public abstract void TestGetStringVersionFromHeader_WithRevision_Found();
    }
}

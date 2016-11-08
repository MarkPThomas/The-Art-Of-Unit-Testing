using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Parser.UnitTests
{
    /// <summary>
    /// The derived class.
    /// </summary>
    public class XmlStringParserTests : TemplateStringParserTests
    {
        protected IStringParser GetParser(string input)
        {
            return new XMLStringParser(input);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_SingleDigit_Found()
        {
            IStringParser parser = GetParser("<Header>1</header");

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1", versionFromHeader);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithMinorVersion_Found()
        {
            IStringParser parser = GetParser("<Header>1.1</header");

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1.1", versionFromHeader);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithRevision_Found()
        {
            IStringParser parser = GetParser("<Header>1.1.1</header");

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1.1.1", versionFromHeader);
        }
    }
}

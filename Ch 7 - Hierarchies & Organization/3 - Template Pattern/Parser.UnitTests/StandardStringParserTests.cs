using System;
using NUnit.Framework;

namespace Parser.UnitTests
{
    /// <summary>
    /// Outline of a test class for StandaloneStringParser.
    /// Note that a nearly identical class needs to be written for IISLogStringParser and XMLStringParser, with only the GetParser factory method changed.
    /// </summary>
    [TestFixture]
    public class StandardStringParserTests
    {
        /// <summary>
        /// Defines the parser factory method.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private StandardStringParser GetParser(string input)
        {
            return new StandardStringParser(input);
        }

        [Test]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = "header;version=1\n";
            StandardStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1", versionFromHeader);
        }

        [Test]
        public void GetStringVersionFromHeader_WithMinorVersion_Found()
        {
            string input = "header;version=1.1\n";
            StandardStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1.1", versionFromHeader);
        }

        [Test]
        public void GetStringversionFromHeader_WithRevision_Found()
        {
            string input = "header;version=1.1.1\n";
            StandardStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1.1.1", versionFromHeader);
        }
    }
}

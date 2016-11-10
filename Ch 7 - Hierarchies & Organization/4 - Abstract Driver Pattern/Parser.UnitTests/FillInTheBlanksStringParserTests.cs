using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Parser.UnitTests
{
    [TestFixture]
    public abstract class FillInTheBlanksStringParserTests
    {
        //=== Abstract factory method that requires a returned interface ===
        
        //Abstract input methods to provide data in a specific format for derived classes
        protected abstract IStringParser GetParser(string input);
        protected abstract string HeaderVersion_SingleDigit { get; }
        protected abstract string HeaderVersion_WithMinorVersion { get; }
        protected abstract string HeaderVersion_WithRevision { get; }

        //Predefined expected output for derived classes if needed
        public const string EXPECTED_SINGLE_DIGIT = "1";
        public const string EXPECTED_WITH_REVISION = "1.1.1";
        public const string EXPECTED_WITH_MINORVERSION = "1.1";

        [Test]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = HeaderVersion_SingleDigit;
            IStringParser parser = GetParser(input);

            // Predefined test logic using derived inputs
            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual(EXPECTED_SINGLE_DIGIT, versionFromHeader);
        }

        [Test]
        public void GetStringVersionFromHeader_WithMinorVersion_Found()
        {
            string input = HeaderVersion_WithMinorVersion;
            IStringParser parser = GetParser(input);

            // Predefined test logic using derived inputs
            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual(EXPECTED_WITH_MINORVERSION, versionFromHeader);
        }

        [Test]
        public void GetStringVersionFromHeader_WithRevision_Found()
        {
            string input = HeaderVersion_WithRevision;
            IStringParser parser = GetParser(input);

            // Predefined test logic using derived inputs
            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual(EXPECTED_WITH_REVISION, versionFromHeader);
        }
    }
}

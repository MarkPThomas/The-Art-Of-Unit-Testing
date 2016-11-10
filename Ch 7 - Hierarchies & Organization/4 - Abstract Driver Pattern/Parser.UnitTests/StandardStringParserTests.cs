using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Parser.UnitTests
{
    /// <summary>
    /// Derived class that fills in the blanks.
    /// </summary>
    [TestFixture]
    public class StandardStringParserTests : FillInTheBlanksStringParserTests
    {
        
        // Filling in the right format for this requirement.

        protected override string HeaderVersion_SingleDigit
        {
            get
            {
                return string.Format("header\tversion={0}\t\n",
                    EXPECTED_SINGLE_DIGIT);
            }
        }

        protected override string HeaderVersion_WithMinorVersion
        {
            get
            {
                return string.Format("header\tversion={0}\t\n",
                     EXPECTED_WITH_MINORVERSION);
            }
        }

        protected override string HeaderVersion_WithRevision
        {
            get
            {
                return string.Format("header\tversion={0}\t\n",
                    EXPECTED_WITH_REVISION);
            }
        }

        // Filling in the right type of class under test
        protected override IStringParser GetParser(string input)
        {
            return new StandardStringParser(input);
        }
    }
}

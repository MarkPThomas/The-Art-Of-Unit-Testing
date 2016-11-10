using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Parser.UnitTests
{
    /// <summary>
    /// Inherits from generic base class.
    /// </summary>
    [TestFixture]
    public class StandardParserGenericTests : GenericParserTests<StandardStringParser>
    {
        protected override string GetInputHeaderSingleDigit()
        {
            // Returns custom input for the current type under test.
            return "Header;1";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class StandardStringParser : BaseStringParser
    {
        public StandardStringParser(string input) : base(input)
        {
        }

        public override string GetTextVersionFromHeader()
        {
            return StringToParse;
        }

        public override bool HasCorrectHeader()
        {
            throw new NotImplementedException();
        }
    }
}

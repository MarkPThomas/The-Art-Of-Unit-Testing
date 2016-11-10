using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class XMLStringParser : BaseStringParser
    {
        public XMLStringParser(string input) : base(input)
        {
        }

        public override string GetTextVersionFromHeader()
        {
            throw new NotImplementedException();
        }

        public override bool HasCorrectHeader()
        {
            throw new NotImplementedException();
        }
    }
}

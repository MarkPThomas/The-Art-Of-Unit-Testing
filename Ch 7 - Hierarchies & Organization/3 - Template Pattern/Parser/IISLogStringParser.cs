using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class IISLogStringParser : BaseStringParser
    {
        public IISLogStringParser(string input) : base(input)
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

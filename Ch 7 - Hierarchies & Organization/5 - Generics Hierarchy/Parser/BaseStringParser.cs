using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public abstract class BaseStringParser : IStringParser
    {
        public string StringToParse { get; set; }

        public BaseStringParser(string input)
        {
            StringToParse = input;
        }

        public abstract string GetTextVersionFromHeader();

        public abstract bool HasCorrectHeader();

    }
}

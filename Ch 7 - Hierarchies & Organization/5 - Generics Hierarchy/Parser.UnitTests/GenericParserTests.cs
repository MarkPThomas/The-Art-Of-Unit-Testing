using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Parser.UnitTests
{
    /// <summary>
    /// An example of an Abstract Test Driver Class Pattern using Generics
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [TestFixture]
    public abstract class GenericParserTests<T>
        where T:IStringParser       // Defines generic constraint on parameter.
    {
        protected abstract string GetInputHeaderSingleDigit();

        // Gets generic type variable instead of an interface.
        protected T GetParser(string input)
        {
            // Returns generic type.
            return (T)Activator.CreateInstance(typeof(T), input);
        }

        [Test]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = GetInputHeaderSingleDigit();
            T parser = GetParser(input);

            bool result = parser.HasCorrectHeader();
            Assert.IsFalse(result);
        }
    }
}

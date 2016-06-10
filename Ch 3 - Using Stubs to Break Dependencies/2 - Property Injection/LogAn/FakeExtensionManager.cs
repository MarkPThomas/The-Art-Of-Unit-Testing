using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    /// <summary>
    /// This form of a 'fake' allows configuration to make it more versatile and reduce the number of different classes needed for different test cases.
    /// It also throws exceptions.
    /// </summary>
    public class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public Exception WillThrow = null;

        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
            return WillBeValid;
        }
    }
}

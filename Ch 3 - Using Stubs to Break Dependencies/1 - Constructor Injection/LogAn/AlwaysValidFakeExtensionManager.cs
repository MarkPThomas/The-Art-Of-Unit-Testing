using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    /// <summary>
    /// A 'fake' denotes an object that looks like another object but can be used as a 'mock' or a 'stub'.
    /// 'Fake' is used to delay deciding whether to name the class as a 'mock' or a 'stub', since these imply specific behaviors.
    /// It also allows the class to be used as BOTH a 'mock' AND a 'stub'.
    /// </summary>
    public class AlwaysValidFakeExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            return true;
        }
    }
}

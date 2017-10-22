using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetApi.Utility
{
    internal class NugetFile : INugetFile
    {
        public string Name => throw new NotImplementedException();

        public string Extension => throw new NotImplementedException();

        public string FullName => throw new NotImplementedException();

        public void Copy(string newLoc, bool overwrite)
        {
            throw new NotImplementedException();
        }
    }
}

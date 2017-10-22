using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetApi.Utility
{
    public interface INugetFile
    {
        void Copy(string newLoc, bool overwrite);

        string Name { get; }

        string Extension { get; }

        string FullName { get; }
    }
}

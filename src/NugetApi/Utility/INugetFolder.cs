using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetApi.Utility
{
    public interface INugetFolder
    {
        IEnumerable<INugetFile> Files { get; }

        IEnumerable<INugetFolder> SubFolders { get; }

        string Name { get; }

        void Copy(string loc);


    }
}

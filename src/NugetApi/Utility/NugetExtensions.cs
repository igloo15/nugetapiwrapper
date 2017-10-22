using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetApi.Utility
{
    public static class NugetExtensions
    {

        public static List<INugetFolder> GetNugetFiles(this PackageReaderBase packReader)
        {
            return new List<INugetFolder>();
        }

    }
}

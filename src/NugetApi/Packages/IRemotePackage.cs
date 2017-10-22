using NuGet.Versioning;
using NugetApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetApi.Packages
{
    public interface IRemotePackage : IPackage
    {
        int GetDownloadCount();

        IPackageDownloadStream Download(string folder, NuGetVersion version);

        NuGetVersion GetLatestVersion();

        NuGetVersion GetAbsoluteLatestVersion();

        NuGetVersion[] GetVersions();
    }
}

using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace NugetApi.Packages
{
    public interface IPackage
    {
        string[] GetTags();

        string GetId();

        string GetName();

        string GetDescription();

        string GetSummary();

        NuGetVersion[] GetVersions();

        DateTime GetDate();

        int GetDownloadCount();

        string GetIconUrl();

        void Download(string folder, NuGetVersion version);

        void Install(string folder, NuGetVersion version);

        NuGetVersion GetLatestVersion();

        NuGetVersion GetAbsoluteLatestVersion();
    }
}

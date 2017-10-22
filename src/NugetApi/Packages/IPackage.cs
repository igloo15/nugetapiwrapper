using NuGet.Versioning;
using NugetApi.Utility;
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
        
        DateTime GetDate();

        

        string GetIconUrl();

    }
}

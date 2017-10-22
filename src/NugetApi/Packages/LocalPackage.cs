using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Packaging;
using NugetApi.Utility;

namespace NugetApi.Packages
{
    class LocalPackage : ILocalPackage
    {
        private PackageReaderBase packageReader;

        private List<INugetFolder> folders;

        public LocalPackage(PackageReaderBase packageReader)
        {
            this.packageReader = packageReader;
            var files = packageReader.GetBuildItems();
            //var files = packageReader.GetPackageFiles(PackageSaveMode.Files);

            folders = packageReader.GetNugetFiles();
        }

        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        public string GetDescription()
        {
            return packageReader.NuspecReader.GetDescription();
        }
        
        public string GetIconUrl()
        {
            return packageReader.NuspecReader.GetIconUrl();
        }

        public string GetId()
        {
            return packageReader.NuspecReader.GetId();
        }

        public string GetName()
        {
            return packageReader.NuspecReader.GetTitle();
        }

        public string GetSummary()
        {
            return packageReader.NuspecReader.GetSummary();
        }

        public string[] GetTags()
        {
            return packageReader.NuspecReader.GetTags().Split(' ');
        }
    }
}

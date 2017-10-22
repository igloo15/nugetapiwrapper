using NuGet.Common;
using NuGet.Configuration;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using NugetApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NugetApi.Packages
{
    internal class V2Package : IRemotePackage
    {
        private IPackageSearchMetadata metaData;
        private SourceRepository source;

        public V2Package(IPackageSearchMetadata data, SourceRepository source)
        {
            metaData = data;
            this.source = source;
        }

        public IPackageDownloadStream Download(string folder, NuGetVersion version)
        {
            ///if(!source.PackageSource.IsHttp)                

            var resource = source.GetResource<DownloadResource>();

            var newWrapper = new DownloadResourceWrapper(resource, new PackageIdentity(metaData.Identity.Id, version), folder);

            return newWrapper;
            
        }
        
        public NuGetVersion GetLatestVersion()
        {
            return metaData.GetVersionsAsync().Result.OrderByDescending(vi => vi.Version).Where(vi => !vi.Version.IsPrerelease).Select(vi => vi.Version).FirstOrDefault();
        }

        public NuGetVersion GetAbsoluteLatestVersion()
        {
            return metaData.GetVersionsAsync().Result.OrderByDescending(vi => vi.Version).Select(vi => vi.Version).FirstOrDefault();
        }

        public DateTime GetDate()
        {
            return metaData.Published.Value.DateTime;
        }

        public string GetDescription()
        {
            return metaData.Description;
        }

        public int GetDownloadCount()
        {
            return Convert.ToInt32(metaData.DownloadCount.Value);
        }
        
        public string GetIconUrl()
        {
            return metaData.IconUrl.ToString();
        }

        public string GetId()
        {
            return metaData.Identity.Id;
        }

        public string GetName()
        {
            return metaData.Title;
        }

        public string GetSummary()
        {
            return metaData.Summary;
        }

        public string[] GetTags()
        {
            return metaData.Tags.Split(' ');
        }

        public NuGetVersion[] GetVersions()
        {
            return metaData.GetVersionsAsync().Result.Select(vi => vi.Version).ToArray();
        }

        

       
    }
}

using NuGet.Protocol.Core.Types;
using NugetApi.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Packaging.Core;
using NuGet.Common;
using System.Threading;

namespace NugetApi.Utility
{

    public interface IPackageDownloadStream
    {
        event EventHandler<PackageProgressEventArgs> Progress;
        ILocalPackage GetPackage();
        Task<ILocalPackage> GetPackageAsync();

    }

    internal class DownloadResourceWrapper : IPackageDownloadStream
    {
        private DownloadResource resource;
        private PackageIdentity packageIdentity;
        private string folder;

        internal DownloadResourceWrapper(DownloadResource resource, PackageIdentity packageIdentity, string folder)
        {
            this.packageIdentity = packageIdentity;
            this.folder = folder;
            this.resource = resource;
        }
                
        public event EventHandler<PackageProgressEventArgs> Progress
        {
            add
            {
                resource.Progress += value;
            }

            remove
            {
                resource.Progress -= value;
            }
        }

        public ILocalPackage GetPackage()
        {
            return GetPackageAsync().Result;
        }

        public async Task<ILocalPackage> GetPackageAsync()
        {
            var result = await resource.GetDownloadResourceResultAsync(
                packageIdentity, 
                new PackageDownloadContext(new SourceCacheContext()), 
                folder, 
                NullLogger.Instance, 
                CancellationToken.None);

            if(result.Status != DownloadResourceResultStatus.Available)
            {
                throw new Exception("Failed to download");
            }

            return new LocalPackage(result.PackageReader);
        }
    }
}

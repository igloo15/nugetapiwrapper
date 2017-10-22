using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NugetApi.Packages;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol;
using NuGet.Common;
using System.Threading;

namespace NugetApi.Feeds
{
    internal class MainFeed : IFeed
    {

        private SourceRepository repo;

        public MainFeed(string location)
        {
            repo = Repository.Factory.GetCoreV3(location);
        }

        public bool IsLocal => repo.PackageSource.IsLocal;

        public Task<IEnumerable<IRemotePackage>> Search(string searchTerm)
        {
            return repo.GetResource<PackageSearchResource>().SearchAsync(searchTerm, new SearchFilter(true), 0, 100, NullLogger.Instance, CancellationToken.None)
                .ContinueWith<IEnumerable<IRemotePackage>>(tr => 
                {
                    return tr.Result.Select(meta => new V2Package(meta, repo));
                });
        }

        public Task<IEnumerable<IRemotePackage>> SearchById(string packageId)
        {
            if (repo.PackageSource.IsHttp)
                packageId = "id:" + packageId;
            return Search(packageId);
        }

        public Task<IEnumerable<IRemotePackage>> SearchByTag(string tag)
        {
            if (repo.PackageSource.IsHttp)
                tag = "tags:" + tag;
            return Search(tag);
        }
    }
}

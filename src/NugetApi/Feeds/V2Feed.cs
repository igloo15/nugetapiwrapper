using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using NugetApi.Packages;
using NugetApi.Utility;
using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

using System.Xml.Linq;
using System.Linq;
using System.Threading;

namespace NugetApi.Feeds
{
    public class V2Feed
    {
        IV2Api api;
        //V2FeedParser test = new V2FeedParser(HttpSource.Create(Repository.Factory.GetCoreV3("")), "");

        public V2Feed(string apiUrl)
        {
            api = RestService.For<IV2Api>(apiUrl);
            //var download = test.DownloadFromIdentity(new NuGet.Packaging.Core.PackageIdentity("", new NuGet.Versioning.NuGetVersion("")), new PackageDownloadContext(new SourceCacheContext()), "", null, CancellationToken.None).Result;
            

            //var test2 = test.GetSearchPageAsync("test", new SearchFilter(true, SearchFilterType.IsLatestVersion), 0, 100, null, CancellationToken.None).Result;
            var source = Repository.Factory.GetCoreV3(apiUrl);
            var localSource = Repository.Factory.GetCoreV3(@"C:\Users\mike\.nuget\packages");
            //PackageSearchResourceV2Feed testFeed = new PackageSearchResourceV2Feed(source.GetResource<HttpSourceResource>(), apiUrl, source.PackageSource);
            
            var testResource = source.GetResource<PackageSearchResource>();
            var localResource = localSource.GetResource<PackageSearchResource>();
            var listResource = localSource.GetResource<ListResource>();
            var downloadResource = source.GetResource<DownloadResource>();
            var findResource = localSource.GetResource<FindLocalPackagesResource>();
            

            var test2 = localResource.SearchAsync("id:Castle.Core", new SearchFilter(true, SearchFilterType.IsLatestVersion), 0, 100, NullLogger.Instance, CancellationToken.None).Result;
            //var downloadResult = downloadResource.GetDownloadResourceResultAsync(null, new PackageDownloadContext(new SourceCacheContext()), "", NullLogger.Instance, CancellationToken.None).Result;

            
            foreach (var pack in test2)
            {
                
                var versions = String.Join(",", pack.GetVersionsAsync().Result.Select(vi => vi.Version.ToNormalizedString()));
                Console.WriteLine($"{pack.Identity.Id} : {versions}");
            }
        }

        
    }
}

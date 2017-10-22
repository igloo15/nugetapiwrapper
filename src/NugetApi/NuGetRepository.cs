using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NugetApi.Feeds;
using NugetApi.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetApi
{
    public class NuGetRepository
    {

        private AggregateFeed aggregateFeed;
        private MainFeed cacheFeed;
        private MainFeed installFeed;

        public NuGetRepository(string cacheLocation, params string[] sources)
        {
            aggregateFeed = new AggregateFeed(sources.Select(s => new MainFeed(s)).ToArray());

            cacheFeed = new MainFeed(cacheLocation);
            
            if (!cacheFeed.IsLocal)
                throw new ArgumentException("Cache Location is not local to machine", "cacheLocation");

            aggregateFeed.AddFeed(cacheFeed);

        }

        public async Task<IEnumerable<IRemotePackage>> Search(string searchTerm)
        {
            return await aggregateFeed.Search(searchTerm);
        }

        public async Task<IEnumerable<IRemotePackage>> SearchById(string id)
        {
            return await aggregateFeed.SearchById(id);
        }

        public async Task<IEnumerable<IRemotePackage>> SearchByTags(string tags)
        {
            return await aggregateFeed.SearchByTag(tags);
        }

        public IEnumerable<IFeed> GetFeeds()
        {
            return aggregateFeed.Feeds;
        }
        
        public static IFeed CreateFeed(string source)
        {
            return new MainFeed(source);
        }

        public static IFeed CreateAggregateFeed(params string[] sources)
        {
            return new AggregateFeed(sources.Select(s => new MainFeed(s)).ToArray());
        }
    }
}

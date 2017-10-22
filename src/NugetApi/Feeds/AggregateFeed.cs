using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NugetApi.Packages;
using System.Linq;

namespace NugetApi.Feeds
{
    public class AggregateFeed : IFeed
    {
        private List<IFeed> feeds;

        public AggregateFeed(params IFeed[] feeds)
        {
            this.feeds = new List<IFeed>();

            this.feeds.AddRange(feeds);
        }


        public bool IsLocal => !feeds.Any(f => !f.IsLocal);

        internal List<IFeed> Feeds => feeds;

        public AggregateFeed AddFeed(IFeed feed)
        {
            feeds.Add(feed);
            return this;
        }
        
        public async Task<IEnumerable<IRemotePackage>> Search(string searchTerm)
        {
            foreach (var feed in feeds)
            {
                var results = await feed.Search(searchTerm);

                if (results.Any())
                    return results;
            }

            return new List<IRemotePackage>();
        }

        public async Task<IEnumerable<IRemotePackage>> SearchById(string packageId)
        {

            foreach (var feed in feeds)
            {
                var results = await feed.SearchById(packageId);

                if (results.Any())
                    return results;
            }

            return new List<IRemotePackage>();
        }

        public async Task<IEnumerable<IRemotePackage>> SearchByTag(string tag)
        {
            foreach (var feed in feeds)
            {
                var results = await feed.SearchByTag(tag);

                if (results.Any())
                    return results;
            }

            return new List<IRemotePackage>();
        }
    }
}

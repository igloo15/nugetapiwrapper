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

        private List<MainFeed> sources = new List<MainFeed>();
        private MainFeed cacheFeed;
        private MainFeed installFeed;

        public NuGetRepository(string cacheLocation, string installLocation, params string[] sources)
        {
            this.sources.AddRange(sources.Select(s => new MainFeed(s)));

            cacheFeed = new MainFeed(cacheLocation);
            installFeed = new MainFeed(installLocation);

            if (!installFeed.IsLocal)
                throw new ArgumentException("Install Location is not local to machine", "installLocation");

            if (!cacheFeed.IsLocal)
                throw new ArgumentException("Cache Location is not local to machine", "cacheLocation");

            this.sources.Add(installFeed);
            this.sources.Add(cacheFeed);

        }

        public async Task<IEnumerable<IPackage>> Search(string searchTerm)
        {
            foreach(var feed in sources)
            {
                var results =  await feed.Search(searchTerm);

                if (results.Any())
                    return results;
            }

            return new List<IPackage>();
        }

        public async Task<IEnumerable<IPackage>> SearchById(string id)
        {
            foreach (var feed in sources)
            {
                var results = await feed.SearchById(id);

                if (results.Any())
                    return results;
            }

            return new List<IPackage>();
        }

        public async Task<IEnumerable<IPackage>> SearchByTags(string tags)
        {
            foreach (var feed in sources)
            {
                var results = await feed.SearchByTag(tags);

                if (results.Any())
                    return results;
            }

            return new List<IPackage>();
        }

        public IEnumerable<IFeed> GetFeeds()
        {
            return sources;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NugetApi.Packages;

namespace NugetApi.Feeds
{
    public class AggregateFeed : IFeed
    {
        public AggregateFeed(params IFeed[] feeds)
        {

        }

        public bool IsLocal => throw new NotImplementedException();

        public AggregateFeed AddFeed(IFeed feed)
        {
            return this;
        }
        
        public Task<IEnumerable<IPackage>> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPackage>> SearchById(string packageId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPackage>> SearchByTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}

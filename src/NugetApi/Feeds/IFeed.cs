using NugetApi.Packages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NugetApi.Feeds
{
    public interface IFeed
    {
        bool IsLocal { get; }

        Task<IEnumerable<IRemotePackage>> Search(string searchTerm);

        Task<IEnumerable<IRemotePackage>> SearchById(string packageId);

        Task<IEnumerable<IRemotePackage>> SearchByTag(string tag);
    }
}

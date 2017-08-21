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

        Task<IEnumerable<IPackage>> Search(string searchTerm);

        Task<IEnumerable<IPackage>> SearchById(string packageId);

        Task<IEnumerable<IPackage>> SearchByTag(string tag);
    }
}

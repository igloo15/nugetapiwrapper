using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using System.Net.Http;

namespace NugetApi.Feeds
{
    public interface IV2Api
    {
        [Get("/Search()?'{searchTerm}'")]
        Task<string> Search(string searchTerm);

        [Get("/FindPackagesById()?Id='{packageId}'")]
        Task<string> SearchById(string packageId);

        [Get("/Packages()?$filter=substringof('{tag}', Tags)")]
        Task<string> SearchByTag(string tag);

        [Get("/package/{id}/{version}")]
        Task<HttpResponseMessage> Download(string id, string version);
    }
}

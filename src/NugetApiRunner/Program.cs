using System;
using System.Linq;

namespace NugetApiRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            NugetApi.Feeds.V2Feed feed = new NugetApi.Feeds.V2Feed("https://www.nuget.org/api/v2");


            NugetApi.NuGetRepository test = new NugetApi.NuGetRepository(@"D:\Development\TestData\Cache", @"D:\Development\TestData\Install");

            var packages = test.Search("Microsoft.Extensions.Logging").Result;

            foreach(var pack in packages)
            {
                Console.WriteLine($"{pack.GetId()} : {pack.GetDescription()}");
            }

            var firstPack = packages.FirstOrDefault();

            firstPack.Download(@"D:\Development\TestData\Cache", firstPack.GetLatestVersion());
            
            Console.ReadLine();

        }
    }
}
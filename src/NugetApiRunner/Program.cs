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


            NugetApi.NuGetRepository test = new NugetApi.NuGetRepository(@"D:\Development\TestData\Cache", @"D:\Development\TestData\Install", "https://www.nuget.org/api/v2");

            var packages = test.Search("WixSharp.wix.bin").Result;

            foreach(var pack in packages)
            {
                Console.WriteLine($"{pack.GetId()} : {pack.GetDescription()}");
            }

            var firstPack = packages.FirstOrDefault();

            var stream = firstPack.Download(@"D:\Development\TestData\Cache", firstPack.GetLatestVersion());

            stream.Progress += Stream_Progress;

            var package = stream.GetPackage();
            
            Console.ReadLine();

        }

        private static void Stream_Progress(object sender, NuGet.Protocol.Core.Types.PackageProgressEventArgs e)
        {
            Console.WriteLine(e.Complete);
        }
    }
}
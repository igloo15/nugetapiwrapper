using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NugetApi.Utility
{
    internal static class XMLExtensions
    {
        public static XElement GetElement(this XElement elem, string name)
        {
            return elem.GetElements(name)?.FirstOrDefault();
        } 

        public static IEnumerable<XElement> GetElements(this XElement elem, string name)
        {
            return elem?.Elements()?.Where(x => x.Name.LocalName == name);
        }

        public static XElement GetFeed(this XDocument elem)
        {
            return elem?.Elements()?.Where(x => x.Name.LocalName == "feed")?.FirstOrDefault();
        }

        public static XElement GetProperties(this XElement elem)
        {
            return elem.GetElement("properties");
        }
    }
}

using System;
using System.Linq;
using System.Xml;

namespace _11.PriceOfAlbumsOlderThanFiveYears
{
    class Program
    {
        static void Main()
        {
            string path = "../../catalog/catalog.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            string xPathQuery = "catalog/album[year<2010]/price";

            Console.WriteLine("Price for all albums older than 5 years");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));

            var prices = doc.SelectNodes(xPathQuery);
            foreach (XmlNode price in prices)
            {
                Console.WriteLine(nameof(price) + " : " + price.InnerText);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _12.PriceOfAlbumsOlderThanFiveYearsUsingLINQ
{
    class Program
    {
        static void Main()
        {
            string path = "../../catalog/catalog.xml";

            XDocument doc = XDocument.Load(path);

            var prices =
                from album in doc.Descendants("albums")
                where int.Parse(album.Element("Year").Value) < 2010
                select new
                {
                    Price = album.Element("price").Value
                };
            Console.WriteLine("Prices for all albums older than 5 years");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));

            foreach (var price in prices)
            {
                Console.WriteLine(nameof(price) + ": " + price.Price);
            }
        }
    }
}

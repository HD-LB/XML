using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace _04.DeleteingAlbums
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            var path = "../../updatedCatalog/updatedCatalog.xml";
            doc.Load(path);

            XmlElement root = doc.DocumentElement;
            const int MaxPrice = 20;

            DeleteAlbums(root, MaxPrice);

            doc.Save("../../updatedCatalog.xml");
            Console.WriteLine("Saved new catalog");
        }

        private static void DeleteAlbums(XmlElement root, double maxPrice)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            foreach (XmlElement album in root.SelectNodes("album"))
            {
                string albumPrice = album["price"].InnerText;
                double price = double.Parse(albumPrice);


                if (maxPrice < price)
                {
                    root.RemoveChild(album);
                }
            }
        }
    }
}

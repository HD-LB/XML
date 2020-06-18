using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace _05.ExtractingAllSongsWithXmlReader
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Songs titels in the catalog: "); ;
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));

            string path = "../../catalog/catalog.xml";

            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "titel"))
                    {
                        Console.WriteLine(reader.ReadElementContentAsString());
                    }
                }
            }


        }
    }
}

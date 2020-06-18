using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06.ExtractingAllSongsUsingXDocument
{
    class Program
    {
        static void Main()
        {
            string path = "../../catalog/catalog.xml";
            XDocument doc = XDocument.Load(path);

            var songs = from song in doc.Descendants("song")
                        select new
                        {
                            Title = song.Element("title").Value
                        };
            Console.WriteLine("Song titles in the catalog: ");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));

            foreach (var song in songs)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}

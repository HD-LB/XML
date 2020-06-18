using System;
using System.Collections;
using System.Xml;

namespace _03.ExtractingArtistsUsingXPath
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            var path = "../../catalog/catalog.xml";

            doc.Load(path);

           
            var artists = ExtractAllUniqueArstists(doc);

            foreach (var artist in artists.Keys)
            {
                string oneOrManyAlbums = (int)artists[artist] > 1 ? "albums" : "album";
                Console.WriteLine(artist + " - " + artists[artist] + oneOrManyAlbums);
            }
        }

        private static Hashtable ExtractAllUniqueArstists(XmlDocument doc)
        {
            var artistPath = "catalog/album/artist";

            XmlNodeList allArtists = doc.SelectNodes(artistPath);

            var artists = new Hashtable();

            foreach (XmlNode artistsNode in allArtists)
            {
                var currentArtistName = artistsNode.InnerText;

                if (!artists.ContainsKey(currentArtistName))
                {
                    artists[currentArtistName] = 1;
                }
                else
                {
                    artists[currentArtistName] = (int)artists[currentArtistName] + 1;
                }
            }

            return artists;
        }
    }
}

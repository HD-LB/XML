using System;
using System.Collections;
using System.Xml;


namespace _02.ExtractingArtistsUsingDOM
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            var path = "../../catalog/catalog.xml";

            doc.Load(path);

            var catalog = doc.DocumentElement;
            var artists = ExtractAllUniqueArstists(catalog);

            foreach (var artist in artists.Keys)
            {
                string oneOrManyAlbums = (int)artists[artist] > 1 ? "albums" : "album";
                Console.WriteLine(artist + " - " + artists[artist] + oneOrManyAlbums);
            }
        }

        private static Hashtable ExtractAllUniqueArstists(XmlElement rootNode)
        {
            string tagName = "album";

            var artists = new Hashtable();

            var albums = rootNode.GetElementsByTagName(tagName);

            foreach (XmlNode album in albums)
            {
                var currentArtistName = album["artist"].InnerText;

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

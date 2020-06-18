using System;
using System.Text;
using System.Xml;

namespace _08.CreatingAlbumXml
{
    class Program
    {
        static void Main()
        {
            string path = "../../catalog/catalog.xml";
            string fileName = "../../myCatalog.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("myCatalog");
                writer.WriteAttributeString("name", "My catalog");

                using (XmlReader reader = XmlReader.Create(path))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "name"))
                        {
                            writer.WriteStartElement("album");
                            writer.WriteElementString("name", reader.ReadElementString());
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "artist")) 
                        {
                            writer.WriteElementString("artist", reader.ReadElementString());
                        }
                    }
                }

                writer.WriteEndDocument();
            }
        }
    }
}

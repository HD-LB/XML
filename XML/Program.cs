//https://www.youtube.com/watch?v=Yc75t8XVUBQ&list=PLF4lVL1sPDSl8UNuhpqDWsEPvgPlQhRwX&index=4

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XML
{
    class Book
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $@"------ Book ------
                    Id: {this.Id}
                    Titel: {this.Titel}
                    Author: {this.Author}
                    --- End ---";
        }
    }


    class Program
    {
        //static string GetXml()
        //{
        //    return @"<?xml version=""1.0"" ?>
        //                <books>
        //                    <book id=""1"">
        //                      <titel>The name of the wind</titel>
        //                      <author>Sample 1</author>
        //                    </book>
        //                 <book id=""2"">
        //                      <titel>Harry Potter 1</titel>
        //                      <author>Sample 2</author>
        //                    </book>
        //                 <book id=""3"">
        //                      <titel>Harry Potter 2</titel>
        //                      <author>Sample 3</author>
        //                    </book>
        //                </books>
        //                ";
        //}

        static void Main()
        {
            //LINQ-to-Xml

            var doc = XDocument.Load("../../data/data.xml");


            //loading a new Attribute
            doc.Root.Add(new XAttribute("last-update", new DateTime().ToString()));
            doc.Save("../../data/data.xml");


            doc.Root.Elements("book").Select(node =>
            {
                var id = int.Parse(node.Attribute("id").Value);
                var titel = node.Element("titel").Value;
                var autor = node.Element("autor").Value;

                return new Book
                {
                    Id = id,
                    Titel = titel,
                    Author = autor
                };
            })
            .ToList()
            .ForEach(Console.WriteLine);




            ////Streaming

            //var books = new List<Book>() {
            //    new Book()
            //       {
            //           Id = 1,
            //           Titel = "The Fellowship of the Ring",
            //           Author = "J.R.R Tolken"
            //       },

            //      new Book()
            //       {
            //           Id = 2,
            //           Titel = "The Two Towers",
            //           Author = "J.R.R Tolken"
            //       },

            //        new Book()
            //       {
            //           Id = 3,
            //           Titel = "The Return of the King",
            //           Author = "J.R.R Tolken"
            //       }
            //};

            //using (var writer = XmlWriter.Create("../../output.xml"))
            //{
            //    writer.WriteStartDocument();//xml Header

            //    writer.WriteStartElement("books");

            //    foreach (var book in books)
            //    {
            //        WriteNextBook(writer, book);
            //    }

            //    writer.WriteEndElement();

            //    writer.WriteEndDocument();
            //}




            ////DOM

            //var xml = GetXml();
            //var doc = new XmlDocument();
            //doc.LoadXml(xml);

            //var root = doc.DocumentElement;
            //Console.WriteLine(root.Name);
            //PrintChildren(root);


            //using (var reader = XmlReader.Create("../../data/data.xml"))
            //{
            //    Console.WriteLine(reader.IsStartElement());
            //}

            //    using (var node = XmlReader.Create("../../data/data.xml"))
            //    {
            //        Book book = ReadNextBook(node);
            //        while (book != null)
            //        {
            //            Console.WriteLine(book);
            //            book = ReadNextBook(node);
            //        }
            //    }

            //}

            //static Book ReadNextBook(XmlReader node)
            //{
            //    var book = new Book();
            //    var isTitelRead = false;
            //    var isIdRead = false;
            //    var isAuthorRead = false;

            //    while ((!isTitelRead || !isIdRead || !isAuthorRead) && node.Read())
            //    {
            //        if (node.IsStartElement() && node.Name =="titel")
            //        {
            //            book.Id = int.Parse(node.GetAttribute("id"));

            //            node.Read();
            //            book.Titel = node.Value;
            //            isTitelRead = true;
            //        }
            //    }

            //    return book;

            //}

            //static void PrintChildren(XmlNode node, string indent = "")
            //{
            //    Console.WriteLine(indent + node.Name);
            //    foreach (XmlNode child in node.ChildNodes)
            //    {
            //        PrintChildren(child, indent + "--");
            //    }
            //}
        }




        ////Streaming
        //private static void WriteNextBook(XmlWriter writer, Book book)
        //{
        //    writer.WriteStartElement("book");

        //    writer.WriteAttributeString("id", book.Id.ToString());

        //    writer.WriteElementString("titel", book.Titel);
        //    writer.WriteElementString("autor", book.Author);



        //    writer.WriteEndElement();
        //}
    }
}

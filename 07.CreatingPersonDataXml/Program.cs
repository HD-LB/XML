using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07.CreatingPersonDataXml
{
    class Program
    {
        static void Main()
        {
            string path = "../../personData/personData.txt";
            var person = new Person();

            using (StreamReader reader = new StreamReader(path))
            {
                person.Name = reader.ReadLine();
                person.Address = reader.ReadLine();
                person.PhoneNumber = reader.ReadLine();
            }

            XElement personElement = new XElement("person", 
                new XElement("name", person.Name), 
                new XElement("Address", person.Address), 
                new XElement("phoneNumber", person.PhoneNumber));

            personElement.Save("../../personData/personData.xml");
        }
    }
}

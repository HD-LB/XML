using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace _16.GenerateXsdSchemaAndValidateXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var schema = new XmlSchemaSet();
            var xsdPath = "../../catalogXsd/catalogXsd.xsd";
            var validXmlPath = "../../catalog/catalog.xml";
            var invalidPath = "../../catalog/invalidCatalog.xml";

            schema.Add(string.Empty, xsdPath);
            XDocument correctDoc = XDocument.Load(validXmlPath);
            XDocument invalidDoc = XDocument.Load(invalidPath);

            ValidateXml(schema, correctDoc);
            ValidateXml(schema, invalidDoc);

        }

        private static void ValidateXml(XmlSchemaSet schema, XDocument correctDoc)
        {
            Console.WriteLine("Valiadting....");
            bool hasError = false;

            correctDoc.Validate(schema, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);

                hasError = true;
            });

            Console.WriteLine("Xml document {0}", hasError ? "did not validate" : "validated");
            Console.WriteLine();

        }

    }
}


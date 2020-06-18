using System;
using System.Xml.Xsl;

namespace _14.XslTransform
{
    class Program
    {
        static void Main()
        {
            var xslt = new XslCompiledTransform();
            var xmlPath = "../../catalog/catalog.xml";
            var xslPath = "../../catalogXslt/catalogStyle.xslt";
            var htmlFile = "../../catalog.html";

            xslt.Load(xslPath);
            xslt.Transform(xmlPath, htmlFile);
        }
    }
}

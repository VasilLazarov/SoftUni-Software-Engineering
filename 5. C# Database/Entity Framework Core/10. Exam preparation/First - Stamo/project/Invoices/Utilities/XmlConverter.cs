using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Invoices.Utilities
{
    public static class XmlConverter
    {

        public static string Serialize<T>(
            T dataTransferObjects,
            string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            var builder = new StringBuilder();

            using var write = XmlWriter.Create(builder, new XmlWriterSettings() { Indent = true });
            serializer.Serialize(write, dataTransferObjects, GetXmlNamespaces());

            return builder.ToString().TrimEnd();
        }

        public static T Deserialize<T>(
            string xmlObjectsAsString,
            string xmlRootAttributeName)
            where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            var dataTransferObjects = serializer.Deserialize(new StringReader(xmlObjectsAsString)) as T;

            return dataTransferObjects;
        }

        private static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }

    }
}

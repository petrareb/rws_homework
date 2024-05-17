using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Models;
using System.Xml.Serialization;

namespace RwsMoraviaHomework.Serializers
{
    public class XmlFileSerializer : ISerializer
    {
        public string Serialize(Document? document)
        {
            if (document is null)
                throw new ArgumentNullException(nameof(document), "It is not possible to serialize document.");

            using var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(Document));
            serializer.Serialize(stringWriter, document);

            return stringWriter.ToString();
        }
    }
}

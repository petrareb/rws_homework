using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Models;
using System.Xml.Serialization;

namespace RwsMoraviaHomework.Deserializers
{
    public class XmlFileDeserializer : IDeserializer
    {
        public Document Deserialize(string? content)
        {
            if (content is null)
            {
                throw new ArgumentNullException(nameof(content), "It is not possible to deserialize document, because it is null.");
            }

            using var stringReader = new StringReader(content);
            var serializer = new XmlSerializer(typeof(Document));
            var deserializedDocument = serializer.Deserialize(stringReader) as Document
                ?? throw new ArgumentException($"Provided file is not a valid XML.");

            return deserializedDocument;
        }
    }
}

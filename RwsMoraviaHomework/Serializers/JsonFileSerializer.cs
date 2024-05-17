using Newtonsoft.Json;
using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Models;

namespace RwsMoraviaHomework.Serializers
{
    public class JsonFileSerializer : ISerializer
    {
        public string Serialize(Document? document)
        {
            if (document is null)
                throw new ArgumentNullException(nameof(document), "It is not possible to serialize document.");

            var serializedContent = JsonConvert.SerializeObject(document);

            return serializedContent;
        }
    }
}

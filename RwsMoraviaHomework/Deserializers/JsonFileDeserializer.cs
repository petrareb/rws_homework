using Newtonsoft.Json;
using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Models;

namespace RwsMoraviaHomework.Deserializers
{
    public class JsonFileDeserializer : IDeserializer
    {
        public Document Deserialize(string? content)
        {
            if (content is null)
            {
                throw new ArgumentNullException(nameof(content), "It is not possible to deserialize document, because it is null.");
            }

            var deserializedDocument = JsonConvert.DeserializeObject<Document>(content) 
                ?? throw new ArgumentException($"Provided file is not a valid JSON.");

            return deserializedDocument;
        }
    }
}

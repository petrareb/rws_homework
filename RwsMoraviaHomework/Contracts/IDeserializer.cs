using RwsMoraviaHomework.Models;

namespace RwsMoraviaHomework.Contracts
{
    public interface IDeserializer
    {
        public Document Deserialize(string content);
    }
}

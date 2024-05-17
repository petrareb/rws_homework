using RwsMoraviaHomework.Models;

namespace RwsMoraviaHomework.Contracts
{
    public interface ISerializer
    {
        public string Serialize(Document document);
    }
}

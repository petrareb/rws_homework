using RwsMoraviaHomework.Models;

namespace RwsMoraviaHomework.Converters.Contracts
{
    public interface IFileWriter
    {
        public void CanWrite();
        public void WriteToFile(string content);
        public string GetDestinationType();
    }
}

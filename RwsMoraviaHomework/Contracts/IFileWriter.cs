namespace RwsMoraviaHomework.Contracts
{
    public interface IFileWriter
    {
        public void CanWrite();
        public void WriteToFile(string content);
        public string GetDestinationType();
    }
}

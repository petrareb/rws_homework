namespace RwsMoraviaHomework.Contracts
{
    public interface IFileWriter
    {
        public void WriteToFile(string content);
        public string GetFileToWriteExtention();
    }
}

using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Writers
{
    // Example of additional file writer; not implemented yet
    public class CloudStorageWriter : IFileWriter
    {

        public CloudStorageWriter(string path)
        {
        }

        public string GetFileToWriteExtention()
        {
            throw new NotImplementedException();
        }

        public void WriteToFile(string content)
        {
            throw new NotImplementedException();
        }
    }
}

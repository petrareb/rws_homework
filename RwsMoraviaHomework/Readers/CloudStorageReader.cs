using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Readers
{
    // Example of additional file reader; not implemented yet
    public class CloudStorageReader : IFileReader
    {
        public CloudStorageReader(string path)
        {
        }

        public string GetFileToReadExtention()
        {
            throw new NotImplementedException();
        }

        public string ReadFromFile()
        {
            throw new NotImplementedException();
        }
    }
}

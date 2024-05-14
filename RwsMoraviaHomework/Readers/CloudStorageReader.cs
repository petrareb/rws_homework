using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Readers
{
    // Example of additional file reader; not implemented yet
    public class CloudStorageReader : IFileReader
    {
        private readonly string _path;

        public CloudStorageReader(string path)
        {
            _path = path;
        }

        public string ReadFromFile()
        {
            throw new NotImplementedException();
        }
    }
}

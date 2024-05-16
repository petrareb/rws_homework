using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Utils;

namespace RwsMoraviaHomework.Writers
{
    public class CloudStorageWriter : IFileWriter
    {
        private readonly string _path;

        public CloudStorageWriter(string path)
        {
            _path = path;
        }

        public void CanWrite()
        {
            throw new NotImplementedException();
        }

        public string GetDestinationType()
        {
            throw new NotImplementedException();
        }

        public void WriteToFile(string content)
        {
            throw new NotImplementedException();
        }
    }
}

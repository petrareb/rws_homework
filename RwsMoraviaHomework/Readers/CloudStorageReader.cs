using RwsMoraviaHomework.Converters.Contracts;

namespace RwsMoraviaHomework.Readers
{
    public class CloudStorageReader : IFileReader // netreba implementovat, len ukazkovo
    {
        private readonly string _path;

        public CloudStorageReader(string path)
        {
            _path = path;
        }

        public string Read()
        {
            throw new NotImplementedException();
        }
    }
}

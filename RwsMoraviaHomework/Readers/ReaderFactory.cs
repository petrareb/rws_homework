using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Readers
{
    public class ReaderFactory
    {
        public static IFileReader CreateFileReader(string path, string storage)
        {
            switch (storage)
            {
                case SupportedStorages.FileSystem:
                    {
                        return new FileSystemReader(path);
                    }
                case SupportedStorages.Cloud:
                    {
                        return new CloudStorageReader(path);
                    }
                default:
                    {
                        throw new ArgumentException($"{storage} storage is not supported.");
                    }
            }
        }
    }
}

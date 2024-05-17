using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Readers
{
    public class ReaderFactory
    {
        public static IFileReader CreateFileReader(string storage)
        {
            if (string.IsNullOrEmpty(storage))
            {
                throw new ArgumentException("Source storage was not defined.");
            }

            switch (storage)
            {
                case SupportedStorages.FileSystem:
                    {
                        return new FileSystemReader();
                    }
                case SupportedStorages.Cloud:
                    {
                        return new CloudStorageReader();
                    }
                default:
                    {
                        throw new ArgumentException($"{storage} storage is not supported.");
                    }
            }
        }
    }
}

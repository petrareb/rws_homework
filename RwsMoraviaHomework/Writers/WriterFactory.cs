using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Writers
{
    public class WriterFactory
    {
        public static IFileWriter CreateFileWriter(string storage)
        {
            if (string.IsNullOrEmpty(storage))
            {
                throw new ArgumentException("Target storage was not defined.");
            }

            switch (storage)
            {
                case SupportedStorages.FileSystem:
                    {
                        return new FileSystemWriter();
                    }
                case SupportedStorages.Cloud:
                    {
                        return new CloudStorageWriter();
                    }
                default:
                    {
                        throw new ArgumentException($"{storage} storage is not supported.");
                    }
            }
        }
    }
}

using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Writers
{
    public class WriterFactory
    {
        public static IFileWriter CreateFileWriter(string path, string storage)
        {
            switch (storage)
            {
                case SupportedStorages.FileSystem:
                    {
                        return new FileSystemWriter(path);
                    }
                case SupportedStorages.Cloud:
                    {
                        return new CloudStorageWriter(path);
                    }
                default:
                    {
                        Console.WriteLine("File location is not supported.");
                        throw new ArgumentException("Unsupported file location.");
                    }
            }
        }
    }
}

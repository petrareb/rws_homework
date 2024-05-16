using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Readers
{
    public class ReaderFactory
    {
        public static IFileReader CreateFileReader(string path, string storage) // TODOOOO: ako rozpoznat ulozisko?
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
                        Console.WriteLine("File location is not supported.");
                        throw new ArgumentException("Unsupported file location.");
                    }
            }
        }
    }
}

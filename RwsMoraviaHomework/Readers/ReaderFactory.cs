using RwsMoraviaHomework.Converters.Contracts;

namespace RwsMoraviaHomework.Readers
{
    public class ReaderFactory
    {
        public static IFileReader CreateFileReader(string path) // TODOOOO: ako rozpoznat ulozisko?
        {
            switch (path)
            {
                case "FileSystem":
                    {
                        return new FileSystemReader(path);
                    }
                case "Cloud":
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

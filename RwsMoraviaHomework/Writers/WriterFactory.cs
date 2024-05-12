using RwsMoraviaHomework.Converters.Contracts;

namespace RwsMoraviaHomework.Writers
{
    public class WriterFactory
    {
        public static IFileWriter CreateFileWriter(string path)
        {
            switch (path)
            {
                case "FileSystem":
                    {
                        return new FileSystemWriter(path);
                    }
                case "Cloud":
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

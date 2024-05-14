using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Writers
{
    public class FileSystemWriter : IFileWriter
    {
        private readonly string _path;

        public FileSystemWriter(string path)
        {
            _path = path;
        }

        public void WriteToFile(string content)
        {
            using (var targetStream = File.Open(_path, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(targetStream))
            {
                sw.Write(content);
            }

            Console.WriteLine($"Content saved to {_path}.");
        }
    }
}

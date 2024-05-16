using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Utils;

namespace RwsMoraviaHomework.Writers
{
    public class FileSystemWriter : IFileWriter
    {
        private readonly string _path;

        public FileSystemWriter(string path)
        {
            var trimmedPath = path.Trim();
            if (string.IsNullOrEmpty(trimmedPath))
            {
                throw new ArgumentException("Target file path mustn't be empty.");
            }

            _path = Path.Combine(Environment.CurrentDirectory, trimmedPath);
        }

        public string GetFileToWriteExtention() => FileExtentionUtils.GetFileExtention(_path);

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

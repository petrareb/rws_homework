using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Utils;

namespace RwsMoraviaHomework.Readers
{
    public class FileSystemReader : IFileReader
    {
        private readonly string _path;

        public FileSystemReader(string path)
        {
            var trimmedPath = path.Trim();
            if (string.IsNullOrEmpty(trimmedPath))
            {
                throw new ArgumentException("Source file path mustn't be empty.");
            }

            _path = Path.Combine(Environment.CurrentDirectory, trimmedPath);
        }

        public string GetFileToReadExtention() => FileExtentionUtils.GetFileExtention(_path);

        public string ReadFromFile()
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException(_path);
            }

            using (var sourceStream = File.Open(_path, FileMode.Open))
            using (var reader = new StreamReader(sourceStream))
            {
                string input = reader.ReadToEnd();
                return input;
            }
        }
    }
}

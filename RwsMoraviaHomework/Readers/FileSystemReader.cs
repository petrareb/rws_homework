using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Readers
{
    public class FileSystemReader : IFileReader
    {
        public string ReadFromFile(string path)
        {
            var trimmedPath = path.Trim();
            if (string.IsNullOrEmpty(trimmedPath))
            {
                throw new ArgumentException("Source file path mustn't be empty.");
            }

            var filePath = Path.Combine(Environment.CurrentDirectory, trimmedPath);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Source file does not exist.");
            }

            using var sourceStream = File.Open(filePath, FileMode.Open);
            using var reader = new StreamReader(sourceStream);
            string input = reader.ReadToEnd();
            
            return input;
        }
    }
}

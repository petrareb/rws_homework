using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Writers
{
    public class FileSystemWriter : IFileWriter
    {
        public void WriteToFile(string path, string content)
        {
            var trimmedPath = path.Trim();
            if (string.IsNullOrEmpty(trimmedPath))
            {
                throw new ArgumentException("Target file path mustn't be empty.");
            }

            var filePath = Path.Combine(Environment.CurrentDirectory, trimmedPath);

            using (var targetStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(targetStream))
            {
                sw.Write(content);
            }

            Console.WriteLine($"Content saved to {filePath}.");
        }
    }
}

using Newtonsoft.Json;
using RwsMoraviaHomework.Converters.Contracts;
using RwsMoraviaHomework.Utils;

namespace RwsMoraviaHomework.Writers
{
    public class FileSystemWriter : IFileWriter
    {
        private readonly string _path;

        public FileSystemWriter(string path)
        {
            _path = path;
        }

        public void CanWrite()
        {
            throw new NotImplementedException();
        }

        public string GetDestinationType() => FileExtentionUtils.GetFileExtention(_path);

        public void WriteToFile(string content)
        {
            using (var targetStream = File.Open(_path, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(targetStream))
            {
                sw.Write(content);
            }

            Console.WriteLine($"Saved to {_path}.");
        }
    }
}

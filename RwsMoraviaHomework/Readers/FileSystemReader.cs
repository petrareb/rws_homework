using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Readers
{
    public class FileSystemReader : IFileReader
    {
        private readonly string _path;

        public FileSystemReader(string path)
        {
            _path = path;
        }

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

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

        public string Read()
        {
            try
            {
                using (var sourceStream = File.Open(_path, FileMode.Open))
                using (var reader = new StreamReader(sourceStream))
                {
                    string input = reader.ReadToEnd();
                    return input;
                }
            }
            catch (Exception ex) // TODO - tryRead a vratit ked tak null???
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

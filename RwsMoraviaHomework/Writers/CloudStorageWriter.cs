using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Writers
{
    // Example of additional file writer; not implemented yet
    public class CloudStorageWriter : IFileWriter
    {

        public CloudStorageWriter(string path)
        {
        }

        public void WriteToFile(string content)
        {
            throw new NotImplementedException();
        }
    }
}

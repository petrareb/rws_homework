using RwsMoraviaHomework.Readers;

namespace Tests.Readers
{
    [TestFixture]
    public class FileSystemReaderTests
    {
        private readonly FileSystemReader _reader = new();

        [TestCase("")]
        [TestCase("    ")]
        public void ReadFromFile_InvalidPath_ThrowsArgumentException(string path)
        {
            var exception = Assert.Throws<ArgumentException>(() => _reader.ReadFromFile(path));
            Assert.That(exception.Message, Is.EqualTo("Source file path mustn't be empty."));
        }
    }
}

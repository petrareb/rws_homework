using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Readers;

namespace Tests.Readers
{
    [TestFixture]
    public class ReaderFactoryTests
    {
        [Test]
        public void CreateFileReader_InvalidStorage_ThrowsArgumentException()
        {
            var storage = "somewhere";

            var exception = Assert.Throws<ArgumentException>(() => ReaderFactory.CreateFileReader(storage));
            Assert.That(exception.Message, Is.EqualTo($"{storage} storage is not supported."));
        }

        [Test]
        public void CreateFileReader_StorageIsEmptyString_ThrowsArgumentException()
        {
            string storage = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => ReaderFactory.CreateFileReader(storage));
            Assert.That(exception.Message, Is.EqualTo("Source storage was not defined."));
        }

        [Test]
        public void CreateFileReader_FileSystemStorage_ReturnsFileSystemReader()
        {
            var storage = SupportedStorages.FileSystem;

            var writer = ReaderFactory.CreateFileReader(storage);

            Assert.That(writer, Is.TypeOf<FileSystemReader>());
        }

        [Test]
        public void CreateFileReader_CloudStorage_ReturnsCloudReader()
        {
            var storage = SupportedStorages.Cloud;

            var writer = ReaderFactory.CreateFileReader(storage);

            Assert.That(writer, Is.TypeOf<CloudStorageReader>());
        }
    }
}

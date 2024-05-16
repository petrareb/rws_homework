using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Writers;

namespace Tests.Writers
{
    [TestFixture]
    public class WriterFactoryTests
    {
        [TestCase("")]
        [TestCase("somewhere")]
        public void CreateFileWriter_InvalidStorage_ThrowsArgumentException(string storage)
        {
            Assert.Throws<ArgumentException>(() => WriterFactory.CreateFileWriter("some_path", storage), message: $"{storage} storage is not supported.");
        }

        [Test]
        public void CreateFileWriter_FileSystemStorage_ReturnsFileSystemWriter()
        {
            var storage = SupportedStorages.FileSystem;
            var path = "file_system_path";

            var writer = WriterFactory.CreateFileWriter(path, storage);

            Assert.That(writer, Is.TypeOf<FileSystemWriter>());
        }

        [Test]
        public void CreateFileWriter_CloudStorage_ReturnsCloudWriter()
        {
            var storage = SupportedStorages.Cloud;
            var path = "cloud_storage_path";

            var writer = WriterFactory.CreateFileWriter(path, storage);

            Assert.That(writer, Is.TypeOf<CloudStorageWriter>());
        }
    }
}

using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Writers;

namespace Tests.Writers
{
    [TestFixture]
    public class WriterFactoryTests
    {
        [Test]
        public void CreateFileWriter_InvalidStorage_ThrowsArgumentException()
        {
            var storage = "somewhere";

            var exception = Assert.Throws<ArgumentException>(() => WriterFactory.CreateFileWriter(storage));
            Assert.That(exception.Message, Is.EqualTo($"{storage} storage is not supported."));
        }

        [Test]
        public void CreateFileWriter_StorageIsEmptyString_ThrowsArgumentException()
        {
            string storage = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => WriterFactory.CreateFileWriter(storage));
            Assert.That(exception.Message, Is.EqualTo("Target storage was not defined."));
        }

        [Test]
        public void CreateFileWriter_FileSystemStorage_ReturnsFileSystemWriter()
        {
            var storage = SupportedStorages.FileSystem;

            var writer = WriterFactory.CreateFileWriter(storage);

            Assert.That(writer, Is.TypeOf<FileSystemWriter>());
        }

        [Test]
        public void CreateFileWriter_CloudStorage_ReturnsCloudWriter()
        {
            var storage = SupportedStorages.Cloud;

            var writer = WriterFactory.CreateFileWriter(storage);

            Assert.That(writer, Is.TypeOf<CloudStorageWriter>());
        }
    }
}

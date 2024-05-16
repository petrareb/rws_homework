using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Converters;
using RwsMoraviaHomework.Readers;
using RwsMoraviaHomework.Writers;

namespace Tests.Converters
{
    [TestFixture]
    public class ConverterFactoryTests
    {
        [Test]
        public void CreateConverter_ReaderIsNull_ThrowsArgumentNullException()
        {
            var writer = new FileSystemWriter("C://fake_file.json");

            Assert.Throws<ArgumentNullException>(() => ConverterFactory.CreateConverter(reader: null, writer));
        }

        [Test]
        public void CreateConverter_WriterIsNull_ThrowsArgumentNullException()
        {
            var reader = new FileSystemReader("C://fake_file.json");

            Assert.Throws<ArgumentNullException>(() => ConverterFactory.CreateConverter(reader, writer: null));
        }

        [TestCase("C://input_file")]
        [TestCase("C://input_file.txt")]
        public void CreateConverter_InvalidSourceFileExtention_ThrowsArgumentException(string sourceFileName)
        {
            var reader = new FileSystemReader(sourceFileName);
            var writer = new FileSystemWriter("C://fake_file.json");

            Assert.Throws<ArgumentException>(() => ConverterFactory.CreateConverter(reader, writer),
                message: $"Source file type is not supported. These types are supported: {SupportedInputTypes.GetDescription()}.");
        }

        [Test]
        public void CreateConverter_JsonSourceFile_ReturnsJsonConverter()
        {
            var reader = new FileSystemReader("C://source.json");
            var writer = new FileSystemWriter("C://target.xml");

            var converter = ConverterFactory.CreateConverter(reader, writer);

            Assert.That(converter, Is.TypeOf<JsonConverter>());
        }

        [Test]
        public void CreateConverter_XmlSourceFile_ReturnsXmlConverter()
        {
            var reader = new FileSystemReader("C://source.xml");
            var writer = new FileSystemWriter("C://target.json");

            var converter = ConverterFactory.CreateConverter(reader, writer);

            Assert.That(converter, Is.TypeOf<XmlConverter>());
        }
    }
}

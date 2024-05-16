using NSubstitute;
using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Converters;

namespace Tests.Converters
{
    [TestFixture]
    public class JsonConverterTests
    {
        private IFileReader _reader;
        private IFileWriter _writer;
        private JsonConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _reader = Substitute.For<IFileReader>();
            _writer = Substitute.For<IFileWriter>();
            _converter = new JsonConverter(_reader, _writer);
        }

        [TestCase("")]
        [TestCase(".txt")]
        public void Convert_InvalidFileExtention_ThrowsArgumentException(string targetExtention)
        {
            Assert.Throws<ArgumentException>(() => _converter.Convert(targetExtention), message: $"Target file type {targetExtention} is not supported.");
        }

        [Test]
        public void Convert_ToJson_CallsServicesCorrectly()
        {
            var targetExtention = ".json";
            var readContent = "{\r\n\"Document\": {\r\n\t\"title\": \"Awesome JSON title\",\r\n\t\"text\":  \"Lorem ipsum something...\"\r\n}\r\n}";
            _reader.ReadFromFile().Returns(readContent);

            _converter.Convert(targetExtention);

            _reader.Received(1).ReadFromFile();
            _writer.Received(1).WriteToFile(Arg.Is(readContent));
        }

        [Test]
        public void Convert_ToXml_CallsServicesCorrectly()
        {
            var targetExtention = ".xml";
            var readContent = "{\r\n\"Document\": {\r\n\t\"title\": \"Awesome JSON title\",\r\n\t\"text\":  \"Lorem ipsum something...\"\r\n}\r\n}";
            var convertedContent = "<Document>\r\n  <title>Awesome JSON title</title>\r\n  <text>Lorem ipsum something...</text>\r\n</Document>";
            _reader.ReadFromFile().Returns(readContent);

            _converter.Convert(targetExtention);

            _reader.Received(1).ReadFromFile();
            _writer.Received(1).WriteToFile(Arg.Is(convertedContent));
        }
    }
}

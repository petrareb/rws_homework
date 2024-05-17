using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Serializers;

namespace Tests.Serializers
{
    [TestFixture]
    public class SerializerFactoryTests
    {
        [TestCase("C://file")]
        [TestCase("")]
        [TestCase("location")]
        public void CreateSerializer_InvalidFilePath_ThrowsArgumentException(string filePath)
        {
            var exception = Assert.Throws<ArgumentException>(() => SerializerFactory.CreateSerializer(filePath));
            Assert.That(exception.Message, Is.EqualTo("Invalid file, unable to get file extention."));
        }

        [TestCase("C://file.html")]
        [TestCase("..//file.bson")]
        public void CreateSerializer_NotSupportedExtention_ThrowsArgumentException(string filePath)
        {
            var exception = Assert.Throws<ArgumentException>(() => SerializerFactory.CreateSerializer(filePath));
            Assert.That(exception.Message, Is.EqualTo($"Target file type is not supported. These types are supported: {SupportedOutputTypes.GetDescription()}."));
        }

        [Test]
        public void CreateSerializer_SerializeToJson_ReturnsJsonFileSerializer()
        {
            var filePath = ".//..//file.json";

            var serializer = SerializerFactory.CreateSerializer(filePath);

            Assert.That(serializer, Is.TypeOf<JsonFileSerializer>());
        }

        [Test]
        public void CreateSerializer_SerializeToXml_ReturnsXmlFileSerializer()
        {
            var filePath = ".//..//file.xml";

            var serializer = SerializerFactory.CreateSerializer(filePath);

            Assert.That(serializer, Is.TypeOf<XmlFileSerializer>());
        }
    }
}

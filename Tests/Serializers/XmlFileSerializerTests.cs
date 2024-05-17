using RwsMoraviaHomework.Models;
using RwsMoraviaHomework.Serializers;

namespace Tests.Serializers
{
    [TestFixture]
    public class XmlFileSerializerTests
    {
        private readonly XmlFileSerializer _serializer = new();

        [Test]
        public void Serialize_DocumentIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _serializer.Serialize(null));
            Assert.That(exception.Message, Does.Contain("It is not possible to serialize document."));
        }

        [Test]
        public void Serialize_DocumentIsValid_DocumentIsSerializedCorrectly()
        {
            var document = new Document { Title = "Awesome Title", Text = "Lorem ipsum..." };
            var expectedResult = "<Title>Awesome Title</Title>\r\n  <Text>Lorem ipsum...</Text>\r\n</Document>";

            var result = _serializer.Serialize(document);

            Assert.That(result, Does.Contain(expectedResult));
        }
    }
}

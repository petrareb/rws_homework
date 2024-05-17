using RwsMoraviaHomework.Models;
using RwsMoraviaHomework.Serializers;

namespace Tests.Serializers
{
    [TestFixture]
    public class JsonFileSerializerTests
    {
        private readonly JsonFileSerializer _serializer = new();

        [Test]
        public void Serialize_DocumentIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _serializer.Serialize(null));
            Assert.That(exception.Message, Does.Contain("It is not possible to serialize document."));
        }

        [Test]
        public void Serialize_DocumentIsValid_DocumentIsSerializedCorrectly()
        {
            var document = new Document
            {
                Title = "Awesome Title",
                Text = "Lorem ipsum..."
            };
            var expectedResult = "{\"Title\":\"Awesome Title\",\"Text\":\"Lorem ipsum...\"}";

            var result = _serializer.Serialize(document);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}

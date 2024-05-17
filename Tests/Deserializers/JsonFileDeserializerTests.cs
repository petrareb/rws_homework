using FluentAssertions;
using RwsMoraviaHomework.Deserializers;
using RwsMoraviaHomework.Models;

namespace Tests.Deserializers
{
    [TestFixture]
    public class JsonFileDeserializerTests
    {
        private readonly JsonFileDeserializer _deserializer = new();

        [Test]
        public void Deserialize_DocumentIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _deserializer.Deserialize(null));
            Assert.That(exception.Message, Does.Contain("It is not possible to deserialize document, because it is null"));
        }

        [Test]
        public void Deserialize_DocumentIsValid_DocumentIsSerializedCorrectly()
        {
            var content = "{\"Title\":\"Awesome Title\",\"Text\":\"Lorem ipsum...\"}";
            var expected = new Document
            {
                Title = "Awesome Title",
                Text = "Lorem ipsum..."
            };

            var result = _deserializer.Deserialize(content);

            result.Should().BeEquivalentTo(expected);
        }
    }
}

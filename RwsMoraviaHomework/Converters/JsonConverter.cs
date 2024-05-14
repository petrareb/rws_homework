using Newtonsoft.Json;
using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Converters
{
    public class JsonConverter : ConverterBase
    {
        private readonly IFileReader _reader;
        private readonly IFileWriter _writer;

        public JsonConverter(IFileReader reader, IFileWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public override void ConvertToJson()
        {
            var content = _reader.ReadFromFile();

            _writer.WriteToFile(content);
        }

        public override void ConvertToXml()
        {
            var content = _reader.ReadFromFile();

            var xmlContent = JsonConvert.DeserializeXmlNode(content, "Root");
            var stream = xmlContent?.ToString() ?? string.Empty;
            _writer.WriteToFile(stream);
        }
    }
}

using Newtonsoft.Json;
using RwsMoraviaHomework.Converters.Contracts;
using RwsMoraviaHomework.Models;

namespace RwsMoraviaHomework.Converters
{
    public class JsonConverter : IConverter
    {
        private readonly IFileReader _reader;
        private readonly IFileWriter _writer;

        public JsonConverter(IFileReader reader, IFileWriter writer)
        {
            ArgumentNullException.ThrowIfNull(reader);
            ArgumentNullException.ThrowIfNull(writer);

            _reader = reader;
            _writer = writer;
        }

        public void Convert()
        {
            var targetFileExtention = _writer.GetDestinationType();

            switch (targetFileExtention)
            {
                case SupportedOutputTypes.Json:
                    {
                        ConvertToJson();
                        return;
                    }
                case SupportedOutputTypes.Xml:
                    {
                        ConvertToXml();
                        return;
                    }
                default:
                    Console.WriteLine("Target file type is not supported.");
                    throw new ArgumentException("Unsupported target file type.");
            }
        }

        public void ConvertToJson()
        {
            var content = _reader.Read();

            _writer.WriteToFile(content);
        }

        public void ConvertToXml()
        {
            var content = _reader.Read();

            var xmlContent = JsonConvert.DeserializeXmlNode(content, "Root");
            var stream = xmlContent?.ToString() ?? string.Empty;
            _writer.WriteToFile(stream);
        }
    }
}

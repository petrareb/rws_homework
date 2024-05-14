using Newtonsoft.Json;
using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Models;
using System.Xml.Linq;

namespace RwsMoraviaHomework.Converters
{
    public class XmlConverter : ConverterBase
    {
        private readonly IFileReader _reader;
        private readonly IFileWriter _writer;

        public XmlConverter(IFileReader reader, IFileWriter writer)
        {
            ArgumentNullException.ThrowIfNull(reader);
            ArgumentNullException.ThrowIfNull(writer);

            _reader = reader;
            _writer = writer;
        }

        public override void ConvertToJson()
        {
            var content = _reader.ReadFromFile();

            var xdoc = XDocument.Parse(content);
            if (xdoc.Root is null)
            {
                throw new ArgumentException("Source XML file is not valid; unable to read.");
            }

            var doc = new Document
            {
                Title = xdoc.Root.Element("title")?.Value ?? string.Empty,
                Text = xdoc.Root.Element("text")?.Value ?? string.Empty
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);
            _writer.WriteToFile(serializedDoc);
        }

        public override void ConvertToXml()
        {
            var content = _reader.ReadFromFile();

            _writer.WriteToFile(content);
        }
    }
}

using Newtonsoft.Json;
using RwsMoraviaHomework.Converters.Contracts;
using RwsMoraviaHomework.Models;
using System.Xml.Linq;

namespace RwsMoraviaHomework.Converters
{
    public class XmlConverter : IConverter
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

        public void Convert() // toto sa opakuje u vsetkych a smrdi to abstraktnou triedou !!!
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

            var xdoc = XDocument.Parse(content);
            if (xdoc.Root is null)
            {
                throw new NullReferenceException("something happened and doc was not created correctly");
            }

            var doc = new Document
            {
                Title = xdoc.Root.Element("title")?.Value ?? string.Empty,
                Text = xdoc.Root.Element("text")?.Value ?? string.Empty
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);
            _writer.WriteToFile(serializedDoc);
        }

        public void ConvertToXml()
        {
            var content = _reader.Read();

            _writer.WriteToFile(content);
        }
    }
}

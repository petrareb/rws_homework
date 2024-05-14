using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Converters;
using RwsMoraviaHomework.Utils;

namespace RwsMoraviaHomework.Readers
{
    public class ConverterFactory
    {
        public static IConverter CreateConverter(string sourceFileName, IFileReader reader, IFileWriter writer)
        {
            ArgumentNullException.ThrowIfNull(reader, nameof(reader));
            ArgumentNullException.ThrowIfNull(writer, nameof(writer));

            var fileExtention = FileExtentionUtils.GetFileExtention(sourceFileName);

            switch (fileExtention)
            {
                case SupportedInputTypes.Json:
                    {
                        return new JsonConverter(reader, writer);
                    }
                case SupportedInputTypes.Xml:
                    {
                        return new XmlConverter(reader, writer);
                    }
                default:
                    {
                        throw new ArgumentException($"Source file type {fileExtention} is not supported.");
                    }

            }
        }
    }
}

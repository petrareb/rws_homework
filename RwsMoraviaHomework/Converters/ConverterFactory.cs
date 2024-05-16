using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Converters;

namespace RwsMoraviaHomework.Readers
{
    public static class ConverterFactory
    {
        public static IConverter CreateConverter(IFileReader? reader, IFileWriter? writer)
        {
            ArgumentNullException.ThrowIfNull(reader, nameof(reader));
            ArgumentNullException.ThrowIfNull(writer, nameof(writer));

            var fileExtention = reader.GetFileToReadExtention();

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
                        throw new ArgumentException($"Source file type is not supported. These types are supported: {SupportedInputTypes.GetDescription()}.");
                    }
            }
        }
    }
}

using RwsMoraviaHomework.Converters;
using RwsMoraviaHomework.Converters.Contracts;
using RwsMoraviaHomework.Models;
using RwsMoraviaHomework.Utils;

namespace RwsMoraviaHomework.Readers
{
    public class ConverterFactory
    {
        public static IConverter CreateConverter(string sourceFileName, IFileReader reader, IFileWriter writer) // alebo len TryCreateConverter a hodit false?
        {
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
                        Console.WriteLine("File type is not supported.");
                        throw new ArgumentException("Unsupported file type, unable to read from the file");
                    }
                    
            }
        }
    }
}

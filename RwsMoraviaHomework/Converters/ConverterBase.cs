using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;

namespace RwsMoraviaHomework.Converters
{
    public abstract class ConverterBase : IConverter
    {
        public void Convert(string targetFileExtention)
        {
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

        public abstract void ConvertToJson();

        public abstract void ConvertToXml();
    }
}

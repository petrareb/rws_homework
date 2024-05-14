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
                    throw new ArgumentException($"Target file type {targetFileExtention} is not supported.");
            }
        }

        public abstract void ConvertToJson();

        public abstract void ConvertToXml();
    }
}

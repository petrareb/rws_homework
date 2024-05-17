using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Utils;

namespace RwsMoraviaHomework.Deserializers
{
    public static class DeserializerFactory
    {
        public static IDeserializer CreateDeserializer(string sourceFilePath)
        {
            var sourceFileExtention = FileExtentionUtils.GetFileExtention(sourceFilePath);
            if (string.IsNullOrEmpty(sourceFileExtention))
            {
                throw new ArgumentException("Source extention is not defined.");
            }

            switch (sourceFileExtention)
            {
                case SupportedInputTypes.Json:
                    {
                        return new JsonFileDeserializer();
                    }
                case SupportedInputTypes.Xml:
                    {
                        return new XmlFileDeserializer();
                    }
                default:
                    {
                        throw new ArgumentException($"Source file type is not supported. These types are supported: {SupportedInputTypes.GetDescription()}.");
                    }
            }
        }
    }
}

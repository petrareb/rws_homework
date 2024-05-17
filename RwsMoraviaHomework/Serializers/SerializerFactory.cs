using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Contracts;
using RwsMoraviaHomework.Utils;

namespace RwsMoraviaHomework.Serializers
{
    public static class SerializerFactory
    {
        public static ISerializer CreateSerializer(string targetFilePath)
        {
            var targetFileExtention = FileExtentionUtils.GetFileExtention(targetFilePath);
            if (string.IsNullOrEmpty(targetFileExtention))
            {
                throw new ArgumentException("Target extention is not defined.");
            }

            switch (targetFileExtention)
            {
                case SupportedOutputTypes.Json:
                    {
                        return new JsonFileSerializer();
                    }
                case SupportedOutputTypes.Xml:
                    {
                        return new XmlFileSerializer();
                    }
                default:
                    {
                        throw new ArgumentException($"Target file type is not supported. These types are supported: {SupportedOutputTypes.GetDescription()}.");
                    }
            }
        }
    }
}

namespace RwsMoraviaHomework.Constants
{
    public static class SupportedOutputTypes
    {
        public const string Json = ".json";
        public const string Xml = ".xml";

        public static string GetDescription() => $"{Json} and {Xml}";
    }
}

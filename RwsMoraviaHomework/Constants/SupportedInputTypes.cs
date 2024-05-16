namespace RwsMoraviaHomework.Constants
{
    public static class SupportedInputTypes
    {
        public const string Json = ".json";
        public const string Xml = ".xml";

        public static string GetDescription() => $"{Json} and {Xml}";
    }
}

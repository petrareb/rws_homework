namespace RwsMoraviaHomework.Constants
{
    public static class SupportedStorages
    {
        public const string Cloud = "cloud";
        public const string FileSystem = "fs";

        public static string GetDescription() =>
            $"\"{FileSystem}\" for File System " +
            $"\"{Cloud}\" for Cloud.";
    }
}

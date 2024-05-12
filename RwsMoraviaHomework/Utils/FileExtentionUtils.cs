namespace RwsMoraviaHomework.Utils
{
    public static class FileExtentionUtils
    {
        public static string GetFileExtention(string sourceFileName)
        {
            var fileExtention = Path.GetExtension(sourceFileName);
            if (string.IsNullOrEmpty(fileExtention))
            {
                throw new ArgumentException("Invalid source file, unable to get file extention.");
            }

            return fileExtention;
        }
    }
}

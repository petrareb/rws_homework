using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Readers;
using RwsMoraviaHomework.Utils;
using RwsMoraviaHomework.Writers;

namespace Moravia.Homework
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Define path to the source file.");
            var relativeSourceFilePath = Console.ReadLine()?.Trim() ?? string.Empty;
            Console.WriteLine($"Define storage for source. {SupportedStorages.GetDescription()}");
            var sourceStorage = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            Console.WriteLine("Define path to the target file.");
            var relativeTargetFilePath = Console.ReadLine()?.Trim() ?? string.Empty;
            Console.WriteLine($"Define storage for target. {SupportedStorages.GetDescription()}");
            var targetStorage = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            var sourceFileName = Path.Combine(Environment.CurrentDirectory, relativeSourceFilePath);
            var targetFileName = Path.Combine(Environment.CurrentDirectory, relativeTargetFilePath);

            try
            {
                var reader = ReaderFactory.CreateFileReader(sourceFileName, sourceStorage);
                var writer = WriterFactory.CreateFileWriter(targetFileName, targetStorage);
                var converter = ConverterFactory.CreateConverter(sourceFileName, reader, writer);

                var targetFileExtention = FileExtentionUtils.GetFileExtention(targetFileName);
                converter.Convert(targetFileExtention);
            }
            catch (Exception ex)
            {
                WriteErrorMessage(ex.Message);
            }
        }

        private static void WriteErrorMessage(string message) => Console.Error.WriteLine(message);
    }
}
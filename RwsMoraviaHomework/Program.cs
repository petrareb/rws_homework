using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Readers;
using RwsMoraviaHomework.Writers;

namespace Moravia.Homework
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Define path to the source file.");
            var sourceFileName = Console.ReadLine()?.Trim() ?? string.Empty;
            Console.WriteLine($"Define storage for source. {SupportedStorages.GetDescription()}");
            var sourceStorage = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            Console.WriteLine("Define path to the target file.");
            var targetFileName = Console.ReadLine()?.Trim() ?? string.Empty;
            Console.WriteLine($"Define storage for target. {SupportedStorages.GetDescription()}");
            var targetStorage = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            try
            {
                var reader = ReaderFactory.CreateFileReader(sourceFileName, sourceStorage);
                var writer = WriterFactory.CreateFileWriter(targetFileName, targetStorage);
                var converter = ConverterFactory.CreateConverter(reader, writer);

                var targetFileExtention = writer.GetFileToWriteExtention();
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
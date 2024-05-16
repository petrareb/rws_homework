using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Readers;
using RwsMoraviaHomework.Writers;

namespace Moravia.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define path to the sorce and targer files
            //var relativeSourceFilePath = "..\\..\\..\\SourceFiles\\Document1.xml";
            //var relativeTargetFilePath = "..\\..\\..\\TargetFiles\\Document1.json";
            var sourceStorage = SupportedStorages.FileSystem; // skusit rozpoznat
            var targetStorage = SupportedStorages.FileSystem;
            var relativeSourceFilePath = "..\\..\\..\\..\\XmlInput.xml";
            var relativeTargetFilePath = "..\\..\\..\\..\\JsonOutput.json";

            var sourceFileName = Path.Combine(Environment.CurrentDirectory, relativeSourceFilePath);
            var targetFileName = Path.Combine(Environment.CurrentDirectory, relativeTargetFilePath);

            // TODO: var source = zistit z kade ide subor

            var reader = ReaderFactory.CreateFileReader(sourceFileName, sourceStorage);
            var writer = WriterFactory.CreateFileWriter(targetFileName, targetStorage);
            var converter = ConverterFactory.CreateConverter(sourceFileName, reader, writer);

            try
            {
                converter.Convert();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
using RwsMoraviaHomework.Constants;
using RwsMoraviaHomework.Deserializers;
using RwsMoraviaHomework.Readers;
using RwsMoraviaHomework.Serializers;
using RwsMoraviaHomework.Writers;

namespace Moravia.Homework
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("* Define path to the source file:");
            var sourceFileName = Console.ReadLine()?.Trim() ?? string.Empty;
            Console.WriteLine($"* Define storage for source ({SupportedStorages.GetDescription()}):");
            var sourceStorage = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            Console.WriteLine("* Define path to the target file:");
            var targetFileName = Console.ReadLine()?.Trim() ?? string.Empty;
            Console.WriteLine($"* Define storage for target ({SupportedStorages.GetDescription()}):");
            var targetStorage = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            Console.WriteLine();

            try
            {
                var reader = ReaderFactory.CreateFileReader(sourceStorage);
                var deserializer = DeserializerFactory.CreateDeserializer(sourceFileName);
                var serializer = SerializerFactory.CreateSerializer(targetFileName);
                var writer = WriterFactory.CreateFileWriter(targetStorage);

                var fileContent = reader.ReadFromFile(sourceFileName);
                var deserializedContent = deserializer.Deserialize(fileContent);
                var serializedContent = serializer.Serialize(deserializedContent);
                writer.WriteToFile(targetFileName, serializedContent);
            }
            catch (Exception ex)
            {
                WriteErrorMessage(ex.Message);
            }
        }

        private static void WriteErrorMessage(string message) => Console.Error.WriteLine(message);
    }
}
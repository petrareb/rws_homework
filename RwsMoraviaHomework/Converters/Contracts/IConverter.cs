namespace RwsMoraviaHomework.Converters.Contracts
{
    public interface IConverter
    {
        public void Convert(string targetFileExtention);
        public void ConvertToJson();
        public void ConvertToXml();
    }
}

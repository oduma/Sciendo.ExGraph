using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Sciendo.Csv.Processor.TypeConverters
{
    internal class ArtistIdTypeConverter:ITypeConverter
    {
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.ToString();
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return new Guid(text);
        }
    }
}
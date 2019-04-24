using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.Csv.Processor.TypeConverters
{
    public class MembersFlattenTypeConverter:ITypeConverter
    {
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return string.Join(";",(List<Artist>)value);
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            List<Artist> result = new List<Artist>();
            foreach (var member in text.Split(new []{";"},StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(new Artist{Name=member});
            }

            return result;
        }
    }
}
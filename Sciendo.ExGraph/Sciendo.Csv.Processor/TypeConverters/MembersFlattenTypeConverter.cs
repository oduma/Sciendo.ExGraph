using System;
using System.Collections.Generic;
using System.Linq;
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
            if(value!=null)
                return string.Join(";",((List<Artist>)value).Select(a=>a.Name));
            return string.Empty;
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
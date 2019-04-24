using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace Sciendo.Csv.Processor
{
    public static class IOManager
    {
        public static void WriteWithMapper<T, TMapper>(IEnumerable<T> input, string filePath) where TMapper : ClassMap
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.RegisterClassMap<TMapper>();
                csv.WriteRecords(input);
            }
        }

        public static List<T> ReadWithMapper<T, TMapper>(string filePath) where TMapper : ClassMap<T>
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<TMapper>();
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}

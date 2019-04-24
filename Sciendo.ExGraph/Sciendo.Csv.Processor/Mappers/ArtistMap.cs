using CsvHelper.Configuration;
using Sciendo.Csv.Processor.TypeConverters;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.Csv.Processor.Mappers
{
    public class ArtistMap:ClassMap<Artist>
    {
        public ArtistMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.ArtistId).Name("Id").TypeConverter<ArtistIdTypeConverter>();
        }
    }
}

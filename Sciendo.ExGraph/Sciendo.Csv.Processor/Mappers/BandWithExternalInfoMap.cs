using CsvHelper.Configuration;
using Sciendo.Csv.Processor.TypeConverters;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.Csv.Processor.Mappers
{
    public class BandWithExternalInfoMap:ClassMap<BandWithExternalInfo>
    {
        public BandWithExternalInfoMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.ArtistId).Name("Id").TypeConverter<ArtistIdTypeConverter>();
            Map(m => m.ExternalInfoIdentifier).Name("ExternalInfoId");
            Map(m => m.Members).Name("Members").TypeConverter<MembersFlattenTypeConverter>();
        }
    }
}

using CsvHelper.Configuration;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.Csv.Processor.Mappers
{
    public class BandWithPossibleMemberMap:ClassMap<BandWithPossibleMember>
    {
        public BandWithPossibleMemberMap()
        {
            Map(m => m.Band.Name).Name("BandName");
            Map(m => m.Band.ArtistId).Name("BandId");
            Map(m => m.Member.Name).Name("MemberName");
            Map(m => m.Member.ArtistId).Name("MemberId");
            Map(m => m.TrackId).Name("TracKId");
        }
    }
}

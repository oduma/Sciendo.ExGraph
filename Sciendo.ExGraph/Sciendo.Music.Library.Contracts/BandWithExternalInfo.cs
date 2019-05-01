using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Music.Library.Contracts
{
    public class BandWithExternalInfo:Artist
    {
        public BandWithExternalInfo()
        {

        }
        public BandWithExternalInfo(Artist artist)
        {
            Name = artist.Name;
            ArtistId = artist.ArtistId;
        }

        public long ExternalInfoIdentifier { get; set; }

        public LanguageType LanguageType { get; set; }

        public List<Artist> Members { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Music.Library.Contracts
{
    public class BandWithPossibleMember
    {
        public Artist Band { get; set; }

        public Guid TrackId { get; set; }

        public Artist Member { get; set; }

    }
}

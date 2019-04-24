using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.Music.Library.Contracts;
using Sciendo.Neo4J.Provider;

namespace Sciendo.ExGraph.Process
{
    public class Neo4jBandWithPossibleMember
    {
        [Neo4jProperty("band", Neo4jType.Node)]
        public Neo4jArtist Band { get; set; }

        [Neo4jProperty("track.trackID", Neo4jType.None)]
        public Guid TrackId { get; set; }

        [Neo4jProperty("member", Neo4jType.Node)]
        public Neo4jArtist Member { get; set; }

        public static implicit operator Neo4jBandWithPossibleMember(BandWithPossibleMember fromType)
        {
            Neo4jBandWithPossibleMember neo4JBandWithPossibleMember=new Neo4jBandWithPossibleMember();
            neo4JBandWithPossibleMember.Band = fromType.Band;
            neo4JBandWithPossibleMember.Member = fromType.Member;
            neo4JBandWithPossibleMember.TrackId = fromType.TrackId;
            return neo4JBandWithPossibleMember;
        }

        public static implicit operator BandWithPossibleMember(Neo4jBandWithPossibleMember fromType)
        {
            BandWithPossibleMember bandWithPossibleMember= new BandWithPossibleMember();
            bandWithPossibleMember.Band = fromType.Band;
            bandWithPossibleMember.Member = fromType.Member;
            bandWithPossibleMember.TrackId = fromType.TrackId;
            return bandWithPossibleMember;
        }
    }
}

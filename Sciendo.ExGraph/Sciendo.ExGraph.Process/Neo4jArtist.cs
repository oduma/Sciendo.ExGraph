using System;
using Sciendo.Music.Library.Contracts;
using Sciendo.Neo4J.Provider;

namespace Sciendo.ExGraph.Process
{
    public class Neo4jArtist
    {
        [Neo4jProperty("name",Neo4jType.None)]
        [Neo4jProperty("band.name",Neo4jType.None)]
        public string Name { get; set; }
        [Neo4jProperty("artistID", Neo4jType.None)]
        [Neo4jProperty("band.artistID",Neo4jType.None)]
        public Guid ArtistId { get; set; }

        public static implicit operator Neo4jArtist(Artist fromType)
        {
            Neo4jArtist neo4JArtist= new Neo4jArtist();
            neo4JArtist.Name = fromType.Name;
            neo4JArtist.ArtistId = fromType.ArtistId;
            return neo4JArtist;
        }

        public static implicit operator Artist(Neo4jArtist fromType)
        {
            Artist artist = new Artist();
            artist.Name = fromType.Name;
            artist.ArtistId = fromType.ArtistId;
            return artist;
        }
    }
}
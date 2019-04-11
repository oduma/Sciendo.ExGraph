using System;
using Sciendo.ExGraph.Process;

namespace SEC
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var query = new GetPossibleBandMembers("bolt://localhost:7687", "neo4j", "password"))
            {
                var results = query.GetGraphObjects();
                foreach (var result in results)
                {
                    Console.WriteLine("Band {0} with id {1} through Track {2} has potential member {3} with id {4}",
                        result.Band.Name, result.Band.ArtistId, result.Track, result.Member.Name,
                        result.Member.ArtistId);
                }
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Neo4j.Driver.V1;
using Sciendo.Neo4J.Provider;

namespace Sciendo.ExGraph.Process
{
    public class GetAllBands:GetGraphObjectsBase<Neo4jArtist>
    {
        public GetAllBands(string url, string userName, string password) : base(url, userName, password)
        {
        }

        protected override IEnumerable<Neo4jArtist> ExecuteQueryWithReturn(ITransaction tx)
        {
            var result =
                tx.Run("match (band:Band) return band.name, band.artistID");
            return result.Select(CastNeo4jObject);
        }
    }
}

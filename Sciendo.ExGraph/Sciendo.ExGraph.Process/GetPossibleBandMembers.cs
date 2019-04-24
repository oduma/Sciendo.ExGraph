using System.Collections.Generic;
using System.Linq;
using Neo4j.Driver.V1;
using Sciendo.Neo4J.Provider;

namespace Sciendo.ExGraph.Process
{
    public class GetPossibleBandMembers:GetGraphObjectsBase<Neo4jBandWithPossibleMember>
    {
        public GetPossibleBandMembers(string url, string userName, string password) : base(url, userName, password)
        {
        }

        protected override IEnumerable<Neo4jBandWithPossibleMember> ExecuteQueryWithReturn(ITransaction tx)
        {
            var result =
                tx.Run("match (member:Artist)-[:COMPOSED]-(track:Track)-[:RELEASED]-(band:Band) return distinct band,member order by band.name");
            return result.Select(CastNeo4jObject);
        }
    }
}

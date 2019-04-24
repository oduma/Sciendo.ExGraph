using System.Collections.Generic;
using System.Linq;
using Neo4j.Driver.V1;
using Sciendo.Neo4J.Provider;

namespace Sciendo.ExGraph.Process
{
    public class GetComposersNotBandMembers: GetGraphObjectsBase<Neo4jBandWithPossibleMember>
    {
        public GetComposersNotBandMembers(string url, string userName, string password) : base(url, userName, password)
        {
        }

        protected override IEnumerable<Neo4jBandWithPossibleMember> ExecuteQueryWithReturn(ITransaction tx)
        {
            var result =
                tx.Run("match (composer:Artist)-[composed:COMPOSED]-(track:Track)-[:RELEASED]-(band:Band) with collect(composer) as composers,band match (member:Artist)-[:MEMBER_OF]->(band) with composers, band, collect(member) as members with filter(x in composers WHERE not x IN members) as nonMembers, band unwind nonMembers as member return distinct member, band order by band.name, member.name");
            return result.Select(CastNeo4jObject);
        }
    }
}

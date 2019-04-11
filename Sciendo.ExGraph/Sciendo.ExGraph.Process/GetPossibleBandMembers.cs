using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4j.Driver.V1;

namespace Sciendo.ExGraph.Process
{
    public class GetPossibleBandMembers:GetGraphObjectsBase<PossibleBandMembers>
    {
        public GetPossibleBandMembers(string url, string userName, string password) : base(url, userName, password)
        {
        }

        protected override IEnumerable<PossibleBandMembers> ExecuteQueryWithReturn(ITransaction tx)
        {
            var result =
                tx.Run("match (r:Artist)-[:COMPOSED]-(a:Track)-[:RELEASED]-(p:Band) return p,a.trackID,r limit 20");
            var res1 = result.Cast<PossibleBandMembers>();
            return res1;
        }
    }
}

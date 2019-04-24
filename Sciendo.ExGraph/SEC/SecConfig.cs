using Sciendo.Config;
using Sciendo.Neo4J.Provider;

namespace SEC
{
    public class SecConfig
    {
        [ConfigProperty("Output")]
        public string OutputFile { get; set; }

        [ConfigProperty("Action")]
        public ActionType ActionType { get; set; }

        [ConfigProperty("neo4jConfig")]
        public Neo4jConfig Neo4JConfig { get; set; }
    }
}
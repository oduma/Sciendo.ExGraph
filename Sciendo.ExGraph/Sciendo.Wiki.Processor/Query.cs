using Newtonsoft.Json;

namespace Sciendo.Wiki.Processor
{
    public class Query
    {
        [JsonProperty("searchinfo")]
        public SearchInfo SearchInfo { get; set; }

        [JsonProperty("search")]
        public SearchResult[] SearchResults { get; set; }
    }
}
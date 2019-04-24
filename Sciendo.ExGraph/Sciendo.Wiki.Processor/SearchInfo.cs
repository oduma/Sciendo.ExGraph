using Newtonsoft.Json;

namespace Sciendo.Wiki.Processor
{
    public class SearchInfo
    {
        [JsonProperty("totalhits")]
        public int TotalHits { get; set; }
    }
}
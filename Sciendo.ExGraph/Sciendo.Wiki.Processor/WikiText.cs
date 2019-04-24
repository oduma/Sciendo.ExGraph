using Newtonsoft.Json;

namespace Sciendo.Wiki.Processor
{
    public class WikiText
    {
        [JsonProperty("*")]
        public string AllText { get; set; }
    }
}
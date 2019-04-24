using Newtonsoft.Json;

namespace Sciendo.Wiki.Processor
{
    public class PageInfo
    {
        [JsonProperty("sroffset")]
        public int Offset { get; set; }

        [JsonProperty("continue")]
        public string Continuation { get; set; }

    }
}
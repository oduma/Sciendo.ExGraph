using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Sciendo.Wiki.Processor
{
    public class WikiSearch : WikiAccessBase,IWikiSearch
    {
        public WikiSearch(UrlProviderBase urlProvider):base(urlProvider)
        {
        }

        public void Search(string text)
        {
            string wikiSearchResult = GetWikiResult(_urlProvider.GetUri(text));
            if (!string.IsNullOrEmpty(wikiSearchResult))
            {
                var searchResult= JsonConvert.DeserializeObject<WikiSearch>(wikiSearchResult);
                this.Query = searchResult.Query;
                this.BatchComplete = searchResult.BatchComplete;
                this.PageInfo = searchResult.PageInfo;
            }
        }

        [JsonProperty("batchcomplete")]
        public string BatchComplete { get; set; }
        [JsonProperty("continue")]
        public PageInfo PageInfo { get; set; }
        [JsonProperty("query")]
        public Query Query { get; set; }
    }
}

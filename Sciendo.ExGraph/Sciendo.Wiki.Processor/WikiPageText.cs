using Newtonsoft.Json;

namespace Sciendo.Wiki.Processor
{
    public class WikiPageText : WikiAccessBase,IWikiPageText
    {
        public void LoadPage(long pageId)
        {
            string wikiResult = GetWikiResult(_urlProvider.GetUri(pageId));

            if (!string.IsNullOrEmpty(wikiResult))
            {
                var pageResult = JsonConvert.DeserializeObject<WikiPageText>(wikiResult);
                this.ParsedPage = pageResult.ParsedPage;
            }

        }

        [JsonProperty("parse")]
        public ParsedPage ParsedPage { get; set; }

        public WikiPageText(UrlProviderBase urlProvider) : base(urlProvider)
        {
        }
    }
}

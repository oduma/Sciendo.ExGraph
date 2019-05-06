namespace Sciendo.Wiki.Processor.SearchUrlProviders
{
    public class SpanishSearchUrlProvider:SearchUrlProviderBase
    {
        protected override string TemplateUrl => "https://es.wikipedia.org/w/api.php?action=query&list=search&srsearch={0}&format=json";
    }
}

namespace Sciendo.Wiki.Processor.SearchUrlProviders
{
    public class GermanSearchUrlProvider:SearchUrlProviderBase
    {
        protected override string TemplateUrl => "https://de.wikipedia.org/w/api.php?action=query&list=search&srsearch={0}&format=json";
    }
}

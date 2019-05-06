namespace Sciendo.Wiki.Processor.SearchUrlProviders
{
    public class EnglishSearchUrlProvider:SearchUrlProviderBase
    {
        protected override string TemplateUrl => "https://en.wikipedia.org/w/api.php?action=query&list=search&srsearch={0}&format=json";
    }
}

namespace Sciendo.Wiki.Processor.SearchUrlProviders
{
    public class ProtugueseSearchUrlProvider : SearchUrlProviderBase
    {
        protected override string TemplateUrl => "https://pt.wikipedia.org/w/api.php?action=query&list=search&srsearch={0}&format=json";
    }
}

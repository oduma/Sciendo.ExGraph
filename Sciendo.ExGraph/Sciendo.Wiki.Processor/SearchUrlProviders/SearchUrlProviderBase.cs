using System;

namespace Sciendo.Wiki.Processor.SearchUrlProviders
{
    public abstract class SearchUrlProviderBase: UrlProviderBase
    {
        public override Uri GetUri(params object[] variables)
        {
                
            return new Uri(string.Format(TemplateUrl, variables[0].ToString().Replace(" ", "_").Replace("&","%26").Replace("'","%27").Replace("+","%2B")));
        }

    }
}

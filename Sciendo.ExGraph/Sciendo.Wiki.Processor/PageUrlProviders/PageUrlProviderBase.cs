using System;

namespace Sciendo.Wiki.Processor.PageUrlProviders
{
    public abstract class PageUrlProviderBase:UrlProviderBase
    {

        public override Uri GetUri(params object[] variables)
        {
            return new Uri(string.Format(TemplateUrl, variables[0]));
        }
    }
}

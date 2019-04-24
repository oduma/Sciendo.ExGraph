using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor
{
    public class PageUrlProvider:UrlProviderBase
    {
        protected override string TemplateUrl =>
            "https://en.wikipedia.org/w/api.php?action=parse&pageid={0}&format=json&prop=wikitext";

        public override Uri GetUri(params object[] variables)
        {
            return new Uri(string.Format(TemplateUrl, variables[0]));
        }
    }
}

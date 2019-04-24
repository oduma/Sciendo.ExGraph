using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor
{
    public class SearchUrlProvider:UrlProviderBase
    {
        protected override string TemplateUrl => "https://en.wikipedia.org/w/api.php?action=query&list=search&srsearch={0}&format=json";

        public override Uri GetUri(params object[] variables)
        {
            return new Uri(string.Format(TemplateUrl, variables[0].ToString().Replace(" ", "_")));
        }
    }
}

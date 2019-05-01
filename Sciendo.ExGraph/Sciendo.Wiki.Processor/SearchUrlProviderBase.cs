using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor
{
    public abstract class SearchUrlProviderBase: UrlProviderBase
    {
        public override Uri GetUri(params object[] variables)
        {
                
            return new Uri(string.Format(TemplateUrl, variables[0].ToString().Replace(" ", "_").Replace("&","%26")));
        }

    }
}

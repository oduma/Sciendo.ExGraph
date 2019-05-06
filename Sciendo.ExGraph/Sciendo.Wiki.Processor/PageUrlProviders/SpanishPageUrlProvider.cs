using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor.PageUrlProviders
{
    public class SpanishPageUrlProvider:PageUrlProviderBase
    {
        protected override string TemplateUrl =>
            "https://es.wikipedia.org/w/api.php?action=parse&pageid={0}&format=json&prop=wikitext";

    }
}

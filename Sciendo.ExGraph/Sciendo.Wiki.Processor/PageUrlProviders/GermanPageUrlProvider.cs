using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor.PageUrlProviders
{
    public class GermanPageUrlProvider:PageUrlProviderBase
    {
        protected override string TemplateUrl =>
            "https://de.wikipedia.org/w/api.php?action=parse&pageid={0}&format=json&prop=wikitext";

    }
}

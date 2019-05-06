using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor.PageUrlProviders
{
    public class SwedishPageUrlProvider:PageUrlProviderBase
    {
        protected override string TemplateUrl =>
            "https://sv.wikipedia.org/w/api.php?action=parse&pageid={0}&format=json&prop=wikitext";

    }
}

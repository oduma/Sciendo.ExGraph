using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor.PageUrlProviders
{
    public class EnglishPageUrlProvider:PageUrlProviderBase
    {
        protected override string TemplateUrl =>
            "https://en.wikipedia.org/w/api.php?action=parse&pageid={0}&format=json&prop=wikitext";

    }
}

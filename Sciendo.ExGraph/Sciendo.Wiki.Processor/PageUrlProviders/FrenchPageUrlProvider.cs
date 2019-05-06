using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor.PageUrlProviders
{
    public class FrenchPageUrlProvider:PageUrlProviderBase
    {
        protected override string TemplateUrl =>
            "https://fr.wikipedia.org/w/api.php?action=parse&pageid={0}&format=json&prop=wikitext";

    }
}

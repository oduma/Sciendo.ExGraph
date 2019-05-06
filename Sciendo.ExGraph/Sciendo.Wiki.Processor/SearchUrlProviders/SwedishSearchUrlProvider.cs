using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor.SearchUrlProviders
{
    public class SwedishSearchUrlProvider:SearchUrlProviderBase
    {
        protected override string TemplateUrl => "https://sv.wikipedia.org/w/api.php?action=query&list=search&srsearch={0}&format=json";
    }
}

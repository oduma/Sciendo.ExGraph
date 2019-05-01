using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor
{
    public class GermanSearchUrlProvider:SearchUrlProviderBase
    {
        protected override string TemplateUrl => "https://de.wikipedia.org/w/api.php?action=query&list=search&srsearch={0}&format=json";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor
{
    public class FrenchSearchUrlProvider:SearchUrlProviderBase
    {
        protected override string TemplateUrl => "https://fr.wikipedia.org/w/api.php?action=query&list=search&srsearch={0}&format=json";
    }
}

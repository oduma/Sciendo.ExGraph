using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.Wiki.Processor
{
    public abstract class UrlProviderBase
    {
        protected abstract string TemplateUrl { get;}

        public abstract Uri GetUri(params object[] variables);
    }
}

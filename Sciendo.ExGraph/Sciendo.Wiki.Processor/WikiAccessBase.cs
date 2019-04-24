using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sciendo.Wiki.Processor
{
    public abstract class WikiAccessBase
    {
        protected readonly UrlProviderBase _urlProvider;

        protected WikiAccessBase(UrlProviderBase urlProvider)
        {
            _urlProvider = urlProvider;
        }

        protected string GetWikiResult(Uri url)
        {
            var httpClient = new HttpClient();
            try
            {
                using (var getTask = httpClient.GetStringAsync(url)
                    .ContinueWith(p => p).Result)
                {
                    if (getTask.Status == TaskStatus.RanToCompletion || !string.IsNullOrEmpty(getTask.Result))
                    {
                        return getTask.Result;
                    }
                    return string.Empty;
                }
            }
            catch (Exception e)
            {
                return string.Empty;
            }

        }

    }
}

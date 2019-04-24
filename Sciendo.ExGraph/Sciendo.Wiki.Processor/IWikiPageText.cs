using System.Collections.Generic;

namespace Sciendo.Wiki.Processor
{
    public interface IWikiPageText
    {
        void LoadPage(long pageId);
        ParsedPage ParsedPage { get; set; }
    }
}
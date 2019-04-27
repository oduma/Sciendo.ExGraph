using System.Collections.Generic;
using Sciendo.BandMembers.Processor;
using Sciendo.Music.Library.Contracts;
using Sciendo.Wiki.Processor;

namespace Sciendo.Music.Library.BusinessLogic
{
    public interface IBandWithExternalInfoComponent
    {
        BandWithExternalInfo LoadExternalInfoIdFromSource(Artist artist, IWikiSearch wikiSearch);

        BandWithExternalInfo LoadMembersFromSource(BandWithExternalInfo band,IWikiPageText wikiPageText,ProcessingRulesEngine processingRulesEngine);

        IEnumerable<BandWithPossibleMember> CleanMembers(BandWithExternalInfo band, ProcessingRulesEngine processingRulesEngine);


    }
}

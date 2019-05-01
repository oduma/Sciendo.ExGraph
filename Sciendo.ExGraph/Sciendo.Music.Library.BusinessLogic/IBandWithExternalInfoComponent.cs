using System.Collections.Generic;
using Sciendo.BandMembers.Processor;
using Sciendo.Music.Library.Contracts;
using Sciendo.Wiki.Processor;

namespace Sciendo.Music.Library.BusinessLogic
{
    public interface IBandWithExternalInfoComponent
    {
        BandWithExternalInfo LoadExternalInfoFromSource(Artist artist, Dictionary<LanguageType,IWikiSearch> wikiSearches);

        BandWithExternalInfo LoadMembersFromSource(BandWithExternalInfo band,IWikiPageText wikiPageText,ProcessingRulesEngine processingRulesEngine);

        IEnumerable<BandWithPossibleMember> CleanMembers(BandWithExternalInfo band, ProcessingRulesEngine processingRulesEngine);


    }
}

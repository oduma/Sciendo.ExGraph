using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.Music.Library.Contracts;
using Sciendo.Wiki.Processor;
using Sciendo.Wiki.Processor.PageUrlProviders;
using Sciendo.Wiki.Processor.SearchUrlProviders;

namespace Sciendo.Music.Library.BusinessLogic
{
    public static class ExtensionMethods
    {
        public static BandWithExternalInfo LoadWikiPageId(this Artist artist)
        {
            BandWithWikiInfo bandWithWikiInfo = new BandWithWikiInfo();
            return bandWithWikiInfo.LoadExternalInfoFromSource(artist,
                new Dictionary<LanguageType, IWikiSearch>
                {
                    {LanguageType.English, new WikiSearch(new EnglishSearchUrlProvider())},
                    {LanguageType.Spanish, new WikiSearch(new SpanishSearchUrlProvider())},
                    {LanguageType.French, new WikiSearch(new FrenchSearchUrlProvider())},
                    {LanguageType.German, new WikiSearch(new GermanSearchUrlProvider()) },
                    {LanguageType.Portuguese, new WikiSearch(new ProtugueseSearchUrlProvider()) },
                    {LanguageType.Swedish,new WikiSearch(new SwedishSearchUrlProvider()) },
                });
        }

        public static BandWithExternalInfo LoadWikiPageMembers(this BandWithExternalInfo bandWithExternalInfo, 
            string knowledgeBaseFolder)
        {
            var bandWithWiki = new BandWithWikiInfo();

            return bandWithWiki.LoadMembersFromSource(bandWithExternalInfo,
                new WikiPageText(GetPageUrlProvider(bandWithExternalInfo.LanguageType)),
                new ExtractBandMembersFromWikiEngine(knowledgeBaseFolder,bandWithExternalInfo.LanguageType));
        }

        private static UrlProviderBase GetPageUrlProvider(LanguageType languageType)
        {
            switch (languageType)
            {
                case LanguageType.English:
                    return new EnglishPageUrlProvider();
                case LanguageType.French:
                    return new FrenchPageUrlProvider();
                case LanguageType.German:
                    return new GermanPageUrlProvider();
                case LanguageType.Portuguese:
                    return new PortuguesePageUrlProvider();
                case LanguageType.Spanish:
                    return new SpanishPageUrlProvider();
                case LanguageType.Swedish:
                    return  new SwedishPageUrlProvider();
                default:
                    return new EnglishPageUrlProvider();
            }
        }

        public static IEnumerable<BandWithPossibleMember> CleanWikiPageMembers(this BandWithExternalInfo bandWithExternalInfo, string knowledgeBaseFolder, string simpleWordsSeparator)
        {
            var bandWithWiki = new BandWithWikiInfo();
            return bandWithWiki.CleanMembers(bandWithExternalInfo, new CleanMembersFromWikiEngine(knowledgeBaseFolder,simpleWordsSeparator));
        }



    }
}

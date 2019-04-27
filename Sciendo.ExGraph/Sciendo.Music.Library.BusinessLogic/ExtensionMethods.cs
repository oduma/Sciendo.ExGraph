using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.Music.Library.Contracts;
using Sciendo.Wiki.Processor;

namespace Sciendo.Music.Library.BusinessLogic
{
    public static class ExtensionMethods
    {
        public static BandWithExternalInfo LoadWikiPageId(this Artist artist)
        {
            BandWithWikiInfo bandWithWikiInfo = new BandWithWikiInfo();
            return bandWithWikiInfo.LoadExternalInfoIdFromSource(artist, new WikiSearch(new SearchUrlProvider()));
        }

        public static BandWithExternalInfo LoadWikiPageMembers(this BandWithExternalInfo bandWithExternalInfo, string knowledgeBaseFolder)
        {
            var bandWithWiki = new BandWithWikiInfo();
            return bandWithWiki.LoadMembersFromSource(bandWithExternalInfo, new WikiPageText(new PageUrlProvider()),
                new ExtractBandMembersFromWikiEngine(knowledgeBaseFolder));
        }

        public static IEnumerable<BandWithPossibleMember> CleanWikiPageMembers(this BandWithExternalInfo bandWithExternalInfo, string knowledgeBaseFolder, string simpleWordsSeparator)
        {
            var bandWithWiki = new BandWithWikiInfo();
            return bandWithWiki.CleanMembers(bandWithExternalInfo, new CleanMembersFromWikiEngine(knowledgeBaseFolder,simpleWordsSeparator));
        }



    }
}

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor.Tests.Unit
{
    [TestClass]
    public class TestProcessors
    {
        [TestMethod]
        public void TestWikiCleanMemberOfMarkdownCharacters()
        {
            var wikiClean = new WikiCleanMemberOfMarkdownCharactersRule(new KnowledgeBaseLoaderStringArray("knowledgebase"),100 );
            var result = wikiClean.ApplyRule("[http://dillanwheeler.com/ Dillan Wheeler]");
            Assert.IsTrue(result.All(r=>!r.Contains("]")));
        }

        [TestMethod]
        public void TestWikiExcludeIfArtistContainsRule()
        {
            var wikiClean = new WikiExcludeIfArtistContainsRule(new KnowledgeBaseLoaderStringArray("knowledgebase"), 100);
            var result = wikiClean.ApplyRule("1967–present").ToList();
            Assert.IsTrue(result.Count==0);
        }
    }
}

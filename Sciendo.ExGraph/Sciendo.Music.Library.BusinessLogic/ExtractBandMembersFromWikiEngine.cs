using Sciendo.BandMembers.Processor;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.Music.Library.BusinessLogic
{
    public class ExtractBandMembersFromWikiEngine:ProcessingRulesEngine
    {
        private readonly string _knowledgeBaseFolder;

        public ExtractBandMembersFromWikiEngine(string knowledgeBaseFolder)
        {
            _knowledgeBaseFolder = knowledgeBaseFolder;
            LoadSetOfRules();
        }
        protected override void LoadSetOfRules()
        {
            RegisterProcessingRule(new WikiPageTextExtractMembersAreasRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), 100));
            RegisterProcessingRule(new WikiExcludeAllHtmlCommentsAndRefsRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), 150));
            RegisterProcessingRule(new WikiIndividualMembersExtractRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), 200));

        }
    }
}

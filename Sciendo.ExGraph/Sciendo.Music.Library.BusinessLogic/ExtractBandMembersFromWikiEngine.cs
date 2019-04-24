using Sciendo.BandMembers.Processor;

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
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), "WikiPageTextExtractMemberAreasRule", 100));
            RegisterProcessingRule(new WikiIndividualMembersExtractRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), "WikiIndividualMembersExtractRule", 200));

        }
    }
}

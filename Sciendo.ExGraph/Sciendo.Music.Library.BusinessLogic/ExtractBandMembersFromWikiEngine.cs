using Sciendo.BandMembers.Processor;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.Music.Library.BusinessLogic
{
    public class ExtractBandMembersFromWikiEngine:ProcessingRulesEngine
    {
        private readonly string _knowledgeBaseFolder;
        private LanguageType _languageType;

        public ExtractBandMembersFromWikiEngine(string knowledgeBaseFolder)
        {
            _knowledgeBaseFolder = knowledgeBaseFolder;
            LoadSetOfRules();
        }

        public ExtractBandMembersFromWikiEngine(string knowledgeBaseFolder, LanguageType languageType)
        {
            _knowledgeBaseFolder = knowledgeBaseFolder;
            _languageType = languageType;
            LoadSetOfRules();
        }
        protected override void LoadSetOfRules()
        {
            RegisterProcessingRule(new WikiPageTextExtractMembersAreasRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), 100,_languageType));
            RegisterProcessingRule(new WikiExcludeAllHtmlCommentsAndRefsRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), 150));
            RegisterProcessingRule(new WikiIndividualMembersExtractRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), 200));

        }
    }
}

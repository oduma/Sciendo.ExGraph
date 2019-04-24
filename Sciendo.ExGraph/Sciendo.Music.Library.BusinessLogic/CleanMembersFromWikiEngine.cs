using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.BandMembers.Processor;

namespace Sciendo.Music.Library.BusinessLogic
{
    public class CleanMembersFromWikiEngine:ProcessingRulesEngine
    {
        private readonly string _knowledgeBaseFolder;

        public CleanMembersFromWikiEngine(string knowledgeBaseFolder)
        {
            _knowledgeBaseFolder = knowledgeBaseFolder;
            LoadSetOfRules();
        }
        protected override void LoadSetOfRules()
        {
            RegisterProcessingRule(new WikiCleanMemberOfMarkdownCharactersRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), "WikiCleanMemberOfMarkdownCharactersRule", 100));
        }
    }
}

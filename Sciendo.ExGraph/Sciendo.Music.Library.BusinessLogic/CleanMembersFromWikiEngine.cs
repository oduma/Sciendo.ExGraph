using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.BandMembers.Processor;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.Music.Library.BusinessLogic
{
    public class CleanMembersFromWikiEngine:ProcessingRulesEngine
    {
        private readonly string _knowledgeBaseFolder;
        private readonly string _simpleWordsSeparator;

        public CleanMembersFromWikiEngine(string knowledgeBaseFolder, string simpleWordsSeparator)
        {
            _knowledgeBaseFolder = knowledgeBaseFolder;
            _simpleWordsSeparator = simpleWordsSeparator;
            LoadSetOfRules();
        }
        protected override void LoadSetOfRules()
        {
            RegisterProcessingRule(new WikiCleanMemberOfMarkdownCharactersRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder),  100));
            RegisterProcessingRule(new TransformToLowerTrimmedSimpleLatinRule(
                new KnowledgeBaseLoaderDictionaryStringString(_knowledgeBaseFolder), 200));
            RegisterProcessingRule(new TransformHtmlEncodedSequenceToTextRule(
                new KnowledgeBaseLoaderDictionaryStringString(_knowledgeBaseFolder), 250));
            RegisterProcessingRule(new WikiExcludeFullNonArtistsRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder),  300));
            RegisterProcessingRule(new WikiExcludeIfArtistContainsRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), 400));
            RegisterProcessingRule(new WikiExcludeWordsStartingWithRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), _simpleWordsSeparator,500));
            RegisterProcessingRule(new WikiExcludeArtistsNotContainingAnyAlphaCharactersRule(
                new KnowledgeBaseLoaderStringArray(_knowledgeBaseFolder), 600));



        }
    }
}

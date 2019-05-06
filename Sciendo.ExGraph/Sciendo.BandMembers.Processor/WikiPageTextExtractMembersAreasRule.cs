using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.BandMembers.Processor
{
    public class WikiPageTextExtractMembersAreasRule:IProcessingRule
    {

        public WikiPageTextExtractMembersAreasRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader,  int rulePriority)
        {
            RulePriority = rulePriority;
            _regexPatternsForMembers = knowledgeBaseLoader.LoadLanguageNeutralKnowledgeBaseObject(this.GetType().Name);
        }

        public WikiPageTextExtractMembersAreasRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, int rulePriority,
            LanguageType languageType) : this(knowledgeBaseLoader, rulePriority)
        {
            _regexPatternsForMembers =
                knowledgeBaseLoader.LoadKnowledgeBaseObjectForLanguage(this.GetType().Name, languageType);
        }
        private readonly string[] _regexPatternsForMembers;
        public IEnumerable<string> ApplyRule(string input)
        {
            if (string.IsNullOrEmpty(input)) yield break;
            foreach (var regexPatternFormMembers in _regexPatternsForMembers)
            {
                var possibleMatch = Regex.Match(input, regexPatternFormMembers);
                if (possibleMatch.Success)
                    yield return possibleMatch.Value;
            }
        }
        public int RulePriority { get; private set; }
    }
}

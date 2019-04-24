using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.BandMembers.Processor
{
    public class WikiCleanMemberOfMarkdownCharactersRule:IProcessingRule
    {

        private readonly string[] _wikiPediaCharacters;
        public WikiCleanMemberOfMarkdownCharactersRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, string ruleName, int rulePriority)
        {
            RuleName = ruleName;
            RulePriority = rulePriority;
            _wikiPediaCharacters=knowledgeBaseLoader.LoadKnowledgeBaseObject(RuleName);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            string bandMember = string.Empty;
            foreach (var wikiPediaCharacter in _wikiPediaCharacters)
            {
                bandMember = input.Replace(wikiPediaCharacter, "");
            }

            return new []{bandMember};
        }

        public string RuleName { get; }
        public int RulePriority { get; set; }
    }
}

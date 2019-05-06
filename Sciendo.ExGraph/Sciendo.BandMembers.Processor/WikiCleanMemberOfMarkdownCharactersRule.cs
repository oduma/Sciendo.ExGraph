using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiCleanMemberOfMarkdownCharactersRule:IProcessingRule
    {

        private readonly string[] _wikiPediaCharacters;
        public WikiCleanMemberOfMarkdownCharactersRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, int rulePriority)
        {
            RulePriority = rulePriority;
            _wikiPediaCharacters=knowledgeBaseLoader.LoadLanguageNeutralKnowledgeBaseObject(this.GetType().Name);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            foreach (var wikiPediaCharacter in _wikiPediaCharacters)
            {
                input = input.Replace(wikiPediaCharacter, "");
            }

            yield return input;
        }

        public int RulePriority { get; set; }
    }
}

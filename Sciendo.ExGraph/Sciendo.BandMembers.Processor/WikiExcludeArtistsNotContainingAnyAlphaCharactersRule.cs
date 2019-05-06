using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiExcludeArtistsNotContainingAnyAlphaCharactersRule:IProcessingRule
    {
        private string[] _matchPatterns;

        public WikiExcludeArtistsNotContainingAnyAlphaCharactersRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader,
            int rulePriority)
        {
            _matchPatterns = knowledgeBaseLoader.LoadLanguageNeutralKnowledgeBaseObject(this.GetType().Name);
            RulePriority = rulePriority;
        }
        public IEnumerable<string> ApplyRule(string input)
        {

            var result = Regex.Match(input, _matchPatterns.First());
            if (!result.Success)
                yield return input;
            else if (result.Value != input)
                yield return input;
        }

        public int RulePriority { get; }
    }
}

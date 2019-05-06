using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiExcludeAllHtmlCommentsAndRefsRule:IProcessingRule
    {
        private string[] _commentsMatchingPatterns;

        public WikiExcludeAllHtmlCommentsAndRefsRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, int rulePriority)
        {
            _commentsMatchingPatterns = knowledgeBaseLoader.LoadLanguageNeutralKnowledgeBaseObject(this.GetType().Name);
            RulePriority = rulePriority;
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            foreach (var matchingPattern in _commentsMatchingPatterns)
            {
                input = Regex.Replace(input, matchingPattern, String.Empty);
            }

            yield return input;
        }

        public int RulePriority { get; }
    }
}

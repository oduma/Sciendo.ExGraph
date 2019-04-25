using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiPageTextExtractMembersAreasRule:IProcessingRule
    {

        public WikiPageTextExtractMembersAreasRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader,  int rulePriority)
        {
            RulePriority = rulePriority;
            _regexPatternsForMembers = knowledgeBaseLoader.LoadKnowledgeBaseObject(this.GetType().Name);
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

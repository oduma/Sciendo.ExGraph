using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Sciendo.BandMembers.Processor
{
    public class WikiPageTextExtractMembersAreasRule:IProcessingRule
    {

        public WikiPageTextExtractMembersAreasRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, string ruleName, int rulePriority)
        {
            RuleName = ruleName;
            RulePriority = rulePriority;
            _regexPatternsForMembers = knowledgeBaseLoader.LoadKnowledgeBaseObject(RuleName);
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

        public string RuleName { get; private set; }
        public int RulePriority { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.BandMembers.Processor
{
    public class WikiIndividualMembersExtractRule:IProcessingRule
    {
        private readonly string[] _bandMembersSeparators;

        public WikiIndividualMembersExtractRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, string ruleName, int rulePriority)
        {
            RuleName = ruleName;
            RulePriority = rulePriority;
            _bandMembersSeparators=knowledgeBaseLoader.LoadKnowledgeBaseObject(RuleName);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            foreach (var bandMember in input.Split(_bandMembersSeparators,
                StringSplitOptions.RemoveEmptyEntries))
            {
                yield return bandMember;
            }

        }

        public string RuleName { get; }
        public int RulePriority { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiIndividualMembersExtractRule:IProcessingRule
    {
        private readonly string[] _bandMembersSeparators;

        public WikiIndividualMembersExtractRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, int rulePriority)
        {
            RulePriority = rulePriority;
            _bandMembersSeparators=knowledgeBaseLoader.LoadKnowledgeBaseObject(this.GetType().Name);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            foreach (var bandMember in input.Split(_bandMembersSeparators,
                StringSplitOptions.RemoveEmptyEntries))
            {
                yield return bandMember;
            }

        }

        public int RulePriority { get; set; }
    }
}

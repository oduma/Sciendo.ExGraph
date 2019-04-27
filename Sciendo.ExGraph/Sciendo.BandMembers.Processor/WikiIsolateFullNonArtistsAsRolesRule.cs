using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiIsolateFullNonArtistsAsRolesRule:IProcessingRule
    {
        private string[] _roles;

        public WikiIsolateFullNonArtistsAsRolesRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader,
            int rulePriority)
        {
            RulePriority = rulePriority;
            _roles = knowledgeBaseLoader.LoadKnowledgeBaseObject(this.GetType().Name);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            if (!_roles.Contains(input))
                yield return input;
        }

        public int RulePriority { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiFinalIsolationOfRolesFromMembersNameRule:IProcessingRule
    {
        private string[] _roles;

        public WikiFinalIsolationOfRolesFromMembersNameRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, int rulePriority)
        {
            RulePriority = rulePriority;
            _roles = knowledgeBaseLoader.LoadLanguageNeutralKnowledgeBaseObject(this.GetType().Name);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            foreach (var role in _roles)
            {
                input = input.Replace(role, "");
            }

            yield return input.Trim();

        }


        public int RulePriority { get; }
    }
}

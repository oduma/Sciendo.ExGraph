using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiIsolateFullNonArtistsAsLocationRule:IProcessingRule
    {
        private string[] _locations;

        public WikiIsolateFullNonArtistsAsLocationRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader,
            int rulePriority)
        {
            RulePriority = rulePriority;
            _locations = knowledgeBaseLoader.LoadLanguageNeutralKnowledgeBaseObject(this.GetType().Name);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            if (!_locations.Contains(input))
                yield return input;
        }

        public int RulePriority { get; }
    }
}

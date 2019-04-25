using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiExcludeFullNonArtistsRule:IProcessingRule
    {
        private readonly string[] _nonArtistsToExclude;

        public WikiExcludeFullNonArtistsRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader,
            int rulePriority)
        {
            RulePriority = rulePriority;
            _nonArtistsToExclude = knowledgeBaseLoader.LoadKnowledgeBaseObject(this.GetType().Name);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            if (!_nonArtistsToExclude.Contains(input))
                yield return input;
        }
        public int RulePriority { get; }
    }
}

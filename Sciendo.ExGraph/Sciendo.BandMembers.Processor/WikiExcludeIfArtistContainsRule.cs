using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiExcludeIfArtistContainsRule:IProcessingRule
    {
        private string[] _nonArtistWords;

        public WikiExcludeIfArtistContainsRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, int rulePriority)
        {
            RulePriority = rulePriority;
            _nonArtistWords = knowledgeBaseLoader.LoadKnowledgeBaseObject(this.GetType().Name);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            if (_nonArtistWords.All(w => !input.Contains(w)))
                yield return input;
        }

        public int RulePriority { get; }
    }
}

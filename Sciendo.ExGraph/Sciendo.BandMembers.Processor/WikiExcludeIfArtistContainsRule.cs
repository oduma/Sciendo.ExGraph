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
            _nonArtistWords = knowledgeBaseLoader.LoadLanguageNeutralKnowledgeBaseObject(this.GetType().Name);
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            if (_nonArtistWords.FirstOrDefault(input.Contains)==null)
                yield return input;
        }

        public int RulePriority { get; }
    }
}

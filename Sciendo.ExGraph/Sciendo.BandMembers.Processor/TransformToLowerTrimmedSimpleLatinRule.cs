using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class TransformToLowerTrimmedSimpleLatinRule:IProcessingRule
    {
        private Dictionary<string, string> _latinAlphabetTransformations;

        public IEnumerable<string> ApplyRule(string input)
        {
            var result = input.ToLower().Trim();
            foreach (var key in _latinAlphabetTransformations.Keys)
            {
                result = result.Replace(key.ToLower(), _latinAlphabetTransformations[key]);
            }

            return new string[] {result};
        }

        public TransformToLowerTrimmedSimpleLatinRule(
            IKnowledgeBaseLoader<Dictionary<string, string>> knowledgeBaseLoader, int rulePriority)
        {
            RulePriority = rulePriority;
            _latinAlphabetTransformations = knowledgeBaseLoader.LoadKnowledgeBaseObject(this.GetType().Name);
        }
        public int RulePriority { get; }
    }
}

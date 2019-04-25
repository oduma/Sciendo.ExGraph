using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class TransformHtmlEncodedSequenceToTextRule:IProcessingRule
    {
        private Dictionary<string, string> _htmlToPlainTransformation;

        public TransformHtmlEncodedSequenceToTextRule(IKnowledgeBaseLoader<Dictionary<string, string>> knowledgeBaseLoader,
            int rulePriority)
        {
            _htmlToPlainTransformation = knowledgeBaseLoader.LoadKnowledgeBaseObject(this.GetType().Name);
            RulePriority = rulePriority;
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            foreach (var key in _htmlToPlainTransformation.Keys)
            {
                input = input.Replace(key, _htmlToPlainTransformation[key]);
            }

            yield return input;
        }

        public int RulePriority { get; }
    }
}

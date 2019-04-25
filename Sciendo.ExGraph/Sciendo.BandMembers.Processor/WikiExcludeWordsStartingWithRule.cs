using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;

namespace Sciendo.BandMembers.Processor
{
    public class WikiExcludeWordsStartingWithRule:IProcessingRule
    {
        private readonly string _simpleWordsSeparator;
        private string[] _startOfWords;

        public WikiExcludeWordsStartingWithRule(IKnowledgeBaseLoader<string[]> knowledgeBaseLoader, string simpleWordsSeparator,int rulePriority)
        {
            _simpleWordsSeparator = simpleWordsSeparator;
            _startOfWords = knowledgeBaseLoader.LoadKnowledgeBaseObject(this.GetType().Name);
            RulePriority = rulePriority;
        }
        public IEnumerable<string> ApplyRule(string input)
        {
            yield return string.Join(_simpleWordsSeparator,
                EliminateWords(input.Split(new[] {_simpleWordsSeparator}, StringSplitOptions.RemoveEmptyEntries)));

        }

        private IEnumerable<string> EliminateWords(string[] inputParts)
        {
            foreach (var inputPart in inputParts)
            {
                if (_startOfWords.All(s => !inputPart.StartsWith(s)))
                    yield return inputPart;
            }
        }

        public int RulePriority { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sciendo.BandMembers.Processor
{
    public abstract class ProcessingRulesEngine
    {
        protected abstract void LoadSetOfRules();
        public List<IProcessingRule> ProcessingRules { get; private set; }
        protected void RegisterProcessingRule(IProcessingRule processingRule)
        {
            if(processingRule!=null)
            {
                if (ProcessingRules==null)
                   ProcessingRules= new List<IProcessingRule>();
                ProcessingRules.Add(processingRule);
            }

        }

        public IEnumerable<string> ApplyAllRules(string input)
        {
            var startingPoint = new string[] {input};
            foreach (var processingRule in ProcessingRules.OrderBy(r => r.RulePriority))
            {
                startingPoint = ApplyRule(processingRule, startingPoint).ToArray();
            }

            return startingPoint;
        }

        private IEnumerable<string> ApplyRule(IProcessingRule processingRule, IEnumerable<string> inputs)
        {
            foreach (var input in inputs)
            {
                foreach (var result in processingRule.ApplyRule(input))
                {
                    yield return result;
                }
            }
        }
    }
}

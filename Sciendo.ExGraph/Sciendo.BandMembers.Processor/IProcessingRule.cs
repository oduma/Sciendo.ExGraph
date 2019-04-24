using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.BandMembers.Processor
{
    public interface IProcessingRule
    {
        IEnumerable<string> ApplyRule(string input);

        string RuleName { get; }

        int RulePriority { get;}
    }
}

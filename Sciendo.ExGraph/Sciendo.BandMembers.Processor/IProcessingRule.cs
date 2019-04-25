using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.BandMembers.Processor
{
    public interface IProcessingRule
    {
        IEnumerable<string> ApplyRule(string input);

        int RulePriority { get;}
    }
}

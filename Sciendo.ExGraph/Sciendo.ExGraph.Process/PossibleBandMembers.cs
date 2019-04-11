using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sciendo.ExGraph.Process
{
    public class PossibleBandMembers
    {
        public Artist Band { get; set; }
        public Guid Track { get; set; }

        public Artist Member { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.BandMembers.Processor
{
    public interface IKnowledgeBaseLoader<T>
    {
        T LoadKnowledgeBaseObject(string forRuleName);
    }
}

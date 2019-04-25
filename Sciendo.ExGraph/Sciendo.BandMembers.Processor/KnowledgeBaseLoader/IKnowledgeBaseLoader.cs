namespace Sciendo.BandMembers.Processor.KnowledgeBaseLoader
{
    public interface IKnowledgeBaseLoader<T>
    {
        T LoadKnowledgeBaseObject(string forRuleName);
    }
}

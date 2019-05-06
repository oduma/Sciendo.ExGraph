using System.Diagnostics.SymbolStore;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.BandMembers.Processor.KnowledgeBaseLoader
{
    public interface IKnowledgeBaseLoader<T>
    {
        T LoadLanguageNeutralKnowledgeBaseObject(string forRuleName);

        T LoadKnowledgeBaseObjectForLanguage(string forRuleName, LanguageType languageType);
    }
}

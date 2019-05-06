using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.BandMembers.Processor.KnowledgeBaseLoader
{
    public class KnowledgeBaseLoaderDictionaryStringString:IKnowledgeBaseLoader<Dictionary<string, string>>
    {
        private readonly string _knowledgeBaseFolder;

        public KnowledgeBaseLoaderDictionaryStringString(string knowledgeBaseFolder)
        {
            _knowledgeBaseFolder = knowledgeBaseFolder;
        }
        public Dictionary<string, string> LoadLanguageNeutralKnowledgeBaseObject(string forRuleName)
        {
            return JsonConvert.DeserializeObject<Dictionary<string,string>>(File.ReadAllText($"{_knowledgeBaseFolder}\\{forRuleName}.json"));
        }

        public Dictionary<string, string> LoadKnowledgeBaseObjectForLanguage(string forRuleName, LanguageType languageType)
        {
            throw new System.NotImplementedException();
        }
    }
}

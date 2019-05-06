using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.BandMembers.Processor.KnowledgeBaseLoader
{
    public class KnowledgeBaseLoaderStringArray:IKnowledgeBaseLoader<string[]>
    {
        private readonly string _knowledgeBaseFolder;

        public KnowledgeBaseLoaderStringArray(string knowledgeBaseFolder)
        {
            _knowledgeBaseFolder = knowledgeBaseFolder;
        }
        public string[] LoadLanguageNeutralKnowledgeBaseObject(string forRuleName)
        {
            return JsonConvert.DeserializeObject<string[]>(File.ReadAllText($"{_knowledgeBaseFolder}\\{forRuleName}.json"));

        }

        public string[] LoadKnowledgeBaseObjectForLanguage(string forRuleName, LanguageType languageType)
        {
            return JsonConvert.DeserializeObject<Dictionary<LanguageType, string[]>>(
                File.ReadAllText($"{_knowledgeBaseFolder}\\{forRuleName}.json"))[languageType];
        }
    }
}

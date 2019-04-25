using System.IO;
using Newtonsoft.Json;

namespace Sciendo.BandMembers.Processor.KnowledgeBaseLoader
{
    public class KnowledgeBaseLoaderStringArray:IKnowledgeBaseLoader<string[]>
    {
        private readonly string _knowledgeBaseFolder;

        public KnowledgeBaseLoaderStringArray(string knowledgeBaseFolder)
        {
            _knowledgeBaseFolder = knowledgeBaseFolder;
        }
        public string[] LoadKnowledgeBaseObject(string forRuleName)
        {
            return JsonConvert.DeserializeObject<string[]>(File.ReadAllText($"{_knowledgeBaseFolder}\\{forRuleName}.json"));

        }
    }
}

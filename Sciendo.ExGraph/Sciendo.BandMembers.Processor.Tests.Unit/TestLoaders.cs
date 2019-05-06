using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sciendo.BandMembers.Processor.KnowledgeBaseLoader;
using Sciendo.Music.Library.Contracts;

namespace Sciendo.BandMembers.Processor.Tests.Unit
{
    [TestClass]
    public class TestLoaders
    {
        [TestMethod]
        public void LoadLanguageBasedKnowledgeBase()
        {
            KnowledgeBaseLoaderStringArray knowledgeBaseLoader= new KnowledgeBaseLoaderStringArray("knowledgeBase");
            var actual = knowledgeBaseLoader.LoadKnowledgeBaseObjectForLanguage("WikiPageTextExtractMembersAreasRule",
                LanguageType.English);
            Assert.AreEqual(4, actual.Length);
        }
    }
}

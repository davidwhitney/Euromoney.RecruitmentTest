using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContentConsole.Interfaces;
using ContentConsole.BusinessManager;
using ContentConsole.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentConsole.Test.Unit
{
    [TestClass]
    public class TestModerator
    {
        [TestMethod]
        public void Count_Negative_Words()
        {
            IContentModerator iContentModerator = new ContentModerator();
            List<String> negativeWords = new List<String> { "swine", "bad", "nasty", "horrible" };
            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

             Assert.AreEqual(2,iContentModerator.CountNegativeWords(negativeWords,content));
        }

        [TestMethod]
        public void Hash_Negative_Words()
        {
            IContentModerator iContentModerator = new ContentModerator();
            List<String> negativeWords = new List<String> { "swine", "bad",};
            List<HashedWord> hashedWords = new List <HashedWord> { new HashedWord {bannedword="swine",Hashedword= "s###e" } , new HashedWord { bannedword = "bad", Hashedword = "ba#d" }, };

            var result=iContentModerator.HashWords(negativeWords);

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("s###e", result[0].Hashedword);
            Assert.AreEqual("b#d", result[1].Hashedword);
        }


        [TestMethod]
        public void Hash_Negative_Content()
        {
            IContentModerator iContentModerator = new ContentModerator();
            List<String> negativeWords = new List<String> { "swine", "bad", "nasty", "horrible" };
            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            string hashedContent = "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";

            var hashedWords = iContentModerator.HashWords(negativeWords);
            var result = iContentModerator.ReplaceWords(hashedWords, content);
            Assert.AreEqual(hashedContent, result);
            
        }



    }
}

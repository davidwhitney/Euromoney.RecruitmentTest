using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContentConsole.Test.Unit
{
    [TestClass]
    public class OutputTests
    {
        private List<BadWord> GetWordList()
        {
            var BadWords = new List<BadWord>();

            BadWords.Add(new BadWord("swine"));
            BadWords.Add(new BadWord("bad"));
            BadWords.Add(new BadWord("nasty"));
            BadWords.Add(new BadWord("horrible"));

            return BadWords;
        }

        [TestMethod]
        public void TestOriginalContent()
        {
            string testContent = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            Assert.IsTrue(Program.OriginalContent == testContent);
        }

        [TestMethod]
        public void TestBadWordsCountReturns()
        {
            Assert.IsTrue(Program.GetBadWordsCount(Program.OriginalContent, GetWordList()).GetType() == typeof(int));            
        }

        [TestMethod]
        public void TestBadWordsCountLogic()
        {
            string testContent = "this phrase contains one bad word";
            Assert.IsTrue(Program.GetBadWordsCount(testContent, GetWordList()).Equals(1));
        }

        [TestMethod]
        public void TestRetrieveWordsFromDataStore()
        {
            Assert.IsTrue(GetWordList().Count > 0);
        }

        [TestMethod]
        public void TestAdditionalWords()
        {
            string testContent = "this phrase contains two bad and negative words";
            var updatedList = GetWordList();
            updatedList.Add(new BadWord("negative"));
            Assert.IsTrue(Program.GetBadWordsCount(testContent, updatedList).Equals(2));
        }

        [TestMethod]
        public void TestFilterWord()
        {
            string testWord = "filter";
            Assert.IsTrue(Program.FilterWord(testWord) == "f####r");
        }

        [TestMethod]
        public void TestWordFiltering()
        {
            string testContent = "this phrase contains two bad and horrible words";
            //check words are present
            Assert.IsTrue(Program.GetBadWordsCount(testContent, GetWordList()).Equals(2));
            //filter words
            string filteredContent = Program.GetContent(testContent, GetWordList());
            //check words have been filtered
            Assert.IsFalse(Program.GetBadWordsCount(filteredContent, GetWordList()).Equals(2));
        }

        [TestMethod]
        public void TestSpecificWordFiltering()
        {
            string testContent = "this phrase contains two bad and horrible words";           
            string filteredContent = Program.GetContent(testContent, GetWordList());
            //check specific words from the test content
            Assert.IsTrue(filteredContent.Contains("b#d"));
            Assert.IsTrue(filteredContent.Contains("h######e"));
        }

        [TestMethod]
        public void TestFilterDisable()
        {
            bool filterText = false;
            string testContent = "this phrase contains two bad and horrible words";
            string filteredContent = Program.GetContent(testContent, GetWordList(), filterText);
            Assert.IsFalse(filteredContent.Contains("b#d"));            
        }

        [TestMethod]
        public void TestFilterEnable()
        {
            bool filterText = true;
            string testContent = "this phrase contains two bad and horrible words";
            string filteredContent = Program.GetContent(testContent, GetWordList(), filterText);
            Assert.IsTrue(filteredContent.Contains("b#d"));
        }
    }
}

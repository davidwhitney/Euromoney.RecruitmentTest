using ContentConsole.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.Test.Unit
{
    class ContentManipulationTests
    {
        private List<string> bannedWords = new List<string>();
        private BannedWordDictionary wordDictionary;

        [SetUp]
        public void Setup()
        {
            wordDictionary = new BannedWordDictionary();
        }

        [Test]
        public void ShouldGetContentOk()
        {
            bannedWords = wordDictionary.GetBannedWords();
            Assert.AreEqual(4, bannedWords.Count);
        }

        [Test]
        public void ShouldAddContentOk()
        {
            bannedWords = wordDictionary.GetBannedWords();
            wordDictionary.AddWord("hello");
            Assert.AreEqual(5, bannedWords.Count);
        }

        [Test]
        public void ShouldDeleteContentOk()
        {
            bannedWords = wordDictionary.GetBannedWords();
            wordDictionary.DeleteWord(bannedWords[0]);
            Assert.AreEqual(3, bannedWords.Count);
        }

    }
}

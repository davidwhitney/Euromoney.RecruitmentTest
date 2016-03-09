using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class ContentAnalyser
    {
        private Core.IContentAnalyser _analyser;

        [SetUp]
        public void Init()
        {
            _analyser = new Core.ContentAnalyser(new Core.MemoryDataStore<string>(), new Core.WordCounter(), new Core.WordFilter());
            _analyser.Content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        }

        [Test]
        public void Analyser_CountNegativeWords_Existing()
        {
            _analyser.AddNegativeWord("it");
            var expected = 2;
            var actual = _analyser.CountNegativeWords();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_CountNegativeWords_NotExisting()
        {
            _analyser.AddNegativeWord("of");
            var expected = 0;
            var actual = _analyser.CountNegativeWords();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_FilterNegativeWords_Existing()
        {
            _analyser.AddNegativeWord("Manchester");
            var expected = "The weather in M########r in winter is bad. It rains all the time - it must be horrible for people visiting.";
            var actual = _analyser.FilterNegativeWords();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_FilterNegativeWords_NotExisting()
        {
            _analyser.AddNegativeWord("London");
            var expected = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            var actual = _analyser.FilterNegativeWords();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_DisableFilter()
        {
            _analyser.AddNegativeWord("Manchester");
            _analyser.DisableFilter();
            var expected = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            var actual = _analyser.FilterNegativeWords();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_EnableFilter()
        {
            _analyser.AddNegativeWord("Manchester");
            _analyser.DisableFilter();
            _analyser.EnableFilter();
            var expected = "The weather in M########r in winter is bad. It rains all the time - it must be horrible for people visiting.";
            var actual = _analyser.FilterNegativeWords();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_AddNegativeWord_Single()
        {
            _analyser.AddNegativeWord("word1");
            var expected = 1;
            var actual = _analyser.GetNegativeWords().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_AddNegativeWord_Multiple_Same()
        {
            _analyser.AddNegativeWord("word1");
            _analyser.AddNegativeWord("word1");
            var expected = 1;
            var actual = _analyser.GetNegativeWords().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_AddNegativeWord_Multiple_Different()
        {
            _analyser.AddNegativeWord("word1");
            _analyser.AddNegativeWord("word2");
            var expected = 2;
            var actual = _analyser.GetNegativeWords().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_DeleteNegativeWord_Existing()
        {
            _analyser.AddNegativeWord("word1");
            _analyser.DeleteNegativeWord("word1");
            var expected = 0;
            var actual = _analyser.GetNegativeWords().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_DeleteNegativeWord_NotExisting()
        {
            _analyser.AddNegativeWord("word1");
            _analyser.DeleteNegativeWord("word2");
            var expected = 1;
            var actual = _analyser.GetNegativeWords().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Analyser_DeleteAllNegativeWords()
        {
            _analyser.AddNegativeWord("word1");
            _analyser.AddNegativeWord("word2");
            _analyser.DeleteAllNegativeWords();
            var expected = 0;
            var actual = _analyser.GetNegativeWords().Count();
            Assert.AreEqual(expected, actual);
        }
    }
}

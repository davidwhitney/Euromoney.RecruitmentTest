using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class WordCounter
    {
        private Core.IWordCounter _counter;

        [SetUp]
        public void Init()
        {
            _counter = new Core.WordCounter();
        }

        [Test]
        public void Counter_EmptyText()
        {
            var text = string.Empty;
            var words = new[] { "word1" };
            var expected = 0;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_NotExisting()
        {
            var text = "word";
            var words = new[] { "word1" };
            var expected = 0;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Existing_Single()
        {
            var text = "word1 word2";
            var words = new[] { "word1" };
            var expected = 1;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Existing_Multiple_Same()
        {
            var text = "word1 word2 word1";
            var words = new[] { "word1" };
            var expected = 2;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Existing_Multiple_Different()
        {
            var text = "word1 word2 word1 word3";
            var words = new[] { "word1", "word2" };
            var expected = 3;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Existing_WordBoundary()
        {
            var text = "word1(word1)";
            var words = new[] { "word1" };
            var expected = 2;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Word_LowerCase()
        {
            var text = "word1 word2";
            var words = new[] { "word1" };
            var expected = 1;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Word_MixedCase()
        {
            var text = "word1 word2";
            var words = new[] { "Word1" };
            var expected = 1;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Word_UpperCase()
        {
            var text = "word1 word2";
            var words = new[] { "WORD1" };
            var expected = 1;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Text_LowerCase()
        {
            var text = "word1 word2";
            var words = new[] { "word1" };
            var expected = 1;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Text_MixedCase()
        {
            var text = "Word1 Word2";
            var words = new[] { "word1" };
            var expected = 1;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_Text_UpperCase()
        {
            var text = "WORD1 WORD2";
            var words = new[] { "word1" };
            var expected = 1;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_PartialMatch_Shorter()
        {
            var text = "words";
            var words = new[] { "word" };
            var expected = 0;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Counter_PartialMatch_Longer()
        {
            var text = "words";
            var words = new[] { "words1" };
            var expected = 0;
            var actual = _counter.Count(text, words);
            Assert.AreEqual(expected, actual);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class WordFilter
    {
        private Core.IWordFilter _filter;

        [SetUp]
        public void Init()
        {
            _filter = new Core.WordFilter();
        }

        [Test]
        public void Filter_InitiallyEnabled()
        {
            Assert.IsTrue(_filter.Enabled);
        }

        [Test]
        public void Filter_Disabled()
        {
            _filter.Enabled = false;
            var text = "alpha";
            var words = new[] { "alpha" };
            var expected = "alpha";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_EmptyText()
        {
            var text = string.Empty;
            var words = new[] { "alpha" };
            var expected = text;
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_NotExisting()
        {
            var text = "word";
            var words = new[] { "alpha" };
            var expected = text;
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Existing_Single()
        {
            var text = "alpha beta";
            var words = new[] { "alpha" };
            var expected = "a###a beta";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Existing_Multiple()
        {
            var text = "alpha beta alpha";
            var words = new[] { "alpha" };
            var expected = "a###a beta a###a";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Existing_Short()
        {
            var text = "a ab abc";
            var words = new[] { "a", "ab", "abc" };
            var expected = "# ## a#c";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Existing_WordBoundary()
        {
            var text = "alpha(alpha)";
            var words = new[] { "alpha" };
            var expected = "a###a(a###a)";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Word_LowerCase()
        {
            var text = "alpha alpha";
            var words = new[] { "alpha" };
            var expected = "a###a a###a";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Word_MixedCase()
        {
            var text = "alpha alpha";
            var words = new[] { "Alpha" };
            var expected = "a###a a###a";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Word_UpperCase()
        {
            var text = "alpha alpha";
            var words = new[] { "ALPHA" };
            var expected = "a###a a###a";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Text_LowerCase()
        {
            var text = "alpha alpha";
            var words = new[] { "alpha" };
            var expected = "a###a a###a";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Text_MixedCase()
        {
            var text = "Alpha alpha";
            var words = new[] { "alpha" };
            var expected = "A###a a###a";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_Text_UpperCase()
        {
            var text = "ALPHA alpha";
            var words = new[] { "alpha" };
            var expected = "A###A a###a";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_PartialMatch_Shorter()
        {
            var text = "alpha1";
            var words = new[] { "alpha" };
            var expected = "alpha1";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_PartialMatch_Longer()
        {
            var text = "alpha";
            var words = new[] { "alpha1" };
            var expected = "alpha";
            var actual = _filter.Filter(text, words);
            Assert.AreEqual(expected, actual);
        }
    }
}

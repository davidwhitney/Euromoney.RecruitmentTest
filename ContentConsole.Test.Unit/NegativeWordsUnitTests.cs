using NegativeWordUnitTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
        [TestFixture]
        public class NegativeWordsUnitTests
        {
            private const string Phrase = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            [Test]
            public void NullResultCheck()
            {
                var negativeWordCheck = new TestNegativeWordCheck();
                var result = negativeWordCheck.RunNegativeWordCheck(Phrase, false);

                Assert.IsNotNull(result);
            }

            [Test]
            public void NegativeFilteringNotEnabled()
            {
                var negativeWordCheck = new TestNegativeWordCheck();
                var result = negativeWordCheck.RunNegativeWordCheck(Phrase, false);

                Assert.IsTrue(!result.Phrase.Contains("#")
                              && result.Phrase == Phrase
                              && result.NegativeWordCount == 2);
            }

            [Test]
            public void NegativeFilteringEnabled()
            {
                var negativeWordCheck = new TestNegativeWordCheck();
                var result = negativeWordCheck.RunNegativeWordCheck(Phrase, true);
                var hashNum = result.Phrase.Count(x => x == '#');

                Assert.IsTrue(hashNum == 7);
            }

            [Test]
            public void WholeWordFilteredOnly()
            {
                var negativeWordCheck = new TestNegativeWordCheck();
                var phrase = "The weather in Manchester in winter is badminton. It rains all the time - it must be horrible for people visiting.";
                var result = negativeWordCheck.RunNegativeWordCheck(phrase, true);
                var hashNum = result.Phrase.Count(x => x == '#');

                Assert.IsTrue(hashNum == 6);
            }

            [Test]
            public void WholeNegativeWordsCountedOnly()
            {
                var negativeWordCheck = new TestNegativeWordCheck();
                var phrase = "The weather in Manchester in winter is badminton. It rains all the time - it must be horrible for people visiting.";
                var result = negativeWordCheck.RunNegativeWordCheck(phrase, true);
                var hashNum = result.Phrase.Count(x => x == '#');

                Assert.IsTrue(result.NegativeWordCount == 1);
            }

            [Test]
            public void NegativeWordCountCheck()
            {
                var negativeWordCheck = new TestNegativeWordCheck();
                var result = negativeWordCheck.RunNegativeWordCheck(Phrase, true);

                Assert.IsTrue(result.NegativeWordCount == 2);
            }

            [Test]
            public void NegativeWordEmptyList()
            {
                var negativeWordCheck = new TestNegativeWordCheck {NegativeWords = new List<string>()};
                var result = negativeWordCheck.RunNegativeWordCheck(Phrase, true);

                Assert.IsTrue(result.NegativeWordCount == 0);
            }
        }
}

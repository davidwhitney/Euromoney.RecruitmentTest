using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Helpers;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class PhraseMatcherTests
    {
        [Test]
        public void Match_GivenMatchAtStringStart_ReturnsCorrectMatch()
        {
            IPhraseMatcher matcher = new PhraseMatcher();
            PhraseMatchResult expectedResult = new PhraseMatchResult()
            {
                Index = 0,
                MatchedPhrase = "An"
            };

            PhraseMatchResult actualResult = matcher.Match(0, "An AWESOME test", new List<string>() { "An", "test" });

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult.MatchedPhrase, actualResult.MatchedPhrase);
            Assert.AreEqual(expectedResult.Index, actualResult.Index);
        }

        [Test]
        public void Match_GivenMatchAtNonZero_ReturnsCorrectMatch()
        {
            IPhraseMatcher matcher = new PhraseMatcher();
            PhraseMatchResult expectedResult = new PhraseMatchResult()
            {
                Index = 3,
                MatchedPhrase = "AWESOME"
            };

            PhraseMatchResult actualResult = matcher.Match(0, "An AWESOME test", new List<string>() { "A", "AWESOME" });

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult.MatchedPhrase, actualResult.MatchedPhrase);
            Assert.AreEqual(expectedResult.Index, actualResult.Index);
        }


        [Test]
        public void Match_GivenMatchAtEnd_ReturnsCorrectMatch()
        {
            IPhraseMatcher matcher = new PhraseMatcher();
            PhraseMatchResult expectedResult = new PhraseMatchResult()
            {
                Index = 11,
                MatchedPhrase = "test"
            };

            PhraseMatchResult actualResult = matcher.Match(0, "An AWESOME test", new List<string>() { "A", "test" });

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult.MatchedPhrase, actualResult.MatchedPhrase);
            Assert.AreEqual(expectedResult.Index, actualResult.Index);
        }

        [Test]
        public void Match_GivenNonMatch_ReturnsNull()
        {
            IPhraseMatcher matcher = new PhraseMatcher();

            PhraseMatchResult result = matcher.Match(0, "An AWESOME test", new List<string>() { "X" });

            Assert.IsNull(result);
        }

        [Test]
        public void Match_GivenPartialInnerMatch_ReturnsNull()
        {
            IPhraseMatcher matcher = new PhraseMatcher();

            PhraseMatchResult result = matcher.Match(0, "An AWESOME test", new List<string>() { "SOME" });
            Assert.IsNull(result);
        }
    }
}
